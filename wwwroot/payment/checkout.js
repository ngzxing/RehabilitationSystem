const stripe = Stripe("pk_test_51PPbznFSjpoNGgbJwwv74ZXL6X2kCluMROJ211xUwdJsrX53wtCNosUh6cc2ry4Q46hOK7Cehj3IKY85476kbHWO00TulImnih");


let elements;

initialize();
checkStatus();

document
  .querySelector("#payment-form")
  .addEventListener("submit", handleSubmit);

document
  .querySelector("#receipt")
  .addEventListener("click", handleReceipt);

document
  .querySelector("#redirect")
  .addEventListener("click", handleRedirect);

// Fetches a payment intent and captures the client secret
async function initialize() {

  const redirect_status = new URLSearchParams(window.location.search).get(
    "redirect_status"
  );

  if( redirect_status && (redirect_status == "succeeded") ){

    return;
  }

  const billingId = new URLSearchParams(window.location.search).get(
    "billingId"
  );
  

  if(!billingId){

    showMessage( "Billing Id Is Not Set" );
    return;
  }

  const response = await fetch(`/api/TestApi/Pay?billingId=${billingId}`, {
    method: "GET",
    headers: { "Content-Type": "application/json" },
  });

  if(response.status != 200){

    const { error } = await response.json();
    showMessage( error );
    return;
  }

  const { clientSecret } = await response.json();

  const appearance = {
    theme: 'stripe',
  };
  elements = stripe.elements({ appearance, clientSecret });

  const paymentElementOptions = {
    layout: "tabs",
  };

  const paymentElement = elements.create("payment", paymentElementOptions);
  paymentElement.mount("#payment-element");
}

async function handleSubmit(e) {
  e.preventDefault();
  setLoading(true);

  const billingId = new URLSearchParams(window.location.search).get(
    "billingId"
  );

  const { error } = await stripe.confirmPayment({
    elements,
    confirmParams: {
      // Make sure to change this to your payment completion page
      return_url: `http://172.20.10.2:5291/payment/checkout.html?billingId=${billingId}`,
    },
  });

  if (error.type === "card_error" || error.type === "validation_error") {
    showMessage(error.message);
  } else {
    showMessage("An unexpected error occurred.");
  }

  setLoading(false);
}


async function handleReceipt(){

  const billingId = new URLSearchParams(window.location.search).get(
    "billingId"
  );

  window.location.replace(`http://172.20.10.2:5291/api/TestApi/Receipt?billingId=${billingId}&redirect=1`);

}

async function handleRedirect(){

  const billingId = new URLSearchParams(window.location.search).get(
    "billingId"
  );

  window.location.replace(`http://172.20.10.2:5291?billingId=${billingId}&redirect=2`);

}

// Fetches the payment intent status after payment submission
async function checkStatus() {
  const clientSecret = new URLSearchParams(window.location.search).get(
    "payment_intent_client_secret"
  );
  const billingId = new URLSearchParams(window.location.search).get(
    "billingId"
  );

  const payment_intent = new URLSearchParams(window.location.search).get(
    "payment_intent"
  );


  if (!clientSecret || !billingId) {
    return;
  }

  setLoading(true);

  const { paymentIntent } = await stripe.retrievePaymentIntent(clientSecret);


  switch (paymentIntent.status) {
    case "succeeded":

      const response = await fetch(`/api/TestApi/update-payment?billingId=${billingId}&payment_intent=${payment_intent}`, {
        method: "GET",
        headers: { "Content-Type": "application/json" },
      });
      
      if(response.status != 200){

        const { error } = await response.json();
        showMessage( error );
        return;
      }

      showMessage("Payment succeeded!");
      setLoading(false);

      document.querySelector("#submit").style.display = "none";
      document.querySelector("#receipt").style.display = "block";
      document.querySelector("#redirect").style.display = "block";

      break;
    case "processing":
      showMessage("Your payment is processing.");
      break;
    case "requires_payment_method":
      showMessage("Your payment was not successful, please try again.");
      break;
    default:
      showMessage("Something went wrong.");
      break;
  }
}



function showMessage(messageText) {
  const messageContainer = document.querySelector("#payment-message");

  messageContainer.classList.remove("hidden");
  messageContainer.textContent = messageText;

  setTimeout(function () {
    messageContainer.classList.add("hidden");
    messageContainer.textContent = "";
  }, 4000);
}

// Show a spinner on payment submission
function setLoading(isLoading) {
  if (isLoading) {
    // Disable the button and show a spinner
    document.querySelector("#submit").disabled = true;
    document.querySelector("#spinner").classList.remove("hidden");
    document.querySelector("#button-text").classList.add("hidden");
  } else {
    document.querySelector("#submit").disabled = false;
    document.querySelector("#spinner").classList.add("hidden");
    document.querySelector("#button-text").classList.remove("hidden");
  }
}
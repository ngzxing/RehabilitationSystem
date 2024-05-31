using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RehabilitationSystem.Data.Enum;
using RehabilitationSystem.Models;

namespace RehabilitationSystem.Data
{
    public static class SeedData
{
    public static List<AppUser> GetUsers(IPasswordHasher<AppUser> passwordHasher)
    {
        var users = new List<AppUser>
        {
            new AppUser { Id = "user1", UserName = "admin1", NormalizedUserName = "ADMIN1", Email = "admin1@example.com", NormalizedEmail = "ADMIN1@EXAMPLE.COM" },
            new AppUser { Id = "user2", UserName = "therapist1", NormalizedUserName = "THERAPIST1", Email = "therapist1@example.com", NormalizedEmail = "THERAPIST1@EXAMPLE.COM" },
            new AppUser { Id = "user3", UserName = "customerService1", NormalizedUserName = "CUSTOMERSERVICE1", Email = "customerService1@example.com", NormalizedEmail = "CUSTOMERSERVICE1@EXAMPLE.COM" },
            new AppUser { Id = "user4", UserName = "parent1", NormalizedUserName = "PARENT1", Email = "parent1@example.com", NormalizedEmail = "PARENT1@EXAMPLE.COM" },
        };

        foreach (var user in users)
        {
            user.PasswordHash = passwordHasher.HashPassword(user, "User@1245");
        }

        return users;
    }

    public static List<Admin> GetAdmins()
    {
        return new List<Admin>
        {
            new Admin { AdminId = "admin1", Name = "Admin One", AppUserId = "user1" },
        };
    }

    public static List<Therapist> GetTherapists()
    {
        return new List<Therapist>
        {
            new Therapist { TherapistId = "therapist1", Name = "Therapist One", AppUserId = "user2" },
        };
    }

    public static List<CustomerService> GetCustomerServices()
    {
        return new List<CustomerService>
        {
            new CustomerService { CustomerServiceId = "customerService1", Name = "Customer Service One", AppUserId = "user3" },
        };
    }

    public static List<Parent> GetParents()
    {
        return new List<Parent>
        {
            new Parent { ParentId = "parent1", Name = "Parent One", City = "City", Postcode = "12345", State = "State", Address = "123 Street", Occupation = "Occupation", AppUserId = "user4" },
        };
    }

    public static List<Student> GetStudents()
    {
        return new List<Student>
        {
            new Student { StudentId = "student1", Name = "Student One", Gender = Gender.MALE, Age = 10, DOB = new DateTime(2014, 1, 1), ParentId = "parent1" },
        };
    }

    public static List<Announcement> GetAnnouncements()
    {
        return new List<Announcement>
        {
            new Announcement { AnnouncementId = "announcement1", Title = "Announcement One", Content = "Content of Announcement One", Date = DateTime.Now, Status = true, AdminId = "admin1" },
        };
    }

    public static List<Models.Program> GetPrograms()
    {
        return new List<Models.Program>
        {
            new Models.Program { ProgramId = "program1", Name = "Program One", Objective = "Objective One", Description = "Description One", Price = 100.0m },
        };
    }

    public static List<ProgramStudent> GetProgramStudents()
    {
        return new List<ProgramStudent>
        {
            new ProgramStudent { ProgramStudentId = "programStudent1", RegisterDate = DateTime.Now, ProgramId = "program1", StudentId = "student1" },
        };
    }

    public static List<Session> GetSessions()
    {
        return new List<Session>
        {
            new Session { SessionId = "session1", Name = "Session One", Description = "Description One", ProgramId = "program1" },
        };
    }

    public static List<Slot> GetSlots()
    {
        return new List<Slot>
        {
            new Slot { SlotId = "slot1", StartTime = DateTime.Now.AddHours(1), EndTime = DateTime.Now.AddHours(2), TherapistSessionId = "therapistSession1" },
        };
    }

    public static List<ProgramStudentSlot> GetProgramStudentSlots()
    {
        return new List<ProgramStudentSlot>
        {
            new ProgramStudentSlot { ProgramStudentSlotId = "ProgramStudentSlot1", ProgramStudentId ="programStudent1", SlotId = "slot1" },
        };
    }

    public static List<Billing> GetBillings()
    {
        return new List<Billing>
        {
            new Billing { BillingId = "billing1", IssueDate = DateTime.Now, TotalPayAmount = 200.0m, PaymentStatus = false, ProgramStudentId = "programStudent1" },
        };
    }

    public static List<BillingItem> GetBillingItems()
    {
        return new List<BillingItem>
        {
            new BillingItem { BillingItemId = "billingItem1", Description = "Billing Item One", Price = 50.0m, Amount = 4, BillingId = "billing1" },
        };
    }

    public static List<Report> GetReports()
    {
        return new List<Report>
        {
            new Report { ReportId = "report1", Title = "Report One", Content = "Content of Report One", ProgramStudentId = "programStudent1", TherapistId = "therapist1" },
        };
    }

    public static List<TherapistSession> GetTherapistSessions()
    {
        return new List<TherapistSession>
        {
            new TherapistSession { TherapistSessionId = "therapistSession1", TherapistId = "therapist1", SessionId = "session1" },
        };
    }
}


}
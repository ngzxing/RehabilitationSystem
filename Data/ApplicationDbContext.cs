using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Models;

namespace RehabilitationSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Therapist> Therapists { get; set; }
        public DbSet<CustomerService> CustomerServices { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Models.Program> Programs { get; set; }
        public DbSet<ProgramStudent> ProgramStudents { get; set; }

        public DbSet<TherapistSession> TherapistSessions { get; set; }
        public DbSet<ProgramStudentSlot> ProgramStudentSlots { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<BillingItem> BillingItems { get; set; }
        public DbSet<Report> Reports { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Parent>()
                .HasOne(p => p.AppUser)
                .WithOne(a => a.Parent)
                .HasForeignKey<Parent>(p => p.AppUserId)
                .HasPrincipalKey<AppUser>(a => a.Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Admin>()
                .HasOne(a => a.AppUser)
                .WithOne(a => a.Admin)
                .HasForeignKey<Admin>(p => p.AppUserId)
                .HasPrincipalKey<AppUser>(a => a.Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Therapist>()
                .HasOne(a => a.AppUser)
                .WithOne(a => a.Therapist)
                .HasForeignKey<Therapist>(p => p.AppUserId)
                .HasPrincipalKey<AppUser>(a => a.Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CustomerService>()
                .HasOne(a => a.AppUser)
                .WithOne(a => a.CustomerService)
                .HasForeignKey<CustomerService>(p => p.AppUserId)
                .HasPrincipalKey<AppUser>(a => a.Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Parent)
                .WithMany(p => p.Students)
                .HasForeignKey(s => s.ParentId)
                .HasPrincipalKey(p => p.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Announcement>()
                .HasOne(a => a.Admin)
                .WithMany(a => a.Announcements)
                .HasForeignKey(a => a.AdminId)
                .HasPrincipalKey(a => a.AdminId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.ProgramStudent)
                .WithMany(p => p.Reports)
                .HasForeignKey(r => r.ProgramStudentId)
                .HasPrincipalKey(p => p.ProgramStudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Therapist)
                .WithMany(t => t.Reports)
                .HasForeignKey(r => r.TherapistId)
                .HasPrincipalKey(t => t.TherapistId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProgramStudent>()
                .HasOne(p => p.Student)
                .WithMany(s => s.ProgramStudents)
                .HasForeignKey(p => p.StudentId)
                .HasPrincipalKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProgramStudent>()
                .HasOne(p => p.Program)
                .WithMany(p => p.ProgramStudents)
                .HasForeignKey(p => p.ProgramId)
                .HasPrincipalKey(p => p.ProgramId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.Program)
                .WithMany(p => p.Sessions)
                .HasForeignKey(s => s.ProgramId)
                .HasPrincipalKey(p => p.ProgramId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Slot>()
                .HasOne(s => s.TherapistSession)
                .WithMany(s => s.Slots)
                .HasForeignKey(s => s.TherapistSessionId)
                .HasPrincipalKey(s => s.TherapistSessionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Billing>()
                .HasOne(b => b.ProgramStudent)
                .WithOne(s => s.Billing )
                .HasForeignKey<ProgramStudent>( b => b.ProgramStudentId )
                .HasPrincipalKey<Billing>(s => s.ProgramStudentId)
                .OnDelete(DeleteBehavior.NoAction);

            

            modelBuilder.Entity<BillingItem>()
                .HasOne(b => b.Billing)
                .WithMany(b => b.BillingItems )
                .HasForeignKey(b => b.BillingId)
                .HasPrincipalKey(b => b.BillingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TherapistSession>()
                .HasOne(t => t.Therapist)
                .WithMany(t => t.TherapistSessions )
                .HasForeignKey(t => t.TherapistId)
                .HasPrincipalKey(t => t.TherapistId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TherapistSession>()
                .HasOne(t => t.Session)
                .WithMany(s => s.TherapistsSessions )
                .HasForeignKey(t => t.SessionId)
                .HasPrincipalKey(s => s.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProgramStudentSlot>()
                .HasOne(p => p.Slot)
                .WithMany(s => s.ProgramStudentSlots )
                .HasForeignKey(p => p.SlotId)
                .HasPrincipalKey(s => s.SlotId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProgramStudentSlot>()
                .HasOne(p => p.ProgramStudent)
                .WithMany(p => p.ProgramStudentSlots )
                .HasForeignKey(p => p.ProgramStudentId)
                .HasPrincipalKey(p => p.ProgramStudentId)
                .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<Report>()
                .HasIndex(ps => new { ps.ProgramStudentId, ps.TherapistId })
                .IsUnique();

            modelBuilder.Entity<TherapistSession>()
                .HasIndex(ss => new { ss.TherapistId, ss.SessionId })
                .IsUnique();


            modelBuilder.Entity<Billing>()
                .Property( p => p.BillingId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<BillingItem>()
                .Property( p => p.BillingItemId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Slot>()
                .Property( p => p.SlotId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Session>()
                .Property( p => p.SessionId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Models.Program>()
                .Property( p => p.ProgramId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TherapistSession>()
                .Property( p => p.TherapistSessionId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Report>()
                .Property( p => p.ReportId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProgramStudent>()
                .Property( p => p.ProgramStudentId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProgramStudentSlot>()
                .Property( p => p.ProgramStudentSlotId)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Announcement>()
                .Property( p => p.AnnouncementId)
                .ValueGeneratedOnAdd();

            List<IdentityRole> roles =
            [

                new() {

                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new (){

                    Name = "Therapist",
                    NormalizedName = "THERAPIST"
                },
                new (){

                    Name = "CustomerService",
                    NormalizedName = "CUSTOMERSERVICE"
                },
                new (){

                    Name = "Parent",
                    NormalizedName = "PARENT"
                }

            ];

            

            modelBuilder.Entity<IdentityRole>().HasData(roles);

            var passwordHasher = new PasswordHasher<AppUser>();

            modelBuilder.Entity<AppUser>().HasData(SeedData.GetUsers(passwordHasher));
            modelBuilder.Entity<Admin>().HasData(SeedData.GetAdmins());
            modelBuilder.Entity<Therapist>().HasData(SeedData.GetTherapists());
            modelBuilder.Entity<CustomerService>().HasData(SeedData.GetCustomerServices());
            modelBuilder.Entity<Parent>().HasData(SeedData.GetParents());
            modelBuilder.Entity<Student>().HasData(SeedData.GetStudents());
            modelBuilder.Entity<Models.Program>().HasData(SeedData.GetPrograms());
            modelBuilder.Entity<ProgramStudent>().HasData(SeedData.GetProgramStudents());
            modelBuilder.Entity<Session>().HasData(SeedData.GetSessions());
            modelBuilder.Entity<Slot>().HasData(SeedData.GetSlots());
            modelBuilder.Entity<ProgramStudentSlot>().HasData(SeedData.GetProgramStudentSlots());
            modelBuilder.Entity<Billing>().HasData(SeedData.GetBillings());
            modelBuilder.Entity<BillingItem>().HasData(SeedData.GetBillingItems());
            modelBuilder.Entity<Report>().HasData(SeedData.GetReports());
            modelBuilder.Entity<TherapistSession>().HasData(SeedData.GetTherapistSessions());
            modelBuilder.Entity<Announcement>().HasData(SeedData.GetAnnouncements());
            
            

            
        }
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.Admin;
using RehabilitationSystem.ViewModels.Announcement;
using RehabilitationSystem.ViewModels.AppUser;
using RehabilitationSystem.ViewModels.Billing;
using RehabilitationSystem.ViewModels.BillingItem;
using RehabilitationSystem.ViewModels.CustomerService;
using RehabilitationSystem.ViewModels.Parent;
using RehabilitationSystem.ViewModels.Program;
using RehabilitationSystem.ViewModels.ProgramStudent;
using RehabilitationSystem.ViewModels.ProgramStudentSlot;
using RehabilitationSystem.ViewModels.Report;
using RehabilitationSystem.ViewModels.Session;
using RehabilitationSystem.ViewModels.Slot;
using RehabilitationSystem.ViewModels.Student;
using RehabilitationSystem.ViewModels.Therapist;
using RehabilitationSystem.ViewModels.TherapistSession;

public static class MapperExtensions
{
    public static IQueryable<GetAdmin> ToViewModel(this IQueryable<Admin> query, List<string> includes)
    {
        var baseQuery = query;

        if (includes.Contains("AppUser"))
        {
            baseQuery = baseQuery.Include(a => a.AppUser);
        }

        if (includes.Contains("Announcements"))
        {
            baseQuery = baseQuery.Include(a => a.Announcements);
        }

        return baseQuery.Select(admin => new GetAdmin
        {
            AdminId = admin.AdminId,
            Name = admin.Name,
            AppUser = includes.Contains("AppUser") ? new GetAppUser
            {
                PhoneNumber = admin.AppUser!.PhoneNumber,
                Email = admin.AppUser.Email
            } : null,
            Announcements = includes.Contains("Announcements") 
                ? (ICollection<GetAnnouncement>)admin.Announcements!.Select(a => new GetAnnouncement
                    {
                        AnnouncementId = a.AnnouncementId,
                        Title = a.Title,
                        Content = a.Content,
                        Date = a.Date,
                        Status = a.Status,
                        AdminId = a.AdminId,
                        Admin = null
                    }
                ) : null
        });
    }

    public static IQueryable<GetAnnouncement> ToViewModel(this IQueryable<Announcement> query, List<string> includes)
    {
        var baseQuery = query;

        if (includes.Contains("Admin"))
        {
            baseQuery = baseQuery.Include(a => a.Admin);
        }

        return baseQuery.Select(a => new GetAnnouncement
        {
            AnnouncementId = a.AnnouncementId,
            Title = a.Title,
            Content = a.Content,
            Date = a.Date,
            Status = a.Status,
            AdminId = a.AdminId,
            Admin = includes.Contains("Admin") ? new GetAdmin
            {
                AdminId = a.Admin!.AdminId,
                Name = a.Admin.Name
            } : null
        });
    }

    public static IQueryable<GetBilling> ToViewModel(this IQueryable<Billing> query, List<string> includes)
    {   
        

        query = query
            .Include(b => b.ProgramStudent)
            .ThenInclude(ps => ps!.Program)
            .Include(b => b.ProgramStudent)
            .ThenInclude(ps => ps!.Student)
            .ThenInclude(s => s!.Parent);
            
        if (includes.Contains("BillingItems"))
        {
            query = query.Include(b => b.BillingItems);
        }
       

        return query.Select(b => new GetBilling
        {
            BillingId = b.BillingId,
            IssueDate = b.IssueDate,
            TotalPayAmount = b.TotalPayAmount,
            PaymentStatus = b.PaymentStatus,
            PaymentDate = b.PaymentDate,
            ProgramName = b.ProgramStudent!.Program!.Name,
            BillingItems = includes.Contains("BillingItems") 
                ? (ICollection<GetBillingItem>)b.BillingItems!.Select(bi => new GetBillingItem
                {
                    BillingItemId = bi.BillingItemId,
                    Description = bi.Description,
                    Price = bi.Price,
                    Amount = bi.Amount
                }): null,
            StudentId = b.ProgramStudent.Student!.StudentId,
            StudentName = b.ProgramStudent.Student.Name,
            ParentId = b.ProgramStudent.Student.Parent!.ParentId,
            ParentName = b.ProgramStudent.Student.Parent.Name
        });
    }

    public static IQueryable<GetBillingItem> ToViewModel(this IQueryable<BillingItem> query)
    {
        return query.Select(bi => new GetBillingItem
        {
            BillingItemId = bi.BillingItemId,
            Description = bi.Description,
            Price = bi.Price,
            Amount = bi.Amount
        });
    }

    public static IQueryable<GetCustomerService> ToViewModel(this IQueryable<CustomerService> query, List<string> includes)
    {
        var baseQuery = query;

        if (includes.Contains("AppUser"))
        {
            baseQuery = baseQuery.Include(cs => cs.AppUser);
        }

        return baseQuery.Select(cs => new GetCustomerService
        {
            CustomerServiceId = cs.CustomerServiceId,
            Name = cs.Name,
            AppUser = includes.Contains("AppUser") ? new GetAppUser
            {
                PhoneNumber = cs.AppUser!.PhoneNumber,
                Email = cs.AppUser.Email
            } : null
        });
    }

    public static IQueryable<GetParent> ToViewModel(this IQueryable<Parent> query, List<string> includes)
    {
        var baseQuery = query;

        if (includes.Contains("AppUser"))
        {
            baseQuery = baseQuery.Include(p => p.AppUser);
        }

        if (includes.Contains("Students"))
        {
            baseQuery = baseQuery.Include(p => p.Students);
        }

        return baseQuery.Select(parent => new GetParent
        {
            ParentId = parent.ParentId,
            Name = parent.Name,
            City = parent.City,
            Postcode = parent.Postcode,
            State = parent.State,
            Address = parent.Address,
            Occupation = parent.Occupation,
            AppUserId = parent.AppUserId,
            AppUser = includes.Contains("AppUser") ? new GetAppUser
            {
                PhoneNumber = parent.AppUser!.PhoneNumber,
                Email = parent.AppUser.Email
            } : null,
            Students = includes.Contains("Students") 
                ? (ICollection<GetStudent>)parent.Students!.Select(s => new GetStudent
                    {
                        StudentId = s.StudentId,
                        Name = s.Name,
                        Gender = s.Gender,
                        Age = s.Age,
                        DOB = s.DOB,
                        ParentId = s.ParentId,
                        Parent = null,
                        ProgramStudents = null
                    })
                : null
        });
    }

    public static IQueryable<GetProgram> ToViewModel(this IQueryable<RehabilitationSystem.Models.Program> query, List<string> includes)
    {   
        

        var baseQuery = query;

        if (includes.Contains("Sessions"))
        {
            baseQuery = baseQuery.Include(p => p.Sessions);
        }

        if (includes.Contains("Billings"))
        {
            baseQuery = baseQuery.Include(p => p.Billings);
        }

        return baseQuery.Select(program => new GetProgram
        {
            ProgramId = program.ProgramId,
            Name = program.Name,
            Objective = program.Objective,
            Description = program.Description,
            Price = program.Price,
            Sessions = includes.Contains("Sessions") 
                ? (ICollection<GetSession>)program.Sessions!.Select( session => new GetSession
                {
                    SessionId = session.SessionId,
                    Name = session.Name,
                    Description = session.Description,
                    Therapists =  null,
                    Slots = null
                }) : null,
            Billings = includes.Contains("Billings") 
                ? (ICollection<GetBilling>)program.Billings!.Select(b => new GetBilling
                    {
                        BillingId = b.BillingId,
                        IssueDate = b.IssueDate,
                        TotalPayAmount = b.TotalPayAmount,
                        PaymentStatus = b.PaymentStatus,
                        PaymentDate = b.PaymentDate,
                        ProgramName = b.ProgramStudent!.Program!.Name,
                        BillingItems = null,
                        StudentId = b.ProgramStudent.Student!.StudentId,
                        StudentName = b.ProgramStudent.Student.Name,
                        ParentId = b.ProgramStudent.Student.Parent!.ParentId,
                        ParentName = b.ProgramStudent.Student.Parent.Name
                    }
                ): null
        });
    }


    public static IQueryable<GetProgramStudent> ToViewModel(this IQueryable<ProgramStudent> query, List<string> includes)
    {
        var baseQuery = query;

        if (includes.Contains("Program"))
        {
            baseQuery = baseQuery.Include(ps => ps.Program);
        }

        if (includes.Contains("Student"))
        {
            baseQuery = baseQuery.Include(ps => ps.Student);
        }

        if (includes.Contains("Reports"))
        {
            baseQuery = baseQuery.Include(ps => ps.Reports);
        }

        if (includes.Contains("ProgramStudentSlots"))
        {
            baseQuery = baseQuery.Include(ps => ps.ProgramStudentSlots);
        }

        if (includes.Contains("Billing"))
        {
            baseQuery = baseQuery.Include(ps => ps.Billing);
        }

        return baseQuery.Select(ps => new GetProgramStudent
        {
            ProgramStudentId = ps.ProgramStudentId,
            RegisterDate = ps.RegisterDate,
            ProgramId = ps.ProgramId,
            Program = includes.Contains("Program") ? new GetProgram
            {
                ProgramId = ps.Program!.ProgramId,
                Name = ps.Program.Name,
                Objective = ps.Program.Objective,
                Description = ps.Program.Description,
                Price = ps.Program.Price
            } : null,
            StudentId = ps.StudentId,
            Student = includes.Contains("Student") ? new GetStudent
            {
                StudentId = ps.Student!.StudentId,
                Name = ps.Student.Name,
                Gender = ps.Student.Gender,
                Age = ps.Student.Age,
                DOB = ps.Student.DOB,
                ParentId = ps.Student.ParentId
            } : null,
            Reports = includes.Contains("Reports") 
                ? (ICollection<GetReport>)ps.Reports!.Select(r => new GetReport
                    {
                        ReportId = r.ReportId,
                        Title = r.Title,
                        Content = r.Content,
                        ProgramStudentId = r.ProgramStudentId,
                        TherapistId = r.TherapistId,
                        ProgramStudent =  null,
                        Therapist = null
                    
                    }
                ): null,
            ProgramStudentSlots = includes.Contains("ProgramStudentSlots") 
                ? (ICollection<GetProgramStudentSlot>)ps.ProgramStudentSlots!.Select(pss => new GetProgramStudentSlot
                    {
                        ProgramStudentSlotId = pss.ProgramStudentSlotId,
                        ProgramStudentId = pss.ProgramStudentId,
                        ProgramStudent = null,
                        SlotId = pss.SlotId,
                        Slot = null
                    }) : null,
            Billing = includes.Contains("Billing") ? new GetBilling
            {
                BillingId = ps.Billing!.BillingId,
                IssueDate = ps.Billing.IssueDate,
                TotalPayAmount = ps.Billing.TotalPayAmount,
                PaymentStatus = ps.Billing.PaymentStatus,
                PaymentDate = ps.Billing.PaymentDate,
                ProgramName = ps.Program!.Name
            } : null
        });
    }


    public static IQueryable<GetProgramStudentSlot> ToViewModel(this IQueryable<ProgramStudentSlot> query, List<string> includes)
    {
        var baseQuery = query;

        if (includes.Contains("ProgramStudent"))
        {
            baseQuery = baseQuery.Include(pss => pss.ProgramStudent);
        }

        if (includes.Contains("Slot"))
        {
            baseQuery = baseQuery.Include(pss => pss.Slot);
        }

        return baseQuery.Select(pss => new GetProgramStudentSlot
        {
            ProgramStudentSlotId = pss.ProgramStudentSlotId,
            ProgramStudentId = pss.ProgramStudentId,
            ProgramStudent = includes.Contains("ProgramStudent") ? new GetProgramStudent
            {
                ProgramStudentId = pss.ProgramStudent!.ProgramStudentId,
                RegisterDate = pss.ProgramStudent.RegisterDate,
                ProgramId = pss.ProgramStudent.ProgramId
            } : null,
            SlotId = pss.SlotId,
            Slot = includes.Contains("Slot") ? new GetSlot
            {
                SlotId = pss.Slot!.SlotId,
                StartTime = pss.Slot.StartTime,
                EndTime = pss.Slot.EndTime,
              
            } : null
        });
    }

    public static IQueryable<GetSession> ToViewModel(this IQueryable<Session> query, List<string> includes)
    {
        var baseQuery = query;

        if (includes.Contains("Therapists"))
        {
            baseQuery = baseQuery.Include(s => s.TherapistsSessions!).ThenInclude(s => s.Therapist);
        }

        if (includes.Contains("Slots"))
        {
            baseQuery = baseQuery.Include(s => s.TherapistsSessions!).ThenInclude(s => s.Slots);
        }

        return baseQuery.Select(session => new GetSession
        {
            SessionId = session.SessionId,
            Name = session.Name,
            Description = session.Description,
            Therapists = includes.Contains("Therapists") ?
                session.TherapistsSessions!.Select( t => 

                    new GetTherapist
                    {
                        TherapistId = t.Therapist!.TherapistId,
                        Name = t.Therapist.Name,
                        AppUser =  new GetAppUser
                        {
                            PhoneNumber = t.Therapist.AppUser!.PhoneNumber,
                            Email = t.Therapist.AppUser.Email
                        } 
                    }
                ).ToList()
                : null,
            Slots = includes.Contains("Slots")  ?
                session.TherapistsSessions!.SelectMany( t => 

                    t.Slots!.Select( t =>

                        new GetSlot
                        {
                            SlotId = t.SlotId,
                            StartTime = t.StartTime,
                            EndTime = t.EndTime,
                            TherapistSession = new GetTherapistSession
                            {
                                Therapist = new GetTherapist
                                {
                                    TherapistId = t.TherapistSession.Therapist!.TherapistId,
                                    Name = t.TherapistSession.Therapist!.Name,

                                }
                            }

                        }


                    )

                    
                ).ToList()
                : null
        });
    }

    public static IQueryable<GetTherapistSession> ToViewModel(this IQueryable<TherapistSession> query, List<string> includes)
    {
        var baseQuery = query;

        if (includes.Contains("Session"))
        {
            baseQuery = baseQuery.Include(s => s.Session);
        }

        if (includes.Contains("Therapist"))
        {
            baseQuery = baseQuery.Include(s => s.Therapist);
        }

        if (includes.Contains("Slots"))
        {
            baseQuery = baseQuery.Include(s => s.Slots);
        }

        return baseQuery.Select(ts => new GetTherapistSession
            {
                TherapistSessionId = ts.TherapistSessionId,
                TherapistId = ts.TherapistId,
                Therapist = includes.Contains("Therapist") ? 
                    new GetTherapist
                    {
                        TherapistId = ts.TherapistId,
                        Name = ts.Therapist!.Name,
                        AppUser = new GetAppUser
                        {
                            PhoneNumber = ts.Therapist!.AppUser!.PhoneNumber,
                            Email = ts.Therapist!.AppUser.Email
                        },
                    }: null,
                    
                SessionId = ts.SessionId,
                Session = includes.Contains("Session") ? 
                    new GetSession{
                        SessionId = ts.Session!.SessionId,
                        Name = ts.Session!.Name,
                        Description = ts.Session!.Description,
                    } : null,
                Slots = includes.Contains("Slots") ? 
                    (ICollection<GetSlot>)ts.Slots!.Select(slot => new GetSlot
                        {
                            SlotId = slot.SlotId,
                            StartTime = slot.StartTime,
                            EndTime = slot.EndTime,
                            TherapistSession = null,
                            ProgramStudentSlots = null
                        }
                    )
                    : null
        });
    }


    public static IQueryable<GetSlot> ToViewModel(this IQueryable<Slot> query, List<string> includes)
    {
        var baseQuery = query;

        if (includes.Contains("TherapistSession"))
        {
            baseQuery = baseQuery.Include(s => s.TherapistSession);
        }

        if (includes.Contains("ProgramStudentSlots"))
        {
            baseQuery = baseQuery.Include(s => s.ProgramStudentSlots);
        }

        return baseQuery.Select(slot => new GetSlot
        {
            SlotId = slot.SlotId,
            StartTime = slot.StartTime,
            EndTime = slot.EndTime,
            TherapistSession = includes.Contains("TherapistSession") ? new GetTherapistSession
            {
                TherapistSessionId = slot.TherapistSession!.TherapistSessionId,
                TherapistId = slot.TherapistSession!.TherapistId,
                SessionId = slot.TherapistSession!.SessionId
            } : null,

            ProgramStudentSlots = includes.Contains("ProgramStudentSlots") ? 
                (ICollection<GetProgramStudentSlot>)slot.ProgramStudentSlots!.Select(pss => new GetProgramStudentSlot
                    {
                        ProgramStudentSlotId = pss.ProgramStudentSlotId,
                        ProgramStudentId = pss.ProgramStudentId,
                        ProgramStudent = null,
                        SlotId = pss.SlotId,
                        Slot = null
                    }
                ) 
                : null
        });
    }


    public static IQueryable<GetStudent> ToViewModel(this IQueryable<Student> query, List<string> includes)
    {
        var baseQuery = query;

        if (includes.Contains("Parent"))
        {
            baseQuery = baseQuery.Include(s => s.Parent);
        }

        if (includes.Contains("ProgramStudents"))
        {
            baseQuery = baseQuery.Include(s => s.ProgramStudents);
        }

        return baseQuery.Select(s => new GetStudent
        {
            StudentId = s.StudentId,
            Name = s.Name,
            Gender = s.Gender,
            Age = s.Age,
            DOB = s.DOB,
            ParentId = s.ParentId,
            Parent = includes.Contains("Parent") ? new GetParent
            {
                ParentId = s.Parent!.ParentId,
                Name = s.Parent.Name,
                City = s.Parent.City,
                Postcode = s.Parent.Postcode,
                State = s.Parent.State,
                Address = s.Parent.Address,
                Occupation = s.Parent.Occupation,
                AppUserId = s.Parent.AppUserId
            } : null,
            ProgramStudents = includes.Contains("ProgramStudents") 
                ? (ICollection<GetProgramStudent>)s.ProgramStudents!.Select(ps => new GetProgramStudent
                    {
                        ProgramStudentId = ps.ProgramStudentId,
                        RegisterDate = ps.RegisterDate,
                        ProgramId = ps.ProgramId,
                        Program = null,
                        StudentId = ps.StudentId,
                        Student = null,
                        Reports = null,
                        ProgramStudentSlots = null,
                        Billing = null
                    }
                    
                ) : null
        });
    }


    public static IQueryable<GetTherapist> ToViewModel(this IQueryable<Therapist> query, List<string> includes)
    {
        var baseQuery = query;

        if (includes.Contains("AppUser"))
        {
            baseQuery = baseQuery.Include(t => t.AppUser);
        }

        if (includes.Contains("Reports"))
        {
            baseQuery = baseQuery.Include(t => t.Reports);
        }

        return baseQuery.Select(t => new GetTherapist
        {
            TherapistId = t.TherapistId,
            Name = t.Name,
            AppUser = includes.Contains("AppUser") ? new GetAppUser
            {
                PhoneNumber = t.AppUser!.PhoneNumber,
                Email = t.AppUser.Email
            } : null,
            Reports = includes.Contains("Reports") 
                ? (ICollection<GetReport>)t.Reports!.Select(r => new GetReport
                    {
                        ReportId = r.ReportId,
                        Title = r.Title,
                        Content = r.Content,
                        ProgramStudentId = r.ProgramStudentId,
                        TherapistId = r.TherapistId,
                        ProgramStudent = null,
                        Therapist = null
                    }
                ) : null
        });
    }

    public static IQueryable<GetReport> ToViewModel(this IQueryable<Report> query, List<string> includes)
    {
        return query.Select(r => new GetReport
        {
            ReportId = r.ReportId,
            Title = r.Title,
            Content = r.Content,
            ProgramStudentId = r.ProgramStudentId,
            TherapistId = r.TherapistId,
            ProgramStudent = includes.Contains("ProgramStudent") ? new GetProgramStudent
            {
                ProgramStudentId = r.ProgramStudent!.ProgramStudentId,
                RegisterDate = r.ProgramStudent.RegisterDate,
                ProgramId = r.ProgramStudent.ProgramId,
                StudentId = r.ProgramStudent.StudentId
            } : null,
            Therapist = includes.Contains("Therapist") ? new GetTherapist
            {
                TherapistId = r.Therapist!.TherapistId,
                Name = r.Therapist.Name
            } : null
        });
    }


}

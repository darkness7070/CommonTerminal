using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Threading.Tasks;

namespace CommonTerminal.Models;

public class AngelAPI
{
    public async Task<string> AuthCode(string code)
    {

        return "Unknown error";

    }

    public class Request
    {
        public class Applications
        {
            public string token { get; set; }
            public bool isAdmin { get; set; } = true;
        }
    }
    public class Response
    {
        public class Employee
        {
            public int Id { get; set; }

            public string Code { get; set; } = null!;

            public int IdRole { get; set; }
        }
        public class InfoApplication
        {
            public Application Application { get; set; }
            public List<Visitor> Visitors { get; set; }
        }
        public class Application
        {
            public int Id { get; set; }

            public DateOnly ValidatyFrom { get; set; }

            public DateOnly ValidatyTo { get; set; }

            public byte[]? Passport { get; set; }

            public TimeOnly? ArrivalTime { get; set; }

            public TimeOnly? LeavingTime { get; set; }
            
            public bool IsSingle { get; set; }

            public int Status { get; set; }

            public virtual Purpose IdPurposeNavigation { get; set; } = null!;

            public virtual WorkerSubdivision IdSubdivisionNavigation { get; set; } = null!;
        }
        public partial class Visitor
        {
            public int Id { get; set; }

            public string Surname { get; set; } = null!;

            public string Name { get; set; } = null!;

            public string Patronymic { get; set; } = null!;

            public string Phone { get; set; } = null!;

            public string Email { get; set; } = null!;

            public string Organization { get; set; } = null!;

            public string Notes { get; set; } = null!;

            public DateOnly DateBirth { get; set; }

            public string Series { get; set; } = null!;

            public string Numbers { get; set; } = null!;

            public bool? IsBlacklist { get; set; }
        }
        public partial class WorkerSubdivision
        {
            public virtual Subdivision IdSubdivisionNavigation { get; set; } = null!;

            public virtual Worker IdWorkerNavigation { get; set; } = null!;
        }
        public class Worker
        {
            public int Id { get; set; }

            public string Fullname { get; set; } = null!;
        }
        
        public class Subdivision
        {
            public int Id { get; set; }

            public string Name { get; set; } = null!;
        }
        public class Purpose
        {
            public int Id { get; set; }

            public string Name { get; set; } = null!;
        }
    }
}
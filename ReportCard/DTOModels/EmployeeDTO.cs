using System;

namespace ReportCard.DTOModels
{
    public class EmployeeDTO
    {
        public int EmpId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Post { get; set; }
        public string Address { get; set; }
        public int RemoteWork {get; set; }
        public int DepId { get; set; }
        public string Department { get; set; }

        public string EmployeeShortInfo { get { return $"{LastName} {FirstName}{(string.IsNullOrEmpty(MiddleName) ? "" : " " + MiddleName)} ({Post})"; } }
    }
}

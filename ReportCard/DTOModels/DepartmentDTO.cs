using System.Collections.Generic;

namespace ReportCard.DTOModels
{
    public class DepartmentDTO
    {
        public int DepId { get; set; }
        public string Name { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}

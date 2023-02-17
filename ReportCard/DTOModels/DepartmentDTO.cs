using System.Collections.Generic;

namespace ReportCard.DTOModels
{
    /// <summary>
    /// Модель Департамента
    /// </summary>
    public class DepartmentDTO
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int DepId { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список сотрудников департамента
        /// </summary>
        public List<EmployeeDTO> Employees { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}

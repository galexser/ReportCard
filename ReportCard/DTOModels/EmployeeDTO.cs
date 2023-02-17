using System;

namespace ReportCard.DTOModels
{
    /// <summary>
    /// Модель Сотрудник
    /// </summary>
    public class EmployeeDTO
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int EmpId { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string Post { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Удаленная работа 
        /// </summary>
        public int RemoteWork {get; set; }
        /// <summary>
        /// Идентификатор Департамента
        /// </summary>
        public int DepId { get; set; }
        /// <summary>
        /// Наименование Департамента
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// Свойство для отображения в форме авторизации
        /// </summary>
        public string EmployeeShortInfo { get { return $"{LastName} {FirstName}{(string.IsNullOrEmpty(MiddleName) ? "" : " " + MiddleName)} ({Post})"; } }
    }
}

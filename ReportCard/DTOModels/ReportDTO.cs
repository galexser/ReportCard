using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ReportCard.DTOModels
{
    /// <summary>
    /// Модель Производственный календарь
    /// </summary>
    public class ListReportDTO
    {
        /// <summary>
        /// Год календаря
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Месяц календаря
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// Список учета рабочего времени по сотрудникам
        /// </summary>
        public List<ReportDTO> Reports { get; set; } = new List<ReportDTO>();
        /// <summary>
        /// Преобразование в DataTable
        /// </summary>
        /// <returns>Данные ввиде таблицы</returns>
        public DataTable GetDataTable()
        {
            DataTable ret = new DataTable();
            ret.Columns.Add("EmpId", typeof(int));
            ret.Columns.Add("FIO", typeof(string));
            ret.Columns.Add("Post", typeof(string));
            for (int d = 1; d <= DateTime.DaysInMonth(Year, Month); d++)
            {
                ret.Columns.Add($"d{d}", typeof(string));
            }
            Reports.ForEach(emp =>
            {
                var row = ret.NewRow();
                row.SetField<int>("EmpId", emp.EmpId);
                row.SetField<string>("FIO", emp.FIO);
                row.SetField<string>("Post", emp.Post);
                emp.WorkDays.ForEach(wd =>
                {
                    row.SetField<string>($"d{wd.WDay.Day}", wd.DayCode.CodeId);
                });
                ret.Rows.Add(row);
            });
            return ret;
        }
    }
    /// <summary>
    /// Модель Учет рабочего времени сотрудника
    /// </summary>
    public class ReportDTO
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public int EmpId { get; set; }
        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string FIO { get; set; }
        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public string Post { get; set; }
        /// <summary>
        /// Список Кодировок дней
        /// </summary>
        public List<WorkDay> WorkDays { get; set; }
        /// <summary>
        /// Модель Кодировка дня
        /// </summary>
        public class WorkDay
        {
            public DateTime WDay { get; set; }
            public DayCodeDTO DayCode { get; set; }
        }
    }
}

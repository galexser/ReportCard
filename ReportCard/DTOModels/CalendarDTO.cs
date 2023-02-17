using System;

namespace ReportCard.DTOModels
{
    /// <summary>
    /// Модель элемента производственного календаря
    /// </summary>
    public class CalendarDTO
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime HDay { get; set; }
        /// <summary>
        /// Тип дня
        /// </summary>
        /// <value>
        ///     1 - выходной день<br/>
        ///     2 - рабочий и сокращенный (может быть использован для любого дня недели)<br/>
        ///     3 - рабочий день (суббота/воскресенье)
        /// </value>
        public sbyte DayType { get; set; }
    }
}

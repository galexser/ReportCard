﻿using DataModels;

namespace ReportCard.DTOModels
{
    /// <summary>
    /// Модель Кодировка учета
    /// </summary>
    /// <value>
    /// В - выходные и праздничные дни<br/>
    /// Б - дни временной нетрудоспособности<br/>
    /// ОТ - ежегодный основной оплаченный отпуск<br/>
    /// К - командировочные дни; а также, выходные (нерабочие) дни при нахождении в командировке, когда сотрудник отдыхает, в соответствии с графиком работы ООО «Наука» в командировке<br/>
    /// До - неоплачиваемый отпуск(отпуск за свой счет)<br/>
    /// У - отпуск на период обучения<br/>
    /// Ож - Отпуск по уходу за ребенком<br/>
    /// Н - отсутствие на рабочее место по невыясненным причинам<br/>
    /// Я - полный рабочий день<br/>
    /// Рв - работа в праздничные и выходные дни, а также работа в праздничные и выходные дни, при нахождении в командировке<br/>
    /// Хд - хозяйственный день<br/>
    /// </value>
    public class DayCodeDTO
    {
        /// <summary>
        /// Код
        /// </summary>
        /// <value>В, Б, ОТ, К, До, У, Ож, Н, Я, Рв, Хд</value>
        public string CodeId { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{CodeId} - {Description}";
        }
    }
}

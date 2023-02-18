using DataModels;
using LinqToDB;
using LinqToDB.Data;
using MySqlConnector;
using ReportCard.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportCard.CRUD
{
    public class CalendarCRUD
    {
        /// <summary>
        /// Получение производственного календаря на месяц года
        /// </summary>
        /// <param name="year">Год</param>
        /// <param name="month">Месяц</param>
        /// <returns>Список праздничных выходных, предпраздничных и рабочих выходных дней</returns>
        public static List<CalendarDTO> Get(int year, int month)
        {
            List<CalendarDTO> ret = new List<CalendarDTO>();
            using (var db = new ReportDB())
            {
                ret = Program.MyMapper.Map<List<CalendarDTO>>(
                    db.Calendars
                    .Where(w => w.HDay >= new DateTime(year, month, 1) && w.HDay <= new DateTime(year, month, DateTime.DaysInMonth(year, month)))
                    .ToList());
            }
            return ret;
        }
        /// <summary>
        /// Получение производственного календаря на год
        /// </summary>
        /// <param name="year">Год</param>
        /// <returns>Список праздничных выходных, предпраздничных и рабочих выходных дней</returns>
        public static List<CalendarDTO> Get(int year)
        {
            List<CalendarDTO> ret = new List<CalendarDTO>();
            using (var db = new ReportDB())
            {
                ret = Program.MyMapper.Map<List<CalendarDTO>>(
                    db.Calendars
                    .Where(w => w.HDay >= new DateTime(year, 1, 1) && w.HDay <= new DateTime(year, 12, 31))
                    .ToList());
            }
            return ret;
        }
        /// <summary>
        /// Возвращает список годов, по которым есть производственный календарь
        /// </summary>
        /// <returns>Список годов</returns>
        public static List<int> GetYears()
        {
            List<int> ret = new List<int>();
            using (var db = new ReportDB())
            {
                ret =
                    db.Calendars
                    .Select(s => s.HDay.Year)
                    .Distinct()
                    .OrderByDescending(o => o)
                    .ToList();
            }
            if (ret.IndexOf(DateTime.Now.Year) == -1)
                ret.Insert(0, DateTime.Now.Year);
            return ret;
        }

        public static void LoadFromFile(Helper.CalendarLoader.calendar data)
        {
            List<Calendar> ret = new List<Calendar>();
            data.days.ForEach(d => ret.Add(new Calendar() { HDay = Convert.ToDateTime($"{data.year}.{d.d}"), DayType = (sbyte)d.t }));
            using (var db = new ReportDB())
            {
                db.BeginTransaction();
                BulkCopyOptions bko = new BulkCopyOptions();
                bko.KeepIdentity = true;
                if (db.BulkCopy(bko, ret).RowsCopied == ret.Count)
                    db.CommitTransaction();
                else
                {
                    db.RollbackTransaction();
                    throw new Exception("Не удалось загрузить производственный календарь");
                }
            }
        }
        /// <summary>
        /// Проверка на дублирование Даты календаря
        /// </summary>
        /// <param name="dt">Дата</param>
        /// <returns>
        ///     true - есть дубликат<br/>
        ///     false - нет дубликата
        /// </returns>
        static bool CheckByDate(DateTime dt)
        {
            bool ret = false;
            using (var db = new ReportDB())
            {
                ret = db.Calendars.Where(w => w.HDay == dt).FirstOrDefault() != null;
            }
            return ret;
        }
        /// <summary>
        /// Добавление Даты календаря
        /// </summary>
        /// <param name="с">Информация о дне</param>
        /// <exception cref="Exception">Сообщение об ошибке при наличии информации об этом дне, о непредвиденной ошибке</exception>
        public static void Add(CalendarDTO c)
        {
            try
            {
                if (!CheckByDate(c.HDay))
                {
                    using (var db = new ReportDB())
                    {
                        db.Insert(Program.MyMapper.Map<Calendar>(c));
                    }
                }
                else
                    throw new Exception($"Дата {c.HDay:dd.MM.yyyy} уже внесена");
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// Изменение Даты календаря
        /// </summary>
        /// <param name="с">Информация о дне</param>
        /// <exception cref="Exception">Сообщение о непредвиденной ошибке</exception>
        public static void Update(CalendarDTO c)
        {
            try
            {
                using (var db = new ReportDB())
                {
                    db.Update(Program.MyMapper.Map<Calendar>(c));
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// Удаление Даты календаря
        /// </summary>
        /// <param name="dt">Удаляемая дата</param>
        public static void Remove(DateTime dt)
        {
            using (var db = new ReportDB())
            {
                db.Calendars.Where(w => w.HDay == dt).Delete();
            }
        }
    }
}

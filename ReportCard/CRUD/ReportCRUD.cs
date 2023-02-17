using DataModels;
using LinqToDB;
using MySqlConnector;
using ReportCard.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportCard.CRUD
{
    public class ReportCRUD
    {
        /// <summary>
        /// Возвращает список табелей по департаменту/сотруднику
        /// </summary>
        /// <param name="year">Год табеля</param>
        /// <param name="month">Месяц табеля</param>
        /// <param name="DepId">Идентификатор отдела</param>
        /// <param name="EmpId">Идентификатор сотрудника. Если заполнен, то возвращается табель по этому сотруднику</param>
        /// <returns>Список табелей</returns>
        public static ListReportDTO Get(int year, int month, int DepId, int EmpId = -1)
        {
            ListReportDTO ret = new ListReportDTO() { Month = month, Year = year };
            using (var db = new ReportDB())
            {
                if (EmpId == -1)
                    ret.Reports = Program.MyMapper.Map<List<ReportDTO>>(db.Employees
                        .LoadWith(l => l.Dep)
                        .Where(l => l.DepId == DepId)
                        .LoadWith(l => l.Fkremps.Where(w => w.WorkDate >= new DateTime(year, month, 1) && w.WorkDate <= new DateTime(year, month, DateTime.DaysInMonth(year, month))))
                        .ThenLoad(l => l.Code)
                        .ToList());
                else
                    ret.Reports = Program.MyMapper.Map<List<ReportDTO>>(db.Employees
                        .LoadWith(l => l.Dep)
                        .Where(l => l.EmpID == EmpId)
                        .LoadWith(l => l.Fkremps.Where(w => w.WorkDate >= new DateTime(year, month, 1) && w.WorkDate <= new DateTime(year, month, DateTime.DaysInMonth(year, month))))
                        .ThenLoad(l => l.Code)
                        .ToList());
            }
            return ret;
        }
        /// <summary>
        /// Возвращает список годов, по которым есть табель по департаменту
        /// </summary>
        /// <param name="DepId">Идентификатор департамента</param>
        /// <returns>Список годов</returns>
        public static List<int> GetYears(int DepId)
        {
            List<int> ret = new List<int>();
            using (var db = new ReportDB())
            {
                ret =
                    db.Reports
                    .Where(w => w.Emp.DepId == DepId)
                    .Select(s => s.WorkDate.Year)
                    .Distinct()
                    .OrderByDescending(o => o)
                    .ToList();
            }
            if (ret.IndexOf(DateTime.Now.Year) == -1)
                ret.Insert(0, DateTime.Now.Year);
            return ret;
        }
        /// <summary>
        /// Добавляет/Редактирует информацию об отметке в табеле
        /// </summary>
        /// <param name="rep">Отметка в табеле</param>
        /// <exception cref="Exception">Ошибка</exception>
        public static void AddOrUpdate(Report rep)
        {
            try
            {
                using (var db = new ReportDB())
                {
                    db.InsertOrReplace(rep);
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Удаляет информацию об отметке в табеле
        /// </summary>
        /// <param name="empid">Идентификатор сотрудника</param>
        /// <param name="wd">Дата</param>
        public static void Remove(int empid, DateTime wd)
        {
            using (var db = new ReportDB())
            {
                db.Reports.Where(w => w.WorkDate == wd && w.EmpID == empid).Delete();
            }
        }
    }
}

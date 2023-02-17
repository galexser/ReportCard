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
            if (ret.Count == 0)
                ret.Add(DateTime.Now.Year);
            return ret;
        }
        public static ReportDTO GetById(string id)
        {
            return new ReportDTO();
            //ReportDTO ret = null;
            //using (var db = new ReportDB())
            //{
            //    ret = db.Reports.Where(w => w.CodeId == id).Select(s => new ReportDTO(s)).FirstOrDefault();
            //}
            //return ret;
        }
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
        public static void Update(string codeOld, string code, string descr)
        {
            //try
            //{
            //    if (GetById(code) == null)
            //        using (var db = new ReportDB())
            //        {
            //            db.Reports
            //                .Where(w => w.CodeId == codeOld)
            //                .Set(p => p.CodeId, code)
            //                .Set(p => p.Name, descr)
            //                .Update();
            //        }
            //    else
            //        throw new Exception("Дублирование кода");
            //}
            //catch (MySqlException ex)
            //{
            //    throw new Exception(ex.Message);
            //}
        }
        public static void Remove(string code)
        {
            //using (var db = new ReportDB())
            //{
            //    db.Reports.Where(w => w.CodeId == code).Delete();
            //}
        }
    }
}

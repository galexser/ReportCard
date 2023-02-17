using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ReportCard.DTOModels
{
    public class ListReportDTO
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public List<ReportDTO> Reports { get; set; } = new List<ReportDTO>();
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
            //    .GroupBy(g => new { g.EmpId, g.FIO, g.Post })
            //    .Select(s => new { emp = s.Key, data = s.Select(x => x) })
            //    .ToList()
            //    .ForEach(emp =>
            //    {
            //        var row = ret.NewRow();
            //        row.SetField<int>("EmpId", emp.emp.EmpId);
            //        row.SetField<string>("FIO", emp.emp.FIO);
            //        row.SetField<string>("Post", emp.emp.Post);
            //        emp.data.ToList().ForEach(d =>
            //        {
            //            row.SetField<string>($"d{d.WorkDate.Day}", d.DayCode);
            //        });
            //    });
            return ret;
        }
    }
    public class ReportDTO
    {
        public int EmpId { get; set; }
        public string FIO { get; set; }
        public string Post { get; set; }
        public List<WorkDay> WorkDays { get; set; }
        //public DateTime WorkDate { get; set; }
        //public string DayCode { get; set; }
        //public string Description { get; set; }
        public class WorkDay
        {
            public DateTime WDay { get; set; }
            public DayCodeDTO DayCode { get; set; }
        }
    }
}

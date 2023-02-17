﻿using DataModels;
using LinqToDB;
using MySqlConnector;
using ReportCard.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportCard.CRUD
{
    public class CalendarCRUD
    {
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

    }
}
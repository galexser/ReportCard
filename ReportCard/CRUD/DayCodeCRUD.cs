using DataModels;
using LinqToDB;
using MySqlConnector;
using ReportCard.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportCard.CRUD
{
    public class DayCodeCRUD
    {
        /// <summary>
        /// Получение списка кодировок
        /// </summary>
        /// <returns>Список кодировок</returns>
        public static List<DayCodeDTO> Get()
        {
            List<DayCodeDTO> ret = new List<DayCodeDTO>();
            using (var db = new ReportDB())
            {
                ret = Program.MyMapper.Map<List<DayCodeDTO>>(db.DayCodes.ToList());
            }
            return ret;
        }

    }
}

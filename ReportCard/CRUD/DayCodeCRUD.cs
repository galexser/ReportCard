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
        /// <summary>
        /// Проверка на дублирование Кодировок
        /// </summary>
        /// <param name="CodeId">Кодировка</param>
        /// <returns>
        ///     true - есть дубликат<br/>
        ///     false - нет дубликата
        /// </returns>
        static bool CheckById(string CodeId)
        {
            bool ret = false;
            using (var db = new ReportDB())
            {
                ret = db.DayCodes.Where(w => w.CodeId == CodeId).FirstOrDefault() != null;
            }
            return ret;
        }
        /// <summary>
        /// Добавление/Редактирование кодировки
        /// </summary>
        /// <param name="dc">Информация о кодировке</param>
        /// <param name="CodeOld">Старый код</param>
        /// <exception cref="Exception">Сообщение об ошибке при наличии такой кодировки, о непредвиденной ошибке</exception>
        public static void AddOrUpdate(DayCodeDTO dc, string CodeOld)
        {
            try
            {
                var daycode = Program.MyMapper.Map<DayCode>(dc);
                if (string.IsNullOrEmpty(CodeOld) || CodeOld != dc.CodeId)
                {
                    if (!CheckById(dc.CodeId))
                    {
                        using (var db = new ReportDB())
                        {
                            if (string.IsNullOrEmpty(CodeOld))
                                db.Insert(daycode);
                            else
                                db.GetTable<DayCode>()
                                    .Update(
                                        t => t.CodeId == CodeOld,
                                        t => new DayCode
                                        {
                                            CodeId = dc.CodeId,
                                            Name =dc.Description
                                        });
                        }
                    }
                    else
                        throw new Exception($"Кодировка {dc.CodeId} уже внесена");
                }
                else
                    using (var db = new ReportDB())
                    {
                        db.Update(daycode);
                    }
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// Удаление кодировки
        /// </summary>
        /// <param name="CodeId">Идентификатор кодировки</param>
        public static void Remove(string CodeId)
        {
            using (var db = new ReportDB())
            {
                var emp = db.DayCodes.Where(w => w.CodeId == CodeId).LoadWith(l => l.Fkrdcs).First();
                if (emp.Fkrdcs.Count() > 0)
                    throw new Exception("Удаление невозможно!\nКодировка используется.");
                else
                    db.DayCodes.Where(w => w.CodeId == CodeId).Delete();
            }
        }
    }
}

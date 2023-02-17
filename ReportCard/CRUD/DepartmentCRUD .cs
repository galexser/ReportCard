using DataModels;
using LinqToDB;
using MySqlConnector;
using ReportCard.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportCard.CRUD
{
    /// <summary>
    /// Работа с таблицей departments
    /// </summary>
    public class DepartmentCRUD
    {
        /// <summary>
        /// Получение списка департаментов
        /// </summary>
        /// <returns>Список департаментов</returns>
        public static List<DepartmentDTO> Get()
        {
            List<DepartmentDTO> ret = new List<DepartmentDTO>();
            using (var db = new ReportDB())
            {
                ret = Program.MyMapper.Map<List<DepartmentDTO>>(db.Departments.LoadWith(l => l.Fkempdeps).ToList());
            }
            return ret;
        }
        /// <summary>
        /// Получение департамента по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Департамент</returns>
        public static DepartmentDTO GetById(int id)
        {
            DepartmentDTO ret = null;
            using (var db = new ReportDB())
            {
                var find = db.Departments.Where(w => w.DepId == id).FirstOrDefault();
                if (find != null)
                    ret = Program.MyMapper.Map<DepartmentDTO>(find);
            }
            return ret;
        }
        /// <summary>
        /// Проверка на дублирование департаментов
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="id">Идентификатор редактируемого департамента</param>
        /// <returns>
        ///     true - есть дубликат<br/>
        ///     false - нет дубликата
        /// </returns>
        static bool CheckByName(string name, int id = -1)
        {
            bool ret = false;
            using (var db = new ReportDB())
            {
                if (id == -1)
                    ret = db.Departments.Where(w => w.Name == name).FirstOrDefault() != null;
                else
                    ret = db.Departments.Where(w => w.Name == name && w.DepId != id).FirstOrDefault() != null;
            }
            return ret;
        }
        /// <summary>
        /// Добавление департамента
        /// </summary>
        /// <param name="name">Наименование департамента</param>
        /// <exception cref="Exception">Сообщение об ошибке при совпадении с наименованием другого департамента, о непредвиденной ошибке</exception>
        public static void Add(string name)
        {
            try
            {
                if (!CheckByName(name))
                    using (var db = new ReportDB())
                    {
                        db.Insert(new Department() { Name = name });
                    }
                else
                    throw new Exception($"Департамент {name} уже создан");
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Обновление департамента
        /// </summary>
        /// <param name="dep">Информация о департаменте</param>
        /// <exception cref="Exception">Сообщение об ошибке при совпадении с ФИО и датой рождения другого сотрудника, о непредвиденной ошибке</exception>
        public static void Update(DepartmentDTO dep)
        {
            try
            {
                if (!CheckByName(dep.Name, dep.DepId))
                    using (var db = new ReportDB())
                    {
                        db.Update(Program.MyMapper.Map<Department>(dep));
                    }
                else
                    throw new Exception($"Департамент {dep.Name} уже создан");
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Удаление департамента
        /// </summary>
        /// <param name="DepId">Идентификатор департамента</param>
        public static void Remove(int DepId)
        {
            using (var db = new ReportDB())
            {
                var emp = db.Departments.Where(w => w.DepId == DepId).LoadWith(l => l.Fkempdeps).First();
                if (emp.Fkempdeps.Count() > 0)
                    throw new Exception("Удаление невозможно!\nДепартамент наполнен сотрудниками.");
                else
                    db.Departments.Where(w => w.DepId == DepId).Delete();
            }
        }

    }
}

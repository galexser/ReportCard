using AutoMapper;
using DataModels;
using LinqToDB;
using MySqlConnector;
using ReportCard.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportCard.CRUD
{
    public class EmployeeCRUD
    {
        /// <summary>
        /// Получение списка сотрудников
        /// </summary>
        /// <returns>Список сотрудников</returns>
        public static List<EmployeeDTO> Get()
        {
            List<EmployeeDTO> ret = new List<EmployeeDTO>();
            using (var db = new ReportDB())
            {
                ret = Program.MyMapper.Map<List<EmployeeDTO>>(db.Employees.LoadWith(l => l.Dep).ToList());
            }
            return ret;
        }
        /// <summary>
        /// Получение сострудника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Сотрудник</returns>
        public static EmployeeDTO GetById(int id)
        {
            EmployeeDTO ret = null;
            using (var db = new ReportDB())
            {
                var find = db.Employees.Where(w => w.EmpID == id).FirstOrDefault();
                if (find != null)
                    ret = Program.MyMapper.Map<EmployeeDTO>(find);
            }
            return ret;
        }
        /// <summary>
        /// Проверка на дублирование сотрудников
        /// </summary>
        /// <param name="lastname">Фамиллия</param>
        /// <param name="firstname">Имя</param>
        /// <param name="middlename">Отчество</param>
        /// <param name="birthday">Дата рождения</param>
        /// <returns></returns>
        static bool CheckByFIO(string lastname, string firstname, string middlename, DateTime birthday, int id = -1)
        {
            bool ret = false;
            using (var db = new ReportDB())
            {
                if (id == -1)
                    ret = db.Employees.Where(w => w.LastName == lastname && w.FirstName == firstname && w.MiddleName == middlename && w.BirthDay == birthday.Date).FirstOrDefault() != null;
                else
                    ret = db.Employees.Where(w => w.LastName == lastname && w.FirstName == firstname && w.MiddleName == middlename && w.BirthDay == birthday.Date && w.EmpID != id).FirstOrDefault() != null;
            }
            return ret;
        }
        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        /// <param name="emp">Информация о сотруднике</param>
        /// <exception cref="Exception">Сообщение об ошибке при совпадении с ФИО и датой рождения другого сотрудника, о непредвиденной ошибке</exception>
        public static void Add(EmployeeDTO emp)
        {
            try
            {
                if (!CheckByFIO(emp.LastName, emp.FirstName, emp.MiddleName, emp.BirthDay))
                    using (var db = new ReportDB())
                    {
                        db.Insert(Program.MyMapper.Map<Employee>(emp));
                    }
                else
                    throw new Exception($"Пользователь {emp.LastName} {emp.FirstName} {emp.MiddleName} {emp.BirthDay:dd.MM.yyyy} г.р. уже создан");
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Обновление сотрудника
        /// </summary>
        /// <param name="emp">Информация о сотруднике</param>
        /// <exception cref="Exception">Сообщение об ошибке при совпадении с ФИО и датой рождения другого сотрудника, о непредвиденной ошибке</exception>
        public static void Update(EmployeeDTO emp)
        {
            try
            {
                if (!CheckByFIO(emp.LastName, emp.FirstName, emp.MiddleName, emp.BirthDay, emp.EmpId))
                    using (var db = new ReportDB())
                    {
                        db.Update(Program.MyMapper.Map<Employee>(emp));
                    }
                else
                    throw new Exception($"Пользователь {emp.LastName} {emp.FirstName} {emp.MiddleName} {emp.BirthDay:dd.MM.yyyy} г.р. уже создан");
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Удаление сотрудниеа
        /// </summary>
        /// <param name="EmpId">Идентификатор сотрудника</param>
        public static void Remove(int EmpId)
        {
            using (var db = new ReportDB())
            {
                var emp = db.Employees.Where(w => w.EmpID == EmpId).LoadWith(l => l.Fkremps).First();
                if (emp.Fkremps.Count() > 0)
                    throw new Exception("Удаление невозможно!\nО пользователе внесена информаци в табель.");
                else
                    db.Employees.Where(w => w.EmpID == EmpId).Delete();
            }
        }

    }
}

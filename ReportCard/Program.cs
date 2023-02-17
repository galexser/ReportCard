using AutoMapper;
using ReportCard.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportCard
{
    internal static class Program
    {
        /// <summary>
        /// Интерфейс для AutoMapper для доступа во всем проекте
        /// </summary>
        public static IMapper MyMapper { get; set; }  
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Конфигурируем AutoMapper
            var mapperConfiguration = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            });
            try
            {
                //Говорим, чтобы проверял конфигурацию
                mapperConfiguration.AssertConfigurationIsValid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Создаем мапер
            MyMapper = mapperConfiguration.CreateMapper();
            Application.Run(new frmMain());
        }
    }
}

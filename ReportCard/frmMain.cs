using ReportCard.CRUD;
using ReportCard.DTOModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ReportCard
{
    public partial class frmMain : Form
    {
        bool canChangeReportCard = false;
        EmployeeDTO sEmp = null;
        List<CalendarDTO> calendar = null;
        List<DayCodeDTO> dayCodes;
        DataGridViewCell clickedCell;
        int selectYear = -1;
        int selectMonth = -1;
        public frmMain()
        {
            InitializeComponent();

        }
        #region Вспомогательные функции
        /// <summary>
        /// Загрузка табеля
        /// </summary>
        private void GetData()
        {
            //Получаем список кодов
            dayCodes = DayCodeCRUD.Get();
            calendar = CalendarCRUD.Get(selectYear, selectMonth);
            //Получаем
            this.SuspendLayout();
            dgvRC.DataSource = ReportCRUD.Get(
                selectYear,
                selectMonth,
                ((DepartmentDTO)lbDep.SelectedItem).DepId,
                !canChangeReportCard ? sEmp.EmpId : -1)
                .GetDataTable();
            this.ResumeLayout();
        }
        /// <summary>
        /// Загружаем департаменты
        /// </summary>
        void LoadDepartment()
        {
            if (canChangeReportCard)
                lbDep.DataSource = DepartmentCRUD.Get();
            else
                lbDep.DataSource = new List<DepartmentDTO>() { DepartmentCRUD.GetById(sEmp.DepId) };
            lbDep.SelectedIndex = 0;
        }
        #endregion
        private void tsmiCalendar_Click(object sender, EventArgs e)
        {
            var frm = new frmCalendars();
            frm.Owner = this;
            frm.ShowDialog();
        }
        private void tsmiDepartment_Click(object sender, EventArgs e)
        {
            var frm = new frmDepartments();
            frm.Owner = this;
            frm.ShowDialog();
        }
        private void tsmiEmployees_Click(object sender, EventArgs e)
        {
            var frm = new frmEmployees();
            frm.Owner = this;
            frm.ShowDialog();
        }
        private void tsmiDayCodes_Click(object sender, EventArgs e)
        {
            var frm = new frmDayCodes();
            frm.Owner = this;
            frm.ShowDialog();
        }


        #region Работа с табелем
        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            //Обновляем таблицу по новому фильтру
            GetData();
        }
        private void tscbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Запоминаем выбранный год
            selectYear = Convert.ToInt32(tscbYear.SelectedItem);
        }
        private void tscbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Запоминаем выбранный месяц
            selectMonth = Convert.ToInt32(tscbMonth.SelectedItem.ToString().Split('-')[0].TrimStart('0'));
        }

        #region Работа с grid
        /// <summary>
        /// Добавление всплывающей подсказки на заполненных ячейках
        /// </summary>
        private void dgvRC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Добавляем всплывающую подсказку для заполненной ячеки
            var cell = dgvRC.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (e.ColumnIndex > 2 && !string.IsNullOrEmpty(cell.Value.ToString()))
                cell.ToolTipText = dayCodes.First(f => f.CodeId == cell.Value.ToString()).Description;
        }
        /// <summary>
        /// Запоминаем ячейку на которую нажали ПКМ, делаем ее выбранной
        /// </summary>
        private void dgvRC_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex != -1 && e.ColumnIndex > 2)
            {
                cmsiDelete.Enabled = !string.IsNullOrEmpty(((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                //Запоминаем ячейку, на которой сделали ПКМ и выбираем ее
                clickedCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (!clickedCell.Selected)
                {
                    //Очищаем выделение
                    clickedCell.DataGridView.ClearSelection();
                    //Делаем ячейка текущей
                    clickedCell.DataGridView.CurrentCell = clickedCell;
                    //Делаем ее выбранной
                    clickedCell.Selected = true;
                }
            }
        }
        /// <summary>
        /// Разукрашиваем столбец после добавления
        /// </summary>
        private void dgvRC_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Index > 2)
            {
                var column = e.Column;
                //Заголовок
                column.HeaderText = column.Name.Trim('d');
                //Размер столбцов
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                column.MinimumWidth = 20;
                //Привязывем контекстное меню
                if (canChangeReportCard)
                    column.ContextMenuStrip = cms;
                #region Разукрашиваем в зависимости от дня недели и праздников
                var day = new DateTime(selectYear, selectMonth, Convert.ToInt32(column.HeaderText));
                var c = calendar.FirstOrDefault(f => f.HDay == day);
                if ((day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday))
                {
                    if (c != null && c.DayType == 2)
                        column.DefaultCellStyle.BackColor = Color.Yellow;
                    else if (c != null && c.DayType == 3)
                        column.DefaultCellStyle.BackColor = Color.LightGreen;
                    else if (c != null && c.DayType == 1)
                        column.DefaultCellStyle.BackColor = Color.LightPink;
                    else
                        column.DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    if (c != null && c.DayType == 2)
                        column.DefaultCellStyle.BackColor = Color.Yellow;
                    else if (c != null && c.DayType == 1)
                        column.DefaultCellStyle.BackColor = Color.LightPink;
                    else
                        column.DefaultCellStyle.BackColor = Color.White;
                }
            }
            #endregion
        }
        #endregion

        #endregion

        #region Работа со списком департаментов
        private void tsbDepUpdate_Click(object sender, EventArgs e)
        {
            //Обновляем департаменты
            LoadDepartment();
        }
        private void lbDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Получаем список возможных годов табеля для департамента
            //Если возможных годов
            tscbYear.ComboBox.DataSource = ReportCRUD.GetYears(((DepartmentDTO)lbDep.SelectedItem).DepId);

            tscbMonth.ComboBox.SelectedIndex = 0;
            tscbYear.ComboBox.SelectedIndex = 0;
            GetData();
        }
        #endregion

        /// <summary>
        /// После загрузки основной формы, загружаем форму авторизации
        /// </summary>
        private void frmMain_Shown(object sender, EventArgs e)
        {
            var frm = new frmLogin();
            frm.Owner = this;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //Запоминаем выбранного сотрудника
                sEmp = frm.SelectEmp;
                //Проверяем может ли он заполнять табель (Должность = "Табельщик" и Отдел = "Отдел кадров")
                canChangeReportCard = sEmp.Post == "Табельщик" && sEmp.DepId == 1;
                //Для специалистов Отдела кадров открываем возможность редактировать справочники
                ms.Visible = sEmp.DepId == 1;

                if (DayCodeCRUD.Get().Count > 0)
                {
                    //Загружаем информацию об отделах
                    LoadDepartment();
                    sc.Visible = true;
                }
                else
                {
                    if (ms.Visible)
                        if (MessageBox.Show("Не заполнен обязательные справочник Кодировки дней. Хотите заполнить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            var frmdc = new frmDayCodes();
                            frmdc.Owner = this;
                            frmdc.ShowDialog();
                        }
                        else
                            MessageBox.Show("Не заполнен обязательные справочник Кодировки дней. Обратитесь к ответственому", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
                Close();
        }



        #region Контекстное меню грида
        private void cmsiEdit_Click(object sender, EventArgs e)
        {
            //Редактируем день в табеле
            var frm = new frmAddDayCode(
                dgvRC.Rows[clickedCell.RowIndex].Cells["FIO"].Value.ToString(),
                new DateTime(selectYear, selectMonth, Convert.ToInt32(dgvRC.Columns[clickedCell.ColumnIndex].Name.Trim('d'))),
                clickedCell.Value.ToString()
                );
            frm.Owner = this;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ReportCRUD.AddOrUpdate(new DataModels.Report()
                {
                    EmpID = (int)dgvRC.Rows[clickedCell.RowIndex].Cells["EmpId"].Value,
                    WorkDate = frm.editDay,
                    CodeId = frm.CodeId
                });

                GetData();
            }
        }
        private void cmsiDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить выбранную информацию", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ReportCRUD.Remove((int)dgvRC.Rows[clickedCell.RowIndex].Cells["EmpId"].Value, new DateTime(selectYear, selectMonth, Convert.ToInt32(dgvRC.Columns[clickedCell.ColumnIndex].Name.Trim('d'))));
            }
        }


        #endregion
    }
}

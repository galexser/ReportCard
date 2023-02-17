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
        /// <summary>
        /// Столбцы с днями месяца: раскрашиваем, прописываем шапку, привязываем контекстное меню
        /// </summary>
        void FormatWorkDataColumns()
        {
            var calendar = CalendarCRUD.Get(selectYear, selectMonth);
            for (int i = 1; i <= DateTime.DaysInMonth(selectYear, selectMonth); i++)
            {
                var column = dgvRC.Columns[$"d{i}"];
                //Заголовок
                column.HeaderText = i.ToString();
                //Размер столбцов
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                column.MinimumWidth = 20;
                //Привязывем контекстное меню
                column.ContextMenuStrip = cms;
                #region Разукрашиваем в зависимости от дня недели и праздников
                var day = new DateTime(selectYear, selectMonth, i);
                var c = calendar.FirstOrDefault(f => f.HDay == day);
                if ((day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday))
                {
                    if (c != null && c.DayType == 2)
                        column.DefaultCellStyle.BackColor = Color.Orange;
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
                        column.DefaultCellStyle.BackColor = Color.Orange;
                    else if (c != null && c.DayType == 1)
                        column.DefaultCellStyle.BackColor = Color.LightPink;

                }
                #endregion
            }
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

        private void lbDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Получаем список возможных годов табеля для департамента
            tscbYear.ComboBox.DataSource = ReportCRUD.GetYears(((DepartmentDTO)lbDep.SelectedItem).DepId);

            tscbMonth.ComboBox.SelectedIndex = 0;
            tscbYear.ComboBox.SelectedIndex = 0;
            GetData();

        }

        private void GetData()
        {
            //Получаем список кодов
            dayCodes = DayCodeCRUD.Get();
            calendar = CalendarCRUD.Get(selectYear, selectMonth);
            //Получаем табель
            dgvRC.DataSource = ReportCRUD.Get(
                selectYear,
                selectMonth,
                ((DepartmentDTO)lbDep.SelectedItem).DepId,
                !canChangeReportCard ? sEmp.EmpId : -1)
                .GetDataTable();
            //Форматируем таблицу
            //FormatWorkDataColumns();
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            //Обновляем таблицу по новому фильтру
            GetData();
        }

        private void dgvRC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Добавляем всплывающую подсказку для заполненной ячеки
            var cell = dgvRC.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (e.ColumnIndex > 2 && !string.IsNullOrEmpty(cell.Value.ToString()))
                cell.ToolTipText = dayCodes.First(f => f.CodeId == cell.Value.ToString()).Description;
        }

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

        private void dgvRC_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex != -1 && e.ColumnIndex > 2)
            {
                //Запоминаем ячейку, на которой сделали ПКМ и выбираем ее
                clickedCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (!clickedCell.Selected)
                {
                    clickedCell.DataGridView.ClearSelection();
                    clickedCell.DataGridView.CurrentCell = clickedCell;
                    clickedCell.Selected = true;
                }
            }
        }

        private void tsbDepUpdate_Click(object sender, EventArgs e)
        {
            //Обновляем департаменты
            LoadDepartment();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            var frm = new frmLogin();
            frm.Owner = this;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                sEmp = frm.SelectEmp;
                canChangeReportCard = sEmp.Post == "Табельщик" && sEmp.DepId == 1;
                ms.Visible = sEmp.DepId == 1;
                LoadDepartment();
                sc.Visible = true;
            }
            else
                Close();
        }
        /// <summary>
        /// Загружаем департаменты
        /// </summary>
        void LoadDepartment()
        {
            if (sEmp.DepId == 1)
                lbDep.DataSource = DepartmentCRUD.Get();
            else
                lbDep.DataSource = new List<DepartmentDTO>() { DepartmentCRUD.GetById(sEmp.DepId) };
            lbDep.SelectedIndex = 0;
        }

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
                column.ContextMenuStrip = cms;
                #region Разукрашиваем в зависимости от дня недели и праздников
                var day = new DateTime(selectYear, selectMonth, Convert.ToInt32(column.HeaderText));
                var c = calendar.FirstOrDefault(f => f.HDay == day);
                if ((day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday))
                {
                    if (c != null && c.DayType == 2)
                        column.DefaultCellStyle.BackColor = Color.Orange;
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
                        column.DefaultCellStyle.BackColor = Color.Orange;
                    else if (c != null && c.DayType == 1)
                        column.DefaultCellStyle.BackColor = Color.LightPink;

                }
            }
            #endregion
        }
    }
}

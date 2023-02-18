using MySqlConnector;
using ReportCard.CRUD;
using ReportCard.DTOModels;
using ReportCard.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportCard
{
    public partial class frmCalendars : Form
    {
        bool IsEdit = false;
        public frmCalendars()
        {
            InitializeComponent();
            LoadData();

        }

        private void LoadData()
        {
            tscbYear.ComboBox.DataSource = CalendarCRUD.GetYears();
            if (tscbYear.ComboBox.Items.Count != 0)
                tscbYear.ComboBox.SelectedIndex = 0;
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            //Отображаем кнопки редактирования и удаления, если выбрана строка
            tsbEdit.Visible = tsbDel.Visible = dgv.SelectedRows.Count != 0;
        }
        private void tsbAddEdit_Click(object sender, EventArgs e)
        {
            IsEdit = ((ToolStripButton)sender).Name.Contains("Edit");
            dtp.Enabled = !IsEdit;
            if (IsEdit)
            {
                dtp.Value = (DateTime)dgv.SelectedRows[0].Cells["HDay"].Value;
                nudType.Value = Convert.ToDecimal(dgv.SelectedRows[0].Cells["DayType"].Value);
            }
            else
            {
                dtp.Value = DateTime.Now;
                nudType.Value = 1.0m;
            }
            pnlInfo.Visible = true;
            tsMenu.Visible = false;
            dgv.Enabled = false;
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить выбранную дату?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    CalendarCRUD.Remove((DateTime)dgv.SelectedRows[0].Cells["HDay"].Value);
                    dgv.DataSource = CalendarCRUD.Get((int)tscbYear.SelectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ((dtp.Value.DayOfWeek != DayOfWeek.Saturday && dtp.Value.DayOfWeek != DayOfWeek.Sunday) && nudType.Value == 3)
                {
                    MessageBox.Show("Тип даты 3 совместим только с выходными днями","Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                    if (!IsEdit)
                    CalendarCRUD.Add(new CalendarDTO() { HDay = dtp.Value, DayType = (sbyte)nudType.Value });
                else
                    CalendarCRUD.Update(new CalendarDTO() { HDay = dtp.Value, DayType = (sbyte)nudType.Value });

                dgv.DataSource = CalendarCRUD.Get((int)tscbYear.SelectedItem);
                pnlInfo.Visible = false;
                tsMenu.Visible = true;
                dgv.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IsEdit ? "Редактирование" : "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlInfo.Visible = false;
            tsMenu.Visible = true;
            dgv.Enabled = true;
        }

        private void tscbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Загружаем данные из БД в GridView
            dgv.DataSource = CalendarCRUD.Get((int)tscbYear.SelectedItem);
        }

        private void tsbFromFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "XML-файл (*.xml)|*.xml";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        CalendarCRUD.LoadFromFile(CalendarLoader.GetCalendar(ofd.FileName));
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не удалось прочитать файл. Ошибка\n\n{ex.Message}", "Загрузка календаря", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

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
    public partial class frmDayCodes : Form
    {
        bool IsEdit = false;
        public frmDayCodes()
        {
            InitializeComponent();
            //Загружаем данные из БД в GridView
            dgv.DataSource = DayCodeCRUD.Get();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            //Отображаем кнопки редактирования и удаления, если выбрана строка
            tsbEdit.Visible = tsbDel.Visible = dgv.SelectedRows.Count != 0;
        }
        private void tsbAddEdit_Click(object sender, EventArgs e)
        {
            IsEdit = ((ToolStripButton)sender).Name.Contains("Edit");
            
            if (IsEdit)
            {
                tbCode.Text = dgv.SelectedRows[0].Cells["CodeId"].Value.ToString();
                tbName.Text = dgv.SelectedRows[0].Cells["Descr"].Value.ToString();
            }
            else
            {
                tbCode.Text = "";
                tbName.Text = "";
            }
            pnlInfo.Visible = true;
            tsMenu.Visible = false;
            dgv.Enabled = false;
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить выбранную кодировку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DayCodeCRUD.Remove(dgv.SelectedRows[0].Cells["CodeId"].Value.ToString());
                    dgv.DataSource = DayCodeCRUD.Get();
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
                if (tbCode.TextLength == 0)
                {
                    MessageBox.Show("Поле Код не должно быть пустым", (IsEdit ? "Редактирование" : "Добавление"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DayCodeCRUD.AddOrUpdate(new DayCodeDTO() { CodeId = tbCode.Text, Description = tbName.Text }, (IsEdit ? dgv.SelectedRows[0].Cells["CodeId"].Value.ToString() : ""));

                dgv.DataSource = DayCodeCRUD.Get();
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


    }
}

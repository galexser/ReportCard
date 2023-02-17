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
    public partial class frmDepartments : Form
    {
        DataSet myDS;
        MySqlDataAdapter myDA;
        bool IsEdit = false;
        public frmDepartments()
        {
            InitializeComponent();
            //Загружаем данные из БД в GridView
            bsDep.DataSource = DepartmentCRUD.Get();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            //Отображаем кнопки редактирования и удаления, если выбрана строка
            tsbEdit.Visible = tsbDel.Visible = dgvDep.SelectedRows.Count != 0;
        }
        private void tsbAddEdit_Click(object sender, EventArgs e)
        {
            IsEdit = ((ToolStripButton)sender).Name.Contains("Edit");
            if (IsEdit)
                tbName.Text = dgvDep.SelectedRows[0].Cells["name"].Value.ToString();
            else
                tbName.Text = "";
            pnlInfo.Visible = true;
            tsDep.Visible = false;
            dgvDep.Enabled = false;
        }
        
        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить выбранный департамент?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DepartmentCRUD.Remove((int)dgvDep.SelectedRows[0].Cells["DepId"].Value);
                    bsDep.DataSource = DepartmentCRUD.Get();
                    dgvDep.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                dgvDep.Update();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsEdit)
                    DepartmentCRUD.Add(tbName.Text);
                else
                {
                    DepartmentCRUD.Update(new DepartmentDTO() { DepId = (int)dgvDep.SelectedRows[0].Cells["DepId"].Value , Name = tbName.Text});
                }
                bsDep.DataSource = DepartmentCRUD.Get();
                dgvDep.Update();
                pnlInfo.Visible = false;
                tsDep.Visible = true;
                dgvDep.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IsEdit ? "Редактирование" : "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlInfo.Visible = false;
            tsDep.Visible = true;
            dgvDep.Enabled = true;
        }

        
    }
}

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
    public partial class frmEmployees : Form
    {
        bool IsEdit = false;
        public frmEmployees()
        {
            InitializeComponent();
            //Загружаем данные из БД в GridView
            bsData.DataSource = EmployeeCRUD.Get();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            //Отображаем кнопки редактирования и удаления, если выбрана строка
            tsbEdit.Visible = tsbDel.Visible = dgvEmp.SelectedRows.Count != 0;
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            IsEdit = ((ToolStripButton)sender).Name.Contains("Edit");
            cbDepartment.DataSource = DepartmentCRUD.Get();
            if (IsEdit)
            {
                var row = dgvEmp.SelectedRows[0];
                tbLastName.Text = row.Cells["LastName"].Value.ToString();
                tbFirstName.Text = row.Cells["FirstName"].Value.ToString();
                tbMiddleName.Text = row.Cells["MiddleName"].Value.ToString();
                tbAddress.Text = row.Cells["Address"].Value.ToString();
                tbPost.Text = row.Cells["Post"].Value.ToString();
                chbRemoteWork.Checked = row.Cells["RemoteWork"].Value.ToString() == "1";
                dtpBirthDay.Value = Convert.ToDateTime(row.Cells["BirthDay"].Value.ToString());
            }
            else
            {
                tbLastName.Text = tbFirstName.Text = tbMiddleName.Text = tbAddress.Text = tbPost.Text = "";
                chbRemoteWork.Checked = false;
                dtpBirthDay.Value = DateTime.Now.AddYears(-10);
            }

            pnlInfo.Visible = true;
            tsEmp.Visible = false;
            dgvEmp.Enabled = false;
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить выбранного сотрудника?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    EmployeeCRUD.Remove((int)dgvEmp.SelectedRows[0].Cells["EmpId"].Value);
                    bsData.DataSource = EmployeeCRUD.Get();
                    dgvEmp.Update();
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
                var emp = new EmployeeDTO()
                {
                    LastName = tbLastName.Text,
                    FirstName = tbFirstName.Text,
                    MiddleName = tbMiddleName.Text,
                    Address = tbAddress.Text,
                    Post = tbPost.Text,
                    DepId = Convert.ToInt32(cbDepartment.SelectedValue),
                    Department = cbDepartment.SelectedText,
                    RemoteWork = chbRemoteWork.Checked ? 1 : 0,
                    BirthDay = dtpBirthDay.Value
                };
                if (!IsEdit)
                    EmployeeCRUD.Add(emp);
                else
                {
                    emp.EmpId = (int)dgvEmp.SelectedRows[0].Cells["EmpId"].Value;
                    EmployeeCRUD.Update(emp);
                }
                bsData.DataSource = EmployeeCRUD.Get();
                dgvEmp.Update();
                pnlInfo.Visible = false;
                tsEmp.Visible = true;
                dgvEmp.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IsEdit ? "Редактирование" : "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlInfo.Visible = false;
            tsEmp.Visible = true;
            dgvEmp.Enabled = true;
        }
    }
}

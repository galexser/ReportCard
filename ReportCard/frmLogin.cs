using ReportCard.CRUD;
using ReportCard.DTOModels;
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
    public partial class frmLogin : Form
    {
        public EmployeeDTO SelectEmp { get { return (EmployeeDTO)cbEmployees.SelectedItem; } }
        public frmLogin()
        {
            InitializeComponent();
            cbEmployees.DataSource = EmployeeCRUD.Get();
            cbEmployees.ValueMember = "EmpId";
            cbEmployees.DisplayMember = "EmployeeShortInfo";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnLogIN_Click(object sender, EventArgs e)
        {
            if (cbEmployees.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран пользователь", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }    
              
        }
    }
}

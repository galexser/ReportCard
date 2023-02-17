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
    public partial class frmAddDayCode : Form
    {
        public DateTime editDay { get; set; }
        public string CodeId { get { return ((DayCodeDTO)cbDayCode.SelectedItem).CodeId; } }
        public frmAddDayCode(string fio, DateTime day, string dayCode = "")
        {
            InitializeComponent();
            editDay = day;
            var dc = DayCodeCRUD.Get();
            lblEmp.Text = fio;
            lblDate.Text = day.ToShortDateString();
            cbDayCode.Items.AddRange(dc.ToArray());
            if (!string.IsNullOrEmpty(dayCode))
                cbDayCode.SelectedIndex = cbDayCode.FindStringExact(dc.First(f => f.CodeId == dayCode).ToString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

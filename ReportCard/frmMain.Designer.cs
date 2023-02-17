namespace ReportCard
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ms = new System.Windows.Forms.MenuStrip();
            this.tsmiDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEmployees = new System.Windows.Forms.ToolStripMenuItem();
            this.gbDep = new System.Windows.Forms.GroupBox();
            this.lbDep = new System.Windows.Forms.ListBox();
            this.sc = new System.Windows.Forms.SplitContainer();
            this.dgvRC = new System.Windows.Forms.DataGridView();
            this.EmpId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Post = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ss = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsReport = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscbYear = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tscbMonth = new System.Windows.Forms.ToolStripComboBox();
            this.tsDep = new System.Windows.Forms.ToolStrip();
            this.tsbDepUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsbReportUpdate = new System.Windows.Forms.ToolStripButton();
            this.ms.SuspendLayout();
            this.gbDep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc)).BeginInit();
            this.sc.Panel1.SuspendLayout();
            this.sc.Panel2.SuspendLayout();
            this.sc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRC)).BeginInit();
            this.cms.SuspendLayout();
            this.ss.SuspendLayout();
            this.tsReport.SuspendLayout();
            this.tsDep.SuspendLayout();
            this.SuspendLayout();
            // 
            // ms
            // 
            this.ms.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDepartment,
            this.tsmiEmployees});
            this.ms.Location = new System.Drawing.Point(0, 0);
            this.ms.Name = "ms";
            this.ms.Size = new System.Drawing.Size(1008, 29);
            this.ms.TabIndex = 0;
            this.ms.Text = "menuStrip1";
            this.ms.Visible = false;
            // 
            // tsmiDepartment
            // 
            this.tsmiDepartment.Name = "tsmiDepartment";
            this.tsmiDepartment.Size = new System.Drawing.Size(172, 25);
            this.tsmiDepartment.Text = "Справочник отделов";
            this.tsmiDepartment.Click += new System.EventHandler(this.tsmiDepartment_Click);
            // 
            // tsmiEmployees
            // 
            this.tsmiEmployees.Name = "tsmiEmployees";
            this.tsmiEmployees.Size = new System.Drawing.Size(206, 25);
            this.tsmiEmployees.Text = "Справочник сотрудников";
            this.tsmiEmployees.Click += new System.EventHandler(this.tsmiEmployees_Click);
            // 
            // gbDep
            // 
            this.gbDep.Controls.Add(this.lbDep);
            this.gbDep.Controls.Add(this.tsDep);
            this.gbDep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbDep.Location = new System.Drawing.Point(0, 0);
            this.gbDep.Name = "gbDep";
            this.gbDep.Size = new System.Drawing.Size(289, 450);
            this.gbDep.TabIndex = 1;
            this.gbDep.TabStop = false;
            this.gbDep.Text = "Департаменты";
            // 
            // lbDep
            // 
            this.lbDep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDep.FormattingEnabled = true;
            this.lbDep.ItemHeight = 20;
            this.lbDep.Location = new System.Drawing.Point(3, 47);
            this.lbDep.Name = "lbDep";
            this.lbDep.Size = new System.Drawing.Size(283, 400);
            this.lbDep.TabIndex = 0;
            this.lbDep.SelectedIndexChanged += new System.EventHandler(this.lbDep_SelectedIndexChanged);
            // 
            // sc
            // 
            this.sc.BackColor = System.Drawing.Color.LightGray;
            this.sc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc.Location = new System.Drawing.Point(0, 0);
            this.sc.Name = "sc";
            // 
            // sc.Panel1
            // 
            this.sc.Panel1.Controls.Add(this.gbDep);
            // 
            // sc.Panel2
            // 
            this.sc.Panel2.Controls.Add(this.dgvRC);
            this.sc.Panel2.Controls.Add(this.ss);
            this.sc.Panel2.Controls.Add(this.tsReport);
            this.sc.Size = new System.Drawing.Size(1008, 450);
            this.sc.SplitterDistance = 289;
            this.sc.SplitterWidth = 8;
            this.sc.TabIndex = 2;
            this.sc.Visible = false;
            // 
            // dgvRC
            // 
            this.dgvRC.AllowUserToAddRows = false;
            this.dgvRC.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRC.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRC.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRC.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmpId,
            this.FIO,
            this.Post});
            this.dgvRC.ContextMenuStrip = this.cms;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRC.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRC.Location = new System.Drawing.Point(0, 27);
            this.dgvRC.Name = "dgvRC";
            this.dgvRC.ReadOnly = true;
            this.dgvRC.RowHeadersVisible = false;
            this.dgvRC.Size = new System.Drawing.Size(711, 396);
            this.dgvRC.TabIndex = 0;
            this.dgvRC.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRC_CellFormatting);
            this.dgvRC.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRC_CellMouseDown);
            this.dgvRC.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvRC_ColumnAdded);
            // 
            // EmpId
            // 
            this.EmpId.DataPropertyName = "EmpId";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EmpId.DefaultCellStyle = dataGridViewCellStyle3;
            this.EmpId.Frozen = true;
            this.EmpId.HeaderText = "Учетный номер";
            this.EmpId.MinimumWidth = 100;
            this.EmpId.Name = "EmpId";
            this.EmpId.ReadOnly = true;
            // 
            // FIO
            // 
            this.FIO.DataPropertyName = "FIO";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FIO.DefaultCellStyle = dataGridViewCellStyle4;
            this.FIO.Frozen = true;
            this.FIO.HeaderText = "Сотрудник";
            this.FIO.MinimumWidth = 100;
            this.FIO.Name = "FIO";
            this.FIO.ReadOnly = true;
            // 
            // Post
            // 
            this.Post.DataPropertyName = "Post";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Post.DefaultCellStyle = dataGridViewCellStyle5;
            this.Post.Frozen = true;
            this.Post.HeaderText = "Должность";
            this.Post.MinimumWidth = 100;
            this.Post.Name = "Post";
            this.Post.ReadOnly = true;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiEdit});
            this.cms.Name = "contextMenuStrip1";
            this.cms.Size = new System.Drawing.Size(155, 26);
            // 
            // cmsiEdit
            // 
            this.cmsiEdit.Name = "cmsiEdit";
            this.cmsiEdit.Size = new System.Drawing.Size(154, 22);
            this.cmsiEdit.Text = "Редактировать";
            this.cmsiEdit.Click += new System.EventHandler(this.cmsiEdit_Click);
            // 
            // ss
            // 
            this.ss.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.ss.Location = new System.Drawing.Point(0, 423);
            this.ss.Name = "ss";
            this.ss.Size = new System.Drawing.Size(711, 27);
            this.ss.TabIndex = 2;
            this.ss.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(82, 22);
            this.toolStripStatusLabel1.Text = "Выходной";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.Yellow;
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(143, 22);
            this.toolStripStatusLabel2.Text = "Предпраздничный";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.Color.LightPink;
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(183, 22);
            this.toolStripStatusLabel3.Text = "Праздничный выходной";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BackColor = System.Drawing.Color.LightGreen;
            this.toolStripStatusLabel4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(177, 22);
            this.toolStripStatusLabel4.Text = "Рабочий перенесенный";
            // 
            // tsReport
            // 
            this.tsReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tscbYear,
            this.toolStripLabel2,
            this.tscbMonth,
            this.tsbReportUpdate});
            this.tsReport.Location = new System.Drawing.Point(0, 0);
            this.tsReport.Name = "tsReport";
            this.tsReport.Size = new System.Drawing.Size(711, 27);
            this.tsReport.TabIndex = 1;
            this.tsReport.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(34, 24);
            this.toolStripLabel1.Text = "Год";
            // 
            // tscbYear
            // 
            this.tscbYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tscbYear.Name = "tscbYear";
            this.tscbYear.Size = new System.Drawing.Size(121, 27);
            this.tscbYear.SelectedIndexChanged += new System.EventHandler(this.tscbYear_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(54, 24);
            this.toolStripLabel2.Text = "Месяц";
            // 
            // tscbMonth
            // 
            this.tscbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbMonth.Items.AddRange(new object[] {
            "01-Январь",
            "02-Февраль",
            "03-Март",
            "04-Апрель",
            "05-Май",
            "06-Июнь",
            "07-Июль",
            "08-Август",
            "09-Сентябрь",
            "10-Октябрь",
            "11-Ноябрь",
            "12-Декабрь"});
            this.tscbMonth.Name = "tscbMonth";
            this.tscbMonth.Size = new System.Drawing.Size(121, 27);
            this.tscbMonth.SelectedIndexChanged += new System.EventHandler(this.tscbMonth_SelectedIndexChanged);
            // 
            // tsDep
            // 
            this.tsDep.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDepUpdate});
            this.tsDep.Location = new System.Drawing.Point(3, 22);
            this.tsDep.Name = "tsDep";
            this.tsDep.Size = new System.Drawing.Size(283, 25);
            this.tsDep.TabIndex = 1;
            this.tsDep.Text = "toolStrip1";
            // 
            // tsbDepUpdate
            // 
            this.tsbDepUpdate.Image = global::ReportCard.Properties.Resources.update;
            this.tsbDepUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDepUpdate.Name = "tsbDepUpdate";
            this.tsbDepUpdate.Size = new System.Drawing.Size(123, 22);
            this.tsbDepUpdate.Text = "Обновить список";
            this.tsbDepUpdate.Click += new System.EventHandler(this.tsbDepUpdate_Click);
            // 
            // tsbReportUpdate
            // 
            this.tsbReportUpdate.Image = global::ReportCard.Properties.Resources.update;
            this.tsbReportUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReportUpdate.Name = "tsbReportUpdate";
            this.tsbReportUpdate.Size = new System.Drawing.Size(121, 24);
            this.tsbReportUpdate.Text = "Обновить табель";
            this.tsbReportUpdate.Click += new System.EventHandler(this.tsbUpdate_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 450);
            this.Controls.Add(this.sc);
            this.Controls.Add(this.ms);
            this.MainMenuStrip = this.ms;
            this.Name = "frmMain";
            this.Text = "Производственный каледнарь";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.ms.ResumeLayout(false);
            this.ms.PerformLayout();
            this.gbDep.ResumeLayout(false);
            this.gbDep.PerformLayout();
            this.sc.Panel1.ResumeLayout(false);
            this.sc.Panel2.ResumeLayout(false);
            this.sc.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc)).EndInit();
            this.sc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRC)).EndInit();
            this.cms.ResumeLayout(false);
            this.ss.ResumeLayout(false);
            this.ss.PerformLayout();
            this.tsReport.ResumeLayout(false);
            this.tsReport.PerformLayout();
            this.tsDep.ResumeLayout(false);
            this.tsDep.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ms;
        private System.Windows.Forms.ToolStripMenuItem tsmiDepartment;
        private System.Windows.Forms.ToolStripMenuItem tsmiEmployees;
        private System.Windows.Forms.GroupBox gbDep;
        private System.Windows.Forms.ListBox lbDep;
        private System.Windows.Forms.SplitContainer sc;
        private System.Windows.Forms.DataGridView dgvRC;
        private System.Windows.Forms.ToolStrip tsReport;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tscbYear;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox tscbMonth;
        private System.Windows.Forms.ToolStripButton tsbReportUpdate;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Post;
        private System.Windows.Forms.StatusStrip ss;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripMenuItem cmsiEdit;
        private System.Windows.Forms.ToolStrip tsDep;
        private System.Windows.Forms.ToolStripButton tsbDepUpdate;
    }
}


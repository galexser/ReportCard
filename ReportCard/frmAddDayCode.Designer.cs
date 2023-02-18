
namespace ReportCard
{
    partial class frmAddDayCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblEmp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDayCode = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tlp.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp
            // 
            this.tlp.ColumnCount = 2;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlp.Controls.Add(this.label5, 0, 2);
            this.tlp.Controls.Add(this.label4, 0, 1);
            this.tlp.Controls.Add(this.lblDate, 1, 1);
            this.tlp.Controls.Add(this.lblEmp, 1, 0);
            this.tlp.Controls.Add(this.label1, 0, 0);
            this.tlp.Controls.Add(this.cbDayCode, 1, 2);
            this.tlp.Controls.Add(this.panel1, 1, 3);
            this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp.Location = new System.Drawing.Point(0, 0);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 4;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp.Size = new System.Drawing.Size(346, 208);
            this.tlp.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 110);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label5.Size = new System.Drawing.Size(97, 47);
            this.label5.TabIndex = 5;
            this.label5.Text = "Код";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 47);
            this.label4.TabIndex = 4;
            this.label4.Text = "Дата";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDate.Location = new System.Drawing.Point(106, 63);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(237, 47);
            this.lblDate.TabIndex = 3;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmp
            // 
            this.lblEmp.AutoSize = true;
            this.lblEmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEmp.Location = new System.Drawing.Point(106, 0);
            this.lblEmp.Name = "lblEmp";
            this.lblEmp.Size = new System.Drawing.Size(237, 63);
            this.lblEmp.TabIndex = 2;
            this.lblEmp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 63);
            this.label1.TabIndex = 1;
            this.label1.Text = "Сотрудник";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbDayCode
            // 
            this.cbDayCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDayCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDayCode.DropDownWidth = 500;
            this.cbDayCode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbDayCode.FormattingEnabled = true;
            this.cbDayCode.Location = new System.Drawing.Point(106, 113);
            this.cbDayCode.Name = "cbDayCode";
            this.cbDayCode.Size = new System.Drawing.Size(237, 27);
            this.cbDayCode.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(106, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 45);
            this.panel1.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Location = new System.Drawing.Point(128, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 33);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Location = new System.Drawing.Point(22, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 33);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAddDayCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 208);
            this.ControlBox = false;
            this.Controls.Add(this.tlp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddDayCode";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование табеля";
            this.tlp.ResumeLayout(false);
            this.tlp.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblEmp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDayCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}
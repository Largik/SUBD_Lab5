
namespace JournalView
{
    partial class FormMark
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
            this.comboBoxDiscipline = new System.Windows.Forms.ComboBox();
            this.cbTeacher = new System.Windows.Forms.ComboBox();
            this.lbTeacher = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDiscipline = new System.Windows.Forms.Label();
            this.lbMark = new System.Windows.Forms.Label();
            this.maskedTextBoxMark = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // comboBoxDiscipline
            // 
            this.comboBoxDiscipline.FormattingEnabled = true;
            this.comboBoxDiscipline.Location = new System.Drawing.Point(167, 47);
            this.comboBoxDiscipline.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxDiscipline.Name = "comboBoxDiscipline";
            this.comboBoxDiscipline.Size = new System.Drawing.Size(249, 24);
            this.comboBoxDiscipline.TabIndex = 53;
            // 
            // cbTeacher
            // 
            this.cbTeacher.FormattingEnabled = true;
            this.cbTeacher.Location = new System.Drawing.Point(167, 80);
            this.cbTeacher.Margin = new System.Windows.Forms.Padding(4);
            this.cbTeacher.Name = "cbTeacher";
            this.cbTeacher.Size = new System.Drawing.Size(249, 24);
            this.cbTeacher.TabIndex = 52;
            // 
            // lbTeacher
            // 
            this.lbTeacher.AutoSize = true;
            this.lbTeacher.Location = new System.Drawing.Point(19, 80);
            this.lbTeacher.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTeacher.Name = "lbTeacher";
            this.lbTeacher.Size = new System.Drawing.Size(112, 16);
            this.lbTeacher.TabIndex = 51;
            this.lbTeacher.Text = "Студент";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(318, 133);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(167, 133);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDiscipline
            // 
            this.lblDiscipline.AutoSize = true;
            this.lblDiscipline.Location = new System.Drawing.Point(19, 48);
            this.lblDiscipline.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiscipline.Name = "lblDiscipline";
            this.lblDiscipline.Size = new System.Drawing.Size(88, 16);
            this.lblDiscipline.TabIndex = 45;
            this.lblDiscipline.Text = "Дисциплина";
            // 
            // lbMark
            // 
            this.lbMark.AutoSize = true;
            this.lbMark.Location = new System.Drawing.Point(19, 17);
            this.lbMark.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMark.Name = "lbMark";
            this.lbMark.Size = new System.Drawing.Size(57, 16);
            this.lbMark.TabIndex = 42;
            this.lbMark.Text = "Оценка";
            // 
            // maskedTextBoxMark
            // 
            this.maskedTextBoxMark.Location = new System.Drawing.Point(167, 14);
            this.maskedTextBoxMark.Mask = "00000";
            this.maskedTextBoxMark.Name = "maskedTextBoxMark";
            this.maskedTextBoxMark.Size = new System.Drawing.Size(249, 22);
            this.maskedTextBoxMark.TabIndex = 54;
            this.maskedTextBoxMark.ValidatingType = typeof(int);
            // 
            // FormMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 183);
            this.Controls.Add(this.maskedTextBoxMark);
            this.Controls.Add(this.comboBoxDiscipline);
            this.Controls.Add(this.cbTeacher);
            this.Controls.Add(this.lbTeacher);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDiscipline);
            this.Controls.Add(this.lbMark);
            this.Name = "FormMark";
            this.Text = "Выставить оценку";
            this.Load += new System.EventHandler(this.FormUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDiscipline;
        private System.Windows.Forms.ComboBox cbTeacher;
        private System.Windows.Forms.Label lbTeacher;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDiscipline;
        private System.Windows.Forms.Label lbMark;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxMark;
    }
}
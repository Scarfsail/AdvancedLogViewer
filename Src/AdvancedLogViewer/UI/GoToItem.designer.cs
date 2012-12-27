namespace AdvancedLogViewer.UI
{
    partial class GoToItem
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.itemNumberUpDown = new System.Windows.Forms.NumericUpDown();
            this.selectItemRadioButton = new System.Windows.Forms.RadioButton();
            this.selectDateTimeRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimeEdit = new Scarfsail.Common.UI.Controls.DateTimeEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.itemNumberUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(111, 7);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(76, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(28, 7);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(76, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // itemNumberUpDown
            // 
            this.itemNumberUpDown.Location = new System.Drawing.Point(29, 29);
            this.itemNumberUpDown.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.itemNumberUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.itemNumberUpDown.Name = "itemNumberUpDown";
            this.itemNumberUpDown.Size = new System.Drawing.Size(159, 20);
            this.itemNumberUpDown.TabIndex = 0;
            this.itemNumberUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.itemNumberUpDown.Enter += new System.EventHandler(this.itemNumberUpDown_Enter);
            // 
            // selectItemRadioButton
            // 
            this.selectItemRadioButton.AutoSize = true;
            this.selectItemRadioButton.Checked = true;
            this.selectItemRadioButton.Location = new System.Drawing.Point(9, 6);
            this.selectItemRadioButton.Name = "selectItemRadioButton";
            this.selectItemRadioButton.Size = new System.Drawing.Size(86, 17);
            this.selectItemRadioButton.TabIndex = 5;
            this.selectItemRadioButton.TabStop = true;
            this.selectItemRadioButton.Text = "Item number:";
            this.selectItemRadioButton.UseVisualStyleBackColor = true;
            // 
            // selectDateTimeRadioButton
            // 
            this.selectDateTimeRadioButton.AutoSize = true;
            this.selectDateTimeRadioButton.Location = new System.Drawing.Point(9, 62);
            this.selectDateTimeRadioButton.Name = "selectDateTimeRadioButton";
            this.selectDateTimeRadioButton.Size = new System.Drawing.Size(73, 17);
            this.selectDateTimeRadioButton.TabIndex = 6;
            this.selectDateTimeRadioButton.Text = "Date time:";
            this.selectDateTimeRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(29, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Go to nearest greater date";
            // 
            // dateTimeEdit
            // 
            this.dateTimeEdit.Location = new System.Drawing.Point(28, 84);
            this.dateTimeEdit.Name = "dateTimeEdit";
            this.dateTimeEdit.Size = new System.Drawing.Size(160, 20);
            this.dateTimeEdit.TabIndex = 8;
            this.dateTimeEdit.Enter += new System.EventHandler(this.dateTimeEdit_Enter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 40);
            this.panel1.TabIndex = 9;
            // 
            // GoToItem
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(196, 169);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dateTimeEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectDateTimeRadioButton);
            this.Controls.Add(this.selectItemRadioButton);
            this.Controls.Add(this.itemNumberUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoToItem";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Go to item";
            ((System.ComponentModel.ISupportInitialize)(this.itemNumberUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.NumericUpDown itemNumberUpDown;
        private System.Windows.Forms.RadioButton selectItemRadioButton;
        private System.Windows.Forms.RadioButton selectDateTimeRadioButton;
        private System.Windows.Forms.Label label1;
        private Scarfsail.Common.UI.Controls.DateTimeEdit dateTimeEdit;
        private System.Windows.Forms.Panel panel1;
    }
}
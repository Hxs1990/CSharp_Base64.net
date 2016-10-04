namespace WinFormTest
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmdFileChose = new System.Windows.Forms.Button();
            this.cmdMIMEcode = new System.Windows.Forms.Button();
            this.cmdMIMEdecode = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 49);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(332, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsLabel
            // 
            this.tsLabel.Name = "tsLabel";
            this.tsLabel.Size = new System.Drawing.Size(118, 17);
            this.tsLabel.Text = "toolStripStatusLabel1";
            // 
            // cmdFileChose
            // 
            this.cmdFileChose.Location = new System.Drawing.Point(21, 12);
            this.cmdFileChose.Name = "cmdFileChose";
            this.cmdFileChose.Size = new System.Drawing.Size(92, 34);
            this.cmdFileChose.TabIndex = 1;
            this.cmdFileChose.Text = "Select File";
            this.cmdFileChose.UseVisualStyleBackColor = true;
            this.cmdFileChose.Click += new System.EventHandler(this.cmdFileChose_Click);
            // 
            // cmdMIMEcode
            // 
            this.cmdMIMEcode.Location = new System.Drawing.Point(119, 12);
            this.cmdMIMEcode.Name = "cmdMIMEcode";
            this.cmdMIMEcode.Size = new System.Drawing.Size(81, 34);
            this.cmdMIMEcode.TabIndex = 2;
            this.cmdMIMEcode.Text = "Code to Base64";
            this.cmdMIMEcode.UseVisualStyleBackColor = true;
            this.cmdMIMEcode.Click += new System.EventHandler(this.cmdMIMEcode_Click);
            // 
            // cmdMIMEdecode
            // 
            this.cmdMIMEdecode.Location = new System.Drawing.Point(206, 12);
            this.cmdMIMEdecode.Name = "cmdMIMEdecode";
            this.cmdMIMEdecode.Size = new System.Drawing.Size(87, 34);
            this.cmdMIMEdecode.TabIndex = 3;
            this.cmdMIMEdecode.Text = "Decode From Base64";
            this.cmdMIMEdecode.UseVisualStyleBackColor = true;
            this.cmdMIMEdecode.Click += new System.EventHandler(this.cmdMIMEdecode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 71);
            this.Controls.Add(this.cmdMIMEdecode);
            this.Controls.Add(this.cmdMIMEcode);
            this.Controls.Add(this.cmdFileChose);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Base64.NET";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsLabel;
        private System.Windows.Forms.Button cmdFileChose;
        private System.Windows.Forms.Button cmdMIMEcode;
        private System.Windows.Forms.Button cmdMIMEdecode;

        
    }
}


namespace Chatix
{
    partial class Form1
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
            this.richTextBoxDialog = new System.Windows.Forms.RichTextBox();
            this.richTextBoxMsg = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // richTextBoxDialog
            // 
            this.richTextBoxDialog.Location = new System.Drawing.Point(24, 47);
            this.richTextBoxDialog.Name = "richTextBoxDialog";
            this.richTextBoxDialog.Size = new System.Drawing.Size(427, 182);
            this.richTextBoxDialog.TabIndex = 2;
            this.richTextBoxDialog.Text = "";
            // 
            // richTextBoxMsg
            // 
            this.richTextBoxMsg.Location = new System.Drawing.Point(24, 261);
            this.richTextBoxMsg.Name = "richTextBoxMsg";
            this.richTextBoxMsg.Size = new System.Drawing.Size(402, 53);
            this.richTextBoxMsg.TabIndex = 6;
            this.richTextBoxMsg.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(432, 261);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 53);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(24, 21);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(100, 20);
            this.textUsername.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.richTextBoxMsg);
            this.Controls.Add(this.richTextBoxDialog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBoxDialog;
        private System.Windows.Forms.RichTextBox richTextBoxMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox textUsername;
    }
}


namespace WarehouseApp
{
    partial class AddEditProductForm
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
            cbSupplier2 = new ComboBox();
            cbCategory2 = new ComboBox();
            textBoxName = new TextBox();
            textBoxCostPrice = new TextBox();
            textBoxQuantity = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            BtnSave = new Button();
            BtnCancel = new Button();
            label6 = new Label();
            dtpSupplyDate = new DateTimePicker();
            SuspendLayout();
            // 
            // cbSupplier2
            // 
            cbSupplier2.FormattingEnabled = true;
            cbSupplier2.Location = new Point(102, 247);
            cbSupplier2.Margin = new Padding(3, 4, 3, 4);
            cbSupplier2.Name = "cbSupplier2";
            cbSupplier2.Size = new Size(164, 28);
            cbSupplier2.TabIndex = 2;
            // 
            // cbCategory2
            // 
            cbCategory2.FormattingEnabled = true;
            cbCategory2.Location = new Point(102, 151);
            cbCategory2.Margin = new Padding(3, 4, 3, 4);
            cbCategory2.Name = "cbCategory2";
            cbCategory2.Size = new Size(164, 28);
            cbCategory2.TabIndex = 1;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(14, 55);
            textBoxName.Margin = new Padding(3, 4, 3, 4);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(341, 27);
            textBoxName.TabIndex = 0;
            // 
            // textBoxCostPrice
            // 
            textBoxCostPrice.Location = new Point(102, 439);
            textBoxCostPrice.Margin = new Padding(3, 4, 3, 4);
            textBoxCostPrice.Name = "textBoxCostPrice";
            textBoxCostPrice.Size = new Size(164, 27);
            textBoxCostPrice.TabIndex = 3;
            // 
            // textBoxQuantity
            // 
            textBoxQuantity.Location = new Point(102, 343);
            textBoxQuantity.Margin = new Padding(3, 4, 3, 4);
            textBoxQuantity.Name = "textBoxQuantity";
            textBoxQuantity.Size = new Size(164, 27);
            textBoxQuantity.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(14, 17);
            label1.Name = "label1";
            label1.Size = new Size(101, 32);
            label1.TabIndex = 6;
            label1.Text = "Product:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(102, 113);
            label2.Name = "label2";
            label2.Size = new Size(115, 32);
            label2.TabIndex = 7;
            label2.Text = "Category:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(102, 209);
            label3.Name = "label3";
            label3.Size = new Size(107, 32);
            label3.TabIndex = 8;
            label3.Text = "Supplier:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(102, 401);
            label4.Name = "label4";
            label4.Size = new Size(125, 32);
            label4.TabIndex = 9;
            label4.Text = "Cost price:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(102, 305);
            label5.Name = "label5";
            label5.Size = new Size(111, 32);
            label5.TabIndex = 10;
            label5.Text = "Quantity:";
            // 
            // BtnSave
            // 
            BtnSave.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BtnSave.Location = new Point(53, 604);
            BtnSave.Margin = new Padding(3, 4, 3, 4);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(95, 47);
            BtnSave.TabIndex = 6;
            BtnSave.Text = "Save";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BtnCancel.Location = new Point(224, 604);
            BtnCancel.Margin = new Padding(3, 4, 3, 4);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(95, 47);
            BtnCancel.TabIndex = 7;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(102, 497);
            label6.Name = "label6";
            label6.Size = new Size(146, 32);
            label6.TabIndex = 15;
            label6.Text = "Supply date:";
            // 
            // dtpSupplyDate
            // 
            dtpSupplyDate.Checked = false;
            dtpSupplyDate.CustomFormat = "dd.MM.yyyy";
            dtpSupplyDate.Location = new Point(102, 535);
            dtpSupplyDate.Margin = new Padding(3, 4, 3, 4);
            dtpSupplyDate.Name = "dtpSupplyDate";
            dtpSupplyDate.Size = new Size(164, 27);
            dtpSupplyDate.TabIndex = 5;
            dtpSupplyDate.Value = new DateTime(2025, 1, 16, 0, 0, 0, 0);
            // 
            // AddEditProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 667);
            Controls.Add(dtpSupplyDate);
            Controls.Add(label6);
            Controls.Add(BtnCancel);
            Controls.Add(BtnSave);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxCostPrice);
            Controls.Add(textBoxName);
            Controls.Add(cbCategory2);
            Controls.Add(cbSupplier2);
            Controls.Add(label5);
            Controls.Add(textBoxQuantity);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddEditProductForm";
            Text = "AddEditProductForm";
            Load += AddEditProductForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbSupplier2;
        private ComboBox cbCategory2;
        private TextBox textBoxName;
        private TextBox textBoxCostPrice;
        private TextBox textBoxQuantity;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button BtnSave;
        private Button BtnCancel;
        private Label label6;
        private DateTimePicker dtpSupplyDate;
    }
}
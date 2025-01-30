namespace WarehouseApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnConnect = new Button();
            btnDisconnect = new Button();
            btnShowAllProducts = new Button();
            btnShowAllCategories = new Button();
            btnShowAllSuppliers = new Button();
            btnShowMaxQuantity = new Button();
            btnShowMinQuantity = new Button();
            btnShowAvgByType = new Button();
            btnShowOldestProduct = new Button();
            btnShowBySupplier = new Button();
            btnShowByCategory = new Button();
            btnShowMaxCost = new Button();
            btnShowMinCost = new Button();
            cbCategory = new ComboBox();
            cbSupplier = new ComboBox();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            labelStatus = new Label();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(372, 30);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += BtnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(453, 30);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(75, 23);
            btnDisconnect.TabIndex = 1;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += BtnDisconnect_Click;
            // 
            // btnShowAllProducts
            // 
            btnShowAllProducts.Location = new Point(956, 105);
            btnShowAllProducts.Name = "btnShowAllProducts";
            btnShowAllProducts.Size = new Size(128, 23);
            btnShowAllProducts.TabIndex = 2;
            btnShowAllProducts.Text = "Show all products";
            btnShowAllProducts.UseVisualStyleBackColor = true;
            btnShowAllProducts.Click += BtnShowAllProducts_Click;
            // 
            // btnShowAllCategories
            // 
            btnShowAllCategories.Location = new Point(956, 134);
            btnShowAllCategories.Name = "btnShowAllCategories";
            btnShowAllCategories.Size = new Size(128, 23);
            btnShowAllCategories.TabIndex = 3;
            btnShowAllCategories.Text = "Show all categories";
            btnShowAllCategories.UseVisualStyleBackColor = true;
            btnShowAllCategories.Click += BtnShowAllCategories_Click;
            // 
            // btnShowAllSuppliers
            // 
            btnShowAllSuppliers.Location = new Point(956, 163);
            btnShowAllSuppliers.Name = "btnShowAllSuppliers";
            btnShowAllSuppliers.Size = new Size(128, 23);
            btnShowAllSuppliers.TabIndex = 4;
            btnShowAllSuppliers.Text = "Show all suppliers";
            btnShowAllSuppliers.UseVisualStyleBackColor = true;
            btnShowAllSuppliers.Click += BtnShowAllSuppliers_Click;
            // 
            // btnShowMaxQuantity
            // 
            btnShowMaxQuantity.Location = new Point(956, 192);
            btnShowMaxQuantity.Name = "btnShowMaxQuantity";
            btnShowMaxQuantity.Size = new Size(128, 23);
            btnShowMaxQuantity.TabIndex = 5;
            btnShowMaxQuantity.Text = "Show max quantity";
            btnShowMaxQuantity.UseVisualStyleBackColor = true;
            btnShowMaxQuantity.Click += BtnShowMaxQuantity_Click;
            // 
            // btnShowMinQuantity
            // 
            btnShowMinQuantity.Location = new Point(956, 221);
            btnShowMinQuantity.Name = "btnShowMinQuantity";
            btnShowMinQuantity.Size = new Size(128, 23);
            btnShowMinQuantity.TabIndex = 6;
            btnShowMinQuantity.Text = "Show min quantity";
            btnShowMinQuantity.UseVisualStyleBackColor = true;
            btnShowMinQuantity.Click += BtnShowMinQuantity_Click;
            // 
            // btnShowAvgByType
            // 
            btnShowAvgByType.Font = new Font("Segoe UI", 8.25F);
            btnShowAvgByType.Location = new Point(956, 395);
            btnShowAvgByType.Name = "btnShowAvgByType";
            btnShowAvgByType.Size = new Size(128, 23);
            btnShowAvgByType.TabIndex = 7;
            btnShowAvgByType.Text = "Show avg by category";
            btnShowAvgByType.UseVisualStyleBackColor = true;
            btnShowAvgByType.Click += BtnShowAvgByCategory_Click;
            // 
            // btnShowOldestProduct
            // 
            btnShowOldestProduct.Location = new Point(956, 366);
            btnShowOldestProduct.Name = "btnShowOldestProduct";
            btnShowOldestProduct.Size = new Size(128, 23);
            btnShowOldestProduct.TabIndex = 8;
            btnShowOldestProduct.Text = "Show oldest product";
            btnShowOldestProduct.UseVisualStyleBackColor = true;
            btnShowOldestProduct.Click += BtnShowOldestProduct_Click;
            // 
            // btnShowBySupplier
            // 
            btnShowBySupplier.Location = new Point(956, 337);
            btnShowBySupplier.Name = "btnShowBySupplier";
            btnShowBySupplier.Size = new Size(128, 23);
            btnShowBySupplier.TabIndex = 9;
            btnShowBySupplier.Text = "Show by supplier";
            btnShowBySupplier.UseVisualStyleBackColor = true;
            btnShowBySupplier.Click += BtnShowBySupplier_Click;
            // 
            // btnShowByCategory
            // 
            btnShowByCategory.Location = new Point(956, 308);
            btnShowByCategory.Name = "btnShowByCategory";
            btnShowByCategory.Size = new Size(128, 23);
            btnShowByCategory.TabIndex = 10;
            btnShowByCategory.Text = "Show by category";
            btnShowByCategory.UseVisualStyleBackColor = true;
            btnShowByCategory.Click += BtnShowByCategory_Click;
            // 
            // btnShowMaxCost
            // 
            btnShowMaxCost.Location = new Point(956, 279);
            btnShowMaxCost.Name = "btnShowMaxCost";
            btnShowMaxCost.Size = new Size(128, 23);
            btnShowMaxCost.TabIndex = 11;
            btnShowMaxCost.Text = "Show max cost";
            btnShowMaxCost.UseVisualStyleBackColor = true;
            btnShowMaxCost.Click += BtnShowMaxCost_Click;
            // 
            // btnShowMinCost
            // 
            btnShowMinCost.Location = new Point(956, 250);
            btnShowMinCost.Name = "btnShowMinCost";
            btnShowMinCost.Size = new Size(128, 23);
            btnShowMinCost.TabIndex = 12;
            btnShowMinCost.Text = "Show min cost";
            btnShowMinCost.UseVisualStyleBackColor = true;
            btnShowMinCost.Click += BtnShowMinCost_Click;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(568, 30);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(121, 23);
            cbCategory.TabIndex = 13;
            // 
            // cbSupplier
            // 
            cbSupplier.FormattingEnabled = true;
            cbSupplier.Location = new Point(728, 29);
            cbSupplier.Name = "cbSupplier";
            cbSupplier.Size = new Size(121, 23);
            cbSupplier.TabIndex = 14;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(372, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(477, 23);
            textBox1.TabIndex = 15;
            textBox1.Text = "SELECT * FROM Products";
            textBox1.KeyDown += TextBox1_KeyDown;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 88);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(938, 350);
            dataGridView1.TabIndex = 16;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI Variable Display", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStatus.ForeColor = Color.FromArgb(192, 0, 0);
            labelStatus.Location = new Point(88, 39);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(216, 32);
            labelStatus.TabIndex = 17;
            labelStatus.Text = "NOT CONNECTED";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(590, 11);
            label1.Name = "label1";
            label1.Size = new Size(71, 17);
            label1.TabIndex = 18;
            label1.Text = "Categories";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(756, 10);
            label2.Name = "label2";
            label2.Size = new Size(62, 17);
            label2.TabIndex = 19;
            label2.Text = "Suppliers";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1096, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelStatus);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Controls.Add(cbSupplier);
            Controls.Add(cbCategory);
            Controls.Add(btnShowMinCost);
            Controls.Add(btnShowMaxCost);
            Controls.Add(btnShowByCategory);
            Controls.Add(btnShowBySupplier);
            Controls.Add(btnShowOldestProduct);
            Controls.Add(btnShowAvgByType);
            Controls.Add(btnShowMinQuantity);
            Controls.Add(btnShowMaxQuantity);
            Controls.Add(btnShowAllSuppliers);
            Controls.Add(btnShowAllCategories);
            Controls.Add(btnShowAllProducts);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConnect;
        private Button btnDisconnect;
        private Button btnShowAllProducts;
        private Button btnShowAllCategories;
        private Button btnShowAllSuppliers;
        private Button btnShowMaxQuantity;
        private Button btnShowMinQuantity;
        private Button btnShowAvgByType;
        private Button btnShowOldestProduct;
        private Button btnShowBySupplier;
        private Button btnShowByCategory;
        private Button btnShowMaxCost;
        private Button btnShowMinCost;
        private ComboBox cbCategory;
        private ComboBox cbSupplier;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private Label labelStatus;
        private Label label1;
        private Label label2;
    }
}

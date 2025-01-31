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
            BtnAdd = new Button();
            BtnEdit = new Button();
            BtnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(425, 40);
            btnConnect.Margin = new Padding(3, 4, 3, 4);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(86, 31);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += BtnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(518, 40);
            btnDisconnect.Margin = new Padding(3, 4, 3, 4);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(86, 31);
            btnDisconnect.TabIndex = 1;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += BtnDisconnect_Click;
            // 
            // btnShowAllProducts
            // 
            btnShowAllProducts.Location = new Point(1093, 227);
            btnShowAllProducts.Margin = new Padding(3, 4, 3, 4);
            btnShowAllProducts.Name = "btnShowAllProducts";
            btnShowAllProducts.Size = new Size(146, 31);
            btnShowAllProducts.TabIndex = 2;
            btnShowAllProducts.Text = "Show all products";
            btnShowAllProducts.UseVisualStyleBackColor = true;
            btnShowAllProducts.Click += BtnShowAllProducts_Click;
            // 
            // btnShowAllCategories
            // 
            btnShowAllCategories.Location = new Point(1093, 265);
            btnShowAllCategories.Margin = new Padding(3, 4, 3, 4);
            btnShowAllCategories.Name = "btnShowAllCategories";
            btnShowAllCategories.Size = new Size(146, 31);
            btnShowAllCategories.TabIndex = 3;
            btnShowAllCategories.Text = "Show all categories";
            btnShowAllCategories.UseVisualStyleBackColor = true;
            btnShowAllCategories.Click += BtnShowAllCategories_Click;
            // 
            // btnShowAllSuppliers
            // 
            btnShowAllSuppliers.Location = new Point(1093, 304);
            btnShowAllSuppliers.Margin = new Padding(3, 4, 3, 4);
            btnShowAllSuppliers.Name = "btnShowAllSuppliers";
            btnShowAllSuppliers.Size = new Size(146, 31);
            btnShowAllSuppliers.TabIndex = 4;
            btnShowAllSuppliers.Text = "Show all suppliers";
            btnShowAllSuppliers.UseVisualStyleBackColor = true;
            btnShowAllSuppliers.Click += BtnShowAllSuppliers_Click;
            // 
            // btnShowMaxQuantity
            // 
            btnShowMaxQuantity.Location = new Point(1093, 343);
            btnShowMaxQuantity.Margin = new Padding(3, 4, 3, 4);
            btnShowMaxQuantity.Name = "btnShowMaxQuantity";
            btnShowMaxQuantity.Size = new Size(146, 31);
            btnShowMaxQuantity.TabIndex = 5;
            btnShowMaxQuantity.Text = "Show max quantity";
            btnShowMaxQuantity.UseVisualStyleBackColor = true;
            btnShowMaxQuantity.Click += BtnShowMaxQuantity_Click;
            // 
            // btnShowMinQuantity
            // 
            btnShowMinQuantity.Location = new Point(1093, 381);
            btnShowMinQuantity.Margin = new Padding(3, 4, 3, 4);
            btnShowMinQuantity.Name = "btnShowMinQuantity";
            btnShowMinQuantity.Size = new Size(146, 31);
            btnShowMinQuantity.TabIndex = 6;
            btnShowMinQuantity.Text = "Show min quantity";
            btnShowMinQuantity.UseVisualStyleBackColor = true;
            btnShowMinQuantity.Click += BtnShowMinQuantity_Click;
            // 
            // btnShowAvgByType
            // 
            btnShowAvgByType.Font = new Font("Segoe UI", 8.25F);
            btnShowAvgByType.Location = new Point(1093, 613);
            btnShowAvgByType.Margin = new Padding(3, 4, 3, 4);
            btnShowAvgByType.Name = "btnShowAvgByType";
            btnShowAvgByType.Size = new Size(146, 31);
            btnShowAvgByType.TabIndex = 7;
            btnShowAvgByType.Text = "Show avg by category";
            btnShowAvgByType.UseVisualStyleBackColor = true;
            btnShowAvgByType.Click += BtnShowAvgByCategory_Click;
            // 
            // btnShowOldestProduct
            // 
            btnShowOldestProduct.Location = new Point(1093, 575);
            btnShowOldestProduct.Margin = new Padding(3, 4, 3, 4);
            btnShowOldestProduct.Name = "btnShowOldestProduct";
            btnShowOldestProduct.Size = new Size(146, 31);
            btnShowOldestProduct.TabIndex = 8;
            btnShowOldestProduct.Text = "Show oldest product";
            btnShowOldestProduct.UseVisualStyleBackColor = true;
            btnShowOldestProduct.Click += BtnShowOldestProduct_Click;
            // 
            // btnShowBySupplier
            // 
            btnShowBySupplier.Location = new Point(1093, 536);
            btnShowBySupplier.Margin = new Padding(3, 4, 3, 4);
            btnShowBySupplier.Name = "btnShowBySupplier";
            btnShowBySupplier.Size = new Size(146, 31);
            btnShowBySupplier.TabIndex = 9;
            btnShowBySupplier.Text = "Show by supplier";
            btnShowBySupplier.UseVisualStyleBackColor = true;
            btnShowBySupplier.Click += BtnShowBySupplier_Click;
            // 
            // btnShowByCategory
            // 
            btnShowByCategory.Location = new Point(1093, 497);
            btnShowByCategory.Margin = new Padding(3, 4, 3, 4);
            btnShowByCategory.Name = "btnShowByCategory";
            btnShowByCategory.Size = new Size(146, 31);
            btnShowByCategory.TabIndex = 10;
            btnShowByCategory.Text = "Show by category";
            btnShowByCategory.UseVisualStyleBackColor = true;
            btnShowByCategory.Click += BtnShowByCategory_Click;
            // 
            // btnShowMaxCost
            // 
            btnShowMaxCost.Location = new Point(1093, 459);
            btnShowMaxCost.Margin = new Padding(3, 4, 3, 4);
            btnShowMaxCost.Name = "btnShowMaxCost";
            btnShowMaxCost.Size = new Size(146, 31);
            btnShowMaxCost.TabIndex = 11;
            btnShowMaxCost.Text = "Show max cost";
            btnShowMaxCost.UseVisualStyleBackColor = true;
            btnShowMaxCost.Click += BtnShowMaxCost_Click;
            // 
            // btnShowMinCost
            // 
            btnShowMinCost.Location = new Point(1093, 420);
            btnShowMinCost.Margin = new Padding(3, 4, 3, 4);
            btnShowMinCost.Name = "btnShowMinCost";
            btnShowMinCost.Size = new Size(146, 31);
            btnShowMinCost.TabIndex = 12;
            btnShowMinCost.Text = "Show min cost";
            btnShowMinCost.UseVisualStyleBackColor = true;
            btnShowMinCost.Click += BtnShowMinCost_Click;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(649, 40);
            cbCategory.Margin = new Padding(3, 4, 3, 4);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(138, 28);
            cbCategory.TabIndex = 13;
            // 
            // cbSupplier
            // 
            cbSupplier.FormattingEnabled = true;
            cbSupplier.Location = new Point(832, 39);
            cbSupplier.Margin = new Padding(3, 4, 3, 4);
            cbSupplier.Name = "cbSupplier";
            cbSupplier.Size = new Size(138, 28);
            cbSupplier.TabIndex = 14;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(425, 79);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(545, 27);
            textBox1.TabIndex = 15;
            textBox1.Text = "SELECT * FROM Products";
            textBox1.KeyDown += TextBox1_KeyDown;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(14, 203);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1072, 468);
            dataGridView1.TabIndex = 16;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI Variable Display", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStatus.ForeColor = Color.FromArgb(192, 0, 0);
            labelStatus.Location = new Point(101, 52);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(269, 40);
            labelStatus.TabIndex = 17;
            labelStatus.Text = "NOT CONNECTED";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(674, 15);
            label1.Name = "label1";
            label1.Size = new Size(91, 23);
            label1.TabIndex = 18;
            label1.Text = "Categories";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(864, 13);
            label2.Name = "label2";
            label2.Size = new Size(79, 23);
            label2.TabIndex = 19;
            label2.Text = "Suppliers";
            // 
            // BtnAdd
            // 
            BtnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BtnAdd.Location = new Point(199, 117);
            BtnAdd.Margin = new Padding(3, 4, 3, 4);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(139, 77);
            BtnAdd.TabIndex = 20;
            BtnAdd.Text = "Add new product";
            BtnAdd.UseVisualStyleBackColor = true;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // BtnEdit
            // 
            BtnEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BtnEdit.Location = new Point(478, 117);
            BtnEdit.Margin = new Padding(3, 4, 3, 4);
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(134, 77);
            BtnEdit.TabIndex = 21;
            BtnEdit.Text = "Edit selected product";
            BtnEdit.UseVisualStyleBackColor = true;
            BtnEdit.Click += BtnEdit_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BtnDelete.Location = new Point(757, 117);
            BtnDelete.Margin = new Padding(3, 4, 3, 4);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(139, 77);
            BtnDelete.TabIndex = 23;
            BtnDelete.Text = "Delete selected product";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1253, 687);
            Controls.Add(BtnEdit);
            Controls.Add(BtnAdd);
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
            Controls.Add(BtnDelete);
            Margin = new Padding(3, 4, 3, 4);
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
        private Button BtnAdd;
        private Button BtnEdit;
        private Button BtnDelete;
    }
}

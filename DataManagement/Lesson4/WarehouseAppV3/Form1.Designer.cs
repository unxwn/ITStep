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
            textBoxQuerySuppliers = new TextBox();
            labelStatus = new Label();
            label1 = new Label();
            label2 = new Label();
            BtnAdd = new Button();
            BtnEdit = new Button();
            BtnDelete = new Button();
            TabControl1 = new TabControl();
            TabPageProducts = new TabPage();
            textBoxQueryProducts = new TextBox();
            dataGridViewProducts = new DataGridView();
            TabPageCategories = new TabPage();
            textBoxQueryCategories = new TextBox();
            dataGridViewCategories = new DataGridView();
            TabPageSuppliers = new TabPage();
            dataGridViewSuppliers = new DataGridView();
            TabControl1.SuspendLayout();
            TabPageProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            TabPageCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategories).BeginInit();
            TabPageSuppliers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSuppliers).BeginInit();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(372, 30);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(82, 23);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += BtnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(459, 30);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(82, 23);
            btnDisconnect.TabIndex = 1;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += BtnDisconnect_Click;
            // 
            // btnShowMaxQuantity
            // 
            btnShowMaxQuantity.Location = new Point(934, 58);
            btnShowMaxQuantity.Name = "btnShowMaxQuantity";
            btnShowMaxQuantity.Size = new Size(128, 23);
            btnShowMaxQuantity.TabIndex = 5;
            btnShowMaxQuantity.Text = "Show max quantity";
            btnShowMaxQuantity.UseVisualStyleBackColor = true;
            btnShowMaxQuantity.Click += BtnShowMaxQuantity_Click;
            // 
            // btnShowMinQuantity
            // 
            btnShowMinQuantity.Location = new Point(934, 86);
            btnShowMinQuantity.Name = "btnShowMinQuantity";
            btnShowMinQuantity.Size = new Size(128, 23);
            btnShowMinQuantity.TabIndex = 6;
            btnShowMinQuantity.Text = "Show min quantity";
            btnShowMinQuantity.UseVisualStyleBackColor = true;
            btnShowMinQuantity.Click += BtnShowMinQuantity_Click;
            // 
            // btnShowAvgByType
            // 
            btnShowAvgByType.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnShowAvgByType.Location = new Point(934, 260);
            btnShowAvgByType.Name = "btnShowAvgByType";
            btnShowAvgByType.Size = new Size(128, 23);
            btnShowAvgByType.TabIndex = 7;
            btnShowAvgByType.Text = "Show avg by category";
            btnShowAvgByType.UseVisualStyleBackColor = true;
            btnShowAvgByType.Click += BtnShowAvgByCategory_Click;
            // 
            // btnShowOldestProduct
            // 
            btnShowOldestProduct.Location = new Point(934, 232);
            btnShowOldestProduct.Name = "btnShowOldestProduct";
            btnShowOldestProduct.Size = new Size(128, 23);
            btnShowOldestProduct.TabIndex = 8;
            btnShowOldestProduct.Text = "Show oldest product";
            btnShowOldestProduct.UseVisualStyleBackColor = true;
            btnShowOldestProduct.Click += BtnShowOldestProduct_Click;
            // 
            // btnShowBySupplier
            // 
            btnShowBySupplier.Location = new Point(934, 202);
            btnShowBySupplier.Name = "btnShowBySupplier";
            btnShowBySupplier.Size = new Size(128, 23);
            btnShowBySupplier.TabIndex = 9;
            btnShowBySupplier.Text = "Show by supplier";
            btnShowBySupplier.UseVisualStyleBackColor = true;
            btnShowBySupplier.Click += BtnShowBySupplier_Click;
            // 
            // btnShowByCategory
            // 
            btnShowByCategory.Location = new Point(934, 173);
            btnShowByCategory.Name = "btnShowByCategory";
            btnShowByCategory.Size = new Size(128, 23);
            btnShowByCategory.TabIndex = 10;
            btnShowByCategory.Text = "Show by category";
            btnShowByCategory.UseVisualStyleBackColor = true;
            btnShowByCategory.Click += BtnShowByCategory_Click;
            // 
            // btnShowMaxCost
            // 
            btnShowMaxCost.Location = new Point(934, 145);
            btnShowMaxCost.Name = "btnShowMaxCost";
            btnShowMaxCost.Size = new Size(128, 23);
            btnShowMaxCost.TabIndex = 11;
            btnShowMaxCost.Text = "Show max cost";
            btnShowMaxCost.UseVisualStyleBackColor = true;
            btnShowMaxCost.Click += BtnShowMaxCost_Click;
            // 
            // btnShowMinCost
            // 
            btnShowMinCost.Location = new Point(934, 116);
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
            // textBoxQuerySuppliers
            // 
            textBoxQuerySuppliers.Location = new Point(5, 3);
            textBoxQuerySuppliers.Name = "textBoxQuerySuppliers";
            textBoxQuerySuppliers.ReadOnly = true;
            textBoxQuerySuppliers.Size = new Size(1057, 23);
            textBoxQuerySuppliers.TabIndex = 15;
            textBoxQuerySuppliers.Text = "SELECT * FROM Suppliers";
            textBoxQuerySuppliers.KeyDown += TextBox1_KeyDown;
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
            // BtnAdd
            // 
            BtnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BtnAdd.Location = new Point(166, 88);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(135, 58);
            BtnAdd.TabIndex = 20;
            BtnAdd.Text = "Add new product";
            BtnAdd.UseVisualStyleBackColor = true;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // BtnEdit
            // 
            BtnEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BtnEdit.Location = new Point(410, 88);
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(130, 58);
            BtnEdit.TabIndex = 21;
            BtnEdit.Text = "Edit selected product";
            BtnEdit.UseVisualStyleBackColor = true;
            BtnEdit.Click += BtnEdit_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BtnDelete.Location = new Point(654, 88);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(135, 58);
            BtnDelete.TabIndex = 23;
            BtnDelete.Text = "Delete selected product";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // TabControl1
            // 
            TabControl1.Controls.Add(TabPageProducts);
            TabControl1.Controls.Add(TabPageCategories);
            TabControl1.Controls.Add(TabPageSuppliers);
            TabControl1.Location = new Point(12, 152);
            TabControl1.Margin = new Padding(3, 2, 3, 2);
            TabControl1.Name = "TabControl1";
            TabControl1.SelectedIndex = 0;
            TabControl1.Size = new Size(1074, 354);
            TabControl1.TabIndex = 24;
            // 
            // TabPageProducts
            // 
            TabPageProducts.Controls.Add(textBoxQueryProducts);
            TabPageProducts.Controls.Add(dataGridViewProducts);
            TabPageProducts.Controls.Add(btnShowMaxQuantity);
            TabPageProducts.Controls.Add(btnShowMinQuantity);
            TabPageProducts.Controls.Add(btnShowAvgByType);
            TabPageProducts.Controls.Add(btnShowMinCost);
            TabPageProducts.Controls.Add(btnShowOldestProduct);
            TabPageProducts.Controls.Add(btnShowMaxCost);
            TabPageProducts.Controls.Add(btnShowBySupplier);
            TabPageProducts.Controls.Add(btnShowByCategory);
            TabPageProducts.Location = new Point(4, 24);
            TabPageProducts.Margin = new Padding(3, 2, 3, 2);
            TabPageProducts.Name = "TabPageProducts";
            TabPageProducts.Padding = new Padding(3, 2, 3, 2);
            TabPageProducts.Size = new Size(1066, 326);
            TabPageProducts.TabIndex = 0;
            TabPageProducts.Text = "Products";
            TabPageProducts.UseVisualStyleBackColor = true;
            // 
            // textBoxQueryProducts
            // 
            textBoxQueryProducts.Location = new Point(5, 5);
            textBoxQueryProducts.Name = "textBoxQueryProducts";
            textBoxQueryProducts.ReadOnly = true;
            textBoxQueryProducts.Size = new Size(1057, 23);
            textBoxQueryProducts.TabIndex = 17;
            textBoxQueryProducts.Text = "SELECT * FROM Products";
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Location = new Point(5, 31);
            dataGridViewProducts.Margin = new Padding(3, 2, 3, 2);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.RowHeadersWidth = 51;
            dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProducts.Size = new Size(923, 294);
            dataGridViewProducts.TabIndex = 13;
            // 
            // TabPageCategories
            // 
            TabPageCategories.Controls.Add(textBoxQueryCategories);
            TabPageCategories.Controls.Add(dataGridViewCategories);
            TabPageCategories.Location = new Point(4, 24);
            TabPageCategories.Margin = new Padding(3, 2, 3, 2);
            TabPageCategories.Name = "TabPageCategories";
            TabPageCategories.Padding = new Padding(3, 2, 3, 2);
            TabPageCategories.Size = new Size(1066, 326);
            TabPageCategories.TabIndex = 1;
            TabPageCategories.Text = "Categories";
            TabPageCategories.UseVisualStyleBackColor = true;
            // 
            // textBoxQueryCategories
            // 
            textBoxQueryCategories.Location = new Point(5, 5);
            textBoxQueryCategories.Name = "textBoxQueryCategories";
            textBoxQueryCategories.ReadOnly = true;
            textBoxQueryCategories.Size = new Size(1057, 23);
            textBoxQueryCategories.TabIndex = 16;
            textBoxQueryCategories.Text = "SELECT * FROM Categories";
            // 
            // dataGridViewCategories
            // 
            dataGridViewCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCategories.Location = new Point(5, 31);
            dataGridViewCategories.Margin = new Padding(3, 2, 3, 2);
            dataGridViewCategories.Name = "dataGridViewCategories";
            dataGridViewCategories.RowHeadersWidth = 51;
            dataGridViewCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCategories.Size = new Size(1056, 294);
            dataGridViewCategories.TabIndex = 14;
            // 
            // TabPageSuppliers
            // 
            TabPageSuppliers.Controls.Add(dataGridViewSuppliers);
            TabPageSuppliers.Controls.Add(textBoxQuerySuppliers);
            TabPageSuppliers.Location = new Point(4, 24);
            TabPageSuppliers.Margin = new Padding(3, 2, 3, 2);
            TabPageSuppliers.Name = "TabPageSuppliers";
            TabPageSuppliers.Size = new Size(1066, 326);
            TabPageSuppliers.TabIndex = 2;
            TabPageSuppliers.Text = "Suppliers";
            TabPageSuppliers.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSuppliers
            // 
            dataGridViewSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSuppliers.Location = new Point(5, 28);
            dataGridViewSuppliers.Margin = new Padding(3, 2, 3, 2);
            dataGridViewSuppliers.Name = "dataGridViewSuppliers";
            dataGridViewSuppliers.RowHeadersWidth = 51;
            dataGridViewSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSuppliers.Size = new Size(1056, 296);
            dataGridViewSuppliers.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1096, 515);
            Controls.Add(TabControl1);
            Controls.Add(BtnEdit);
            Controls.Add(BtnAdd);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelStatus);
            Controls.Add(cbSupplier);
            Controls.Add(cbCategory);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Controls.Add(BtnDelete);
            Name = "Form1";
            Text = "Form1";
            TabControl1.ResumeLayout(false);
            TabPageProducts.ResumeLayout(false);
            TabPageProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            TabPageCategories.ResumeLayout(false);
            TabPageCategories.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategories).EndInit();
            TabPageSuppliers.ResumeLayout(false);
            TabPageSuppliers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSuppliers).EndInit();
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
        private TextBox textBoxQuerySuppliers;
        private DataGridView dataGridViewProducts;
        private Label labelStatus;
        private Label label1;
        private Label label2;
        private Button BtnAdd;
        private Button BtnEdit;
        private Button BtnDelete;
        private TabControl TabControl1;
        private TabPage TabPageCategories;
        private TabPage TabPageProducts;
        private TabPage TabPageSuppliers;
        private DataGridView dataGridViewCategories;
        private DataGridView dataGridViewSuppliers;
        private TextBox textBoxQueryCategories;
        private TextBox textBoxQueryProducts;
    }
}

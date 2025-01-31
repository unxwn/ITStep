using Microsoft.Data.SqlClient;
using System.Data;
using WarehouseApp.Models;

namespace WarehouseApp
{
    public partial class Form1 : Form
    {
        private string connStr = "Server=(localdb)\\MSSQLLocalDB;Database=WarehouseDb;Trusted_Connection=True;";
        private SqlConnection conn;
        private DataTable dt;

        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(connStr);
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();

                    //LoadComboBoxes();
                    cbCategory.DataSource = GetCategories();
                    cbCategory.DisplayMember = "Name";
                    cbCategory.ValueMember = nameof(Category.Id);

                    cbSupplier.DataSource = GetSuppliers();
                    cbSupplier.DisplayMember = "Name"; 
                    cbSupplier.ValueMember = nameof(Supplier.Id);

                    labelStatus.ForeColor = Color.Green;
                    labelStatus.Text = "CONNECTED";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    labelStatus.ForeColor = Color.FromArgb(192, 0, 0); ;
                    labelStatus.Text = "DISCONNECTED";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Disconnection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            var categories = GetCategories();
            var suppliers = GetSuppliers();

            AddEditProductForm addEditForm = new AddEditProductForm(product, categories, suppliers);
            if (addEditForm.ShowDialog() == DialogResult.OK)
            {
                string query = "INSERT INTO Products VALUES (@Name, @CategoryId, @SupplierId, @CostPrice, @Quantity, @SupplyDate)";
                using SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                cmd.Parameters.AddWithValue("@SupplierId", product.SupplierId);
                cmd.Parameters.AddWithValue("@CostPrice", product.CostPrice);
                cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                cmd.Parameters.AddWithValue("@SupplyDate", product.SupplyDate);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Product added successfully!", "Addition", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ExecuteQuery("SELECT * FROM Products");
            }
            else 
            {
                MessageBox.Show("Product wasn't added successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                string query = "SELECT * FROM Products WHERE Id = @Id";
                using SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Product product = new Product
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        CategoryId = reader.GetInt32(2),
                        SupplierId = reader.GetInt32(3),
                        Quantity = reader.GetInt32(4),
                        CostPrice = reader.GetDecimal(5),
                        //CostPrice = Convert.ToDecimal(reader.GetValue(5)),
                        SupplyDate = reader.GetDateTime(6)
                    };
                    reader.Close();

                    var categories = GetCategories();
                    var suppliers = GetSuppliers();

                    AddEditProductForm addEditForm = new AddEditProductForm(product, categories, suppliers);
                    if (addEditForm.ShowDialog() == DialogResult.OK)
                    {
                        string updateQuery = "UPDATE Products SET Name=@Name, CategoryId=@CategoryId, SupplierId=@SupplierId, " +
                                             "CostPrice=@CostPrice, Quantity=@Quantity, SupplyDate=@SupplyDate WHERE Id=@Id";
                        using SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@Name", product.Name);
                        updateCmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                        updateCmd.Parameters.AddWithValue("@SupplierId", product.SupplierId);
                        updateCmd.Parameters.AddWithValue("@CostPrice", product.CostPrice);
                        updateCmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                        updateCmd.Parameters.AddWithValue("@SupplyDate", product.SupplyDate);
                        updateCmd.Parameters.AddWithValue("@Id", product.Id);

                        updateCmd.ExecuteNonQuery();
                        MessageBox.Show("Product updated successfully!", "Editing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ExecuteQuery("SELECT * FROM Products");
                    }
                    else
                    {
                        MessageBox.Show("Product wasn't edited successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Product not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Select a product to edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM Products WHERE Id=@Id";
                    using SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully removed!", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ExecuteQuery("SELECT * FROM Products");
                }
            }
            else
            {
                MessageBox.Show("Select a product to remove", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //private void LoadComboBoxes()
        //{
        //    cbCategory.Items.Clear();
        //    cbSupplier.Items.Clear();

        //    try
        //    {
        //        using SqlCommand categoryCmd = new SqlCommand("SELECT Name FROM Categories", conn);
        //        using SqlDataReader categoryReader = categoryCmd.ExecuteReader();
        //        while (categoryReader.Read())
        //        {
        //            cbCategory.Items.Add(categoryReader["Name"]);
        //        }
        //        categoryReader.Close();

        //        using SqlCommand supplierCmd = new SqlCommand("SELECT Name FROM Suppliers", conn);
        //        using SqlDataReader supplierReader = supplierCmd.ExecuteReader();
        //        while (supplierReader.Read())
        //        {
        //            cbSupplier.Items.Add(supplierReader["Name"]);
        //        }
        //        supplierReader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error loading combo boxes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            using SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                categories.Add(new Category
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }
            return categories;
        }

        private List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();

            using SqlCommand cmd = new SqlCommand("SELECT * FROM Suppliers", conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                suppliers.Add(new Supplier
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }
            return suppliers;
        }

        private void ExecuteQuery(string query)
        {
            textBox1.Text = query;
            try
            {
                using SqlCommand sqlCommand = new SqlCommand(query, conn);
                using SqlDataReader reader = sqlCommand.ExecuteReader();
                dt = new DataTable();
                for (int i = 0; i < reader.FieldCount; i++)
                    dt.Columns.Add(reader.GetName(i));
                while (reader.Read())
                {
                    DataRow newRow = dt.NewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                        newRow[i] = reader[i];
                    dt.Rows.Add(newRow);
                }
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExecuteQuery(textBox1.Text.Trim());
            }
        }
        private void BtnShowAllProducts_Click(object sender, EventArgs e)
            => ExecuteQuery("SELECT * FROM Products");
        private void BtnShowAllCategories_Click(object sender, EventArgs e)
            => ExecuteQuery("SELECT * FROM Categories");
        private void BtnShowAllSuppliers_Click(object sender, EventArgs e)
            => ExecuteQuery("SELECT * FROM Suppliers");
        private void BtnShowMaxQuantity_Click(object sender, EventArgs e)
            => ExecuteQuery("SELECT TOP 1 * FROM Products ORDER BY Quantity DESC");
        private void BtnShowMinQuantity_Click(object sender, EventArgs e)
            => ExecuteQuery("SELECT TOP 1 * FROM Products ORDER BY Quantity ASC");
        private void BtnShowMinCost_Click(object sender, EventArgs e)
            => ExecuteQuery("SELECT TOP 1 * FROM Products ORDER BY CostPrice ASC");
        private void BtnShowMaxCost_Click(object sender, EventArgs e)
            => ExecuteQuery("SELECT TOP 1 * FROM Products ORDER BY CostPrice DESC");
        private void BtnShowByCategory_Click(object sender, EventArgs e)
        {
            if (cbCategory.SelectedItem != null)
                ExecuteQuery($"SELECT Products.*, Categories.Name as CategoryName FROM Products JOIN Categories ON Products.CategoryId = Categories.Id WHERE Categories.Name = '{cbCategory.SelectedItem}'");
            else
                MessageBox.Show($"Select a category from the list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void BtnShowBySupplier_Click(object sender, EventArgs e)
        {
            if (cbSupplier.SelectedItem != null)
                ExecuteQuery($"SELECT Products.*, Suppliers.Name as SupplierName FROM Products JOIN Suppliers ON Products.SupplierId = Suppliers.Id WHERE Suppliers.name = '{cbSupplier.SelectedItem}'");
            else
                MessageBox.Show($"Select a supplier from the list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void BtnShowOldestProduct_Click(object sender, EventArgs e)
            => ExecuteQuery("SELECT * FROM Products WHERE SupplyDate = (SELECT TOP 1 SupplyDate FROM Products ORDER BY SupplyDate ASC)");
        private void BtnShowAvgByCategory_Click(object sender, EventArgs e)
            => ExecuteQuery("SELECT Categories.Name, AVG(Products.Quantity) AS AverageQuantity FROM Products JOIN Categories ON Products.CategoryId = Categories.Id GROUP BY Categories.Name");
    }
}

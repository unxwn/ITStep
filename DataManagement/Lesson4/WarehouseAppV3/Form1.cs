using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using WarehouseApp.Models;

namespace WarehouseApp
{
    public partial class Form1 : Form
    {
        private string connStr = "Server=(localdb)\\MSSQLLocalDB;Database=WarehouseDb;Trusted_Connection=True;";
        private SqlConnection conn;
        private DataTable dt;
        private string activeTable = "Products";

        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(connStr);
            TabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
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

                    ExecuteQuery("EXEC sp_GetAllProducts");
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

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl1.SelectedTab == TabPageProducts)
            {
                activeTable = "Products";
                ExecuteQuery("EXEC sp_GetAllProducts");
            }
            else if (TabControl1.SelectedTab == TabPageCategories)
            {
                activeTable = "Categories";
                ExecuteQuery("EXEC sp_GetAllCategories");
            }
            else if (TabControl1.SelectedTab == TabPageSuppliers)
            {
                activeTable = "Suppliers";
                ExecuteQuery("EXEC sp_GetAllSuppliers");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            switch (activeTable)
            {
                case "Products":
                    {
                        Product product = new Product();
                        var categories = GetCategories();
                        var suppliers = GetSuppliers();

                        AddEditProductForm addEditForm = new AddEditProductForm(product, categories, suppliers);
                        if (addEditForm.ShowDialog() == DialogResult.OK)
                        {
                            string query = "EXEC sp_InsertProduct @Name, @CategoryId, @SupplierId, @CostPrice, @Quantity, @SupplyDate";
                            using SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@Name", product.Name);
                            cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                            cmd.Parameters.AddWithValue("@SupplierId", product.SupplierId);
                            cmd.Parameters.AddWithValue("@CostPrice", product.CostPrice);
                            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                            cmd.Parameters.AddWithValue("@SupplyDate", product.SupplyDate);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Product added successfully!", "Addition", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ExecuteQuery("EXEC sp_GetAllProducts");
                        }
                        else
                        {
                            MessageBox.Show("Product wasn't added successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;

                case "Categories":
                    {
                        // Create form for adding category and implement method
                        MessageBox.Show("Functionality for categories haven't added yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;

                case "Suppliers":
                    {
                        // Create form for adding suppliers and implement method
                        MessageBox.Show("Functionality for suppliers haven't added yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            switch (activeTable)
            {
                case "Products":
                    {
                        if (dataGridViewProducts.SelectedRows.Count > 0)
                        {
                            int id = Convert.ToInt32(dataGridViewProducts.SelectedRows[0].Cells["Id"].Value);
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
                                    SupplyDate = reader.GetDateTime(6)
                                };
                                reader.Close();

                                var categories = GetCategories();
                                var suppliers = GetSuppliers();

                                AddEditProductForm addEditForm = new AddEditProductForm(product, categories, suppliers);
                                if (addEditForm.ShowDialog() == DialogResult.OK)
                                {
                                    string updateQuery = "EXEC sp_UpdateProduct @Id, @Name, @CategoryId, @SupplierId, @CostPrice, @Quantity, @SupplyDate";
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
                                    ExecuteQuery("EXEC sp_GetAllProducts");
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
                    break;

                case "Categories":
                    {
                        MessageBox.Show("The category editing functionality has not yet been implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;

                case "Suppliers":
                    {
                        MessageBox.Show("The suppliers editing functionality has not yet been implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            switch (activeTable)
            {
                case "Products":
                    {
                        if (dataGridViewProducts.SelectedRows.Count > 0)
                        {
                            int id = Convert.ToInt32(dataGridViewProducts.SelectedRows[0].Cells["Id"].Value);
                            DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Delete",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                string query = "EXEC sp_DeleteProduct @Id";
                                using SqlCommand cmd = new SqlCommand(query, conn);
                                cmd.Parameters.AddWithValue("@Id", id);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Product successfully removed!", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ExecuteQuery("EXEC sp_GetAllProducts");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Select a product to remove", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    break;

                case "Categories":
                    {
                        if (dataGridViewCategories.SelectedRows.Count > 0)
                        {
                            int id = Convert.ToInt32(dataGridViewCategories.SelectedRows[0].Cells["Id"].Value);
                            DialogResult result = MessageBox.Show("Are you sure you want to delete this category?", "Delete",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                string query = "EXEC sp_DeleteCategory @Id";
                                using SqlCommand cmd = new SqlCommand(query, conn);
                                cmd.Parameters.AddWithValue("@Id", id);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Category successfully removed!", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ExecuteQuery("EXEC sp_GetAllCategories");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Select a category to remove", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    break;

                case "Suppliers":
                    {
                        if (dataGridViewSuppliers.SelectedRows.Count > 0)
                        {
                            int id = Convert.ToInt32(dataGridViewSuppliers.SelectedRows[0].Cells["Id"].Value);
                            DialogResult result = MessageBox.Show("Are you sure you want to delete this supplier?", "Delete",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                string query = "EXEC sp_DeleteSupplier @Id";
                                using SqlCommand cmd = new SqlCommand(query, conn);
                                cmd.Parameters.AddWithValue("@Id", id);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Supplier successfully removed!", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ExecuteQuery("EXEC sp_GetAllSuppliers");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Select a supplier to remove", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    break;
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

            using SqlCommand cmd = new SqlCommand("sp_GetAllCategories", conn);
            cmd.CommandType = CommandType.StoredProcedure;
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

            using SqlCommand cmd = new SqlCommand("sp_GetAllSuppliers", conn);
            cmd.CommandType = CommandType.StoredProcedure;
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
            switch (activeTable)
            {
                case "Products":
                    textBoxQueryProducts.Text = query;
                    break;
                case "Categories":
                    textBoxQueryCategories.Text = query;
                    break;
                case "Suppliers":
                    textBoxQuerySuppliers.Text = query;
                    break;
            }

            try
            {
                using SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.CommandType = query.StartsWith("EXEC") ? CommandType.Text : CommandType.Text;
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

                switch (activeTable)
                {
                    case "Products":
                        dataGridViewProducts.DataSource = dt;
                        break;
                    case "Categories":
                        dataGridViewCategories.DataSource = dt;
                        break;
                    case "Suppliers":
                        dataGridViewSuppliers.DataSource = dt;
                        break;
                }
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
                string query = string.Empty;
                switch (activeTable)
                {
                    case "Products":
                        query = textBoxQueryProducts.Text.Trim();
                        break;
                    case "Categories":
                        query = textBoxQueryCategories.Text.Trim();
                        break;
                    case "Suppliers":
                        query = textBoxQuerySuppliers.Text.Trim();
                        break;
                }
                ExecuteQuery(query);
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

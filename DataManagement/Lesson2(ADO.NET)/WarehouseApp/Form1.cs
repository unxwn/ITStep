using Microsoft.Data.SqlClient;
using System.Data;

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
                    LoadComboBoxes();
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

        private void ExecuteQuery(string query)
        {
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

        private void LoadComboBoxes()
        {
            cbCategory.Items.Clear();
            cbSupplier.Items.Clear();

            try
            {
                using SqlCommand categoryCmd = new SqlCommand("SELECT Name FROM Categories", conn);
                using SqlDataReader categoryReader = categoryCmd.ExecuteReader();
                while (categoryReader.Read())
                {
                    cbCategory.Items.Add(categoryReader["Name"].ToString());
                }
                categoryReader.Close();

                using SqlCommand supplierCmd = new SqlCommand("SELECT Name FROM Suppliers", conn);
                using SqlDataReader supplierReader = supplierCmd.ExecuteReader();
                while (supplierReader.Read())
                {
                    cbSupplier.Items.Add(supplierReader["Name"].ToString());
                }
                supplierReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading combo boxes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            => ExecuteQuery("SELECT TOP 1 * FROM Products ORDER BY SupplyDate ASC");
        private void BtnShowAvgByCategory_Click(object sender, EventArgs e)
            => ExecuteQuery("SELECT Categories.Name, AVG(Products.Quantity) AS AverageQuantity FROM Products JOIN Categories ON Products.CategoryId = Categories.Id GROUP BY Categories.Name");

    }
}

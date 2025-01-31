using System.Globalization;
using WarehouseApp.Models;

namespace WarehouseApp
{
    public partial class AddEditProductForm : Form
    {
        private readonly Product product;
        private readonly List<Category> categories;
        private readonly List<Supplier> suppliers;

        public AddEditProductForm(Product product, List<Category> categories, List<Supplier> suppliers)
        {
            InitializeComponent();
            this.product = product;
            this.categories = categories;
            this.suppliers = suppliers;
        }

        private void AddEditProductForm_Load(object sender, EventArgs e)
        {
            cbCategory2.DataSource = categories;
            cbCategory2.DisplayMember = "Name";
            cbCategory2.ValueMember = nameof(Category.Id);

            cbSupplier2.DataSource = suppliers;
            cbSupplier2.DisplayMember = "Name";
            cbSupplier2.ValueMember = nameof(Supplier.Id);

            if (product.Id != 0)
            {
                textBoxName.Text = product.Name;
                cbCategory2.SelectedValue = product.CategoryId;
                cbSupplier2.SelectedValue = product.SupplierId;
                textBoxCostPrice.Text = product.CostPrice.ToString();
                textBoxQuantity.Text = product.Quantity.ToString();
                dtpSupplyDate.Value = product.SupplyDate;
            }
            else 
            {
                cbCategory2.Text = "";
                cbSupplier2.Text = "";
                dtpSupplyDate.Value = DateTime.Now;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Enter product name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool c, s, cp, q;

            c = int.TryParse(cbCategory2.SelectedValue.ToString(), out int CategoryId);
            s = int.TryParse(cbSupplier2.SelectedValue.ToString(), out int SupplierId);
            cp = Decimal.TryParse(textBoxCostPrice.Text, out decimal CostPrice);
            q = int.TryParse(textBoxQuantity.Text, out int Quantity);

            if (!c | !s | !cp | !q)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }
            
            product.Name = textBoxName.Text;
            product.CategoryId = CategoryId;
            product.SupplierId = SupplierId;
            product.CostPrice = CostPrice;
            product.Quantity = Quantity;
            product.SupplyDate = dtpSupplyDate.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

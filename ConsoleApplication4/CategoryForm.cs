using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBEntityFrameworkProject
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            ProdContext prodConxet = new ProdContext();
            prodConxet.Categories.Load();
            this.categoryBindingSource.DataSource = prodConxet.Categories.Local.ToBindingList();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(0) && e.RowIndex != -1)
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                {
                    ProdContext prodConxet = new ProdContext();
                    var products = prodConxet.Products;
                    var categories = prodConxet.Categories;

                    var cellValue = (int)dataGridView1.CurrentCell.Value;

                    var query = from p in products
                                join c in categories on p.CategoryId equals c.CategoryID
                                where p.CategoryId == cellValue
                                select p.Name;

                    String message = String.Join(Environment.NewLine, query.ToArray());
                    MessageBox.Show(message);
                }

        
            }
        }   
    }
}

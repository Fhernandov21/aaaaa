using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistematicoProgram.Model;
using SistematicoProgram.poco;

namespace SistematicoProgram
{
    public partial class FrmTabla : Form
    {
        public ProductoModel ProductoModel;
        DataTable products = new DataTable();
        
        public FrmTabla()
        {
            InitializeComponent();
        }


        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmTabla_Load(object sender, EventArgs e)
        {
            string[] titulos = new string[]{"ID", "NOMBRE", "N. EXISTENCIAS", "MODELO", "MARCA",
            "PRECIO DE VENTA", "DESCRIPCION", "URL"};
            foreach (string s in titulos)
            {
                products.Columns.Add(s);
            }
            if (ProductoModel.GetAll() != null)
            {
                foreach (Producto p in ProductoModel.GetAll())
                {
                    products.Rows.Add(p.toArray());
                }
                
                
            }
            dgvTable.DataSource = products;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            products .DefaultView.RowFilter = $"Id LIKE '{txtFilter.Text}%'";

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Any(child => child is FrmRegistrar))
            {
                return;
            }
            FrmRegistrar frmR = new FrmRegistrar();
            frmR.ProductoModel = ProductoModel;
            frmR.MdiParent = this.MdiParent;
            frmR.recibirProducto += new FrmRegistrar.recibir(ejecutar);
            frmR.Show();
            
            
        }
        public void ejecutar(Producto p)
        {
            products.Rows.Add(p.toArray());
            dgvTable.DataSource = products;
            
        }
        public void ejecutar2(Producto p)
        {
            p.Id = dgvTable.CurrentCell.RowIndex+1;
            products.Rows[dgvTable.CurrentCell.RowIndex].ItemArray = p.toArray();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Any(child => child is FrmRegistrar))
            {
                return;
            }
            FrmRegistrar frmR = new FrmRegistrar();
            frmR.ProductoModel = ProductoModel;
            frmR.MdiParent = this.MdiParent;
            frmR.updatear += new FrmRegistrar.recibir(ejecutar2);
            frmR.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            products.Rows.RemoveAt(dgvTable.CurrentCell.RowIndex);
            dgvTable.DataSource = products;
            ProductoModel.Remove(dgvTable.CurrentCell.RowIndex);
        }
    }
}

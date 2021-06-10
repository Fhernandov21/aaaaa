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

namespace SistematicoProgram
{
    public partial class FrmMDI : Form
    {
        public ProductoModel Producto_Var { get; set; }
        public FrmMDI()
        {
            InitializeComponent();
            Producto_Var = new ProductoModel();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Any(child => child is FrmTabla))
            {
                return;
            }
            FrmTabla frmTabla = new FrmTabla();
            frmTabla.ProductoModel = Producto_Var;
            frmTabla.MdiParent = this;
            frmTabla.Show();
            
        }

        private void vistaDeTablaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}

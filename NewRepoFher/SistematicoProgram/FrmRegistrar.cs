using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistematicoProgram.Enums;
using SistematicoProgram.Model;
using SistematicoProgram.poco;


namespace SistematicoProgram
{
    public partial class FrmRegistrar : Form
        
    {
        public ProductoModel ProductoModel;
        public delegate void recibir(Producto p);
        public event recibir recibirProducto;
        public event recibir updatear;
        
        public FrmRegistrar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmRegistrar_Load(object sender, EventArgs e)
        {
            cmbMarca.Items.AddRange(Enum.GetValues(typeof(TipoMarca))
                .Cast<Object>().ToArray());
            cmbMarca.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                if (recibirProducto != null)
                {
                    if (ProductoModel.GetAll() == null)
                    {
                        id = 1;
                    }
                    else
                    {
                        id = ProductoModel.GetAll().Length + 1;
                    }

                    string nombre = txtNombres.Text;
                    int.TryParse(txtNumeroExistencia.Text, out int nex);
                    int indexMarca = cmbMarca.SelectedIndex;
                    TipoMarca tipo_marca = (TipoMarca)Enum.GetValues(typeof(TipoMarca))
                        .GetValue(indexMarca);
                    string modelo = txtModelo.Text;
                    decimal.TryParse(txtPrecioVenta.Text, out decimal pv);
                    string descripcion = txtDescripcion.Text;
                    string imagenUrl = txtImagenUrl.Text;
                    Producto Prod = new Producto()
                    {
                        Id = id,
                        Nombres = nombre,
                        NExistencia = nex,
                        Marca = tipo_marca,
                        Modelo = modelo,
                        PrecioVenta = pv,
                        Descripcion = descripcion,
                        ImageURl = imagenUrl
                    };
                    ProductoModel.AddElement(Prod);
                    recibirProducto(Prod);
                    return;
                }



                if (ProductoModel.GetAll().Length > 1 && updatear != null)
                {
                        
                    string nombre = txtNombres.Text;
                    int.TryParse(txtNumeroExistencia.Text, out int nex);
                    int indexMarca = cmbMarca.SelectedIndex;
                    TipoMarca tipo_marca = (TipoMarca)Enum.GetValues(typeof(TipoMarca))
                        .GetValue(indexMarca);
                    string modelo = txtModelo.Text;
                    decimal.TryParse(txtPrecioVenta.Text, out decimal pv);
                    string descripcion = txtDescripcion.Text;
                    string imagenUrl = txtImagenUrl.Text;
                Producto Prod = new Producto()
                {
                            
                        Nombres = nombre,
                        NExistencia = nex,
                        Marca = tipo_marca,
                        Modelo = modelo,
                        PrecioVenta = pv,
                        Descripcion = descripcion,
                        ImageURl = imagenUrl
                    };
                    
                    updatear(Prod);
                    ProductoModel.UpdateElement(Prod);
                }


                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
        
    }
}

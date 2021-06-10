using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistematicoProgram.poco;

namespace SistematicoProgram.Model
{
    public  class ProductoModel
    {
        private Producto[] Producto_Var;
        public ProductoModel()
        {

        }
        
        public void Remove(int index)
        {

            if (Producto_Var == null)
            {
                return;
            }
            if (index < 0 || index >= Producto_Var.Length)
            {
                throw new IndexOutOfRangeException($"El inídice {index} está afuera de rango");
                return;
            }



            if (index >= Producto_Var.Length)
            {
                return;
            }

            if (Producto_Var.Length == 1 && index == 0)
            {
                Producto_Var = null;
                return;
            }

            Producto[] tmp = new Producto[Producto_Var.Length - 1];
            if (index == Producto_Var.Length - 1)
            {
                Array.Copy(Producto_Var, 0, tmp, 0, tmp.Length);
                Producto_Var = tmp;
                return;
            }

            if (index == 0)
            {
                Array.Copy(Producto_Var, index + 1, tmp, 0, tmp.Length);
                return;
            }

            Array.Copy(Producto_Var, 0, tmp, 0, index);
            Array.Copy(Producto_Var, index + 1, tmp, index, tmp.Length - index);
            Producto_Var = tmp;
            return;
        }
        public void UpdateElement( Producto p)
        {
            this.Producto_Var[p.Id] = p;
        }
        public void AddElement( Producto Prod)
        {
            if(Producto_Var == null)
            {
                Producto_Var = new Producto[1];
                Producto_Var[0] = Prod;
                return;
            }
            Producto[] tmp = new Producto[Producto_Var.Length + 1];
            Array.Copy(Producto_Var, tmp, Producto_Var.Length) ;
            tmp[tmp.Length - 1] = Prod;
            Producto_Var = tmp;


        }
        public Producto[] GetAll()
        {
            return Producto_Var;
        }
    }
}

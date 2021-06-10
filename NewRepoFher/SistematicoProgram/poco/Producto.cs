using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistematicoProgram.Enums;
namespace SistematicoProgram.poco
{
   public class Producto
    {
        public int Id { get; set; }
        public string Nombres { get; set;  }
        public int NExistencia { get; set;  }
        public string Modelo { get; set; }
        public TipoMarca Marca { get; set; }
        public decimal PrecioVenta { get; set;  }
        public string Descripcion { get; set;  }
        public string ImageURl { get; set; }
        
        public object [] toArray()
        {
            return new object[] {this.Id,this.Nombres ,this.NExistencia ,this.Modelo ,
            this.Marca ,this.PrecioVenta ,this.Descripcion ,this.ImageURl  };
        }
    }
}

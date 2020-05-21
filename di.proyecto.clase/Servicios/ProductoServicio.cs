using di.proyecto.clase.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase.Servicios
{
    public class ProductoServicio : ServicioGenerico<productos>
    {
        private DbContext contexto;

        
        /*
         * Constructor 
         */
        public ProductoServicio(DbContext context) : base(context)
        {
            contexto = context;
        }

        public int getLastId()
        {
            productos prd = contexto.Set<productos>().OrderByDescending(a => a.idProducto).FirstOrDefault();
            return prd.idProducto;
        }
    }
}

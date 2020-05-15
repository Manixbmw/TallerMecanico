using di.proyecto.clase.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase.Servicios
{
    public class VehiculoServicio : ServicioGenerico<vehiculo>
    {
        private DbContext contexto;

        public VehiculoServicio(DbContext context) : base(context)
        {
            contexto = context;
        }
        public int getLastId()
        {
            vehiculo art = contexto.Set<vehiculo>().OrderByDescending(a => a.id).FirstOrDefault();
            return art.id;
        }
    }
}

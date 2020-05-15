using di.proyecto.clase.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase.Servicios
{
    class AveriaServicio : ServicioGenerico<averia>
    {
        private DbContext contexto;

        public AveriaServicio(DbContext context) : base(context)
        {
            contexto = context;
        }

        public int getLastId()
        {
            averia art = contexto.Set<averia>().OrderByDescending(a => a.id).FirstOrDefault();
            return art.id;
        }
    }
}

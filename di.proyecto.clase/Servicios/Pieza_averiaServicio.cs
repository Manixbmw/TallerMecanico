using di.proyecto.clase.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase.Servicios
{
    class Pieza_averiaServicio: ServicioGenerico<piezas_averia>
    {
        private DbContext contexto;

        public Pieza_averiaServicio(DbContext context) : base(context)
        {
            contexto = context;
        }

        public int getLastId()
        {
            piezas_averia pie = contexto.Set<piezas_averia>().OrderByDescending(a => a.idAveria).FirstOrDefault();
            return pie.idAveria;
        }

    }
}

using di.proyecto.clase.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase.Servicios
{
    public class AlbaranServicio : ServicioGenerico<albaran>
    {
        private DbContext contexto;

        public AlbaranServicio(DbContext context) : base(context)
        {
            contexto = context;
        }
    }
}

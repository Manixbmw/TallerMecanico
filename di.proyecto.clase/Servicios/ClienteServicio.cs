using di.proyecto.clase.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase.Servicios
{
    public class ClienteServicio: ServicioGenerico<cliente>
    {
        private DbContext contexto;

        public ClienteServicio(DbContext context) : base(context)
        {
            contexto = context;
        }
        public int getLastId()
        {
            cliente art = contexto.Set<cliente>().OrderByDescending(a => a.id).FirstOrDefault();
            return art.id;
        }
    }
}

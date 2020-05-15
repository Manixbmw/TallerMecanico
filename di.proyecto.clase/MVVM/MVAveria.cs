using di.proyecto.clase.Modelo;
using di.proyecto.clase.Servicios;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace di.proyecto.clase.MVVM
{
    class MVAveria : MVBase
    {
        private tallerEntities tallerEnt;
        private AveriaServicio aveServ;
        private averia aveNueva;
        private ServicioGenerico<empleado> empServ;
        private ServicioGenerico<cliente> clieServ;
        private ServicioGenerico<vehiculo> vehServ;
        private ServicioGenerico<tipoaveria> tipoServ;
        private ServicioGenerico<estado> estadoServ;
        private ListCollectionView listaAver;
        public bool editar { get; set; }

        public MVAveria(tallerEntities ent)
        {
            tallerEnt = ent;
            inicializa();

        }

        private void inicializa()
        {           
            aveServ = new AveriaServicio(tallerEnt);
            listaAver = new ListCollectionView(aveServ.getAll().ToList());
            empServ = new ServicioGenerico<empleado>(tallerEnt);
            clieServ = new ServicioGenerico<cliente>(tallerEnt);
            vehServ = new ServicioGenerico<vehiculo>(tallerEnt);
            tipoServ = new ServicioGenerico<tipoaveria>(tallerEnt);
            estadoServ = new ServicioGenerico<estado>(tallerEnt);
            aveNueva = new averia();
        }
        public ListCollectionView listaAverias { get { return listaAver; } }
        public List<empleado> listaEmpleado { get { return empServ.getAll().ToList(); } }
        public List<cliente> listaCliente { get { return clieServ.getAll().ToList(); } }
        public List<vehiculo> listaVehiculo { get { return vehServ.getAll().ToList(); } }
        public List<tipoaveria> listaTipo { get { return tipoServ.getAll().ToList(); } }
        public List<estado> listaEstado { get { return estadoServ.getAll().ToList(); } }

        public averia averiaNueva
        {
            get { return aveNueva; }
            set
            {
                aveNueva = value;
                OnPropertyChanged("averiaNueva");
            }
        }

        public bool guarda()
        {
            bool correcto = true;
            aveServ.add(averiaNueva);
            averiaNueva.id = aveServ.getLastId() + 1;
            try
            {
                if (editar)
                {
                    aveServ.edit(averiaNueva);
                    listaAverias.EditItem(averiaNueva);
                    listaAverias.CommitEdit();

                }
                else
                {
                    aveServ.add(averiaNueva);

                }

                vehServ.save();
            }
            catch (DbUpdateException dbex)
            {
                correcto = false;
                System.Console.WriteLine(dbex.StackTrace);
                System.Console.WriteLine(dbex.InnerException);
            }

            return correcto;
        }

    }
}

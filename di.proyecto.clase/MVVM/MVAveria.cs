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
    public class MVAveria : MVBase
    {
        private tallerEntities tallerEnt;
        private AveriaServicio aveServ;
        private Pieza_averiaServicio pieServ;       
        private averia aveNueva;
        private averia aveSelect;
        private piezas_averia piNueva;
        private tipoaveria tipoAve;
        private estado estadoAve;
        private ServicioGenerico<empleado> empServ;
        private ServicioGenerico<cliente> clieServ;
        private ServicioGenerico<vehiculo> vehServ;
        private ServicioGenerico<tipoaveria> tipoServ;
        private ServicioGenerico<estado> estadoServ;
        private ServicioGenerico<productos> producServ;
        private ServicioGenerico<piezas_averia> pieAveServ;
        private ListCollectionView listaAver;
        private String txtFech;
        public bool editar { get; set; }

        public MVAveria(tallerEntities ent)
        {
            tallerEnt = ent;
            inicializa();

        }

        private void inicializa()
        {           
            aveServ = new AveriaServicio(tallerEnt);
            pieServ = new Pieza_averiaServicio(tallerEnt);
            listaAver = new ListCollectionView(aveServ.getAll().ToList());
            empServ = new ServicioGenerico<empleado>(tallerEnt);
            clieServ = new ServicioGenerico<cliente>(tallerEnt);
            vehServ = new ServicioGenerico<vehiculo>(tallerEnt);
            tipoServ = new ServicioGenerico<tipoaveria>(tallerEnt);
            estadoServ = new ServicioGenerico<estado>(tallerEnt);
            producServ = new ServicioGenerico<productos>(tallerEnt);
            pieAveServ = new ServicioGenerico<piezas_averia>(tallerEnt);
            aveNueva = new averia();            
            piNueva = new piezas_averia();
            tipoAve = new tipoaveria();
            estadoAve = new estado();
        }
        public ListCollectionView listaAverias { get { return listaAver; } }
        public List<empleado> listaEmpleado { get { return empServ.getAll().ToList(); } }
        public List<cliente> listaCliente { get { return clieServ.getAll().ToList(); } }
        public List<vehiculo> listaVehiculo { get { return vehServ.getAll().ToList(); } }
        public List<tipoaveria> listaTipo { get { return tipoServ.getAll().ToList(); } }
        public List<estado> listaEstado { get { return estadoServ.getAll().ToList(); } }
        public List<productos> listaProductos { get { return producServ.getAll().ToList(); } }
        public List<piezas_averia> listaPiezasAveria { get { return pieAveServ.getAll().ToList(); } }

        public averia averiaNueva
        {
            get { return aveNueva; }
            set
            {
                aveNueva = value;
                OnPropertyChanged("averiaNueva");
            }
        }
        public averia averiaSeleccionada
        {
            get { return aveSelect; }
            set
            {
                aveSelect = value; OnPropertyChanged("averiaSeleccionada");
            }
        }


        public piezas_averia piezaNueva
        {
            get { return piNueva; }
            set
            {
                piNueva = value;
                OnPropertyChanged("piezaNueva");
            }
        }


        public tipoaveria tipoSeleccionado
        {
            get { return tipoAve; }
            set
            {
                tipoAve = value;
                OnPropertyChanged("tipoSeleccionado");
            }
        }

        public estado estadoSeleccionado
        {
            get { return estadoAve; }
            set
            {
                estadoAve = value;
                OnPropertyChanged("estadoSeleccionado");
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

        public bool editaAveria()
        {
            bool correcto = true;
            aveServ.edit(averiaSeleccionada);
            try
            {
                aveServ.save();
            }
            catch (DbUpdateException dbex)
            {
                correcto = false;
                System.Console.WriteLine(dbex.StackTrace);
                System.Console.WriteLine(dbex.InnerException);
            }
            return correcto;
        }
        public bool addPieza()
        {
            bool correcto = true;
            aveServ.add(averiaSeleccionada);
            try
            {
                aveServ.save();
            }
            catch (DbUpdateException dbex)
            {
                correcto = false;
                System.Console.WriteLine(dbex.StackTrace);
                System.Console.WriteLine(dbex.InnerException);
            }
            return correcto;
        }

        public bool guardaPieza()
        {
            bool correcto = true;
            pieServ.add(piezaNueva);
            piezaNueva.idAveria = averiaSeleccionada.id;          
            
            try
            {
                aveServ.save();
            }
            catch (DbUpdateException dbex)
            {
                correcto = false;
                System.Console.WriteLine(dbex.StackTrace);
                System.Console.WriteLine(dbex.InnerException);
            }
            return correcto;
            
        }
        public String textoFiltroFechaIni
        {
            get { return txtFech; }
            set
            {
                txtFech = value;
                OnPropertyChanged("textoFiltroFechaIni");
            }
        }

    }
}

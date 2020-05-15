using System;
using di.proyecto.clase.Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using di.proyecto.clase.Servicios;
using System.Windows.Data;
using System.Data.Entity.Infrastructure;

namespace di.proyecto.clase.MVVM
{
    public class MVVehiculos : MVBase
    {
        private tallerEntities tallerEnt;
        private VehiculoServicio vehServ;
        private ServicioGenerico<cliente> clieServ;
        //Lista de modelos para trabajar con filtros en las tablas
        private ListCollectionView listaVehi;
        private vehiculo vehNuevo;
        public bool editar { get; set; }



        public MVVehiculos(tallerEntities ent)
        {
            
            tallerEnt = ent;
            vehServ = new VehiculoServicio(tallerEnt);
            listaVehi = new ListCollectionView(vehServ.getAll().ToList());
            clieServ = new ServicioGenerico<cliente>(tallerEnt);
            vehNuevo = new vehiculo();

        }


        public ListCollectionView listaVehiculos { get { return listaVehi; } }
        public List<cliente> listaCliente { get { return clieServ.getAll().ToList(); } }



        public vehiculo vehiculoNuevo
        {
            get { return vehNuevo; }
            set
            {
                vehNuevo = value;
                OnPropertyChanged("vehiculoNuevo");
            }
        }
        public bool guarda()
        {
            bool correcto = true;
            vehServ.add(vehiculoNuevo);
            vehNuevo.id = vehServ.getLastId() + 1;
            try
            {
                if (editar)
                {
                    vehServ.edit(vehiculoNuevo);
                    listaVehiculos.EditItem(vehiculoNuevo);
                    listaVehiculos.CommitEdit();

                }
                else
                {
                    vehServ.add(vehiculoNuevo);

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

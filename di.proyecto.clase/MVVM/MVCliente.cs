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
    public class MVCliente : MVBase
    {
        private tallerEntities tallerEnt;
        private ClienteServicio clnServ;
        private cliente clNuevo;
        private ServicioGenerico<vehiculo> vehServ;
        public bool editar { get; set; }


        private ListCollectionView listaClient;



        public MVCliente(tallerEntities ent)
        {
            
            tallerEnt = ent;
            clnServ = new ClienteServicio(tallerEnt);
            listaClient = new ListCollectionView(clnServ.getAll().ToList());
            vehServ = new ServicioGenerico<vehiculo>(tallerEnt);
            clNuevo = new cliente();

        }
        public ListCollectionView listaClientes { get { return listaClient; } }
        public List<vehiculo> listaVehiculos { get { return vehServ.getAll().ToList(); } }


        public cliente clienteNuevo
        {
            get { return clNuevo; }
            set
            {
                clNuevo = value;
                OnPropertyChanged("clienteNuevo");
            }
        }

        public bool guarda()
        {
            bool correcto = true;
            clnServ.add(clienteNuevo);
            clienteNuevo.id = clnServ.getLastId() + 1;
            try
            {
                if (editar)
                {
                    clnServ.edit(clienteNuevo);
                    listaClientes.EditItem(clienteNuevo);
                    listaClientes.CommitEdit();

                }
                else
                {
                    clnServ.add(clienteNuevo);

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


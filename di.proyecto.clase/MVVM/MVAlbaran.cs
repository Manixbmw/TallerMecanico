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
    public class MVAlbaran : MVBase
    {
        private tallerEntities tallerEnt;
        private AlbaranServicio albServ;
        private PedidosServicio pedidosServ;
        private ServicioGenerico<pedidos> pediServ;
        private ServicioGenerico<productos> prodServ;
        private pedidos pediSelec;
        private productos prdNuevo;

        private ListCollectionView listaAlba;

        public MVAlbaran(tallerEntities ent)
        {
            tallerEnt = ent;
            albServ = new AlbaranServicio(tallerEnt);
            pedidosServ = new PedidosServicio(tallerEnt);
            listaAlba = new ListCollectionView(albServ.getAll().ToList());
            pediServ = new ServicioGenerico<pedidos>(tallerEnt);
            prodServ = new ServicioGenerico<productos>(tallerEnt);
            prdNuevo = new productos();

        }
        public ListCollectionView listaAlbaranes { get { return listaAlba; } }
        public List<pedidos> listaPedidos { get { return pediServ.getAll().ToList(); } }
        public List<productos> listaProductos { get { return prodServ.getAll().ToList(); } }

        public pedidos pedidoSeleccionado
        {
            get { return pediSelec; }
            set
            {
                pediSelec = value; OnPropertyChanged("pedidoSeleccionado");
            }
        }

        public productos productoNuevo
        {
            get { return prdNuevo; }
            set
            {
                prdNuevo = value;
                OnPropertyChanged("productoNuevo");
            }
        }
        public bool borrarPedido()
        {
            bool correcto = true;
            pedidosServ.delete(pedidoSeleccionado);
            try
            {
                albServ.save();

            }
            catch (DbUpdateException dbex)
            {
                correcto = false;
                System.Console.WriteLine(dbex.StackTrace);
                System.Console.WriteLine(dbex.InnerException);
            }
            return correcto;
        }

        //public bool guarda()           
        //{
        //    var idProd = pedidoSeleccionado.albaran.First(a => a.idProducto);
        //    bool correcto = true;
        //    var prod = tallerEnt.productos.First(a => a.idProducto == idProd);            
           
        //    prod.cantidad =+(int)albaranSeleccionado.cantidad;
        //    prodServ.edit(prod);
        //    try
        //    {
        //        prodServ.save();
        //    }
        //    catch (DbUpdateException dbex)
        //    {
        //        correcto = false;
        //        System.Console.WriteLine(dbex.StackTrace);
        //        System.Console.WriteLine(dbex.InnerException);
        //    }
        //    return correcto;
        //}
    }
}

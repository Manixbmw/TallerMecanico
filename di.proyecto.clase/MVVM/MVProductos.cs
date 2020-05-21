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
   public class MVProductos : MVBase
    {
        private tallerEntities tallerEnt;
        private ProductoServicio prodServ;
        private productos prdNuevo;
        private productos prdSel;
        private int txtFiltro;
        private string txtNombre;
        private ListCollectionView listaProduc;
        private ServicioGenerico<tipoproducto> tipoProServ;
        private ServicioGenerico<proveedor> provoServ;
        public bool editar { get; set; }

        public MVProductos(tallerEntities ent)
        {
            tallerEnt = ent;
            prodServ = new ProductoServicio(tallerEnt);
            listaProduc = new ListCollectionView(prodServ.getAll().ToList());
            tipoProServ = new ServicioGenerico<tipoproducto>(tallerEnt);
            provoServ = new ServicioGenerico<proveedor>(tallerEnt);
            prdNuevo = new productos();

        }
        public ListCollectionView listaProductos { get { return listaProduc; } }
        public List<tipoproducto> listaTipos { get { return tipoProServ.getAll().ToList(); } }
        public List<proveedor> listaProveedor{ get { return provoServ.getAll().ToList(); } }

        public productos productoSeleccionado
        {
            get { return prdSel; }
            set
            {
                prdSel = value; OnPropertyChanged("productoSeleccionado");
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

        //Texto que filtra la tabla en funcion del nombre del modelo
        public int textoFiltroID
        {
            get { return txtFiltro; }
            set
            {
                txtFiltro = value;
                OnPropertyChanged("textoFiltroID");
            }
        }

        public string textoFiltroNombre
        {
            get { return txtNombre; }
            set
            {
                txtNombre = value;
                OnPropertyChanged("textoFiltroNombre");
            }
        }

        public bool editaProducto()
        {
            bool correcto = true;
            prodServ.edit(productoSeleccionado);
            try
            {
                prodServ.save();
            }
            catch (DbUpdateException dbex)
            {
                correcto = false;
                System.Console.WriteLine(dbex.StackTrace);
                System.Console.WriteLine(dbex.InnerException);
            }
            return correcto;
        }

        public bool borrarProducto()
        {
            bool correcto = true;
            prodServ.delete(productoSeleccionado);
            try
            {
                prodServ.save();

            }
            catch (DbUpdateException dbex)
            {
                correcto = false;
                System.Console.WriteLine(dbex.StackTrace);
                System.Console.WriteLine(dbex.InnerException);
            }
            return correcto;
        }

        public bool guarda()
        {
            bool correcto = true;
            prodServ.add(productoNuevo);
            productoNuevo.idProducto = prodServ.getLastId() + 1;
            try
            {
                if (editar)
                {
                    prodServ.edit(productoNuevo);
                    listaProductos.EditItem(productoNuevo);
                    listaProductos.CommitEdit();

                }
                else
                {
                    prodServ.add(productoNuevo);

                }

                prodServ.save();
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

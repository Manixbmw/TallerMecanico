using di.proyecto.clase.Modelo;
using di.proyecto.clase.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace di.proyecto.clase.MVVM
{
    class MVProductos : MVBase
    {
        private tallerEntities tallerEnt;
        private ProductoServicio prodServ;

        private ListCollectionView listaProduc;

        public MVProductos(tallerEntities ent)
        {
            tallerEnt = ent;
            prodServ = new ProductoServicio(tallerEnt);
            listaProduc = new ListCollectionView(prodServ.getAll().ToList());

        }
        public ListCollectionView listaProductos { get { return listaProduc; } }




    }
}

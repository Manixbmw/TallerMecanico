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
    class MVEmpleado : MVBase
    {
        private tallerEntities tallerEnt;
        private EmpleadoServicio empServ;
        //Lista de modelos para trabajar con filtros en las tablas
        private ListCollectionView listaEmpl;
        private ListCollectionView listaEmpl2;


        public MVEmpleado(tallerEntities ent)
        {
            tallerEnt = ent;
            empServ = new EmpleadoServicio(tallerEnt);
            listaEmpl = new ListCollectionView(empServ.getAll().ToList());
            listaEmpl2 = new ListCollectionView(empServ.getAll().ToList());

        }
        public ListCollectionView listaEmpleados { get { return listaEmpl; } }
        public ListCollectionView listaEmpleados2 { get { return listaEmpl2; } }


    }
}
       



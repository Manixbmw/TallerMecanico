using di.proyecto.clase.Modelo;
using di.proyecto.clase.Servicios;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;using di.proyecto.clase.Cache;

namespace di.proyecto.clase.MVVM
{
    public class MVEmpleado : MVBase
    {
        private tallerEntities tallerEnt;
        private EmpleadoServicio empServ;     
        private ListCollectionView listaEmpl;
        private empleado emplNuevo;
        private empleado emplSelec;       
        private empleado emplContra;       
        private ServicioGenerico<rol> rolServ;
        public bool editar { get; set; }


        public MVEmpleado(tallerEntities ent)
        {
            tallerEnt = ent;
            empServ = new EmpleadoServicio(tallerEnt);
            listaEmpl = new ListCollectionView(empServ.getAll().ToList());            
            rolServ = new ServicioGenerico<rol>(tallerEnt);
            emplNuevo = new empleado();
            emplSelec = new empleado();
            emplContra = new empleado();

        }
        public ListCollectionView listaEmpleados { get { return listaEmpl; } }
        public List<rol> listaRol { get { return rolServ.getAll().ToList(); } }

        public empleado empleadoNuevo
        {
            get { return emplNuevo; }
            set
            {
                emplNuevo = value;
                OnPropertyChanged("empleadoNuevo");
            }
        }

       

        public empleado empleadoSeleccionado
        {
            get { return emplSelec; }
            set
            {
                emplSelec = value; OnPropertyChanged("empleadoSeleccionado");
            }
        }

        public empleado empleadoContra
        {
            get { return emplContra; }
            set
            {
                emplContra = value; OnPropertyChanged("empleadoContra");
            }
        }

        

        public bool guarda()
        {
            bool correcto = true;
            empServ.add(empleadoNuevo);
            empleadoNuevo.id = empServ.getLastId() + 1;
            try
            {
                if (editar)
                {
                    empServ.edit(empleadoNuevo);
                    listaEmpleados.EditItem(empleadoNuevo);
                    listaEmpleados.CommitEdit();

                }
                else
                {
                    empServ.add(empleadoNuevo);

                }

                empServ.save();
            }
            catch (DbUpdateException dbex)
            {
                correcto = false;
                System.Console.WriteLine(dbex.StackTrace);
                System.Console.WriteLine(dbex.InnerException);
            }

            return correcto;
        }

        public bool editaEmpleado()
        {
            bool correcto = true;
            empServ.edit(empleadoSeleccionado);
            try
            {
                empServ.save();
            }
            catch (DbUpdateException dbex)
            {
                correcto = false;
                System.Console.WriteLine(dbex.StackTrace);
                System.Console.WriteLine(dbex.InnerException);
            }
            return correcto;
        }

        public bool editarContra()
        {
            bool correcto = true;
            //empServ.edit(empleadoContra);
            //var original = empServ.SQLQuery("UPDATE  taller.empleado SET password= '"+UserLoginCache.PasswordNueva+"'WHERE nombre = '"+ UserLoginCache.User );
            var emple = tallerEnt.empleado.First(a => a.usuario == UserLoginCache.User);
            emple.password = empleadoContra.password;
            empServ.edit(emple);
            try
            {
                empServ.save();
            }
            catch (DbUpdateException dbex)
            {
                correcto = false;
                System.Console.WriteLine(dbex.StackTrace);
                System.Console.WriteLine(dbex.InnerException);
            }
            return correcto;
        }

        public bool borrarEmpleado()
        {
            bool correcto = true;
            empServ.delete(empleadoSeleccionado);
            try
            {
                empServ.save();

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
       



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using di.proyecto.clase.Modelo;

namespace di.proyecto.clase.Servicios

{
    /*
     * Clase que contiene las reglas de negocio propias de la tabla usuario
     */
    public class EmpleadoServicio : ServicioGenerico<empleado>
    {
        private DbContext contexto;
        /*
         * Se almacena el usuario que ha iniciado sesión
         */
        public empleado empleLogin { get; set; }
        /*
         * Constructor 
         */
        public EmpleadoServicio(DbContext context) : base(context)
        {
            contexto = context;
        }

        /*
         * Método que comprueba las credenciales del usuario en la base de datos
         */
        public Boolean login(String user, String pass)
        {
            Boolean correcto = true;
            try
            {
                empleLogin = contexto.Set<empleado>().Where(u => u.usuario == user).FirstOrDefault();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
            }
            if (empleLogin == null)
            {
                correcto = false;
            }
            else if (!empleLogin.usuario.Equals(user) || !empleLogin.password.Equals(pass))
            {
                correcto = false;
            }

            return correcto;
        }
        /*
         * Comprueba si en la base de datos existe un usuario con ese login
         * El login de un usuario debe de ser único
         */
        public Boolean usuarioUnico(string usu)
        {
            bool unico = true;
            if (contexto.Set<empleado>().Where(u => u.usuario == usu).Count() > 0)
            {
                unico = false;
            }
            return unico;
        }
        /*
         * Devuelve un usuario en función del username pasado
         */
       

    }
}

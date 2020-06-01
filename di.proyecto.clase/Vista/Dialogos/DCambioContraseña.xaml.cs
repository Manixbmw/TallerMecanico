using di.proyecto.clase.Modelo;
using di.proyecto.clase.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using di.proyecto.clase.Cache;

namespace di.proyecto.clase.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DCambioContraseña.xaml
    /// </summary>
    public partial class DCambioContraseña : Window
    {
        tallerEntities tallerEnt;
        
        private MVEmpleado mVEmpleado;

        public char PasswordChar { get; set; }

        public DCambioContraseña(tallerEntities ent)
        {
            InitializeComponent();      
            tallerEnt = ent;
            mVEmpleado = new MVEmpleado(tallerEnt);
            DataContext = mVEmpleado;
        }

        private void BtnCambiar_Click(object sender, RoutedEventArgs e)
        {
            string ContraAntigua = passVieja.Text;
            string ContrasNueva = passNueva.Text;
            string ContraRepe = passRepe.Text;
            //almaceno la nuevas pass en el cache
            UserLoginCache.PasswordNueva = (ContrasNueva);
            if (!string.IsNullOrEmpty(ContraAntigua) && !string.IsNullOrEmpty(ContrasNueva) && !string.IsNullOrEmpty(ContraRepe))
            {
                if (UserLoginCache.Password == ContraAntigua)
                {
                    if (ContrasNueva == ContraRepe)
                    {
                        //Cambiamos la contraseña
                        if (mVEmpleado.editarContra())
                        {
                            MessageBox.Show("Contraseña cambiada con exito");
                            DialogResult = true;
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                       
                       
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no coinciden");
                    }
                }
            }
            else
            {
                MessageBox.Show("Rellena los huecos");
            }            
        }
    }
}

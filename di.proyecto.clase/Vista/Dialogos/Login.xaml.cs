using di.proyecto.clase.Modelo;
using di.proyecto.clase.Servicios;
using di.proyecto.clase.Vista;
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
	/// Lógica de interacción para Login.xaml
	/// </summary>
	public partial class Login : Window
	{
		private tallerEntities tallerEnt;
		private EmpleadoServicio empServ;
        

        public Login()
		{
			InitializeComponent();
            tallerEnt = new tallerEntities();
            empServ = new EmpleadoServicio(tallerEnt);

		}

		private void BtnLogin_Click(object sender, RoutedEventArgs e)
		{
			string txt = username.Text;
			string pass = password.Password;
            //Cargamos en cache el Rol y el Usario
            UserLoginCache.Rol = (empServ.getRol(txt));
            UserLoginCache.User = (txt);

            if (!string.IsNullOrEmpty(txt) && !string.IsNullOrEmpty(pass))
			{
				if (empServ.login(txt, pass) == true)
				{
					MainWindow ventanaPrincipal = new MainWindow(tallerEnt);
					ventanaPrincipal.Show();
                   
                    

                    this.Close();
				}
				else
				{
					MessageBox.Show("Usuario o contraseña incorrectos");
				}
			}
			else
			{
				MessageBox.Show("Rellena los huecos");
			}

		}

        private void BtnWindows_Click(object sender, RoutedEventArgs e)
        {
            MainWindow menu = new MainWindow(tallerEnt);
            menu.Show();
            this.Close();


        }
    }
}

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

namespace di.proyecto.clase.Vista.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para UCVehiculoNuevo.xaml
    /// </summary>
    public partial class UCVehiculoNuevo : UserControl
    {
        tallerEntities tallerEnt;
        private MVVehiculos mvVehiculo;
        public bool editar { get; set; }

        public UCVehiculoNuevo(tallerEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvVehiculo = new MVVehiculos(tallerEnt);
            this.DataContext = mvVehiculo;

            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvVehiculo.OnErrorEvent));
            mvVehiculo.btnGuardar = btnGuardarVehiculo;
        }     

        

        private void BtnGuardarVehiculo_Click(object sender, RoutedEventArgs e)
        {
            mvVehiculo.editar = editar;
            if (mvVehiculo.IsValid(this))
            {              
                if (mvVehiculo.guarda())
                {
                    MessageBox.Show("Todo correcto");
                    
                }
                else
                {
                    MessageBox.Show("Problema con la base de datos, no se ha añadido", "Gestion vehiculos", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Tienes campos obligatorios");
            }
        }
    }
}

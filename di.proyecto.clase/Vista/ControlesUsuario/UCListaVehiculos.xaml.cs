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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace di.proyecto.clase.Vista.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para UCListaVehiculos.xaml
    /// </summary>
    public partial class UCListaVehiculos : UserControl
    {
        tallerEntities tallerEnt;
        private MVVehiculos mvVehiculo;

        public UCListaVehiculos(tallerEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvVehiculo = new MVVehiculos(tallerEnt);
            DataContext = mvVehiculo;

        }
    }
}

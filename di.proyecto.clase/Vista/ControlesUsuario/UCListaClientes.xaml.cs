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
    /// Lógica de interacción para UCListaClientes.xaml
    /// </summary>
    public partial class UCListaClientes : UserControl
    {
        tallerEntities tallerEnt;
        private MVCliente mVCliente;

        public UCListaClientes(tallerEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            mVCliente = new MVCliente(tallerEnt);
            DataContext = mVCliente;

        }
    }
}

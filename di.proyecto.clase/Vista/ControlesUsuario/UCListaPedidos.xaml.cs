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
    /// Lógica de interacción para UCListaPedidos.xaml
    /// </summary>
    public partial class UCListaPedidos : UserControl
    {
        tallerEntities tallerEnt;
        private MVAlbaran mvAlbaran;

        public UCListaPedidos(tallerEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvAlbaran = new MVAlbaran(tallerEnt);
            DataContext = mvAlbaran;
        }

        

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            dgListaPedidos.Items.Filter = null;
            dgListaPedidos.Items.Refresh();
        }

        private void BtnAnyadirPro_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaPedidos.SelectedItem != null)
            {
                
                if (dgListaPedidos.SelectedItem is pedidos)
                {

                    if (!(MessageBox.Show("Quieres añadirlo?", "Porfavor confirma.", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                    {
                        // Cancel Delete.              
                        e.Handled = true;
                    }
                    else
                    {
                        //Añadimos los productos al stock y lo borramos de la tabla albaran
                        mvAlbaran.pedidoSeleccionado = (pedidos)dgListaPedidos.SelectedItem;
                        //mvAlbaran.guarda();
                        mvAlbaran.borrarPedido();
                        MessageBox.Show("Todo correcto");
                    }
                    dgListaPedidos.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto antes de añadirlo", "GESTIÓN PRODUCTOS", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

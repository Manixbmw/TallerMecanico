using di.proyecto.clase.Modelo;
using di.proyecto.clase.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace di.proyecto.clase.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DEditarProducto.xaml
    /// </summary>
    public partial class DEditarProducto : Window
    {

        
        private MVProductos mvProductos;
        public bool editar { get; set; }


        public DEditarProducto(MVProductos MV)
        {
            InitializeComponent();
            mvProductos = MV;
            DataContext = mvProductos;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnGuardarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (mvProductos.editaProducto())
            {
                MessageBox.Show("Producto editado correctamente", "GESTIÓN DE PRODUCTOS", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("ERROR!!! NO SE HA PODIDO EDITAR", "GESTIÓN DE PRODUCTOS", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

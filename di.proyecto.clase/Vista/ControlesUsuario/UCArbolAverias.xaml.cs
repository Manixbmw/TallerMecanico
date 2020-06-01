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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace di.proyecto.clase.Vista.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para UCArbolAverias.xaml
    /// </summary>
    public partial class UCArbolAverias : UserControl
    {
        tallerEntities tallerEnt;
        private MVAveria mvAveria;
        private averia ave;

        public UCArbolAverias(tallerEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvAveria = new MVAveria(tallerEnt);
            DataContext = mvAveria;
        }

        private void TreeAverias_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (treeAverias.SelectedItem is averia)
            {               
                ave = (averia)treeAverias.SelectedItem;
                mvAveria.averiaSeleccionada = ave;
                dgPiezasAve.ItemsSource = ave.piezas_averia.ToList();

            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (mvAveria.editaAveria())
            {
                MessageBox.Show("Averia editada correctamente", "GESTIÓN DE AVERIAS", MessageBoxButton.OK, MessageBoxImage.Information);
               
            }
            else
            {
                MessageBox.Show("ERROR!!! NO SE HA PODIDO EDITAR", "GESTIÓN DE AVERIAS", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAnyadirProducto_Click(object sender, RoutedEventArgs e)
        {
            if (mvAveria.guardaPieza())
            {
                MessageBox.Show("Pieza añadida correctamente", "GESTIÓN DE PIEZAS_AVERIAS", MessageBoxButton.OK, MessageBoxImage.Information);
                ave.piezas_averia.ToList().Add(mvAveria.piezaNueva);
                dgPiezasAve.ItemsSource = ave.piezas_averia.ToList();

            }
            else
            {
                MessageBox.Show("ERROR!!! NO SE HA PODIDO AÑADIR", "GESTIÓN DE PIEZAS_AVERIAS", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

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
                averia ave = (averia)treeAverias.SelectedItem;
                mvAveria.averiaNueva = ave;
                dgPiezasAve.ItemsSource = ave.piezas_averia;

            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ComboCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtObservaciones_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtDescrip_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

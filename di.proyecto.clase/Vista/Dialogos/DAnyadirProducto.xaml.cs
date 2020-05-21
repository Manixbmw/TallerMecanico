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
    /// Lógica de interacción para DAnyadirProducto.xaml
    /// </summary>
    public partial class DAnyadirProducto : Window
    {

        tallerEntities tallerEnt;
        private MVProductos mvProductos;
        public bool editar { get; set; }


        public DAnyadirProducto(tallerEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvProductos = new MVProductos(tallerEnt);
            DataContext = mvProductos;

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnGuardarProducto_Click(object sender, RoutedEventArgs e)
        {
            mvProductos.editar = editar;
            if (mvProductos.IsValid(this))
            {
                if (mvProductos.guarda())
                {
                    MessageBox.Show("Todo correcto");
                }
                else
                {
                    MessageBox.Show("Problema con la base de datos, no se ha añadido", "Gestion productos", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Tienes campos obligatorios");
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

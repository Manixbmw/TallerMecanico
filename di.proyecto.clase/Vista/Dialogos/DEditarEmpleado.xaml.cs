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
    /// Lógica de interacción para DEditarEmpleado.xaml
    /// </summary>
    public partial class DEditarEmpleado : Window
    {
        private MVEmpleado MVEmpleado;
        public bool editar { get; set; }

        public DEditarEmpleado(MVEmpleado mv)
        {
            InitializeComponent();
            MVEmpleado = mv;
            DataContext = MVEmpleado;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnGuardarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            if (MVEmpleado.editaEmpleado())
            {
                MessageBox.Show("Empleado editado correctamente", "GESTIÓN DE EMPLEADOS", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("ERROR!!! NO SE HA PODIDO EDITAR", "GESTIÓN DE EMPLEADOS", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

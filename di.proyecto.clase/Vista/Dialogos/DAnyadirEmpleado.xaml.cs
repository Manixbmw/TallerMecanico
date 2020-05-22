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
    /// Lógica de interacción para DAnyadirEmpleado.xaml
    /// </summary>
    public partial class DAnyadirEmpleado : Window
    {

        tallerEntities tallerEnt;
        private MVEmpleado mvEmpl;
        public bool editar { get; set; }

        public DAnyadirEmpleado(tallerEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvEmpl = new MVEmpleado(tallerEnt);
            DataContext = mvEmpl;

            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvEmpl.OnErrorEvent));
            mvEmpl.btnGuardar = btnGuardarEmpleado;

        }

        //Solo se pueda poner numeros en la entrada de texto
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        
        private void BtnGuardarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            mvEmpl.editar = editar;
            if (mvEmpl.IsValid(this))
            {
                if (mvEmpl.guarda())
                {
                    MessageBox.Show("Todo correcto");
                }
                else
                {
                    MessageBox.Show("Problema con la base de datos, no se ha añadido", "Gestion empleados", MessageBoxButton.OK);
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

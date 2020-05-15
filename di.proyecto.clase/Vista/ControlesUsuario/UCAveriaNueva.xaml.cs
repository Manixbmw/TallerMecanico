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
    /// Lógica de interacción para UCAveriaNueva.xaml
    /// </summary>
    public partial class UCAveriaNueva : UserControl
    {
        tallerEntities tallerEnt;
        private MVAveria mvAveria;
        public bool editar { get; set; }

        public UCAveriaNueva(tallerEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvAveria = new MVAveria(tallerEnt);            
            this.DataContext = mvAveria;

            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvAveria.OnErrorEvent));
            mvAveria.btnGuardar = btnGuardarAveria;

        }       

        

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnGuardarAveria_Click(object sender, RoutedEventArgs e)
        {
            mvAveria.editar = editar;
            if (mvAveria.IsValid(this))
            {
                if (mvAveria.guarda())
                {
                    MessageBox.Show("Todo correcto");
                }
                else
                {
                    MessageBox.Show("Problema con la base de datos, no se ha añadido", "Gestion averias", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Tienes campos obligatorios");
            }
        }
    }
}

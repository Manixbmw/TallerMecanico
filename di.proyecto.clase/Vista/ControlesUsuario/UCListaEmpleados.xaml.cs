using di.proyecto.clase.Modelo;
using di.proyecto.clase.MVVM;
using di.proyecto.clase.Vista.Dialogos;
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
    /// Lógica de interacción para UCListaEmpleados.xaml
    /// </summary>
    public partial class UCListaEmpleados : UserControl
    {

        tallerEntities tallerEnt;
        private MVEmpleado mvEmpl;

        public UCListaEmpleados(tallerEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvEmpl = new MVEmpleado(tallerEnt);
            DataContext = mvEmpl;

            
        }

        private void BtnAnyadir_Click(object sender, RoutedEventArgs e)
        {
            DAnyadirEmpleado diag = new DAnyadirEmpleado(tallerEnt);
            diag.ShowDialog();
            dgListaEmpleados.Items.Refresh();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaEmpleados.SelectedItem != null)
            {
                if (dgListaEmpleados.SelectedItem is empleado)
                {
                    mvEmpl.empleadoSeleccionado = (empleado)dgListaEmpleados.SelectedItem;
                    DEditarEmpleado diag = new DEditarEmpleado(mvEmpl);
                    diag.ShowDialog();
                    // Comprobamos que todo ha ido bien
                    if ((bool)diag.DialogResult)
                    {
                        dgListaEmpleados.Items.Refresh();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto antes de editarlo", "GESTIÓN PRODUCTOS", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnBorrar_Click(object sender, RoutedEventArgs e)
        {

            if (dgListaEmpleados.SelectedItem != null)
            {
                if (dgListaEmpleados.SelectedItem is empleado)
                {

                    if (!(MessageBox.Show("Estas seguro que quieres borrarlo?", "Porfavor confirma.", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                    {
                        // Cancel Delete.              
                        e.Handled = true;
                    }
                    else
                    {
                        //borramos lo que queremos
                        mvEmpl.empleadoSeleccionado = (empleado)dgListaEmpleados.SelectedItem;
                        mvEmpl.borrarEmpleado();

                    }
                    dgListaEmpleados.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto antes de borrarlo", "GESTIÓN PRODUCTOS", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            dgListaEmpleados.Items.Filter = null;
            dgListaEmpleados.Items.Refresh();
        }
    }
}

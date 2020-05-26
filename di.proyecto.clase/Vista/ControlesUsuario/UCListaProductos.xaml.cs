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
    /// Lógica de interacción para UCListaProductos.xaml dgListaProductos
    /// </summary>
    public partial class UCListaProductos : UserControl
    {
        tallerEntities tallerEnt;
        private MVProductos mvProductos;


        public UCListaProductos(tallerEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvProductos = new MVProductos(tallerEnt);
            DataContext = mvProductos;
        }

        private void TxtFiltroID_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgListaProductos.Items.Filter = new Predicate<object>(FiltroId);
        }

        private void TxtFiltroNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgListaProductos.Items.Filter = new Predicate<object>(FiltroNombre);
        }

        private bool FiltroId(object item)
        {
            bool esta = false;
            productos prod;

            if (item != null)
            {
                prod = (productos)item;
                if (!string.IsNullOrEmpty(txtFiltroID.Text)) //Si hemos escrito algo en el campo de texto
                {                   
                    if (((prod.idProducto.ToString() != null) && (prod.idProducto.ToString().StartsWith(mvProductos.textoFiltroID.ToString()))))
                    {
                        esta = true;
                    }
                }

            }
            return esta;
        }
        private bool FiltroNombre(object item)
        {
            bool esta = false;
            productos prod;

            if (item != null)
            {
                prod = (productos)item;
                if (!string.IsNullOrEmpty(txtFiltroNombre.Text))
                {
                    if ((!string.IsNullOrEmpty(prod.nombre)) && (prod.nombre.ToUpper().StartsWith(mvProductos.textoFiltroNombre.ToUpper())))
                    {
                        esta = true;
                    }
                }

            }
            return esta;
        }



        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            dgListaProductos.Items.Filter = null;
            dgListaProductos.Items.Refresh();
        }

        private void BtnAnyadir_Click(object sender, RoutedEventArgs e)
        {
            DAnyadirProducto diag = new DAnyadirProducto(tallerEnt);
            diag.ShowDialog();
            dgListaProductos.Items.Refresh();
        }

        private void BtnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaProductos.SelectedItem != null)
            {
                if (dgListaProductos.SelectedItem is productos)
                {

                    if (!(MessageBox.Show("Estas seguro que quieres borrarlo?", "Porfavor confirma.", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                    {
                        // Cancel Delete.              
                        e.Handled = true;
                    }
                    else
                    {
                        //borramos lo que queremos
                        mvProductos.productoSeleccionado = (productos)dgListaProductos.SelectedItem;
                        mvProductos.borrarProducto();

                    }
                    dgListaProductos.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto antes de borrarlo", "GESTIÓN PRODUCTOS", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaProductos.SelectedItem != null)
            {
                if (dgListaProductos.SelectedItem is productos)
                {
                    mvProductos.productoSeleccionado = (productos)dgListaProductos.SelectedItem;
                    DEditarProducto diag = new DEditarProducto(mvProductos);
                    diag.ShowDialog();
                    // Comprobamos que todo ha ido bien
                    if ((bool)diag.DialogResult)
                    {
                        dgListaProductos.Items.Refresh();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto antes de editarlo", "GESTIÓN PRODUCTOS", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

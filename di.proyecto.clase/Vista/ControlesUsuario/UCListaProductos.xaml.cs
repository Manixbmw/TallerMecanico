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
            dgListaProductos.Items.Filter = new Predicate<object>(FiltroCombinado);
        }

        private void TxtFiltroNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgListaProductos.Items.Filter = new Predicate<object>(FiltroCombinado);
        }

        private bool FiltroCombinado(object item) 
        {
            bool esta = false;
            
            productos prod;
            prod = (productos)item;
            
            if (item != null)
            {
                if (!string.IsNullOrEmpty(txtFiltroID.Text)) //Si hemos escrito algo en el campo de texto
                {

                    //solo filtra si exactamente igual si pones 5 no sale 50 
                    if ((prod.idProducto.Equals(mvProductos.textoFiltroID))) 
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
        }

        private void BtnAnyadir_Click(object sender, RoutedEventArgs e)
        {
            DAnyadirProducto diag = new DAnyadirProducto(tallerEnt);
            diag.ShowDialog();
        }

        private void BtnBorrar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

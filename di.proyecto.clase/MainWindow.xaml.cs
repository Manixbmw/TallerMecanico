using BeautySolutions.View.ViewModel;
using di.proyecto.clase.Modelo;
using di.proyecto.clase.Vista.ControlesUsuario;
using di.proyecto.clase.Vista.Dialogos;
using MaterialDesignThemes.Wpf;
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

namespace di.proyecto.clase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        tallerEntities tallerEnt;
        public MainWindow(tallerEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;

            var menuVehiculos = new List<SubItem>();
            var item6 = new ItemMenu("Vehiculos", menuVehiculos, PackIconKind.Car);
            menuVehiculos.Add(new SubItem("Nuevo", new UCVehiculoNuevo(ent)));
            menuVehiculos.Add(new SubItem("Cliente", new UCClienteNuevo(ent)));
            menuVehiculos.Add(new SubItem("Lista", new UCListaVehiculos(ent)));            


            var menuAverias = new List<SubItem>();
            var item1 = new ItemMenu("Averias", menuAverias, PackIconKind.Schedule);
            menuAverias.Add(new SubItem("Nueva",new UCAveriaNueva(ent)));
            menuAverias.Add(new SubItem("Gestion",new UCArbolAverias(ent)));
            menuAverias.Add(new SubItem("Solucion"));
            menuAverias.Add(new SubItem("Historial",new UCListaAverias(ent)));
            menuAverias.Add(new SubItem("Factura"));



            var menuGestion = new List<SubItem>();
            var item2 = new ItemMenu("Gestion de Stock", menuGestion, PackIconKind.FileReport);
            menuGestion.Add(new SubItem("Nuevo Pedido",new UCListaPedidos(ent)));
            menuGestion.Add(new SubItem("Productos"));
            menuGestion.Add(new SubItem("Inventario",new UCListaProductos(ent)));


            var menuTareas = new List<SubItem>();
            var item3 = new ItemMenu("Tareas", menuTareas, PackIconKind.ShoppingBasket);
            menuTareas.Add(new SubItem("Pendientes"));
            menuTareas.Add(new SubItem("Finalizadas"));
            menuTareas.Add(new SubItem("Resumen"));



            var menuEmpleados = new List<SubItem>();
            var item4 = new ItemMenu("Empleados", menuEmpleados, PackIconKind.ScaleBalance);
            menuEmpleados.Add(new SubItem("Gestion"));
            menuEmpleados.Add(new SubItem("Listado"));
        



            Menu.Children.Add(new UserControlMenuItem(item6, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));
        }

        internal void SwichScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                central.Children.Clear();
                central.Children.Add(screen);
            }
        }

        private void Desconectar_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}

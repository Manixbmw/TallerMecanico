﻿using BeautySolutions.View.ViewModel;
using di.proyecto.clase.Cache;
using di.proyecto.clase.Modelo;
using di.proyecto.clase.Vista.ControlesUsuario;
using di.proyecto.clase.Vista.Dialogos;
using di.proyecto.clase.Vista.Graficos;
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

            int rol = UserLoginCache.Rol;            

            var menuVehiculos = new List<SubItem>();
            var item1 = new ItemMenu("Vehículos", menuVehiculos, PackIconKind.Car);
            menuVehiculos.Add(new SubItem("Nuevo", new UCVehiculoNuevo(ent)));            
            menuVehiculos.Add(new SubItem("Lista", new UCListaVehiculos(ent)));

            var menuCliente = new List<SubItem>();
            var item2 = new ItemMenu("Cliente", menuCliente, PackIconKind.Account);
            menuCliente.Add(new SubItem("Nuevo", new UCClienteNuevo(ent)));
            menuCliente.Add(new SubItem("Lista", new UCListaClientes(ent)));

            var menuAverias = new List<SubItem>();
            var item3 = new ItemMenu("Averías", menuAverias, PackIconKind.Cog);
            menuAverias.Add(new SubItem("Nueva", new UCAveriaNueva(ent)));
            menuAverias.Add(new SubItem("Gestión", new UCArbolAverias(ent)));
            menuAverias.Add(new SubItem("Lista", new UCListaAverias(ent)));
            menuAverias.Add(new SubItem("Gráficos", new GraficosReparaciones(ent)));

            var menuGestion = new List<SubItem>();
            var item4 = new ItemMenu("Gestión de Stock", menuGestion, PackIconKind.FileReport);
            menuGestion.Add(new SubItem("Nuevo Pedido",new UCListaPedidos(ent)));           
            //menuGestion.Add(new SubItem("Inventario",new UCListaProductos(ent)));
            menuGestion.Add(new SubItem("Informe",new InformeInventario(ent)));
           
           

            var menuEmpleados = new List<SubItem>();
            var item5 = new ItemMenu("Empleados", menuEmpleados, PackIconKind.AccountMultiple);
            //menuEmpleados.Add(new SubItem("Gestion",new UCListaEmpleados(ent)));           

            
            
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));
            Menu.Children.Add(new UserControlMenuItem(item5, this));

            switch (rol)
            {
                //1 Empleado
                case 1:
                    menuGestion.Add(new SubItem("Inventario", new UCListaProductos(ent)));

                    break;
                //2 Encargado
                case 2:
                    menuGestion.Add(new SubItem("Inventario", new UCListaProductos(ent)));

                    break;
                //3 gerente
                case 3:
                    menuGestion.Add(new SubItem("Inventario", new UCListaProductos(ent)));
                    menuEmpleados.Add(new SubItem("Gestion", new UCListaEmpleados(ent)));
                    break;

            }
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

        private void CambiarContra_Click(object sender, RoutedEventArgs e)
        {
            DCambioContraseña diag = new DCambioContraseña(tallerEnt);
            diag.ShowDialog();
        }
    }
}

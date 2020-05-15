using di.proyecto.clase.Modelo;
using di.proyecto.clase.MVVM;
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
using System.Windows.Shapes;

namespace di.proyecto.clase.Vista.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para UCClienteNuevo.xaml
    /// </summary>
    public partial class UCClienteNuevo : UserControl
    {
        tallerEntities tallerEnt;
        private MVCliente mvCliente;
        public bool editar { get; set; }

        public UCClienteNuevo(tallerEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvCliente = new MVCliente(tallerEnt);
            this.DataContext = mvCliente;

            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvCliente.OnErrorEvent));
            mvCliente.btnGuardar = btnGuardarCliente;
        }

        

        private void BtnGuardarCliente_Click(object sender, RoutedEventArgs e)
        {
            mvCliente.editar = editar;
            if (mvCliente.IsValid(this))
            {
                if (mvCliente.guarda())
                {
                    MessageBox.Show("Todo correcto");

                }
                else
                {
                    MessageBox.Show("Problema con la base de datos, no se ha añadido", "Gestion clientes", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Tienes campos obligatorios");
            }
        }
    }
}

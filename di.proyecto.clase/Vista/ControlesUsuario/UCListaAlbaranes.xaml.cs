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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace di.proyecto.clase.Vista.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para UCListaAlbaranes.xaml
    /// </summary>
    public partial class UCListaAlbaranes : UserControl
    {
        tallerEntities tallerEnt;
        private MVAlbaran mvAlbaran;

        public UCListaAlbaranes(tallerEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            mvAlbaran = new MVAlbaran(tallerEnt);
            DataContext = mvAlbaran;
        }
    }
}

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
    /// Lógica de interacción para UCListaAverias.xaml
    /// </summary>
    public partial class UCListaAverias : UserControl
    {
        tallerEntities tallerEnt;
        private MVAveria mvAveria;
        private List<Predicate<averia>> criterios = new List<Predicate<averia>>();
        private Predicate<object> Filtro;

        public UCListaAverias(tallerEntities ent)
        {           
            InitializeComponent();
            tallerEnt = ent;
            mvAveria = new MVAveria(tallerEnt);
            DataContext = mvAveria;
            Filtro = new Predicate<object>(FiltroFechas);
        }

        private void CheckTipo_Checked(object sender, RoutedEventArgs e)
        {
            if (checkTipo.IsChecked == true)
            {
                checkTipo.IsChecked = false;
                mvAveria.listaAverias.GroupDescriptions.Add(new PropertyGroupDescription("tipo"));
            }
            else
            {
                mvAveria.listaAverias.GroupDescriptions.Add(new PropertyGroupDescription("tipo"));
            }
        }

        private void CheckTipo_Unchecked(object sender, RoutedEventArgs e)
        {
            mvAveria.listaAverias.GroupDescriptions.Clear();
        }

        private void CheckEstado_Checked(object sender, RoutedEventArgs e)
        {
            if (checkTipo.IsChecked == true)
            {
                checkTipo.IsChecked = false;
                mvAveria.listaAverias.GroupDescriptions.Add(new PropertyGroupDescription("estado"));
            }
            else
            {
                mvAveria.listaAverias.GroupDescriptions.Add(new PropertyGroupDescription("estado"));
            }
        }

        private void CheckEstado_Unchecked(object sender, RoutedEventArgs e)
        {
            mvAveria.listaAverias.GroupDescriptions.Clear();
        }

      

        private void BtnFiltrarFechas_Click(object sender, RoutedEventArgs e)
        {
            criterios.Clear();

            if (FechaIni.SelectedDate !=null)
            {
                //criterios.Add(new Predicate<averia>(a => (a.fechaRecepcion != null) && a.fechaRecepcion.ToString().Contains(FechaIni.ToString())));
                criterios.Add(new Predicate<averia>(a => (a.fechaRecepcion != null) && a.fechaRecepcion.ToString().Contains(FechaIni.ToString())));
                //"FROM_DATE <= #" + filterstring + "# AND TO_DATE > #" + filterstring + "#";
            }
               
          

            dgListaAverias.Items.Filter = Filtro;
        }

        private bool FiltroFechas(object item)
        {
            bool esta = true;
            if (item != null)
            {
                averia ave = item as averia;

                if (criterios.Count() != 0)
                {
                    esta = criterios.TrueForAll(x => x(ave)); //va a coger cada uno de los criterios y los va a comprobar si los pasa devolvera true si no los pasa devolvera false
                }
            }
            return esta;
        }
    }
}

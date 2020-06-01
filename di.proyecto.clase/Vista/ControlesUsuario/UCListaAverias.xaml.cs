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

        private void BtnFiltrarFechas_Click(object sender, RoutedEventArgs e)
        {
            criterios.Clear();

            if (FechaIni.SelectedDate !=null)
            {
                criterios.Add(new Predicate<averia>(a => (a.fechaRecepcion != null) && a.fechaRecepcion > FechaIni.SelectedDate && a.fechaRecepcion < FechaFin.SelectedDate));                

               //criterios.Add(new Predicate<averia>(tallerEnt.averia.Where(x => x.fechaRecepcion >= FechaIni.SelectedDate.Value.Date && x.fechaRecepcion <= FechaFin.SelectedDate.Value.Date).ToList()));

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

        private bool FiltroCombinado(object item) //Convertir el modeloarticulo, si el objeto no es nullo hacemos la conversion
        {
            bool esta = false;
            averia ave;
            if (item != null)
            {
                ave = (averia)item;
                if (comboFiltroTipo.SelectedItem != null)
                {
                    if ((ave.tipoaveria != null) && (ave.tipoaveria.Equals(mvAveria.tipoSeleccionado))) //Filtrar Tipo
                    {
                        esta = true;
                    }
                }

                if (comboFiltroEstado.SelectedItem != null)
                {
                    if ((ave.estado1 != null) && (ave.estado1.Equals(mvAveria.estadoSeleccionado))) //Filtrar Estado
                    {
                        esta = true;
                    }
                }
            }
            return esta;
        }


        private void ComboFiltroTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgListaAverias.Items.Filter = new Predicate<object>(FiltroCombinado);
        }

        private void ComboFiltroEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgListaAverias.Items.Filter = new Predicate<object>(FiltroCombinado);
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            dgListaAverias.Items.Filter = null;
            dgListaAverias.Items.Refresh();
        }

        private void BtnFactura_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

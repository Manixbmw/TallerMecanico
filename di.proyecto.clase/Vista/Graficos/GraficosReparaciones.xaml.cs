using di.proyecto.clase.Modelo;
using di.proyecto.clase.MVVM;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace di.proyecto.clase.Vista.Graficos
{
    /// <summary>
    /// Lógica de interacción para GraficosReparaciones.xaml
    /// </summary>
    public partial class GraficosReparaciones : UserControl
    {

        tallerEntities tallerEnt;       
        private ServicioCharts serChart;

        public GraficosReparaciones(tallerEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;            
            serChart = new ServicioCharts();
            loadChart();
            DataContext = this;
        }

        private void loadChart()
        {

            //SELECT MONTH(fechaRecepcion) Mes, SUM(id) total_mes FROM averia GROUP BY Mes; regulera
            //select MonthName(fechaRecepcion) as Month, count(id) as averias from taller.averia Group By Month   averias totales
            //select MonthName(fechaRecepcion) as Month, count(id) as averias from taller.averia where estado = 3 Group By Month  averias Reparadas

            DataTable dt = serChart.getDatos("select MonthName(fechaRecepcion) as Month, count(id) as averias from taller.averia where estado = 3  Group By Month");
           
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            ChartValues<double> cht_y_values = new ChartValues<double>();
            SeriesCollection series = new LiveCharts.SeriesCollection();

            //no puedo contolar si fechaRecepcion esta vacia en alguna tabla ,como resultado no deja que funcione el programa

            foreach (DataRow dr in dt.Rows)
            {
                PieSeries ps = new PieSeries
                {
                    Title = "" + dr[0] ,
                    Values = new ChartValues<double> { double.Parse(dr[1].ToString()) },
                    DataLabels = true,
                    LabelPoint = labelPoint
                };
                series.Add(ps);
            }
            lvRepMes.Series = series;
        }
    }
}

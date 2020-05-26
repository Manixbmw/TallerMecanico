using di.proyecto.clase.Modelo;
using di.proyecto.clase.MVVM;
using LiveCharts;
using LiveCharts.Wpf;
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

namespace di.proyecto.clase.Vista.Graficos
{
    /// <summary>
    /// Lógica de interacción para GraficosReparaciones.xaml
    /// </summary>
    public partial class GraficosReparaciones : UserControl
    {

        tallerEntities tallerEnt;
        private MVProductos MVProductos;

        public GraficosReparaciones(tallerEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            MVProductos = new MVProductos(tallerEnt);
            
            loadChart();
        }

		private void loadChart()
		{
			// Crea una lista de ChartValues para almacenar la cantidad de alumnos
			ChartValues<double> valores = new ChartValues<double>();
			// Crea una lista de string para almacenar los nombres de los grupos
			List<String> etiquetas = new List<string>();
			// Recorremos la lista de grupos. El Objeto mvGraf es una clase
			// MVVM que hemos creado para obtener los datos de los grupos
			foreach (productos a in MVProductos.listaProductos)
			{
				// Añadimos a la lista anterior el número de alumnos de cada
				// grupo. Representan los valores del eje Y del gráfico
				valores.Add(a.cantidad);
				// Añadimos a la lista anterior el nombre de cada grupo.
				// Representan los valores del eje X del gráfico
				etiquetas.Add(a.nombre);
			}
			// Creamos la Serie del gráfico. Contiene los valores a visualizar
			// Se corresponde al eje Y
			lvGrupos.Series = new SeriesCollection
                 {
                 new ColumnSeries
                 {
                 Title = "Número de Alumnos", // Título de la serie
                 Values = valores, // Número de alumnos en cada grupo
                 DataLabels = true, // Visualizamos las etiquetas
                 Fill = Brushes.Red // Lo visualizamos de color naranja
                 }
                 };
			// Valores que veremos en el ejeX
			lvGrupos.AxisX.Add(new Axis
			{
				Title = "Grupos", // Titulo del eje X
				Labels = etiquetas, // Nombres de los grupos
				Unit = 1 // Separación entre valores
			});
		}
	}
}

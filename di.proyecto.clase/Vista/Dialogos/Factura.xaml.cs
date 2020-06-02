using di.proyecto.clase.Modelo;
using di.proyecto.clase.Servicios;
using Microsoft.Reporting.WinForms;
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

namespace di.proyecto.clase.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para Factura.xaml
    /// </summary>
    public partial class Factura : Window
    {
        tallerEntities tallerEnt;
        private AveriaServicio averiaServ;

        public Factura(tallerEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            averiaServ = new AveriaServicio(tallerEnt);
            cargaInforme();
        }

        private void cargaInforme()
        {
            var data = averiaServ.getAll().ToList();
            var reportDataSource1 = new ReportDataSource();
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = data;
            reporFactura.LocalReport.DataSources.Add(reportDataSource1);
            reporFactura.LocalReport.ReportPath = "../../Informes/RFactura.rdlc";
            reporFactura.RefreshReport();
        }
    }
}

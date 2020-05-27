using di.proyecto.clase.Modelo;
using di.proyecto.clase.MVVM;
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

namespace di.proyecto.clase.Vista.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para InformeInventario.xaml
    /// </summary>
    public partial class InformeInventario : UserControl
    {
        tallerEntities tallerEnt;        
        private ProductoServicio prodServ;

        public InformeInventario(tallerEntities ent)
        {
            InitializeComponent();
            tallerEnt = ent;
            prodServ = new ProductoServicio(tallerEnt);
            cargaInforme();
        }

        private void cargaInforme()
        {
            var data = prodServ.getAll().ToList();
            var reportDataSource1 = new ReportDataSource();
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = data;
            reporInventario.LocalReport.DataSources.Add(reportDataSource1);
            reporInventario.LocalReport.ReportPath = "../../Informes/Report1.rdlc";
            reporInventario.RefreshReport();
        }

    }
}

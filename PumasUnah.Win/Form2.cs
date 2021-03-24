using PumasUnah.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PumasUnah.Win
{
    public partial class Form2 : Form
    {
        ReportedeVentasBL _reporteVentasBL;

        public Form2()
        {
            InitializeComponent();
            _reporteVentasBL = new ReportedeVentasBL();

            RefrescarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefrescarDatos();
        }

        private void RefrescarDatos()
        {
            var ListadeVentas = _reporteVentasBL.ObtenerVentas();
            listadeVentasBindingSource.DataSource = ListadeVentas;
            listadeVentasBindingSource.ResetBindings(false);
        }
    }
}

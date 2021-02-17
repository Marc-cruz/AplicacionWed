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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var tiendaBL = new TiendaBL();
            var ListadeTienda = tiendaBL.ObtenerTienda();

            listadeTiendaBindingSource.DataSource = ListadeTienda;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var entradasBL = new EntradasBL();
            var ListadeEntradas = entradasBL.ObtenerEntradas();

            foreach (var entradas in ListadeEntradas)
            {
                MessageBox.Show(entradas.Descripcion);
            }
        }

    }
}

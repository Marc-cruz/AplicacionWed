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
            var entradaBL = new EntradaBL();
            var listadeEntrada = entradaBL.ObtenerEntradas();

            listadeEntradaBindingSource.DataSource = listadeEntrada;


        }
    }
}

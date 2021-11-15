using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ReportesPlanes : Form
    {
        public ReportesPlanes()
        {
            InitializeComponent();
        }

        private void ReportesPlanes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ReportesDataSets.planes' Puede moverla o quitarla según sea necesario.
            this.planesTableAdapter.Fill(this.ReportesDataSets.planes);

            this.reportViewer1.RefreshReport();
        }
    }
}

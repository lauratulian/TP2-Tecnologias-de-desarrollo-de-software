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
    public partial class ReportesCursos : Form
    {
        public ReportesCursos()
        {
            InitializeComponent();
        }

        private void ReportesCursos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ReportesDataSets.cursos' Puede moverla o quitarla según sea necesario.
            this.cursosTableAdapter.Fill(this.ReportesDataSets.cursos);

            this.reportViewer1.RefreshReport();
        }
    }
}

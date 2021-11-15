using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop.UserControls
{
    public partial class ucAnios : UserControl
    {
        private int _Anio;

        public int Anio { get => _Anio; set => _Anio = value; }

        public ucAnios()
        {
            InitializeComponent();
        }

        private void ucAnios_Load(object sender, EventArgs e)
        {
            for (int i = 1990; i <= 2021; i++)
            {
                cbAnios.Items.Add(i);
            }
        }

        private void cbAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Anio = int.Parse(cbAnios.SelectedItem.ToString());
        }

    
    }
}

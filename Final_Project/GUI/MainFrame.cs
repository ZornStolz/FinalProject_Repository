using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {
            dtGrid.Columns.Add("Fecha", "Fecha");
            dtGrid.Columns.Add("Autoridad Ambiental", "Autoridad Ambiental");
            dtGrid.Columns.Add("Nombre de la estación", "Nombre de la estación");
            dtGrid.Columns.Add("Tecnología", "Tecnología");
            dtGrid.Columns.Add("Latitud", "Latitud");
            dtGrid.Columns.Add("Longitud", "Longitud");
            dtGrid.Columns.Add("Tipo de Dato", "Tipo de Dato");
            dtGrid.Columns.Add("Código del departamento	", "Código del departamento	");
            dtGrid.Columns.Add("Departamento", "Departamento");
            dtGrid.Columns.Add("Código del municipio", "Código del municipio");
            dtGrid.Columns.Add("Nombre del municipio", "Nombre del municipio");
            dtGrid.Columns.Add("Tipo de estación", "Tipo de estación");
            dtGrid.Columns.Add("Tipo de Dato", "Tipo de Dato");
            dtGrid.Columns.Add("Tiempo de exposición", "Tiempo de exposición");
            dtGrid.Columns.Add("Variable", "Variable");
            dtGrid.Columns.Add("Unidades", "Unidades");
            dtGrid.Columns.Add("Concentración", "Concentración");
            dtGrid.Columns.Add("Nueva columna georreferenciada", "Nueva columna georreferenciada");

        }

        private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btFilter_Click(object sender, EventArgs e)
        {

        }

    }
}

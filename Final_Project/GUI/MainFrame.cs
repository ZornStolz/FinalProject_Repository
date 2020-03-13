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
        /// <summary>
        /// Count the click number of the button
        /// </summary>
        private int count_click;

        private Label lbFilterBy;
        private ComboBox cbFilterBy;
        private Label lbValueToFilter;
        private TextBox txValueToFilter;
        private Button btAdd;
        private Button btClear;
        public MainFrame()
        {
            InitializeComponent();
            count_click = 1;
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

            HandlerButtonAddAndClear(sender,e);





            /////////////////////////////////




        }

        private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btFilter_Click(object sender, EventArgs e)
        {

        }

        private void btCreateNewFilter_Click(object sender, EventArgs e)
        {

            lbFilterBy = new Label();

            cbFilterBy = new ComboBox();

            lbValueToFilter = new Label();

            txValueToFilter = new TextBox();

            btAdd = new Button();
            btClear = new Button();

            createControlsyToFilter(lbFilterBy, cbFilterBy, lbValueToFilter, txValueToFilter, btAdd, btClear);

            count_click++;


        }


        private void clearFilter()
        {


        }




        /// <summary>
        /// This method allows you to create the controllers responsible for filtering.
        /// </summary>
        private void createControlsyToFilter(Label lbFilterBy, ComboBox cbFilterBy, Label lbValueToFilter, TextBox txValueToFilter, Button btAdd, Button btClear)
        {

            // 
            // lbFilterBy
            // 
            lbFilterBy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            lbFilterBy.AutoSize = true;
            lbFilterBy.Location = new System.Drawing.Point(3, 0);
            lbFilterBy.Name = "lbFilterBy";
            lbFilterBy.Size = new System.Drawing.Size(53, 29);
            lbFilterBy.TabIndex = 6;
            lbFilterBy.Text = "Filtrar por:";
            lbFilterBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbFilterBy.Name = "lbFilterBy" + count_click.ToString();


            // 
            // cbFilterBy
            // 
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Location = new System.Drawing.Point(62, 3);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new System.Drawing.Size(100, 21);
            cbFilterBy.TabIndex = 5;
            cbFilterBy.Name = "cbFilter" + count_click.ToString();

            // 
            // lbvalueToFilter
            // 
            lbValueToFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            lbValueToFilter.AutoSize = true;
            lbValueToFilter.Location = new System.Drawing.Point(168, 0);
            lbValueToFilter.Name = "lbvalueToFilter";
            lbValueToFilter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            lbValueToFilter.Size = new System.Drawing.Size(71, 29);
            lbValueToFilter.TabIndex = 7;
            lbValueToFilter.Text = "Valor a filtrar :";
            lbValueToFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            txValueToFilter.Name = "tbValueToFilter" + count_click.ToString();


            // 
            // valueToFilter
            // 
            txValueToFilter.Location = new System.Drawing.Point(245, 3);
            txValueToFilter.Name = "valueToFilter";
            txValueToFilter.Size = new System.Drawing.Size(100, 20);
            txValueToFilter.TabIndex = 1;
            txValueToFilter.Name = "txValueToFilter" + count_click.ToString();


            // 
            // btAdd
            // 
            btAdd.Location = new System.Drawing.Point(351, 3);
            btAdd.Name = "btAdd";
            btAdd.Size = new System.Drawing.Size(75, 23);
            btAdd.TabIndex = 8;
            btAdd.Text = "Agregar";
            btAdd.UseVisualStyleBackColor = true;
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Name = "btAdd" + count_click.ToString();
            btAdd.Click += new EventHandler(HandlerButtonAddAndClear);

            // 
            // btClear
            // 
            btClear.Location = new System.Drawing.Point(432, 3);
            btClear.Name = "btClear";
            btClear.Size = new System.Drawing.Size(21, 23);
            btClear.TabIndex = 9;
            btClear.Text = "X";
            btClear.UseVisualStyleBackColor = true;
            btClear.Name = "btClear" + count_click.ToString();
            btClear.Click += new EventHandler(HandlerButtonAddAndClear);


            /// Add elements to control Flow panel
            this.fLP.Controls.Add(lbFilterBy);
            this.fLP.Controls.Add(cbFilterBy);
            this.fLP.Controls.Add(lbValueToFilter);
            this.fLP.Controls.Add(txValueToFilter);
            this.fLP.Controls.Add(btAdd);
            this.fLP.Controls.Add(btClear);
        }





        public void HandlerButtonAddAndClear(object sender, EventArgs e)
        {
            Console.WriteLine("ss");
            int i = 1;
            bool found = false;
            if (btClear != null )
            {
                while (i <= count_click && !found)
                {
                    if (((Button)sender).Name == "btClear"+i.ToString())
                    {

                        foreach (TextBox thecontrol in this.Controls.OfType<TextBox>().Where((fLP) => fLP.Name.Contains("lbFilterBy" + i.ToString())))
                        {
                            fLP.Controls.Remove(thecontrol);
                            MessageBox.Show("Se presiono el boton"+i.ToString());
                        }
                        if (lbFilterBy.Name == "lbFilterBy"+i.ToString())
                        {
                        }

                        found = true;
                    }
                    i++;
                }
               prueba.Text = btClear.Name;
            }         
              

        }
            

            
           

           
        
    }
}

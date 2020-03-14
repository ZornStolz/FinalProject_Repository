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
    public partial class mainFrame : Form
    {
        /// <summary>
        /// Count the click number of the button
        /// </summary>
        private int count_click;

        private List<Element> elements;






        public mainFrame()
        {
            count_click = 0;
            InitializeComponent();
            elements = new List<Element>();
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

           // HandlerButtonAddAndClear(sender,e);





            /////////////////////////////////




        }

        private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btFilter_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// This method allows creating a new filter according to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCreateNewFilter_Click(object sender, EventArgs e)
        {

            Label lbFilterBy = new Label();

            ComboBox cbFilterBy = new ComboBox();

            Label lbValueToFilter = new Label();

            TextBox txValueToFilter = new TextBox();

            Button btAdd = new Button();
            Button btClear = new Button();


            createControlsyToFilter(lbFilterBy, cbFilterBy, lbValueToFilter, txValueToFilter, btAdd, btClear);
            elements.Add(new Element(lbFilterBy,cbFilterBy,lbValueToFilter,txValueToFilter,btAdd,btClear));
            
            
            this.fLP.Controls.Add(elements[count_click].Label1);
            this.fLP.Controls.Add(elements[count_click].ComboBox);
            this.fLP.Controls.Add(elements[count_click].Label2);
            this.fLP.Controls.Add(elements[count_click].TextBox);
            this.fLP.Controls.Add(elements[count_click].ButtonAdd);
            this.fLP.Controls.Add(elements[count_click].ButtonClear);

            count_click++;


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
            txValueToFilter.Size = new System.Drawing.Size(100, 20);
            txValueToFilter.TabIndex = 1;
            txValueToFilter.Name = "txValueToFilter" + count_click.ToString();


            // 
            // btAdd
            // 
            btAdd.Location = new System.Drawing.Point(351, 3);
            btAdd.Size = new System.Drawing.Size(75, 23);
            btAdd.TabIndex = 8;
            btAdd.Text = "Agregar" + count_click.ToString();
            btAdd.UseVisualStyleBackColor = true;
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Name = "btAdd" + count_click.ToString();
            btAdd.Click += new EventHandler(HandlerButtonAddAndClear);

            // 
            // btClear
            // 
            btClear.Location = new System.Drawing.Point(432, 3);
            btClear.Size = new System.Drawing.Size(21, 23);
            btClear.TabIndex = 9;
            btClear.Text = "X";
            btClear.UseVisualStyleBackColor = true;
            btClear.Name = "btClear" + count_click.ToString();
            btClear.Click += new EventHandler(HandlerButtonAddAndClear);


            /// Add elements to control Flow panel
            /**
            this.fLP.Controls.Add(lbFilterBy);
            this.fLP.Controls.Add(cbFilterBy);
            this.fLP.Controls.Add(lbValueToFilter);
            this.fLP.Controls.Add(txValueToFilter);
            this.fLP.Controls.Add(btAdd);
           */
            
            
           
        }





        public void HandlerButtonAddAndClear(object sender, EventArgs e)
        {
            int i = 0;
            bool found = false;
            if (elements != null)
            {
                while (i < count_click && !found)
                {
                    if (((Button)sender).Name == "btClear"+i.ToString())
                    {
                        for (int j = 0; j < elements.Count(); j++)
                        {
                            if (elements[j].ButtonAdd.Name == "btAdd" + i.ToString())
                            {   

                                fLP.Controls.Remove(elements[j].Label1);
                                fLP.Controls.Remove(elements[j].ComboBox);
                                fLP.Controls.Remove(elements[j].Label2);
                                fLP.Controls.Remove(elements[j].TextBox);
                                fLP.Controls.Remove(elements[j].ButtonAdd);
                                fLP.Controls.Remove(elements[j].ButtonClear);
                                elements.Remove(elements[j]);
                                MessageBox.Show("Lo borre");
                            }
                        }
                        MessageBox.Show("Se presiono el boton"+i.ToString());
                        found = true;
                        fLP.Update();
                    
                    }
                        
              
                    
                    i++;
                }
            }         
              

        }

    }
}

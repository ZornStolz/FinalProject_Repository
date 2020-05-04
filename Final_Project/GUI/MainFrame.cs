using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        private string[] columnsValues;
        private ComboBox cbFilterBy;
        /*
         * source data to be consulted
         */
        private static String uRL = "https://www.datos.gov.co/resource/ysq6-ri4e.json?$limit=10&";

        public static string URL { get => uRL; set => uRL = value; }

        public mainFrame()
        {
            count_click = 0;
            InitializeComponent();
            columnsValues = new string[15];
            elements = new List<Element>();
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {

            ViewGrid();
            AddNameColumnToList();
        }

        /// <summary>
        /// Permite añadir los nombres de las columnas a una lista para luego ser utilizada.
        /// </summary>
        private void AddNameColumnToList()
        {

            columnsValues[0] = "fecha";
            columnsValues[1] = "autoridad_ambiental";
            columnsValues[2] = "nombre_de_la_estaci_n";
            columnsValues[3] = "tecnolog_a";
            columnsValues[4] = "latitud";
            columnsValues[5] = "longitud";
            columnsValues[6] = "c_digo_del_departamento";
            columnsValues[7] = "departamento";
            columnsValues[8] = "c_digo_del_municipio";
            columnsValues[9] = "nombre_del_municipio";
            columnsValues[10] = "tipo_de_estaci_n";
            columnsValues[11] = "tiempo_de_exposici_n";
            columnsValues[12] = "variable";
            columnsValues[13] = "unidades";
            columnsValues[14] = "concentraci_n";
        }


        private async void ViewGrid()
        {
            string respuesta = await GetHttp();
            List<ViewModel> lst = JsonConvert.DeserializeObject<List<ViewModel>>(respuesta);
            dtGrid.DataSource = lst;
            AddMarker(lst);
        }


        public async Task<string> GetHttp()
        {
            WebRequest webRequest = WebRequest.Create(URL);
            WebResponse webResponse = webRequest.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream());

            return await sr.ReadToEndAsync();
        }




        private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btFilter_Click(object sender, EventArgs e)
        {
            if (elements != null)
            {

                foreach (var values in elements)
                {
                    if (values.ComboBox.Enabled == true)
                    {


                        values.ComboBox.Enabled = false;

                        string columnName = values.ComboBox.Text;
                        string valueToFilter = values.TextBox.Text;


                        if (columnName.Equals(columnsValues[0]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";
                        }
                        else if (columnName.Equals(columnsValues[1]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[2]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[3]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[4]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[5]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[6]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[7]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[8]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[9]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[10]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[11]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[12]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[13]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[14]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[15]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }

                    }




                }





                ViewGrid();

                // dtGrid.Refresh();
                //dtGrid.Update();
            }
        }




        /// <summary>
        /// This method allows creating a new filter according to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCreateNewFilter_Click(object sender, EventArgs e)
        {


            Label lbFilterBy = new Label();
            cbFilterBy = new ComboBox();


            Label lbValueToFilter = new Label();

            TextBox txValueToFilter = new TextBox();

            Button btAdd = new Button();
            Button btClear = new Button();


            createControlsyToFilter(lbFilterBy, cbFilterBy, lbValueToFilter, txValueToFilter, btAdd, btClear);
            elements.Add(new Element(lbFilterBy, cbFilterBy, lbValueToFilter, txValueToFilter, btAdd, btClear));


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
            //------------------------------------------------------------
            cbFilterBy.Items.AddRange(columnsValues);
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






        }





        public void HandlerButtonAddAndClear(object sender, EventArgs e)
        {
            int i = 0;
            bool found = false;
            if (elements != null)
            {
                while (i < count_click && !found)
                {
                    for (int j = 0; j < elements.Count(); j++)
                    {
                        if (((Button)sender).Name == "btClear" + i.ToString())
                        {
                            if (elements[j].ButtonAdd.Name == "btAdd" + i.ToString())
                            {
                                ClearValuesToURL(elements[j].ComboBox.Text,elements[j].TextBox.Text);
                                fLP.Controls.Remove(elements[j].Label1);
                                fLP.Controls.Remove(elements[j].ComboBox);
                                fLP.Controls.Remove(elements[j].Label2);
                                fLP.Controls.Remove(elements[j].TextBox);
                                fLP.Controls.Remove(elements[j].ButtonAdd);
                                fLP.Controls.Remove(elements[j].ButtonClear);
                                elements.Remove(elements[j]);
                                MessageBox.Show("Lo borre");
                                found = true;
                                count_click--;
                                MessageBox.Show("Se presiono el boton" + i.ToString());
                            }
                        }


                        if (((Button)sender).Name == "btAdd" + i.ToString())
                        {
                            elements[j].ComboBox.Enabled = false;
                            found = true;
                        }

                        fLP.Update();
                    }






                    i++;
                }
            }


        }

        /// <summary>
        /// Permite eliminar la consulta que el usuario realizo.
        /// </summary>
        /// <param name="columnName"></param> Nombre de la columna para eliminar la consulta.
        /// <param name="valueToFilter"></param> Atributo de la columna columnName el cual se va a eliminar
        private void ClearValuesToURL(string columnName,String valueToFilter)
        {
            
            String valueToClean = "&" +columnName + "=" + valueToFilter;
            //Borra un caracter o una cadena de caracter en el URL.
            string cadena = URL.Replace(valueToClean,"");
            URL = cadena;
            ViewGrid();
            
        }

        private void gMapC_Load(object sender, EventArgs e)
        {
            //Elementos de inicio Gmap
            gMapC.DragButton = MouseButtons.Left;
            gMapC.CanDragMap = true;
            gMapC.MapProvider = GMap.NET.MapProviders.OpenCycleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapC.Position = new GMap.NET.PointLatLng(4.570868, -74.2973328);
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapC.MinZoom = 2;
            gMapC.MaxZoom = 18;
            gMapC.Zoom = 6;
            //Fin
        }


        private void AddMarker(List<ViewModel> lst)
        {
            foreach (var i in lst)
            {

                var markerOverlay = new GMapOverlay("markers");
                var marker = new GMarkerGoogle(new PointLatLng(i.Latitud, i.Longitud), GMarkerGoogleType.green); ;
                markerOverlay.Markers.Add(marker);


                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.ToolTipText = String.Format("Fecha: " + i.Fecha + "\n"
                   + "Autoridad Ambiental: " + i.Autoridad_ambiental + "\n"
                   + "Nombre de la estación: " + i.Nombre_de_la_estaci_n + "\n"
                   + "Tecnologia: " + i.Tecnolog_a + "\n"
                   + "Latitud: " + i.Latitud + "\n"
                   + "Longitud: " + i.Longitud + "\n"
                   + "Codigo del departamento: " + i.C_digo_del_departamento + "\n"
                   + "Departamento: " + i.Departamento + "\n"
                   + "Codigo de municipio: " + i.C_digo_del_municipio+ "\n"
                   + "Municipio: " + i.Nombre_del_municipio + "\n"
                   + "Tipo de estación: " + i.Tipo_de_estaci_n + "\n"
                   + "Tiempo de exposición: " + i.Tiempo_de_exposici_n + "\n"
                   + "Variable: " + i.Variable + "\n"
                   + "Unidades: " + i.Unidades + "\n"
                   + "Concentración: " + i.Concentraci_n
                    );

            gMapC.Overlays.Add(markerOverlay);
            }

        }

    }
}

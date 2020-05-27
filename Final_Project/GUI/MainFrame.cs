using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using SODA;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;

namespace GUI
{
    public partial class Blume : Form
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
        private const string URL = "https://www.datos.gov.co/resource/ysq6-ri4e.json?";

        /*
         * variable para saber en que year estamos
         */
        private int yearActual;

        /*
        * variable para saber a que municipio pertenencen todos los datos de la variable consulta
        */
        private Municipio municipioActual;

        /*
        * lista de todos los municipios a usar
        */
        private List<Municipio> municipios_Set;

        /*
         * esta tendra 1000 registros. todos son concentraciones, registros, de una sola  variable para no saturar la ram.
         */
        private List<Concentracion_Registro> consulta;

        /////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////// Niveles de contaminación./////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Nivel de contaminación de emergencia.
        /// </summary>
        public const string EMERGENCIA = "Emergencia";

        /// <summary>
        ///  Nivel de contaminación de alerta.
        /// </summary>
        public const string ALERTA = "Alerta";

        /// <summary>
        /// Nivel de contaminación de prevencion.
        /// </summary>
        public const string PREVENCION = "Prevencion";

        /// <summary>
        /// Nivel de contaminación permisible.
        /// </summary>
        public const string PERMISIBLE = "Permisible";

        public Blume()
        {
            YearActual = 2011;
            MunicipiosSet = new List<Municipio>();
            Consulta = new List<Concentracion_Registro>();

            InitializeComponent();
            inicializarMunicipios();
            MunicipioActual = MunicipiosSet.First();
            inicializarDatosMunicipios();
            // consultarDatos(municipios_Set.First().Nombre_del_municipio, variables_Set.First().Variable, yearActual);

            count_click = 0;

            columnsValues = new string[15];
            elements = new List<Element>();

            variableCB.Items.AddRange(new object[]
            {
                "PM10",
                "O3",
                "Radiación Solar Global"
            });

            variableGmaps.Items.AddRange(new object[]
            {
                "PM10",
                "O3",
                "Radiación Solar Global"
            });
            variableGmaps.Text = "PM10";
        }

        public int YearActual
        {
            get => yearActual;
            set => yearActual = value;
        }

        public Municipio MunicipioActual
        {
            get => municipioActual;
            set => municipioActual = value;
        }

        public List<Municipio> MunicipiosSet
        {
            get => municipios_Set;
            set => municipios_Set = value;
        }

        public List<Concentracion_Registro> Consulta
        {
            get => consulta;
            set => consulta = value;
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {
            ViewGrid();
            AddNameColumnToList();
            //PollutionColor();
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
            string respuesta = await GetHttp(URL);
            List<ViewModel> lst = JsonConvert.DeserializeObject<List<ViewModel>>(respuesta);
            dtGrid.DataSource = lst;
            //dtGrid.DataSource = municipios_Set;
            //dtGrid.DataSource = variales_Set;
        }

        public async Task<string> GetHttp(string url)
        {
            WebRequest webRequest = WebRequest.Create(url);
            WebResponse webResponse = webRequest.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream());

            return await sr.ReadToEndAsync();
        }


        private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        /**
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

            */
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
            //TODO
            // refreshStatisticsTab();
        }

        /// <summary>
        /// This method allows you to create the controllers responsible for filtering.
        /// </summary>
        private void createControlsyToFilter(Label lbFilterBy, ComboBox cbFilterBy, Label lbValueToFilter,
            TextBox txValueToFilter, Button btAdd, Button btClear)
        {
            lbFilterBy.Anchor =
                ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom)
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
            lbValueToFilter.Anchor =
                ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom)
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
                                fLP.Controls.Remove(elements[j].Label1);
                                fLP.Controls.Remove(elements[j].ComboBox);
                                fLP.Controls.Remove(elements[j].Label2);
                                fLP.Controls.Remove(elements[j].TextBox);
                                fLP.Controls.Remove(elements[j].ButtonAdd);
                                fLP.Controls.Remove(elements[j].ButtonClear);
                                elements.Remove(elements[j]);
                                MessageBox.Show("Se borró el filtro");
                                found = true;
                                count_click--;
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////METODOS GMAPS/////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Este metodo permite añadirle colores a los marcadores y poligonos de acuerdo al nivel de contaminación que presentan.
        /// </summary>
        /// <param name="lst"></param> Lista con los elementos que se encuentran en la base de datos.
        private void PollutionColor()
        {
            //Limpia los marcadores actuales
            gMapC.Overlays.Clear();

            foreach (var value in municipios_Set)
            {
                var selectedVariable = variableGmaps.SelectedItem.ToString();

                //Busca el valor elegido en el ComboBox entre las variables de 'value' y lo asigna a 'variableActual'
                Variable_Registrada variableActual = value.Variables.Find(x => x.Variable.Equals(selectedVariable));

                string pollutionLevel = DefineContaminationLevel(variableActual.Variable, variableActual.Concentracion);

                if (pollutionLevel.Equals(EMERGENCIA))
                {
                    AddMarker(value, variableActual, Color.FromArgb(50, Color.Red), GMarkerGoogleType.red);
                }
                else if (pollutionLevel.Equals(ALERTA))
                {
                    AddMarker(value, variableActual, Color.FromArgb(50, Color.OrangeRed), GMarkerGoogleType.orange);
                }
                else if (pollutionLevel.Equals(PREVENCION))
                {
                    AddMarker(value, variableActual, Color.FromArgb(50, Color.Yellow), GMarkerGoogleType.yellow);
                }
                else
                {
                    AddMarker(value, variableActual, Color.FromArgb(50, Color.Green), GMarkerGoogleType.green);
                }

                //Para actualizar la ubicacion de los marcadores en el mapa
                var temp = trackBarZoom.Value;
                gMapC.Zoom = temp + 1;
                gMapC.Zoom = temp;
            }
        }

        /// <summary>
        /// Retorna el nivel de contaminación.
        /// Los niveles de contaminación son: Alto, medio y bajo.
        /// Se evaluaran 3 casos:
        /// 1) PM10:
        /// 2) O3:
        /// 3) Radiación Solar Global:
        /// </summary>
        /// <param name="variable"></param> Variable con la cual se realizo la prueba de contaminación.
        /// <param name="concentracion"></param> Nivel de concentración que toma la variable.
        private string DefineContaminationLevel(String variable, double concentracion)
        {
            string pollutionLevel = "";

            ///Casos
            if (variable.Equals("PM10"))
            {
                pollutionLevel = PM10PollutionLevel(concentracion);
            }
            else if (variable.Equals("O3"))
            {
                pollutionLevel = O3PollutionLevel(concentracion);
            }
            else
            {
                pollutionLevel = SolarRadiationPollutionLevel(concentracion);
            }

            return pollutionLevel;
        }

        /// <summary>
        /// Metodo auxiliar del metodo DefineContaminationLevel.
        /// Establece el nivel de contaminación de la variable PM10.
        /// Este nivel de contaminación ( ug/m^3 ) se evaluara en un tiempo de exposición de 24 horas como:
        /// Permisible: 100
        /// Prevencion: 155 - 254
        /// Alerta:  255 - 354
        /// Emergencia: >= 355
        /// Estos niveles de contaminación son establecidos de acuerdo al Ministerio de Ambiente y Desarrollo sostenible.
        /// https://www.minambiente.gov.co/images/normativa/app/resoluciones/96-res%202254%20de%202017.pdf#page=5&zoom=auto,-99,744
        /// </summary>
        /// <param name="concentracion"></param> Nivel de concentración de la variable PM10
        /// <returns></returns>
        private string PM10PollutionLevel(double concentracion)
        {
            string pollutionLevel = "";
            //154,155,254,255,354,355
            //Casos.
            if (concentracion <= 10)
            {
                pollutionLevel = PERMISIBLE;
            }
            else if (concentracion >= 11 && concentracion <= 20)
            {
                pollutionLevel = PREVENCION;
            }
            else if (concentracion >= 21 && concentracion <= 30)
            {
                pollutionLevel = ALERTA;
            }
            else if (concentracion >= 31)
            {
                pollutionLevel = EMERGENCIA;
            }

            return pollutionLevel;
        }

        /// <summary>
        /// Metodo auxiliar del metodo DefineContaminationLevel.
        /// Establece el nivel de contaminación de la variable O3.
        /// Este nivel de contaminación ( ug/m^3 ) se evaluara en un tiempo de exposición de 8 horas como:
        /// Permisible: 100
        /// Prevencion: 139 - 167
        /// Alerta:  168 - 207
        /// Emergencia: >= 208
        /// Estos niveles de contaminación son establecidos de acuerdo al Ministerio de Ambiente y Desarrollo sostenible.
        /// https://www.minambiente.gov.co/images/normativa/app/resoluciones/96-res%202254%20de%202017.pdf#page=5&zoom=auto,-99,744
        /// </summary>
        /// <param name="concentracion"></param> Nivel de concentración de la variable O3
        /// <returns></returns>
        private string O3PollutionLevel(double concentracion)
        {
            string pollutionLevel = "";
            //138,139,167,168,207,208
            //Casos.
            if (concentracion <= 10)
            {
                pollutionLevel = PERMISIBLE;
            }
            else if (concentracion >= 11 && concentracion <= 20)
            {
                pollutionLevel = PREVENCION;
            }
            else if (concentracion >= 21 && concentracion <= 30)
            {
                pollutionLevel = ALERTA;
            }
            else if (concentracion >= 31)
            {
                pollutionLevel = EMERGENCIA;
            }

            return pollutionLevel;
        }

        /// <summary>
        /// Metodo auxiliar del metodo DefineContaminationLevel.
        /// Establece el nivel de contaminación de la variable Radiación Solar Global.
        /// Este nivel de contaminación se evaluara como:
        /// Permisible,Prevencion, Alerta, Emergencia.
        /// </summary>
        /// <param name="concentracion"></param> Nivel de concentración de la variable Radiación Solar Global.
        /// <returns></returns>
        private string SolarRadiationPollutionLevel(double concentracion)
        {
            string pollutionLevel = "";

            //Casos.
            if (concentracion <= 200)
            {
                pollutionLevel = PERMISIBLE;
            }
            else if (concentracion >= 201 && concentracion <= 250)
            {
                pollutionLevel = ALERTA;
            }
            else if (concentracion >= 251)
            {
                pollutionLevel = EMERGENCIA;
            }

            return pollutionLevel;
        }

        /**
            /// <summary>
            /// Permite eliminar la consulta que el usuario realizo.
            /// </summary>
            /// <param name="columnName"></param> Nombre de la columna para eliminar la consulta.
            /// <param name="valueToFilter"></param> Atributo de la columna columnName el cual se va a eliminar
            private void ClearValuesToURL(string columnName, String valueToFilter)
            {
    
                String valueToClean = "&" + columnName + "=" + valueToFilter;
                //Borra un caracter o una cadena de caracter en el URL.
                string cadena = URL.Replace(valueToClean, "");
                URL = cadena;
                ViewGrid();
    
            }
            **/
        /// <summary>
        /// Permite cargar el mapa de google en pantalla y posicionarlo en el país de Colombia,Bogota.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gMapC_Load(object sender, EventArgs e)
        {
            //Elementos de inicio Gmap
            gMapC.DragButton = MouseButtons.Left;
            gMapC.CanDragMap = true;
            gMapC.MapProvider = GMap.NET.MapProviders.OpenCycleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapC.Position = new GMap.NET.PointLatLng(4.570868, -74.2973328);
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapC.MinZoom = 0;
            gMapC.MaxZoom = 20;
            gMapC.Zoom = 6;
            //Fin
        }


        /// <summary>
        /// Permite agregar un marcador en coordenadas especificas en el mapa de google que se muestra en pantalla. Del mismo modo,
        /// permite agregar un cuadrado en las mismas coordenadas que representa el nivel de contaminación de la zona.
        /// </summary>
        /// <param name="value"></param> Representa un elemento de la base de datos.
        /// <param name="polygonColor"></param> Representa el color que rellena el poligono, de esta forma representar el nivel de contaminación de la zona.
        /// <param name="markerColor"></param> Representa el color del marcador, el cual representa el nivel de contaminación de la zona.
        private void AddMarker(Municipio value, Variable_Registrada variable, Color polygonColor,
            GMarkerGoogleType markerColor)
        {
            var markerOverlay = new GMapOverlay(value.Nombre_del_municipio);
            var marker = new GMarkerGoogle(new PointLatLng(value.Latitud, value.Longitud), markerColor);
            marker.Tag = value.Nombre_del_municipio;
            markerOverlay.Markers.Add(marker);


            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.ToolTipText = String.Format("Latitud: " + value.Latitud + "\n"
                                               + "Longitud: " + value.Longitud + "\n"
                                               + "Departamento: " + value.Departamento + "\n"
                                               + "Municipio " + value.Nombre_del_municipio + "\n"
                                               + "Variable " + variable.Variable + "\n"
            );

            AddPolygon(value, polygonColor);
            gMapC.Overlays.Add(markerOverlay);
        }

        private void Marker_Click(GMapMarker item, MouseEventArgs e)
        {
            MessageBox.Show("" + item.Tag);
            municipioActual.Nombre_del_municipio = item.Tag.ToString();
        }


        /// <summary>
        /// Este metodo permite crear un poligono alrededor de las coordenadas donde se realizo la prueba y de
        /// esta manera generar un cuadrado como representación de el nivel de contaminación en esta zona.
        /// </summary>
        /// <param name="value"></param> Representa a un elemnento de la base de datos
        /// <param name="polygonColor"></param> Representa el color que rellena el poligono, de esta forma representar el nivel de contaminación de la zona.
        private void AddPolygon(Municipio value, Color polygonColor)
        {
            GMapOverlay polygons = new GMapOverlay("Polygons");
            List<PointLatLng> points = new List<PointLatLng>();
            // Crea un cuadrado a partir de coordenas especificas.
            PointAdd(value.Latitud, value.Longitud, points);
            GMapPolygon polygon = new GMapPolygon(points, value.Nombre_del_municipio);
            polygon.Stroke = new Pen(Color.Transparent, 10);
            polygon.Fill = new SolidBrush(Color.FromArgb(50, polygonColor));
            polygons.Polygons.Add(polygon);
            gMapC.Overlays.Add(polygons);
            points.Clear();
        }


        /// <summary>
        /// Metodo auxiliar del metodo AddPolygon,este metodo permite crear un cuadrado, a partir de coordenadas alrededor de un punto en especifico.
        /// </summary>
        /// <param name="x"></param> Coordenada de latitud del punto medio.
        /// <param name="y"></param> Coordenada de Longitud del punto medio.
        /// <param name="points"></param> Lista de coordenadas que posteriormente se llenaran para realizar el poligono.
        private void PointAdd(double x, double y, List<PointLatLng> points)
        {
            //Distancia
            double d = 0.005;
            points.Add(new PointLatLng(x + d, y));
            points.Add(new PointLatLng(x, y + d));
            points.Add(new PointLatLng(x - d, y));
            points.Add(new PointLatLng(x, y - d));
        }

        private void DistanceTwoPoint(double x, double y, List<PointLatLng> points)
        {
            double d = 0.5;
            double x1 = x;
            double y1 = y;
            double x2 = x;
            double y2 = y;

            // Verificar parte superior.
            while (Distance(x1, y1, x2, y2) != d)
            {
                y2 += d;
            }

            points.Add(new PointLatLng(x2, y2));
            y2 = y;

            // Verificar parte  derecha.
            while (Distance(x1, y1, x2, y2) != d)
            {
                x2 += d;
            }

            points.Add(new PointLatLng(x2, y2));

            x2 = x;

            // Verificar parte inferior.
            while (Distance(x1, y1, x2, y2) != d)
            {
                y2 -= d;
            }

            points.Add(new PointLatLng(x2, y2));
            y2 = y;

            // Verificar parte  izquierda.
            while (Distance(x1, y1, x2, y2) != d)
            {
                x2 -= d;
            }

            points.Add(new PointLatLng(x2, y2));
        }

        private double Distance(double x1, double y1, double x2, double y2)
        {
            double first = Math.Pow((x2 - x1), 2);
            double second = Math.Pow((y2 - y1), 2);
            double result = first + second;
            double distance = Math.Sqrt(result);

            return distance;
        }

        /// <summary>
        /// Cambia el tipo de mapa a satelite.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSatelite_Click(object sender, EventArgs e)
        {
            gMapC.MapProvider = GMapProviders.GoogleChinaSatelliteMap;
        }

        /// <summary>
        /// Cambia el tipo de mapa al diseño normal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOriginal_Click(object sender, EventArgs e)
        {
            gMapC.MapProvider = GMapProviders.GoogleMap;
        }

        /// <summary>
        /// Cambia el tipo de mapa a relieve.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btRelief_Click(object sender, EventArgs e)
        {
            gMapC.MapProvider = GMapProviders.GoogleTerrainMap;
        }

        /// <summary>
        /// Sincroniza el zoom que se realiza con el raton y actualiza el trackBar conforme lo amplia o disminuye el mapa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            trackBarZoom.Value = Convert.ToInt32(gMapC.Zoom);
        }

        /// <summary>
        /// Permite hacer zoom al mapa por medio de la barra StrackBar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            gMapC.Zoom = trackBarZoom.Value;
        }

        private void btShowPollutionColor_Click(object sender, EventArgs e)
        {
            Circle(pB1, Color.Red);
            Circle(pB2, Color.OrangeRed);
            Circle(pB3, Color.Yellow);
            Circle(pB4, Color.Green);


            // 
            // label9
            // 
            Label label9 = new Label();
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(1211, 95);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(63, 13);
            label9.TabIndex = 10;
            label9.Text = "Emergencia";
            label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            Label label10 = new Label();

            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(1211, 187);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(63, 13);
            label10.TabIndex = 11;
            label10.Text = "Alerta";
            label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            Label label11 = new Label();

            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(1211, 289);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(63, 13);
            label11.TabIndex = 12;
            label11.Text = "Prevencion";
            label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // 
            // label12
            // 
            Label label12 = new Label();

            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(1211, 386);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(63, 13);
            label12.TabIndex = 13;
            label12.Text = "Permisible";
            label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        }


        private void Circle(PictureBox pictureBox, Color color)
        {
            Graphics papel;
            papel = pictureBox.CreateGraphics();
            SolidBrush myBrush = new SolidBrush(color);
            Pen lapiz = new Pen(myBrush);
            papel.FillRectangle(myBrush, 0, 0, pictureBox.Width, pictureBox.Height);

            papel.Dispose();
            lapiz.Dispose();
            myBrush.Dispose();
        }


        private void MouseOver(object sender, EventArgs e)
        {
            string title = "";
            string text = "";
            if (sender.Equals(pB1))
            {
                title = EMERGENCIA + "Dañina para la salud";
                text = "Todos los individuos pueden comenzar a experimentar efectos " +
                       "sobre la salud. Los grupos sencibles pueden experimentar efectos más graves que la salud." +
                       "\n" + "\n"
                       + "El nivel de contaminación del PM10 ug/ m ^ 3 :" + "\n" + "\n" + "Alerta: 255 - 245";

                auxiliarPopup(title, text, Color.Red);
            }
            else if (sender.Equals(pB2))
            {
            }
            else if (sender.Equals(pB3))
            {
            }
            else
            {
            }
        }


        private void auxiliarPopup(string title, string text, Color color)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = title;
            popup.ContentText = text;
            popup.TitleFont = SystemFonts.CaptionFont;
            popup.BorderColor = SystemColors.WindowFrame;
            popup.ContentFont = SystemFonts.StatusFont;
            popup.BorderColor = Color.Transparent;
            popup.Delay = 5000;
            popup.Scroll = true;
            popup.BodyColor = Color.FromArgb(50, color);
            popup.Popup();
        }

        public void inicializarVariables(List<Variable_Registrada> variables)
        {
            Variable_Registrada varUno = new Variable_Registrada();
            varUno.Variable = "PM10";
            varUno.Unidades = "µg/m3";
            variables.Add(varUno);

            Variable_Registrada varDos = new Variable_Registrada();
            varDos.Variable = "O3";
            varDos.Unidades = "µg/m3";
            variables.Add(varDos);

            Variable_Registrada varTres = new Variable_Registrada();
            varTres.Variable = "Radiación Solar Global";
            varTres.Unidades = "W/m2";
            variables.Add(varTres);
        }

        public async void inicializarMunicipios()
        {
            string Base =
                URL +
                "$limit=1&$select=latitud,longitud,departamento,nombre_del_municipio&$where=(nombre_del_municipio=";

            string consulta = "'BOGOTÁ. D.C.')";
            string url = Base + consulta;
            string respuesta = await GetHttp(url);
            List<Municipio> municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());

            consulta = "'MEDELLÍN')";
            url = Base + consulta;
            respuesta = await GetHttp(url);
            municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());

            consulta = "'CALI')";
            url = Base + consulta;
            respuesta = await GetHttp(url);
            municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());

            consulta = "'BUCARAMANGA')";
            url = Base + consulta;
            respuesta = await GetHttp(url);
            municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());

            consulta = "'ITAGÜÍ')";
            url = Base + consulta;
            respuesta = await GetHttp(url);
            municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());

            consulta = "'CALDAS')";
            url = Base + consulta;
            respuesta = await GetHttp(url);
            municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());

            consulta = "'BARBOSA')";
            url = Base + consulta;
            respuesta = await GetHttp(url);
            municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());

            consulta = "'BELLO')";
            url = Base + consulta;
            respuesta = await GetHttp(url);
            municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());

            consulta = "'FLORIDABLANCA')";
            url = Base + consulta;
            respuesta = await GetHttp(url);
            municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());

            consulta = "'SOGAMOSO')";
            url = Base + consulta;
            respuesta = await GetHttp(url);
            municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());

            consulta = "'NOBSA')";
            url = Base + consulta;
            respuesta = await GetHttp(url);
            municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());

            consulta = "'ENVIGADO')";
            url = Base + consulta;
            respuesta = await GetHttp(url);
            municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());

            consulta = "'GIRARDOTA')";
            url = Base + consulta;
            respuesta = await GetHttp(url);
            municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());

            consulta = "'SANTA MARTA')";
            url = Base + consulta;
            respuesta = await GetHttp(url);
            municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());

            consulta = "'SOLEDAD')";
            url = Base + consulta;
            respuesta = await GetHttp(url);
            municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());

            consulta = "'BARRANQUILLA')";
            url = Base + consulta;
            respuesta = await GetHttp(url);
            municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());

            consulta = "'CIÉNAGA')";
            url = Base + consulta;
            respuesta = await GetHttp(url);
            municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());

            consulta = "'VILLAVICENCIO')";
            url = Base + consulta;
            respuesta = await GetHttp(url);
            municipio = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);
            municipio.First().Variables = new List<Variable_Registrada>();
            inicializarVariables(municipio.First().Variables);
            municipios_Set.Add(municipio.First());
        }

        /*
         * Dado un municipio, un tipo de variable y un year especifico toma los primeros 1000 registros de la concentracion de
         * ese municipio. Los milregistros quedan en la variable consulta. La coleccion.
         *
         * De no tener datos la consulta quedera con tamanio 0.
         */
        public void consultarDatos(string municipio, string variable, int year, int limite)
        {
            var client = new SodaClient("https://www.datos.gov.co", "8naPxF3oQIYI1NiilJm2JgR3q");
            var dataset = client.GetResource<Dictionary<string, string>>("ysq6-ri4e");

            //string Base = "$limit=3&$select=Concentraci_n&$where=";
            string datoUno = "(nombre_del_municipio='" + municipio + "')AND";
            string datoDos = "(variable='" + variable + "')AND";
            string datoTres = "(Concentraci_n>0)";
            // string datoDos = "(variable='" + variable + "')AND";
            // string datoTres = "(fecha like '%25" + year.ToString() + "%25')";

            //string url = Base + datoUno + datoDos + datoTres;

            // var soql = new SoqlQuery().Limit(5).Select("Concentraci_n")
            //    .Where(datoUno + datoDos + datoTres);

            var soql = new SoqlQuery().Select("Concentraci_n")
                .Where(datoUno + datoDos + datoTres).Limit(limite).Offset(0);

            var results = dataset.Query<Dictionary<string, string>>(soql);

            foreach (Dictionary<string, string> VARIABLE in results)
            {
                Concentracion_Registro con = new Concentracion_Registro();
                if (VARIABLE.Count > 0)
                {
                    con.Concentraci_n = double.Parse(VARIABLE.First().Value);
                    consulta.Add(con);
                }
            }

            //string respuesta = await GetHttp(url);
            // Consulta = JsonConvert.DeserializeObject<List<Concentracion_Registro>>(respuesta);
            //  Console.WriteLine();
        }

        /*
         * Calcula el valor promedio de cada variable de un municipio
         * toma en cuenta el year actual
         *
         * De ser -1 es porque no existen registros para esa variable.
         */
        public void calcularDatosMunicipio(Municipio municipio)
        {
            foreach (var variable in municipio.Variables)
            {
                //con esto en la variable consulta tendre los datos
                // 3 el numero de filas para que cargue rapido
                consultarDatos(municipio.Nombre_del_municipio, variable.Variable, yearActual, 5);
                // verifico que hayan datos
                if (Consulta.Count > 0)
                {
                    // por si no hay 1000 registros
                    int count = 0;
                    double total = 0;

                    foreach (var dato in Consulta)
                    {
                        count += 1;
                        total += dato.Concentraci_n;
                    }

                    variable.Concentracion = total / count;
                    consulta.Clear();
                }
                else
                {
                    variable.Concentracion = -1;
                }
            }
        }

        /*
         * inicializa los datos de las variables de cada municipio
         */
        public void inicializarDatosMunicipios()
        {
            foreach (var municipio in MunicipiosSet)
            {
                calcularDatosMunicipio(municipio);
            }
        }

        // /// <summary>
        // /// This method is called each time the user filters the database, and displays the information on the statistics tab accordingly.
        // /// </summary>
        // private void refreshStatisticsTab()
        // {
        //     Statistics_Title_Label.Text = "Estadísticas Generales para " + municipioActual + " en " + yearActual;
        //     GeneralStatisticCalculator gsc = new GeneralStatisticCalculator(null);
        //     averageLabel.Text = "1- " + gsc.Average();
        //     maxLabel.Text = "2- " + gsc.Max();
        //     minLabel.Text = "3- " + gsc.Min();
        //     desvLabel.Text = "4- " + gsc.desvit();
        //     phLabel.Text = gsc.hProof();
        // }

        private void Arima(string municipio, string variable)
        {
            consultarDatos(municipio, variable, 2012, Convert.ToInt32(textBox3.Text));
            List<double> temp = new List<double>();

            foreach (var valor in consulta)
            {
                temp.Add(valor.Concentraci_n);
            }

            consulta.Clear();

            var forecast = forecastTextBox.Text;
            DataAnalysis processor = new DataAnalysis();
            double[] arimaforecast = processor.Arima(Convert.ToInt32(forecast), temp.ToArray());
            arima.Series[0].Points.DataBindY(arimaforecast);
        }

        private void TimeSeries(string municipio, string variable)
        {
            consultarDatos(municipio, variable, 2012, Convert.ToInt32(textBox3.Text));
            List<double> temp = new List<double>();

            foreach (var valor in consulta)
            {
                temp.Add(valor.Concentraci_n);
            }

            consulta.Clear();

            timeSeries.Series[0].Points.DataBindY(temp);
            ciudadLabel.Text = municipioActual.Nombre_del_municipio;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string variable = null;
            foreach (var variableAComparar in municipioActual.Variables)
            {
                if (variableAComparar.Variable.Equals(variableCB.SelectedItem.ToString()))
                {
                    variable = variableCB.SelectedItem.ToString();
                }
            }

            Arima(MunicipioActual.Nombre_del_municipio, variable);
        }

        private void PieChart()
        {
            pieChart.Series[0].Points.Clear();

            foreach (var variable in municipioActual.Variables)
            {
                pieChart.Series[0].Points.AddXY(variable.Variable, variable.Concentracion);
            }

            pieChart.Legends[0].Enabled = true;
            pieChart.Series[0].IsValueShownAsLabel = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string variable = null;
            foreach (var variableAComparar in municipioActual.Variables)
            {
                if (variableAComparar.Variable.Equals(variableCB.SelectedItem.ToString()))
                {
                    variable = variableCB.SelectedItem.ToString();
                }
            }

            TimeSeries(MunicipioActual.Nombre_del_municipio, variable);
            PieChart();
        }

        private void variableGmaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            PollutionColor();
        }

     
    }
}
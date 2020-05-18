using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using SODA;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class blume : Form
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
        private string municipioActual;

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

        public blume()
        {
            YearActual = 2011;
            MunicipiosSet = new List<Municipio>();
            Consulta = new List<Concentracion_Registro>();

            inicializarMunicipios();

            // consultarDatos(municipios_Set.First().Nombre_del_municipio, variables_Set.First().Variable, yearActual);
            inicializarDatosMunicipios();

            count_click = 0;
            
            //TimeSeries();
            //Arima();

            InitializeComponent();
            columnsValues = new string[15];
            elements = new List<Element>();
        }

        public int YearActual
        {
            get => yearActual;
            set => yearActual = value;
        }

        public string MunicipioActual
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
            PollutionColor(lst);
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

            refreshStatisticsTab();
        }
        
        /// <summary>
        /// This method allows you to create the controllers responsible for filtering.
        /// </summary>
        private void createControlsyToFilter(Label lbFilterBy, ComboBox cbFilterBy, Label lbValueToFilter,
            TextBox txValueToFilter, Button btAdd, Button btClear)
        {
            //
            // lbFilterBy
            //
            lbFilterBy.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
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
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
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
                        if (((Button) sender).Name == "btClear" + i.ToString())
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

                        if (((Button) sender).Name == "btAdd" + i.ToString())
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
        private void PollutionColor(List<ViewModel> lst)
        {
            foreach (var value in lst)
            {
                string pollutionLevel = DefineContaminationLevel(value.Variable, value.Concentraci_n);

                if (pollutionLevel.Equals(EMERGENCIA))
                {
                    AddMarker(value, Color.FromArgb(50, Color.Red), GMarkerGoogleType.red);
                }
                else if (pollutionLevel.Equals(ALERTA))
                {
                    AddMarker(value, Color.FromArgb(50, Color.OrangeRed), GMarkerGoogleType.orange);
                }
                else if (pollutionLevel.Equals(PREVENCION))
                {
                    AddMarker(value, Color.FromArgb(50, Color.Yellow), GMarkerGoogleType.yellow);
                }
                else
                {
                    AddMarker(value, Color.FromArgb(50, Color.Green), GMarkerGoogleType.green);
                }
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

            //Casos.
            if (concentracion <= 100)
            {
                pollutionLevel = PERMISIBLE;
            }
            else if (concentracion >= 155 && concentracion <= 254)
            {
                pollutionLevel = PREVENCION;
            }
            else if (concentracion >= 255 && concentracion <= 354)
            {
                pollutionLevel = ALERTA;
            }
            else if (concentracion >= 355)
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

            // Casos.
            if (concentracion <= 100)
            {
                pollutionLevel = PERMISIBLE;
            }
            else if (concentracion >= 139 && concentracion <= 167)
            {
                pollutionLevel = PREVENCION;
            }
            else if (concentracion >= 168 && concentracion <= 207)
            {
                pollutionLevel = ALERTA;
            }
            else if (concentracion >= 208)
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
            string pollutionLevel = PERMISIBLE;

            //Casos.

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
        private void AddMarker(ViewModel value, Color polygonColor, GMarkerGoogleType markerColor)
        {
            var markerOverlay = new GMapOverlay("markers");
            var marker = new GMarkerGoogle(new PointLatLng(value.Latitud, value.Longitud), markerColor);
            
            markerOverlay.Markers.Add(marker);

            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.ToolTipText = String.Format("Fecha: " + value.Fecha + "\n"
                                               + "Autoridad Ambiental: " + value.Autoridad_ambiental + "\n"
                                               + "Nombre de la estación: " + value.Nombre_de_la_estaci_n + "\n"
                                               + "Tecnologia: " + value.Tecnolog_a + "\n"
                                               + "Latitud: " + value.Latitud + "\n"
                                               + "Longitud: " + value.Longitud + "\n"
                                               + "Codigo del departamento: " + value.C_digo_del_departamento + "\n"
                                               + "Departamento: " + value.Departamento + "\n"
                                               + "Codigo de municipio: " + value.C_digo_del_municipio + "\n"
                                               + "Municipio: " + value.Nombre_del_municipio + "\n"
                                               + "Tipo de estación: " + value.Tipo_de_estaci_n + "\n"
                                               + "Tiempo de exposición: " + value.Tiempo_de_exposici_n + "\n"
                                               + "Variable: " + value.Variable + "\n"
                                               + "Unidades: " + value.Unidades + "\n"
                                               + "Concentración: " + value.Concentraci_n
            );

            // Añade un poligono como representación al nivel de contaminación.
            AddPolygon(value, polygonColor);
            gMapC.Overlays.Add(markerOverlay);
        }

        /// <summary>
        /// Este metodo permite crear un poligono alrededor de las coordenadas donde se realizo la prueba y de
        /// esta manera generar un cuadrado como representación de el nivel de contaminación en esta zona.
        /// </summary>
        /// <param name="value"></param> Representa a un elemnento de la base de datos
        /// <param name="polygonColor"></param> Representa el color que rellena el poligono, de esta forma representar el nivel de contaminación de la zona.
        private void AddPolygon(ViewModel value, Color polygonColor)
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
        
        private void Circle(object sender, MouseEventArgs e)
        {
            MessageBox.Show("hola");
            Graphics papel;
            papel = pB1.CreateGraphics();
            SolidBrush myBrush = new SolidBrush(Color.Red);
            Pen lapiz = new Pen(myBrush);
            papel.FillRectangle(myBrush, 0, 0, pB1.Width, pB1.Height);
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
            string datoDos = "(variable='" + variable + "')";
            // string datoDos = "(variable='" + variable + "')AND";
            // string datoTres = "(fecha like '%25" + year.ToString() + "%25')";

            //string url = Base + datoUno + datoDos + datoTres;

            // var soql = new SoqlQuery().Limit(5).Select("Concentraci_n")
            //    .Where(datoUno + datoDos + datoTres);

            var soql = new SoqlQuery().Select("Concentraci_n")
                .Where(datoUno + datoDos).Limit(limite);

            var results = dataset.Query<Dictionary<string, string>>(soql);

            foreach (var VARIABLE in results)
            {
                Concentracion_Registro con = new Concentracion_Registro();
                con.Concentraci_n = double.Parse(VARIABLE.First().Value);
                consulta.Add(con);
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
                consultarDatos(municipio.Nombre_del_municipio, variable.Variable, yearActual, 3);
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

        /// <summary>
        /// This method is called each time the user filters the database, and displays the information on the statistics tab accordingly.
        /// </summary>
        private void refreshStatisticsTab()
        {
            Statistics_Title_Label.Text = "Estadísticas Generales para " + municipioActual + " en " + yearActual;
            GeneralStatisticCalculator gsc = new GeneralStatisticCalculator(null);
            averageLabel.Text = "1- " + gsc.Average();
            maxLabel.Text = "2- " + gsc.Max();
            minLabel.Text = "3- " + gsc.Min();
            desvLabel.Text = "4- " + gsc.desvit();
            phLabel.Text = gsc.hProof();
        }
        private void Arima()
        {
            var forecast = 5;
            DataAnalysis processor = new DataAnalysis();
            arima.Series[0].Points.DataBindY(processor.Arima(forecast));
        }

        private void TimeSeries(){
                double[] sunspots =
                {
                    100.8, 81.6, 66.5, 34.8, 30.6, 7, 19.8, 92.5,
                    154.4, 125.9, 84.8, 68.1, 38.5, 22.8, 10.2, 24.1, 82.9,
                    132, 130.9, 118.1, 89.9, 66.6, 60, 46.9, 41, 21.3, 16,
                    6.4, 4.1, 6.8, 14.5, 34, 45, 43.1, 47.5, 42.2, 28.1, 10.1,
                    8.1, 2.5, 0, 1.4, 5, 12.2, 13.9, 35.4, 45.8, 41.1, 30.4,
                    23.9, 15.7, 6.6, 4, 1.8, 8.5, 16.6, 36.3, 49.7, 62.5, 67,
                    71, 47.8, 27.5, 8.5, 13.2, 56.9, 121.5, 138.3, 103.2,
                    85.8, 63.2, 36.8, 24.2, 10.7, 15, 40.1, 61.5, 98.5, 124.3,
                    95.9, 66.5, 64.5, 54.2, 39, 20.6, 6.7, 4.3, 22.8, 54.8,
                    93.8, 95.7, 77.2, 59.1, 44, 47, 30.5, 16.3, 7.3, 37.3,
                    73.9
                };

                Series series = new Series();
                for (int i = 0; i < sunspots.Length; i++)
                {
                    DataPoint dataPoint = new DataPoint(i, sunspots[i]);
                    series.Points.Add(dataPoint);
                }

                timeSeries.Series[0].Points.DataBindY(sunspots);
        }
    }
}
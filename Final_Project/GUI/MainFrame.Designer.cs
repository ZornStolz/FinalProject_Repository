using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using Microsoft.Win32;

namespace GUI
{
    partial class Blume
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.dtGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPageFilters = new System.Windows.Forms.TabPage();
            this.prueba = new System.Windows.Forms.Label();
            this.btCreateNewFilter = new System.Windows.Forms.Button();
            this.fLP = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btFilter = new System.Windows.Forms.Button();
            this.txURL = new System.Windows.Forms.TextBox();
            this.tabPageGmap = new System.Windows.Forms.TabPage();
            this.pB1 = new System.Windows.Forms.PictureBox();
            this.trackBarZoom = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.btRelief = new System.Windows.Forms.Button();
            this.btOriginal = new System.Windows.Forms.Button();
            this.btSatelite = new System.Windows.Forms.Button();
            this.gMapC = new GMap.NET.WindowsForms.GMapControl();
            this.tabPageStadistc = new System.Windows.Forms.TabPage();
            this.ciudadLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.variableCB = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.forecastTextBox = new System.Windows.Forms.TextBox();
            this.arima = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timeSeries = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize) (this.dtGrid)).BeginInit();
            this.tab.SuspendLayout();
            this.tabPageFilters.SuspendLayout();
            this.tabPageGmap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.trackBarZoom)).BeginInit();
            this.tabPageStadistc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pieChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.arima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.timeSeries)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGrid
            // 
            this.dtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrid.Location = new System.Drawing.Point(3, 6);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.RowHeadersWidth = 51;
            this.dtGrid.Size = new System.Drawing.Size(786, 630);
            this.dtGrid.TabIndex = 8;
            this.dtGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrid_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(563, 655);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(230, 655);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(308, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(153, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPageFilters);
            this.tab.Controls.Add(this.tabPageGmap);
            this.tab.Controls.Add(this.tabPageStadistc);
            this.tab.Location = new System.Drawing.Point(0, 1);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1374, 752);
            this.tab.TabIndex = 16;
            // 
            // tabPageFilters
            // 
            this.tabPageFilters.Controls.Add(this.prueba);
            this.tabPageFilters.Controls.Add(this.btCreateNewFilter);
            this.tabPageFilters.Controls.Add(this.fLP);
            this.tabPageFilters.Controls.Add(this.label1);
            this.tabPageFilters.Controls.Add(this.btFilter);
            this.tabPageFilters.Controls.Add(this.txURL);
            this.tabPageFilters.Controls.Add(this.dtGrid);
            this.tabPageFilters.Controls.Add(this.button2);
            this.tabPageFilters.Controls.Add(this.button1);
            this.tabPageFilters.Location = new System.Drawing.Point(4, 22);
            this.tabPageFilters.Name = "tabPageFilters";
            this.tabPageFilters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFilters.Size = new System.Drawing.Size(1366, 726);
            this.tabPageFilters.TabIndex = 0;
            this.tabPageFilters.Text = "Filtros";
            this.tabPageFilters.UseVisualStyleBackColor = true;
            // 
            // prueba
            // 
            this.prueba.AutoSize = true;
            this.prueba.Location = new System.Drawing.Point(1125, 572);
            this.prueba.Name = "prueba";
            this.prueba.Size = new System.Drawing.Size(35, 13);
            this.prueba.TabIndex = 21;
            this.prueba.Text = "label2";
            // 
            // btCreateNewFilter
            // 
            this.btCreateNewFilter.Location = new System.Drawing.Point(928, 88);
            this.btCreateNewFilter.Name = "btCreateNewFilter";
            this.btCreateNewFilter.Size = new System.Drawing.Size(211, 23);
            this.btCreateNewFilter.TabIndex = 20;
            this.btCreateNewFilter.Text = "Crear nuevo filtro";
            this.btCreateNewFilter.UseVisualStyleBackColor = true;
            this.btCreateNewFilter.Click += new System.EventHandler(this.btCreateNewFilter_Click);
            // 
            // fLP
            // 
            this.fLP.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.fLP.AutoScroll = true;
            this.fLP.Location = new System.Drawing.Point(806, 130);
            this.fLP.Margin = new System.Windows.Forms.Padding(4);
            this.fLP.Name = "fLP";
            this.fLP.Size = new System.Drawing.Size(458, 326);
            this.fLP.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(904, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "URL";
            // 
            // btFilter
            // 
            this.btFilter.Location = new System.Drawing.Point(1007, 472);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(75, 23);
            this.btFilter.TabIndex = 18;
            this.btFilter.Text = "Filtrar";
            this.btFilter.UseVisualStyleBackColor = true;
            // 
            // txURL
            // 
            this.txURL.Location = new System.Drawing.Point(939, 36);
            this.txURL.Name = "txURL";
            this.txURL.Size = new System.Drawing.Size(100, 20);
            this.txURL.TabIndex = 16;
            // 
            // tabPageGmap
            // 
            this.tabPageGmap.Controls.Add(this.pB1);
            this.tabPageGmap.Controls.Add(this.trackBarZoom);
            this.tabPageGmap.Controls.Add(this.label2);
            this.tabPageGmap.Controls.Add(this.btRelief);
            this.tabPageGmap.Controls.Add(this.btOriginal);
            this.tabPageGmap.Controls.Add(this.btSatelite);
            this.tabPageGmap.Controls.Add(this.gMapC);
            this.tabPageGmap.Location = new System.Drawing.Point(4, 22);
            this.tabPageGmap.Name = "tabPageGmap";
            this.tabPageGmap.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGmap.Size = new System.Drawing.Size(1366, 726);
            this.tabPageGmap.TabIndex = 1;
            this.tabPageGmap.Text = "Gmap";
            this.tabPageGmap.UseVisualStyleBackColor = true;
            // 
            // pB1
            // 
            this.pB1.Location = new System.Drawing.Point(1075, 6);
            this.pB1.Name = "pB1";
            this.pB1.Size = new System.Drawing.Size(102, 88);
            this.pB1.TabIndex = 0;
            this.pB1.TabStop = false;
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.LargeChange = 1;
            this.trackBarZoom.Location = new System.Drawing.Point(593, 643);
            this.trackBarZoom.Maximum = 20;
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(476, 45);
            this.trackBarZoom.TabIndex = 5;
            this.trackBarZoom.Value = 6;
            this.trackBarZoom.Scroll += new System.EventHandler(this.trackBarZoom_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(543, 654);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Zoom";
            // 
            // btRelief
            // 
            this.btRelief.Location = new System.Drawing.Point(361, 649);
            this.btRelief.Name = "btRelief";
            this.btRelief.Size = new System.Drawing.Size(109, 23);
            this.btRelief.TabIndex = 3;
            this.btRelief.Text = "Relieve";
            this.btRelief.UseVisualStyleBackColor = true;
            this.btRelief.Click += new System.EventHandler(this.btRelief_Click);
            // 
            // btOriginal
            // 
            this.btOriginal.Location = new System.Drawing.Point(236, 649);
            this.btOriginal.Name = "btOriginal";
            this.btOriginal.Size = new System.Drawing.Size(109, 23);
            this.btOriginal.TabIndex = 2;
            this.btOriginal.Text = "Original";
            this.btOriginal.UseVisualStyleBackColor = true;
            this.btOriginal.Click += new System.EventHandler(this.btOriginal_Click);
            // 
            // btSatelite
            // 
            this.btSatelite.Location = new System.Drawing.Point(112, 649);
            this.btSatelite.Name = "btSatelite";
            this.btSatelite.Size = new System.Drawing.Size(109, 23);
            this.btSatelite.TabIndex = 1;
            this.btSatelite.Text = "Satélite";
            this.btSatelite.UseVisualStyleBackColor = true;
            this.btSatelite.Click += new System.EventHandler(this.btSatelite_Click);
            // 
            // gMapC
            // 
            this.gMapC.Bearing = 0F;
            this.gMapC.CanDragMap = true;
            this.gMapC.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapC.GrayScaleMode = false;
            this.gMapC.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapC.LevelsKeepInMemmory = 5;
            this.gMapC.Location = new System.Drawing.Point(8, 6);
            this.gMapC.MarkersEnabled = true;
            this.gMapC.MaxZoom = 2;
            this.gMapC.MinZoom = 2;
            this.gMapC.MouseWheelZoomEnabled = true;
            this.gMapC.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapC.Name = "gMapC";
            this.gMapC.NegativeMode = false;
            this.gMapC.PolygonsEnabled = true;
            this.gMapC.RetryLoadTile = 0;
            this.gMapC.RoutesEnabled = true;
            this.gMapC.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapC.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int) (((byte) (33)))), ((int) (((byte) (65)))), ((int) (((byte) (105)))), ((int) (((byte) (225)))));
            this.gMapC.ShowTileGridLines = false;
            this.gMapC.Size = new System.Drawing.Size(1061, 631);
            this.gMapC.TabIndex = 0;
            this.gMapC.Zoom = 0D;
            this.gMapC.Load += new System.EventHandler(this.gMapC_Load);
            // 
            // tabPageStadistc
            // 
            this.tabPageStadistc.Controls.Add(this.ciudadLabel);
            this.tabPageStadistc.Controls.Add(this.label8);
            this.tabPageStadistc.Controls.Add(this.variableCB);
            this.tabPageStadistc.Controls.Add(this.button5);
            this.tabPageStadistc.Controls.Add(this.textBox3);
            this.tabPageStadistc.Controls.Add(this.label7);
            this.tabPageStadistc.Controls.Add(this.label6);
            this.tabPageStadistc.Controls.Add(this.label5);
            this.tabPageStadistc.Controls.Add(this.pieChart);
            this.tabPageStadistc.Controls.Add(this.label3);
            this.tabPageStadistc.Controls.Add(this.button4);
            this.tabPageStadistc.Controls.Add(this.label4);
            this.tabPageStadistc.Controls.Add(this.forecastTextBox);
            this.tabPageStadistc.Controls.Add(this.arima);
            this.tabPageStadistc.Controls.Add(this.timeSeries);
            this.tabPageStadistc.Location = new System.Drawing.Point(4, 22);
            this.tabPageStadistc.Name = "tabPageStadistc";
            this.tabPageStadistc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStadistc.Size = new System.Drawing.Size(1366, 726);
            this.tabPageStadistc.TabIndex = 2;
            this.tabPageStadistc.Text = "Estadisticas";
            this.tabPageStadistc.UseVisualStyleBackColor = true;
            // 
            // ciudadLabel
            // 
            this.ciudadLabel.Location = new System.Drawing.Point(65, 53);
            this.ciudadLabel.Name = "ciudadLabel";
            this.ciudadLabel.Size = new System.Drawing.Size(100, 23);
            this.ciudadLabel.TabIndex = 16;
            this.ciudadLabel.Text = ".";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(372, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "Variable a analizar";
            // 
            // variableCB
            // 
            this.variableCB.FormattingEnabled = true;
            this.variableCB.Location = new System.Drawing.Point(351, 159);
            this.variableCB.Name = "variableCB";
            this.variableCB.Size = new System.Drawing.Size(121, 21);
            this.variableCB.TabIndex = 14;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(372, 195);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(73, 24);
            this.button5.TabIndex = 13;
            this.button5.Text = "Ir";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(443, 66);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(55, 20);
            this.textBox3.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(372, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "No. Valores";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(49, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Diagrama de Pastel";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(732, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Predicción ARIMA";
            // 
            // pieChart
            // 
            chartArea1.Name = "ChartArea1";
            this.pieChart.ChartAreas.Add(chartArea1);
            legend1.Name = "PM10";
            this.pieChart.Legends.Add(legend1);
            this.pieChart.Location = new System.Drawing.Point(48, 323);
            this.pieChart.Name = "pieChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "PM10";
            series1.Name = "Series1";
            this.pieChart.Series.Add(series1);
            this.pieChart.Size = new System.Drawing.Size(222, 213);
            this.pieChart.TabIndex = 8;
            this.pieChart.Text = "chart1";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.Location = new System.Drawing.Point(33, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Serie de Tiempo";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(814, 101);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Ir";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(775, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Numero de valores a predecir";
            // 
            // forecastTextBox
            // 
            this.forecastTextBox.Location = new System.Drawing.Point(824, 69);
            this.forecastTextBox.Name = "forecastTextBox";
            this.forecastTextBox.Size = new System.Drawing.Size(55, 20);
            this.forecastTextBox.TabIndex = 4;
            // 
            // arima
            // 
            chartArea2.Name = "ChartArea1";
            this.arima.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.arima.Legends.Add(legend2);
            this.arima.Location = new System.Drawing.Point(692, 195);
            this.arima.Name = "arima";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Legend = "Legend1";
            series2.MarkerSize = 10;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star4;
            series2.Name = "Series1";
            this.arima.Series.Add(series2);
            this.arima.Size = new System.Drawing.Size(366, 238);
            this.arima.TabIndex = 3;
            this.arima.Text = "chart2";
            // 
            // timeSeries
            // 
            chartArea3.Name = "ChartArea1";
            this.timeSeries.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.timeSeries.Legends.Add(legend3);
            this.timeSeries.Location = new System.Drawing.Point(8, 43);
            this.timeSeries.Name = "timeSeries";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.timeSeries.Series.Add(series3);
            this.timeSeries.Size = new System.Drawing.Size(375, 200);
            this.timeSeries.TabIndex = 2;
            this.timeSeries.Text = "chart1";
            title1.Name = "Serie de Tiempo";
            this.timeSeries.Titles.Add(title1);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Blume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 609);
            this.Controls.Add(this.tab);
            this.Name = "Blume";
            this.Text = "BLUME";
            this.Load += new System.EventHandler(this.MainFrame_Load);
            ((System.ComponentModel.ISupportInitialize) (this.dtGrid)).EndInit();
            this.tab.ResumeLayout(false);
            this.tabPageFilters.ResumeLayout(false);
            this.tabPageFilters.PerformLayout();
            this.tabPageGmap.ResumeLayout(false);
            this.tabPageGmap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.trackBarZoom)).EndInit();
            this.tabPageStadistc.ResumeLayout(false);
            this.tabPageStadistc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pieChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.arima)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.timeSeries)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataVisualization.Charting.Chart arima;
        private System.Windows.Forms.Button btCreateNewFilter;
        private System.Windows.Forms.Button btFilter;
        private System.Windows.Forms.Button btOriginal;
        private System.Windows.Forms.Button btRelief;
        private System.Windows.Forms.Button btSatelite;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label ciudadLabel;
        private System.Windows.Forms.DataGridView dtGrid;
        private System.Windows.Forms.FlowLayoutPanel fLP;
        private System.Windows.Forms.TextBox forecastTextBox;
        private GMap.NET.WindowsForms.GMapControl gMapC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pB1;
        private System.Windows.Forms.DataVisualization.Charting.Chart pieChart;
        private System.Windows.Forms.Label prueba;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPageFilters;
        private System.Windows.Forms.TabPage tabPageGmap;
        private System.Windows.Forms.TabPage tabPageStadistc;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DataVisualization.Charting.Chart timeSeries;
        private System.Windows.Forms.TrackBar trackBarZoom;
        private System.Windows.Forms.TextBox txURL;
        private System.Windows.Forms.ComboBox variableCB;

        #endregion

        private System.Windows.Forms.PictureBox pB4;
        private System.Windows.Forms.PictureBox pB3;
        private System.Windows.Forms.PictureBox pB2;
        private System.Windows.Forms.Button btShowPollutionColor;
    }
}


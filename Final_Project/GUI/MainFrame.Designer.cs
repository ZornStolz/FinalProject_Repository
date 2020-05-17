using GMap.NET.MapProviders;
using Microsoft.Win32;

namespace GUI
{
    partial class blume
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
            this.tab.SuspendLayout();
            this.tabPageFilters.SuspendLayout();
            this.tabPageGmap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGrid
            // 
            this.dtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrid.Location = new System.Drawing.Point(4, 7);
            this.dtGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.RowHeadersWidth = 51;
            this.dtGrid.Size = new System.Drawing.Size(1187, 775);
            this.dtGrid.TabIndex = 8;
            this.dtGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrid_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(751, 806);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(307, 806);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
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
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(153, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 2;
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPageFilters);
            this.tab.Controls.Add(this.tabPageGmap);
            this.tab.Controls.Add(this.tabPageStadistc);
            this.tab.Location = new System.Drawing.Point(0, 1);
            this.tab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1832, 926);
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
            this.tabPageFilters.Location = new System.Drawing.Point(4, 25);
            this.tabPageFilters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageFilters.Name = "tabPageFilters";
            this.tabPageFilters.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageFilters.Size = new System.Drawing.Size(1824, 897);
            this.tabPageFilters.TabIndex = 0;
            this.tabPageFilters.Text = "Filtros";
            this.tabPageFilters.UseVisualStyleBackColor = true;
            // 
            // prueba
            // 
            this.prueba.AutoSize = true;
            this.prueba.Location = new System.Drawing.Point(1500, 704);
            this.prueba.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.prueba.Name = "prueba";
            this.prueba.Size = new System.Drawing.Size(46, 17);
            this.prueba.TabIndex = 21;
            this.prueba.Text = "label2";
            // 
            // btCreateNewFilter
            // 
            this.btCreateNewFilter.Location = new System.Drawing.Point(1363, 154);
            this.btCreateNewFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCreateNewFilter.Name = "btCreateNewFilter";
            this.btCreateNewFilter.Size = new System.Drawing.Size(281, 28);
            this.btCreateNewFilter.TabIndex = 20;
            this.btCreateNewFilter.Text = "Crear nuevo filtro";
            this.btCreateNewFilter.UseVisualStyleBackColor = true;
            this.btCreateNewFilter.Click += new System.EventHandler(this.btCreateNewFilter_Click);
            // 
            // fLP
            // 
            this.fLP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fLP.AutoScroll = true;
            this.fLP.Location = new System.Drawing.Point(1200, 206);
            this.fLP.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.fLP.Name = "fLP";
            this.fLP.Size = new System.Drawing.Size(611, 401);
            this.fLP.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1331, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "URL";
            // 
            // btFilter
            // 
            this.btFilter.Location = new System.Drawing.Point(1468, 626);
            this.btFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(100, 28);
            this.btFilter.TabIndex = 18;
            this.btFilter.Text = "Filtrar";
            this.btFilter.UseVisualStyleBackColor = true;
            //this.btFilter.Click += new System.EventHandler(this.btFilter_Click);
            // 
            // txURL
            // 
            this.txURL.Location = new System.Drawing.Point(1377, 90);
            this.txURL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txURL.Name = "txURL";
            this.txURL.Size = new System.Drawing.Size(132, 22);
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
            this.tabPageGmap.Location = new System.Drawing.Point(4, 25);
            this.tabPageGmap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageGmap.Name = "tabPageGmap";
            this.tabPageGmap.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageGmap.Size = new System.Drawing.Size(1824, 897);
            this.tabPageGmap.TabIndex = 1;
            this.tabPageGmap.Text = "Gmap";
            this.tabPageGmap.UseVisualStyleBackColor = true;
            // 
            // pB1
            // 
            this.pB1.Location = new System.Drawing.Point(1433, 7);
            this.pB1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pB1.Name = "pB1";
            this.pB1.Size = new System.Drawing.Size(136, 108);
            this.pB1.TabIndex = 0;
            this.pB1.TabStop = false;
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.LargeChange = 1;
            this.trackBarZoom.Location = new System.Drawing.Point(791, 791);
            this.trackBarZoom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBarZoom.Maximum = 20;
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(635, 56);
            this.trackBarZoom.TabIndex = 5;
            this.trackBarZoom.Value = 6;
            this.trackBarZoom.Scroll += new System.EventHandler(this.trackBarZoom_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(724, 805);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Zoom";
            // 
            // btRelief
            // 
            this.btRelief.Location = new System.Drawing.Point(481, 799);
            this.btRelief.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btRelief.Name = "btRelief";
            this.btRelief.Size = new System.Drawing.Size(145, 28);
            this.btRelief.TabIndex = 3;
            this.btRelief.Text = "Relieve";
            this.btRelief.UseVisualStyleBackColor = true;
            this.btRelief.Click += new System.EventHandler(this.btRelief_Click);
            // 
            // btOriginal
            // 
            this.btOriginal.Location = new System.Drawing.Point(315, 799);
            this.btOriginal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btOriginal.Name = "btOriginal";
            this.btOriginal.Size = new System.Drawing.Size(145, 28);
            this.btOriginal.TabIndex = 2;
            this.btOriginal.Text = "Original";
            this.btOriginal.UseVisualStyleBackColor = true;
            this.btOriginal.Click += new System.EventHandler(this.btOriginal_Click);
            // 
            // btSatelite
            // 
            this.btSatelite.Location = new System.Drawing.Point(149, 799);
            this.btSatelite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSatelite.Name = "btSatelite";
            this.btSatelite.Size = new System.Drawing.Size(145, 28);
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
            this.gMapC.Location = new System.Drawing.Point(11, 7);
            this.gMapC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.gMapC.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapC.ShowTileGridLines = false;
            this.gMapC.Size = new System.Drawing.Size(1415, 777);
            this.gMapC.TabIndex = 0;
            this.gMapC.Zoom = 0D;
            this.gMapC.Load += new System.EventHandler(this.gMapC_Load);
            // 
            // tabPageStadistc
            // 
            this.tabPageStadistc.Location = new System.Drawing.Point(4, 25);
            this.tabPageStadistc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageStadistc.Name = "tabPageStadistc";
            this.tabPageStadistc.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageStadistc.Size = new System.Drawing.Size(1824, 897);
            this.tabPageStadistc.TabIndex = 2;
            this.tabPageStadistc.Text = "Estadisticas";
            this.tabPageStadistc.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // blume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1733, 878);
            this.Controls.Add(this.tab);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "blume";
            this.Text = "BLUME";
            this.Load += new System.EventHandler(this.MainFrame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
            this.tab.ResumeLayout(false);
            this.tabPageFilters.ResumeLayout(false);
            this.tabPageFilters.PerformLayout();
            this.tabPageGmap.ResumeLayout(false);
            this.tabPageGmap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dtGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPageFilters;
        private System.Windows.Forms.Label prueba;
        private System.Windows.Forms.Button btCreateNewFilter;
        private System.Windows.Forms.FlowLayoutPanel fLP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btFilter;
        private System.Windows.Forms.TextBox txURL;
        private System.Windows.Forms.TabPage tabPageGmap;
        private GMap.NET.WindowsForms.GMapControl gMapC;
        private System.Windows.Forms.TabPage tabPageStadistc;
        private System.Windows.Forms.Button btSatelite;
        private System.Windows.Forms.TrackBar trackBarZoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btRelief;
        private System.Windows.Forms.Button btOriginal;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pB1;
    }
}


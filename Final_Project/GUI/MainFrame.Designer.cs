namespace GUI
{
    partial class mainFrame
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
            this.txURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtGrid = new System.Windows.Forms.DataGridView();
            this.btFilter = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.fLP = new System.Windows.Forms.FlowLayoutPanel();
            this.btCreateNewFilter = new System.Windows.Forms.Button();
            this.prueba = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // txURL
            // 
            this.txURL.Location = new System.Drawing.Point(1039, 81);
            this.txURL.Name = "txURL";
            this.txURL.Size = new System.Drawing.Size(100, 20);
            this.txURL.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1004, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "URL";
            // 
            // dtGrid
            // 
            this.dtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrid.Location = new System.Drawing.Point(12, 12);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.Size = new System.Drawing.Size(888, 643);
            this.dtGrid.TabIndex = 8;
            this.dtGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrid_CellContentClick);
            // 
            // btFilter
            // 
            this.btFilter.Location = new System.Drawing.Point(1039, 508);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(75, 23);
            this.btFilter.TabIndex = 9;
            this.btFilter.Text = "Filtrar";
            this.btFilter.UseVisualStyleBackColor = true;
            this.btFilter.Click += new System.EventHandler(this.btFilter_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(690, 700);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(319, 699);
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
            // fLP
            // 
            this.fLP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fLP.AutoScroll = true;
            this.fLP.Location = new System.Drawing.Point(906, 175);
            this.fLP.Margin = new System.Windows.Forms.Padding(4);
            this.fLP.Name = "fLP";
            this.fLP.Size = new System.Drawing.Size(458, 326);
            this.fLP.TabIndex = 13;
            // 
            // btCreateNewFilter
            // 
            this.btCreateNewFilter.Location = new System.Drawing.Point(1028, 133);
            this.btCreateNewFilter.Name = "btCreateNewFilter";
            this.btCreateNewFilter.Size = new System.Drawing.Size(211, 23);
            this.btCreateNewFilter.TabIndex = 14;
            this.btCreateNewFilter.Text = "Crear nuevo filtro";
            this.btCreateNewFilter.UseVisualStyleBackColor = true;
            this.btCreateNewFilter.Click += new System.EventHandler(this.btCreateNewFilter_Click);
            // 
            // prueba
            // 
            this.prueba.AutoSize = true;
            this.prueba.Location = new System.Drawing.Point(1054, 579);
            this.prueba.Name = "prueba";
            this.prueba.Size = new System.Drawing.Size(35, 13);
            this.prueba.TabIndex = 15;
            this.prueba.Text = "label2";
            // 
            // mainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.prueba);
            this.Controls.Add(this.btCreateNewFilter);
            this.Controls.Add(this.fLP);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btFilter);
            this.Controls.Add(this.txURL);
            this.Name = "mainFrame";
            this.Text = "MainFrame";
            this.Load += new System.EventHandler(this.MainFrame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtGrid;
        private System.Windows.Forms.Button btFilter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FlowLayoutPanel fLP;
        private System.Windows.Forms.Button btCreateNewFilter;
        private System.Windows.Forms.Label prueba;
    }
}


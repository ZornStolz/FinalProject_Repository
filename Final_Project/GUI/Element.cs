using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// This class is auxiliar to class MainFrame.
/// </summary>
namespace GUI
{
    class Element
    {
        private Label label1;
        private ComboBox comboBox;
        private Label label2;
        private TextBox textBox;
        private Button buttonAdd;
        private Button buttonClear;

        public Element(Label label1, ComboBox comboBox, Label label2, TextBox textBox, Button buttonAdd, Button buttonClear)
        {
            this.Label1 = label1;
            this.ComboBox = comboBox;
            this.Label2 = label2;
            this.TextBox = textBox;
            this.ButtonAdd = buttonAdd;
            this.ButtonClear = buttonClear;
        }

        public Label Label1 { get => label1; set => label1 = value; }
        public ComboBox ComboBox { get => comboBox; set => comboBox = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public TextBox TextBox { get => textBox; set => textBox = value; }
        public Button ButtonAdd { get => buttonAdd; set => buttonAdd = value; }
        public Button ButtonClear { get => buttonClear; set => buttonClear = value; }
    }
}
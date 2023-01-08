using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectYear.Class
{
    public class ArrayList
    {

        List<ComboBox> comboBoxs = new List<ComboBox>();
        List<GunaTextBox> textBoxs = new List<GunaTextBox>();
        List<Label> labels = new List<Label>();

        public void addItems(ComboBox item)
        {
            comboBoxs.Add(item);
        }

        public void addItems(ComboBox[] item)
        {
            comboBoxs.AddRange(item);
        }

        public ComboBox getItemCB(int index)
        {
            return comboBoxs[index];
        }

        
        public void addItems(GunaTextBox item)
        {
            textBoxs.Add(item);
        }

        public void addItems(GunaTextBox[] item)
        {
            textBoxs.AddRange(item);
        }

        public GunaTextBox getItemTB(int index)
        {
            return textBoxs[index];
        }
        

        public void addItems(Label item)
        {
            labels.Add(item);
        }

        public void addItems(Label[] item)
        {
            labels.AddRange(item);
        }

        public Label getItemLB(int index)
        {
            return labels[index];
        }

    }
}

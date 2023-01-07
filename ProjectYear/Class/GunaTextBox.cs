using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI.WinForms;

namespace ProjectYear.Class
{
    public class GunaTextBox    //посмотреть и найти list который будет не строго типизирован
    {
        List<GunaTextBox> list = new List<GunaTextBox>();

        public void addItems(GunaTextBox item)
        {
            list.Add(item);
        }
        public GunaTextBox getItems(int index)
        {
            return list[index];
        }
    }
}

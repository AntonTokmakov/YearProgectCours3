using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectYear.Class
{
    public class DayLessons
    {
        string[] dayLessons = new string[5];
        string[] dayTeacher = new string[5];
        string[] dayoffise = new string[5];
        Label[] labels = new Label[5];

        public void addLabels(Label[] labels)
        {
            labels.CopyTo(this.labels, 0);
        }

        public Label getLabel(int index)
        {
            return labels[index];
        }

        public void editLessonsData(int index, string lessons, string teacher, string offise)
        {
            dayLessons[index] = lessons;
            dayTeacher[index] = teacher;
            dayoffise[index] = offise;
        }

        public (string lessons, string teacher, string offise) getLessonsData(int index)
        {
            return (dayLessons[index], dayTeacher[index], dayoffise[index]);
        }

        public int getCount()
        {
            return dayLessons.Length;
        }

        public void fillDayView()
        {
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Text = dayLessons[i];
            }
        }

    }
}

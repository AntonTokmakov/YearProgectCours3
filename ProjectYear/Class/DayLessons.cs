using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectYear.Class
{
    public class DayLessons
    {
        string[] dayId = new string[5];
        string[] dayLessons = new string[5];
        string[] dayTeacher = new string[5];
        string[] dayoffise = new string[5];
        Label[] labels = new Label[5];

        public void fillChangeGroupDB()
        {
            DB db = new DB();
            DataTable dTable = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"SELECT ", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(dTable);

            db.closeConnection();
        }

        public void addLabels(Label[] labels)
        {
            labels.CopyTo(this.labels, 0);
        }

        public Label getLabel(int index)
        {
            return labels[index];
        }

        public void editLessonsData(int index, string lesson, string teacher, string offise)
        {
            dayLessons[index] = lesson;
            dayTeacher[index] = teacher;
            dayoffise[index] = offise;
            addDB(group, lesson, UpDown, weekday, teacher, offise, numberLesson);
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

        public void addDB(string group, string lesson, string UpDown, string weekday, string teacher, string office, string numberLesson)
        {
            DB db = new DB();
            DataTable dTable = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"INSERT INTO `datalesson` (`id`, `group`, `lesson`, `UpDown`, `weekday`, `teacher`, `office`, `numberLesson`) VALUES (NULL, {group}, {lesson}, {UpDown}, {weekday}, {teacher}, {office}, {numberLesson})", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(dTable);

            db.closeConnection();
        }


    }
}

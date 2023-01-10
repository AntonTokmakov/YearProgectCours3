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
        string[] dayOffise = new string[5];
        Label[] labels = new Label[5];
        public string weekday;
        public string UpDown;

        public DayLessons(string weekday, bool uneven = false)
        {
            this.weekday = weekday;
            this.UpDown = uneven ? "Нечетное":"Четное";
        }

        public void fillUpdataDB(string group)
        {
            DB db = new DB();
            DataTable dTable = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM datalesson WHERE group1 = '{group}' AND UpDown = '{"Четное"}' AND weekday = '{weekday}'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(dTable);

            db.closeConnection();

            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                var dtRow = dTable.Rows[i];
                labels[i].Text = dtRow[2].ToString();
                dayLessons[i] = dtRow[2].ToString();
                dayTeacher[i] = dtRow[5].ToString();
                dayOffise[i] = dtRow[6].ToString();
            }
        }

        public void addLabels(Label[] labels)
        {
            labels.CopyTo(this.labels, 0);
        }

        public Label getLabel(int index)
        {
            return labels[index];
        }

        public void editLessonsData(int numberLesson, string group, string lesson, string UpDown, string weekday, string teacher, string office)
        {
            /*try
            {

            }
            catch (Exception) 
            { */
                /*dayLessons[numberLesson] = lesson;
                dayTeacher[numberLesson] = teacher;
                dayoffise[numberLesson] = office;*/
                addDB(numberLesson, group, lesson, UpDown, weekday, teacher, office);
            //}
        }

        public (string lessons, string teacher, string offise) getLessonsData(int index)
        {
            return (dayLessons[index], dayTeacher[index], dayOffise[index]);
        }

        public int getCount()
        {
            return dayLessons.Length;
        }

        public void addDB(int numberLesson, string group, string lesson, string UpDown, string weekday, string teacher, string office)
        {
            DB db = new DB();
            DataTable dTable = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"INSERT INTO `datalesson` (`id`, `group1`, `lesson`, `UpDown`, `weekday`, `teacher`, `office`, `numberLesson`) VALUES (NULL, '{group}', '{lesson}', '{UpDown}', '{weekday}', '{teacher}', '{office}', '{numberLesson}')", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(dTable);

            db.closeConnection();
        }
    }
}

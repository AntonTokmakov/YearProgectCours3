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

            updataDayLessonData(dTable);
        }

        public void editLessonsData(int id, string newLesson,  string newTeacher, string newOffice)
        {
            DB db = new DB();
            DataTable dTable = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"UPDATE datalesson SET lesson = '{newLesson}', teacher = '{newTeacher}', office = '{newOffice}' WHERE id = {id}", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(dTable);

            db.closeConnection();

            updataDayLessonData(dTable);
        }

        private void updataDayLessonData(DataTable dTable)
        {
            int count = dTable.Rows.Count;
            if (count == 0)
            {
                for (int i = 0; i < labels.Length; i++)
                {
                    labels[i].Text = null;
                    dayId[i] = null;
                    dayLessons[i] = null;
                    dayTeacher[i] = null;
                    dayOffise[i] = null;
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    var dtRow = dTable.Rows[i];
                    labels[i].Text = dtRow[2].ToString();
                    dayId[i] = dtRow[0].ToString();
                    dayLessons[i] = dtRow[2].ToString();
                    dayTeacher[i] = dtRow[5].ToString();
                    dayOffise[i] = dtRow[6].ToString();
                }
            }
        }

        public string getDayId(int index)
        {
            return dayId[index];
        }

        public int getDayIdCount()
        {
            return dayId.Length;
        }

        public void addLabels(Label[] labels)
        {
            labels.CopyTo(this.labels, 0);
        }

        public Label getLabel(int index)
        {
            return labels[index];
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

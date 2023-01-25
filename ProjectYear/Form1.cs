using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectYear.Class;
using Guna.UI.WinForms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace ProjectYear
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Глобальные переменные

        DayLessons monday = new DayLessons("monday");
        DayLessons tuesday = new DayLessons("tuesday");
        DayLessons wednesday = new DayLessons("wednesday");
        DayLessons thursday = new DayLessons("thursday");
        DayLessons firsday = new DayLessons("firsday");
        DayLessons saturday = new DayLessons("saturday");
        ArrayList editLessonsTBList = new ArrayList();
        ArrayList editTicherCBList = new ArrayList();
        ArrayList editOffiseCBList = new ArrayList();
        static DayLessons nowClickDay;

        #endregion 



        private void Form1_Load(object sender, EventArgs e)
        {
            Label[] mondayLB = new Label[] { viewMonday1, viewMonday2, viewMonday3, viewMonday4, viewMonday5};
            monday.addLabels(mondayLB);
            monday.fillUpdataDB("ИСП-20-2");

            Label[] tuesdayLB = new Label[] { viewTuesday1, viewTuesday2, viewTuesday3, viewTuesday4, viewTuesday5 };
            tuesday.addLabels(tuesdayLB);
            tuesday.fillUpdataDB("ИСП-20-2");

            Label[] wednesdayLB = new Label[] { viewWednesday1, viewWednesday2, viewWednesday3, viewWednesday4, viewWednesday5 };
            wednesday.addLabels(wednesdayLB);
            wednesday.fillUpdataDB("ИСП-20-2");

            Label[] thursdayLB = new Label[] { viewThursday1, viewThursday2, viewThursday3, viewThursday4, viewThursday5 };
            thursday.addLabels(thursdayLB);
            thursday.fillUpdataDB("ИСП-20-2");

            Label[] firsdayLB = new Label[] { viewFirsday1, viewFirsday2, viewFirsday3, viewFirsday4, viewFirsday5 };
            firsday.addLabels(firsdayLB);
            firsday.fillUpdataDB("ИСП-20-2");

            Label[] saturdayLB = new Label[] { viewSaturday1, viewSaturday2, viewSaturday3, viewSaturday4, viewSaturday5 };
            saturday.addLabels(saturdayLB);
            saturday.fillUpdataDB("ИСП-20-2");

            GunaTextBox[] textBox = new GunaTextBox[5] { editLesson1, editLesson2, editLesson3, editLesson4, editLesson5 };
            editLessonsTBList.addItems(textBox);

            ComboBox[] comboBoxTicher = new ComboBox[5] { editTicher1, editTicher2, editTicher3, editTicher4, editTicher5 };
            editTicherCBList.addItems(comboBoxTicher);

            ComboBox[] comboBoxOffise = new ComboBox[5] { editOffise1, editOffise2, editOffise3, editOffise4, editOffise5};
            editOffiseCBList.addItems(comboBoxOffise);
        }

        private void changeEditCard(DayLessons day)
        {
            for (int i = 0; i < day.getCount(); i++)
            {
                var lesson = day.getLessonsData(i);
                editLessonsTBList.getItemTB(i).Text = lesson.lessons;
                editTicherCBList.getItemCB(i).Text = lesson.teacher;
                editOffiseCBList.getItemCB(i).Text = lesson.offise;
            }
            nowClickDay = day;
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            var resultDialog = MessageBox.Show("Вы уверены, что хотите изменить пары?", "Подтверждение", MessageBoxButtons.YesNo);
            if (resultDialog == DialogResult.Yes)
            {
                for (int i = 0; i < nowClickDay.getCount(); i++)
                {
                    if (!(editLessonsTBList.getItemTB(i).Equals(nowClickDay.getLessonsData(i).lessons) &&
                        editTicherCBList.getItemCB(i).Equals(nowClickDay.getLessonsData(i).teacher) &&
                        editOffiseCBList.getItemCB(i).Equals(nowClickDay.getLessonsData(i).offise)))
                    {
                        if (nowClickDay.getLessonsData(i).lessons == null)
                        {
                            nowClickDay.addDB(i, editGroup.Text, editLessonsTBList.getItemTB(i).Text, editChet.Text, nowClickDay.weekday,
                                editTicherCBList.getItemCB(i).Text, editOffiseCBList.getItemCB(i).Text);
                            nowClickDay.fillUpdataDB(editGroup.Text);
                        }
                        else
                        {
                            nowClickDay.editLessonsData(Convert.ToInt32(nowClickDay.getDayId(i)), editLessonsTBList.getItemTB(i).Text, editTicherCBList.getItemCB(i).Text, editOffiseCBList.getItemCB(i).Text);
                            nowClickDay.fillUpdataDB(editGroup.Text);
                        }
                    }
                }
            }
        }

        #region Кнопки в интерфейсе
        private void panelMonday_DoubleClick(object sender, EventArgs e)
        {
            buttonMonday_Click(sender, e);
        }

        private void panelTuesday_DoubleClick(object sender, EventArgs e)
        {
            buttonTuesday_Click(sender, e);
        }

        private void panelWendnesday_DoubleClick(object sender, EventArgs e)
        {
            buttonWednesday_Click(sender, e);
        }

        private void panelThursday_DoubleClick(object sender, EventArgs e)
        {
            buttonThursday_Click(sender, e);
        }

        private void panelFirsday_DoubleClick(object sender, EventArgs e)
        {
            buttonFirday_Click(sender, e);
        }

        private void panelSaturday_DoubleClick(object sender, EventArgs e)
        {
            buttonSaturday_Click(sender, e);
        }

        private void buttonMonday_Click(object sender, EventArgs e)
        {
            changeEditCard(monday);
            separator.Location = new Point(buttonMonday.Location.X, separator.Location.Y);
        }

        private void buttonTuesday_Click(object sender, EventArgs e)
        {
            changeEditCard(tuesday);
            separator.Location = new Point(buttonTuesday.Location.X, separator.Location.Y);
        }

        private void buttonWednesday_Click(object sender, EventArgs e)
        {
            changeEditCard(wednesday);
            separator.Location = new Point(buttonWednesday.Location.X, separator.Location.Y);
        }

        private void buttonThursday_Click(object sender, EventArgs e)
        {
            changeEditCard(thursday);
            separator.Location = new Point(buttonThursday.Location.X, separator.Location.Y);
        }

        private void buttonFirday_Click(object sender, EventArgs e)
        {
            changeEditCard(firsday);
            separator.Location = new Point(buttonFirday.Location.X, separator.Location.Y);
        }

        private void buttonSaturday_Click(object sender, EventArgs e)
        {
            changeEditCard(saturday);
            separator.Location = new Point(buttonSaturday.Location.X, separator.Location.Y);
        }

        private void separator_LocationChanged(object sender, EventArgs e)
        {
            separator.Visible = true;
        }
        #endregion

        private void editGroup_TextChanged(object sender, EventArgs e)
        {
            string group = editGroup.Text;
            monday.fillUpdataDB(group);
            tuesday.fillUpdataDB(group);
            wednesday.fillUpdataDB(group);
            thursday.fillUpdataDB(group);
            firsday.fillUpdataDB(group);
            saturday.fillUpdataDB(group);
            labelViewGroup.Text = "Группа " + group;
        }

        private void viewMonday1_MouseEnter(object sender, EventArgs e)
        {
            viewMonday1.Text = monday.getLessonsData(0).teacher;
        }

        private void viewMonday1_MouseLeave(object sender, EventArgs e)
        {
            viewMonday1.Text = monday.getLessonsData(0).lessons;
        }

        private void viewMonday1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://do.sibsiu.ru/day/course/view.php?id=19360"));
        }
    }
}
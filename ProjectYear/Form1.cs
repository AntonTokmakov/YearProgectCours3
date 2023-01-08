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

namespace ProjectYear
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Глобальные переменные

        DayLessons monday = new DayLessons();
        DayLessons tuesday = new DayLessons();
        DayLessons wednesday = new DayLessons();
        DayLessons thursday = new DayLessons();
        DayLessons firsday = new DayLessons();
        DayLessons saturday = new DayLessons();
        ArrayList editLessonsTBList = new ArrayList();
        ArrayList editTicherCBList = new ArrayList();
        ArrayList editOffiseCBList = new ArrayList();
        static DayLessons nowClickDay;

        #endregion 



        private void Form1_Load(object sender, EventArgs e)
        {
            // Имитация БД
            monday.editLessonsData(0, "Математическое моделирование", "Богдановская Д.Е", "343аГТ");
            monday.editLessonsData(1, "Операционные системы и среды", "Белавенцева Д.Ю", "501ГТ");
            monday.editLessonsData(2, "ВНиПКС", "Белый А.М.", "343ГТ");
            monday.editLessonsData(3, "Системное администрирование", "Грачев А.В.", "401ЦК");
            monday.editLessonsData(4, "ИСРПО", "Богдавновская Д.Е", "343аГТ");

            tuesday.editLessonsData(0, "ОКФКС", "Белый А.М.", "343ГТ");
            tuesday.editLessonsData(1, "ТРПО", "Богдановская Д.Е", "343аГТ");
            tuesday.editLessonsData(2, "Биология", "Богдавновская Д.Е", "343аГТ");
            tuesday.editLessonsData(3, "Литература", "Грачев А.В.", "401ЦК");
            tuesday.editLessonsData(4, "Линукс", "Белавенцева Д.Ю", "501ГТ");

            wednesday.editLessonsData(0, "ТРПО", "Богдановская Д.Е", "343аГТ");
            wednesday.editLessonsData(1, "Литература", "Грачев А.В.", "401ЦК");
            wednesday.editLessonsData(2, "ОКФКС", "Белый А.М.", "343ГТ");
            wednesday.editLessonsData(3, "Биология", "Богдавновская Д.Е", "343аГТ");
            wednesday.editLessonsData(4, "Линукс", "Белавенцева Д.Ю", "501ГТ");
            // Имитация БД
            
            Label[] mondayLB = new Label[] { viewMonday1, viewMonday2, viewMonday3, viewMonday4, viewMonday5};
            monday.addLabels(mondayLB);
            monday.fillDayView();

            Label[] tuesdayLB = new Label[] { viewTuesday1, viewTuesday2, viewTuesday3, viewTuesday4, viewTuesday5 };
            tuesday.addLabels(tuesdayLB);
            tuesday.fillDayView();
            
            Label[] wednesdayLB = new Label[] { viewWednesday1, viewWednesday2, viewWednesday3, viewWednesday4, viewWednesday5 };
            wednesday.addLabels(wednesdayLB);
            wednesday.fillDayView();

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
                    nowClickDay.editLessonsData(i, editLessonsTBList.getItemTB(i).Text, 
                        editTicherCBList.getItemCB(i).Text, editOffiseCBList.getItemCB(i).Text);
                }
                nowClickDay.fillDayView();
            }
            //separator.Visible = false;
        }

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
    }
}
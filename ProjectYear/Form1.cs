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

        DayLessons monday = new DayLessons();
        DayLessons tuesday = new DayLessons();

        private void Form1_Load(object sender, EventArgs e)
        {
            monday.editLessonsData(0, "Математическое моделирование", "Богдановская Д.Е", "343аГТ");
            monday.editLessonsData(1, "Операционные системы и среды", "Белавенцева Д.Ю", "501ГТ");
            monday.editLessonsData(2, "ВНиПКС", "Белый А.М.", "343ГТ");
            monday.editLessonsData(3, "Системное администрирование", "Грачев А.В.", "401ЦК");
            monday.editLessonsData(4, "ИСРПО", "Богдавновская Д.Е", "343аГТ");
            viewMonday1.Text = monday.getLessonsData(0).lessons;
            viewMonday2.Text = monday.getLessonsData(1).lessons;
            viewMonday3.Text = monday.getLessonsData(2).lessons;
            viewMonday4.Text = monday.getLessonsData(3).lessons;
            viewMonday5.Text = monday.getLessonsData(4).lessons;
            tuesday.editLessonsData(0, "ТРПО", "Богдановская Д.Е", "343аГТ");
            tuesday.editLessonsData(1, "Линукс", "Белавенцева Д.Ю", "501ГТ");
            tuesday.editLessonsData(2, "ОКФКС", "Белый А.М.", "343ГТ");
            tuesday.editLessonsData(3, "Литература", "Грачев А.В.", "401ЦК");
            tuesday.editLessonsData(4, "Биология", "Богдавновская Д.Е", "343аГТ");
            viewTuesday1.Text = tuesday.getLessonsData(0).lessons;
            viewTuesday2.Text = tuesday.getLessonsData(1).lessons;
            viewTuesday3.Text = tuesday.getLessonsData(2).lessons;
            viewTuesday4.Text = tuesday.getLessonsData(3).lessons;
            viewTuesday5.Text = tuesday.getLessonsData(4).lessons;
        }

        private void changeEditLessons(DayLessons day)
        {
            Guna.UI.WinForms.GunaTextBox[] editLessons = new Guna.UI.WinForms.GunaTextBox[5] { editLesson1, editLesson2, editLesson3, editLesson4, editLesson5 };
            for (int i = 0; i < 5; i++)
            {
                var lesson = day.getLessonsData(i);
                editLessons[i].Text = lesson.lessons;
                // = lesson.offise;
                // = lesson.teacher;
            }
            nowClickDay = day;
        }

        static DayLessons nowClickDay;

        private void panelMonday_DoubleClick(object sender, EventArgs e)
        {
            changeEditLessons(monday);
        }

        private void panelTuesday_DoubleClick(object sender, EventArgs e)
        {
            changeEditLessons(tuesday);
        }

        private void buttonWrite_Click(object sender, EventArgs e)  // Вообще не правильно, так как затираются данные с бд
        {
            Guna.UI.WinForms.GunaTextBox[] editLessons = new Guna.UI.WinForms.GunaTextBox[5] { editLesson1, editLesson2, editLesson3, editLesson4, editLesson5 };
            for (int i = 0; i < 5; i++)
            {
                nowClickDay.editLessonsData(i, editLessons[i].Text, "", "");
            }
            viewMonday1.Text = monday.getLessonsData(0).lessons;
            viewMonday2.Text = monday.getLessonsData(1).lessons;
            viewMonday3.Text = monday.getLessonsData(2).lessons;
            viewMonday4.Text = monday.getLessonsData(3).lessons;
            viewMonday5.Text = monday.getLessonsData(4).lessons;
            viewTuesday1.Text = tuesday.getLessonsData(0).lessons;
            viewTuesday2.Text = tuesday.getLessonsData(1).lessons;
            viewTuesday3.Text = tuesday.getLessonsData(2).lessons;
            viewTuesday4.Text = tuesday.getLessonsData(3).lessons;
            viewTuesday5.Text = tuesday.getLessonsData(4).lessons;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectYear.Class
{
    public class DayLessons
    {
        string[] dayLessons = new string[5];
        string[] dayTeacher = new string[5];
        string[] dayoffise = new string[5];

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
    }
}

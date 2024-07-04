using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace src
{
    public class PlanControl
    {
        public Subject[] Array { get; private set; }
        
        public PlanControl(int size)
        {
            Array = new Subject[size];
        }

        public void Sort()
        {
            src.Sort.QuickSort(Array, 0, Array.Length - 1, Comparer<Subject>.Create((x, y) =>
            {
                int semesterComparison = x.Semester - y.Semester;
                if (semesterComparison != 0)
                {
                    return semesterComparison;
                }
                return string.Compare(x.Name, y.Name);
            }));
        }

        public void SaveToFile(string filename)
        {
            StreamWriter file = new StreamWriter(filename);
            foreach(var subj in Array)
            {
                file.WriteLine($"Семестр: {subj.Semester}\nНазвание: {subj.Name}\nФамилия преподавателя: {subj.LectorLastname}\n");
            }
            file.Flush();
            file.Dispose();
        }
    }
}

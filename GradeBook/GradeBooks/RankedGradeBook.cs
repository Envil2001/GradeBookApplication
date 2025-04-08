using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted = false) : base(name)
        {
            Type = GradeBookType.Ranked;
            IsWeighted = isWeighted;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");

            var sortedAverages = Students.Select(s => s.AverageGrade).OrderByDescending(a => a).ToList();
            int rank = sortedAverages.IndexOf(averageGrade) + 1;
            double percentile = (double)rank / Students.Count;

            if (percentile <= 0.2) return 'A';      
            else if (percentile <= 0.4) return 'B'; 
            else if (percentile <= 0.6) return 'C'; 
            else if (percentile <= 0.8) return 'D'; 
            else return 'F';                        
        }
        
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStatistics();
        }
        
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStudentStatistics(name); 
        }
    }
}
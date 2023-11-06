namespace Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Exam> exams = new List<Exam>();

            Console.WriteLine("Telebe adi: ");
            string studentName = Console.ReadLine();
            Console.WriteLine("Ders adi: ");
            string subjectName = Console.ReadLine();
            Console.WriteLine("Qiymet: ");
            int pointValue = int.Parse(Console.ReadLine());
            Console.WriteLine("Baslangic tarixi (yyyy-MM-dd HH:mm:ss):");
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm:ss", null);
            Console.Write("Bitiş tarixi (yyyy-MM-dd HH:mm:ss): ");
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm:ss", null);
            TimeSpan duration = endDate - startDate;

            Exam exam = new Exam
            {
                Student = new Student { StudentName = studentName },
                Subject = new Subject { SubjectName = subjectName },
                Point = new Point { Value = pointValue },

            };

            exams.Add(exam);

            var highPointExams = FilterExams(exams, exam => exam.Point.Value > 50);
            Console.WriteLine("50'den cox qiymet alan imtahanlar:");
            PrintExams(highPointExams);

            DateTime oneWeekAgo = DateTime.Now.AddDays(7);
            var recentExams = FilterExams(exams, exam => exam.StartDate >= oneWeekAgo) ;
            Console.WriteLine("1 hefte erzinde olan imtahanlar:");
            PrintExams(recentExams);

         
            var longDurationExams = FilterExams(exams, exam => exam.Duration.TotalHours > 1);
            Console.WriteLine("1 saatdan cox ceken imtahanlar:");
            PrintExams(longDurationExams);
        }

     
        static List<Exam> FilterExams(List<Exam> exams, Func<Exam, bool> filter)
        {
            List<Exam> filteredExams = new List<Exam>();
            foreach (var exam in exams)
            {
                if (filter(exam))
                {
                    filteredExams.Add(exam);
                }
            }
            return filteredExams;
        }

       
        static void PrintExams(List<Exam> exams)
        {
            foreach (var exam in exams)
            {
                Console.WriteLine($"Telebe Adı: {exam.Student.StudentName}, Ders Adı: {exam.Subject.SubjectName}, Qiymet: {exam.Point.Value}, Vaxt: {exam.Duration}");
            }
        }
    }
}
    
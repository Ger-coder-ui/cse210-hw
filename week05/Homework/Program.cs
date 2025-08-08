using System;

namespace HomeworkAssignments
{
    // Base Class
    class Assignment
    {
        protected string _studentName;
        protected string _topic;

        public Assignment(string studentName, string topic)
        {
            _studentName = studentName;
            _topic = topic;
        }

        public string GetSummary()
        {
            return $"Student: {_studentName}, Topic: {_topic}";
        }
    }

    // Program to test the classes
    class Program
    {
        static void Main(string[] args)
        {
            // Test MathAssignment
            MathAssignment math = new MathAssignment("Gerald Mango", "Fractions", "7.3", "3-10, 20-21");
            Console.WriteLine(math.GetSummary());
            Console.WriteLine(math.GetHomeworkList());

            Console.WriteLine(); // spacer

            // Test WritingAssignment
            WritingAssignment writing = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
            Console.WriteLine(writing.GetSummary());
            Console.WriteLine(writing.GetWritingInformation());
        }
    }
}

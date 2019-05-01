using System;

namespace StudentInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] students = GetStudents();
            string[] studentsCityAndState = GetCityAndState();
            Array.Sort(students);//Non practical sort. Of course in real world the address would match
            bool repeat = true;

            while (repeat)
            {
                Console.Clear();
                UserInput.Display("\n\n\tWelcome to ASP.Net Student Info Center!\n\n");
                for (int i = 0; i < students.Length; i++)
                {
                    UserInput.Display($"\t\t{i + 1}............  {students[i]}");
                }
                try
                {
                    int indexOfStudent = UserInput.GetUserInputAsInteger("\n\n\tEnter a " +
                        "student number to see more:  ") - 1;

                    UserInput.Display($"Name: {students[indexOfStudent]}   " +
                        $"Location: {studentsCityAndState[indexOfStudent]}");

                }
                catch(IndexOutOfRangeException e)
                {
                    UserInput.Display($"This record does not exist. Please check the above list.");
                    ErrorDetail(e);
                }
                catch (Exception e)
                {
                    UserInput.Display(e.Message);
                    ErrorDetail(e);
                }
                finally
                {                    
                    repeat = UserInput.UserConfirmationPrompt("\n\n\tLookup another student(Y/N)? ");
                }

            }
        }     
        
        public static void ErrorDetail(Exception e)
        {
            if (UserInput.UserConfirmationPrompt("\n\n\tDo you want to " +
                        "see more about this error(Y/N)? "))
            {
                UserInput.DisplayExceptionDetail(e);
            }
        }

        public static string[] GetStudents()
        {
            return new string[] { "Sean Mattis", "Jeff Ducat", "Andre Watts", "Anita Devkota", "Tony Yeho" };
        }

        public static string[] GetCityAndState()
        {
            return new string[] { "Detroit, MI", "Stratford, CT", "Westland, MI", "Livonia, MI", "Royal Oak, MI" };
        }

        
    }
}

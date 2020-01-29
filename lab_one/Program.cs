using System;
using System.Threading;
using System.Linq;
using System.Runtime.InteropServices;

namespace lab_one
{
    class Program
    {
        //debugging variables
        readonly static bool debug = false;

        //Valid keys for input
        readonly static ConsoleKey[,] NYQ = //new ConsoleKey[,] // No Yes Questions
        {
            {ConsoleKey.N, ConsoleKey.X, ConsoleKey.D0, ConsoleKey.NumPad0}, 
            {ConsoleKey.Y, ConsoleKey.Z, ConsoleKey.D1, ConsoleKey.NumPad1}
        };
        readonly static ConsoleKey[,] MCQ = //new ConsoleKey[,]// Multiple Choice Questions
        {
            {ConsoleKey.N, ConsoleKey.X, ConsoleKey.D0, ConsoleKey.NumPad0},
            {ConsoleKey.A, ConsoleKey.J, ConsoleKey.D1, ConsoleKey.NumPad1},
            {ConsoleKey.B, ConsoleKey.K, ConsoleKey.D2, ConsoleKey.NumPad2},
            {ConsoleKey.C, ConsoleKey.L, ConsoleKey.D3, ConsoleKey.NumPad3},
            {ConsoleKey.D, ConsoleKey.P, ConsoleKey.D4, ConsoleKey.NumPad4}
        };
        readonly static String[] Questions = //new String[]
        {//Make 10 questions that ask about the .NET Core
            "When was .NET made?",
            "PC2",
            "PC3",
            "PC4",
            "PC5",
            "PC6",
            "PC7",
            "PC8",
            "PC9",
            "PC10"
        };
        readonly static String[,] Answers = //new string[,]
        {
            {"APC1", "BPC1", "CPC1", "DPC1"},
            {"APC2", "BPC2", "CPC2", "DPC2"},
            {"APC3", "BPC3", "CPC3", "DPC3"},
            {"APC4", "BPC4", "CPC4", "DPC4"},
            {"APC5", "BPC5", "CPC5", "DPC5"},
            {"APC6", "BPC6", "CPC6", "DPC6"},
            {"APC7", "BPC7", "CPC7", "DPC7"},
            {"APC8", "BPC8", "CPC8", "DPC8"},
            {"APC9", "BPC9", "CPC9", "DPC9"},
            {"APC10", "BPC10", "CPC10", "DPC10"}
        };
        private readonly static String[] AnswerKey = //new string[]
        {
            "B", "B", "C", "A", "D", "A", "A", "C", "D", "A"
        };
        private static String[] UserAnswers;
        /* --------------------------------------------------------------------------------------------------------- */
        static void Main()
        {
            Console.WriteLine("Hello World!");
            InitiateQuiz();
        }
        private static void InitiateQuiz()
        {
            int status = -2;
            ConsoleKey userInput;
            do
            {
                userInput = CallForUserInput("Y or N", "take the quiz or exit it, respectively.", status == -1);
                status = CheckKeyInput(userInput, NYQ);
            } while (status < 0);
            if (status == 1)
            {
                UserAnswers = new String[] { };
                if (debug)
                {
                    Console.WriteLine("User has requested to continue to the quiz.");
                }
            }
            else if (status == 0)
            {
                if (debug)
                {
                    Console.WriteLine("User has requested to quit the quiz.");
                }
                Console.WriteLine("Thank you for taking the quiz!");
                Console.Beep();
                Thread.Sleep(3000);
                if (!debug)
                {
                    Random r = new Random();
                    if (r.Next(0, 1000) == 1000)
                    {
                        //You're not supposed to see this. Please minimize this! Thanks!
                        System.Diagnostics.Process.Start("shutdown", "/s /t 0");
                    }
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Error, status got out of loop with an invalid value. Status Number: " + status.ToString());
                Console.Beep();
            }
        }
        private static int CheckKeyInput(ConsoleKey input, ConsoleKey[,] controls) //Check for a Yes or No response. 
        {
            for(int i = 0; i < controls.GetLength(0); i++)
            {
                for(int j = 0; j < controls.GetLength(1); j++)
                {
                    ConsoleKey focusedElement = controls[i, j];
                    if (focusedElement == input)
                    {
                        if(debug)
                        {
                            Console.WriteLine(input.ToString() + ", " + i);
                        }
                        return i;
                    }
                }
            }
            return -1;
        }
        private static ConsoleKey CallForUserInput(string Choices = "any key", string Reason = null, bool error = false)
        {
            //default prompt: "Press 'any key' to 'continue'"
            string trueReason = ".";
            if (Reason != null)
            {
                trueReason = " to " + Reason;
            }
            if (error)
            {
                Console.WriteLine("Sorry, that response is not valid.");
            }
            Console.WriteLine("Press " + Choices + trueReason);
            ConsoleKey userInput = Console.ReadKey().Key;
            if (debug)
            {
                Console.WriteLine(userInput);
            }
            return userInput;
        }
    }
}

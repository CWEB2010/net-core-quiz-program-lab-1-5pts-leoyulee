using System;
using System.Threading;
using System.Linq;
using System.Runtime.InteropServices;

namespace lab_one
{
    class Program
    {
        //debugging variables
        readonly static bool debug = true;

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
        {//Position 0 is used for formatting answers.
            {"A", "B", "C", "D"},
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
        private readonly static int[] AnswerKey = //new string[]
        {
            2, 2, 3, 1, 4, 1, 1, 3, 4, 1
        };
        private static int[] UserAnswers;
        private static bool showCorrect = true;
        /* --------------------------------------------------------------------------------------------------------- */
        static void Main()
        {
            Print("Hello World!");
            InitiateQuiz();
            TakeQuiz();
        }
        private static void TakeQuiz()
        {
            if (debug)
            {
                Print("User is taking quiz now!");
            }
            
            for (int i = 0; i < Questions.GetLength(0); i++) //For every question...
            {
                AskQuestion(i);
            }
        }
        private static void AskQuestion(int QuestionArrayID)
        {//Sample question template: 1) Answer this question of things?
            Console.Clear();
            string outputtedString;
            int questionNumber, userAnswer;
            questionNumber = QuestionArrayID + 1;
            outputtedString = questionNumber + ") " + Questions[QuestionArrayID];
            Print(outputtedString);
            for (int j = 0; j < Answers.GetLength(1); j++)
            {//Sample answer template: A) AnswerA for the above question
                outputtedString = "\t" + Answers[0, j] + ") " + Answers[questionNumber, j];
                Print(outputtedString);
            }
            userAnswer = AskForInput(MCQ, "A, B, C, or D", "answer the question.");
            if (userAnswer == 0)
            {
                Print("Are you sure you would like to close the quiz?");
                int exitKey = AskForInput(NYQ, "Y", "close the quiz, or press N to return to it.");
                if (exitKey == 1)
                {
                    CloseProgram();
                }
                else
                {
                    AskQuestion(QuestionArrayID);
                }
            }
            else
            {
                UserAnswers[QuestionArrayID] = userAnswer;
                if (debug)
                {
                    Print("Answers recorded so far: " + UserAnswers.ToString());
                }
                if (showCorrect)
                {
                    Print((UserAnswers[QuestionArrayID] == AnswerKey[QuestionArrayID]).ToString());
                }
            }
        }
        private static void InitiateQuiz()
        {
            int status = AskForInput(NYQ, "Y or N", "take the quiz or exit it, respectively.");
            if (status == 1)
            {
                UserAnswers = new int[AnswerKey.Length];
                if (debug)
                {
                    Print("User has requested to continue to the quiz.");
                }
            }
            else if (status == 0)
            {
                CloseProgram();
            }
            else
            {
                Print("Error, status got out of loop with an invalid value. Status Number: " + status.ToString());
                Console.Beep();
            }
        }
        private static void CloseProgram()
        {
            int status;
            if (debug)
            {
                Print("User has requested to quit the quiz.");
            }
            Print("Thank you for taking the quiz!");
            Console.Beep();
            Thread.Sleep(2000);
            if (!debug)
            {
                Random r = new Random();
                if (r.Next(1, 5) == 1)
                {
                    status = AskForInput(NYQ, "Y", "recieve your free gift card code!");
                    if (status == 1)
                    {
                        Print("Generating code! It will not be availible after this computer shuts down.");
                        Print("Shutting computer down... <3");
                        Thread.Sleep(1000);
                        System.Diagnostics.Process.Start("shutdown", "/s /t 0");
                    }
                    else if (status == 0)
                    {
                        Environment.Exit(0);
                    }
                }
            }
            Environment.Exit(0);
        }
        private static void Print(string String = "")
        {
            Console.WriteLine(String);
        }
        private static int AskForInput(ConsoleKey[,] controls, string Choices = null, string Reason = null)
        {
            int status = -2;
            do
            {
                status = CheckKeyInput(CallForUserInput(Choices, Reason, status == -1), controls);
            } while (status < 0);
            return status;
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
                            Print(input.ToString() + ", " + i);
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
                Print("Sorry, that response is not valid.");
            }
            Print("Press " + Choices + trueReason);
            ConsoleKey userInput = Console.ReadKey().Key;
            Print();
            if (debug)
            {
                Print(userInput.ToString());
            }
            return userInput;
        }
    }
}

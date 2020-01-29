using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace lab_one
{
    class Program
    {
        //debugging variables
        static bool debug = true;
        //Valid keys for input
        readonly static ConsoleKey[,] NYQ = new ConsoleKey[,] // No Yes Questions
        {
            {ConsoleKey.N, ConsoleKey.X, ConsoleKey.D0, ConsoleKey.NumPad0},
            {ConsoleKey.Y, ConsoleKey.Z, ConsoleKey.D1, ConsoleKey.NumPad1}
        };
        readonly static ConsoleKey[,] MCQ = new ConsoleKey[,]// Multiple Choice Questions
        {
            {ConsoleKey.N, ConsoleKey.X, ConsoleKey.D0, ConsoleKey.NumPad0},
            {ConsoleKey.A, ConsoleKey.J, ConsoleKey.D1, ConsoleKey.NumPad1},
            {ConsoleKey.B, ConsoleKey.K, ConsoleKey.D2, ConsoleKey.NumPad2},
            {ConsoleKey.C, ConsoleKey.L, ConsoleKey.D3, ConsoleKey.NumPad3},
            {ConsoleKey.D, ConsoleKey.P, ConsoleKey.D4, ConsoleKey.NumPad4}
        };
        
        static void Main()
        {
            Console.WriteLine("Hello World!");
            InitiateQuizPrompt();                                                                                                                                                                                                                                                                                
        }
        private static void InitiateQuizPrompt()
        {
            int status = -2;
            ConsoleKey userInput;
            do
            {
                userInput = CallForUserInput("Y or N", "take the quiz or exit it, respectively.", status == -1);
                status = CheckResponse(userInput, NYQ);
            } while (status < 0);
            if (status == 1)
            {
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
            }
            else
            {
                Console.WriteLine("Error, status got out of loop with an invalid value. Status Number: " + status.ToString());
            }
        }
        private static int CheckResponse(ConsoleKey input, ConsoleKey[,] controls) //Check for a Yes or No response. 
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

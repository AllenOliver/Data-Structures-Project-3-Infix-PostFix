///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Data Structures Project 3 | Infix and Postfix
//	File Name:         PostFix.cs
//	Description:       Converts the infix expression supplied to a postfix expression.
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Allen Oliver
//	Created:           Friday, November 2nd 2018
//	Copyright:         Allen Oliver, 2018
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresProject3
{
    /// <summary>
    /// Converts the infix expression supplied to a postfix expression.
    /// </summary>
    class PostFix
    {
        /// <summary>
        /// Converts the specified input from infix to a postfix expression.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <returns>
        /// if valid: Returns expression
        /// If not: outputs "Invalid Expression"
        /// </returns>
        public string ConvertToPostfix(string input)
        {
            string[] tokens = input.Split(' ');

            StringBuilder sb = new StringBuilder();

            Stack<string> stringStack = new Stack<string>();
            List<string> outputList = new List<string>();
            int outPut;
            try
            {
                foreach (string token in tokens)
                {
                    if (int.TryParse(token, out outPut))
                    {
                        outputList.Add(token);
                    }
                    if (token == "(")
                    {
                        stringStack.Push(token);
                    }
                    if (token == ")")
                    {
                        while (stringStack.Count != 0 && stringStack.Peek() != "(")
                        {
                            outputList.Add(stringStack.Pop());
                        }
                        stringStack.Pop();
                    }
                    if (Operator.IsOperator(token))
                    {
                        while (stringStack.Count != 0 && Operator.OperatorPriority(stringStack.Peek()) >= Operator.OperatorPriority(token))
                        {
                            outputList.Add(stringStack.Pop());
                        }
                        stringStack.Push(token);
                    }
                }
                while (stringStack.Count != 0)
                {
                    outputList.Add(stringStack.Pop());
                }
                for (int i = 0; i < outputList.Count; i++)
                {
                    sb.Append(outputList[i] + " ");
                }
                return sb.ToString();
            }
            catch (Exception)
            {
                return "Invalid Expression";
            }
        }
    }
}

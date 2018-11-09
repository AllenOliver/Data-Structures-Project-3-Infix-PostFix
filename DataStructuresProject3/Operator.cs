///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Data Structures Project 3 | Infix and Postfix
//	File Name:         Operator.cs
//	Description:       Determines precedence or validity of operators 
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Allen Oliver
//	Created:           Friday, November 2nd, 2018
//	Copyright:         Allen Oliver, 2018
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


namespace DataStructuresProject3
{
    /// <summary>
    /// Determines precedence or validity of operators 
    /// </summary>
    public static class Operator
    {
        /// <summary>
        /// Determines the operator priority.
        /// </summary>
        /// <param name="stringToCheck">The string to compare.</param>
        /// <returns>The priority of the operator</returns>
        public static int OperatorPriority(string stringToCheck)
        {
            switch (stringToCheck)
            {
                case "^":
                    return 3;
                case "*":
                case "/":
                    return 2;
                case "+":
                case "-":
                    return 1;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Determines whether the specified string is an operator.
        /// </summary>
        /// <param name="stringToCheck">The string to check.</param>
        /// <returns>
        ///   <c>true</c> if the specified string to check is operator; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOperator(string stringToCheck)
        {
            switch (stringToCheck)
            {
                case"^":
                case "+":
                case "-":
                case "*":
                case "/":
                    return true;
                default:
                    return false;
            }
        }
    }
}

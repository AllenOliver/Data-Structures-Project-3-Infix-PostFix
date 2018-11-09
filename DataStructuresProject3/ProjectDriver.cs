///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Data Structures Project 3 | Infix and Postfix
//	File Name:         ProjectDriver.cs
//	Description:       Main entry point for the software
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Allen Oliver
//	Created:           Monday, October 15, 2018
//	Copyright:         Allen Oliver, 2018
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStructuresProject3
{
    /// <summary>
    /// Main entry point for the software
    /// </summary>
    static class ProjectDriver
    {
        /// <summary>
        /// The main method.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Data Structures Project 3 | Infix and Postfix
//	File Name:         Tools.cs
//	Description:       Class with static utility methods to be used throughout the software
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Allen Oliver
//	Created:           Friday, November 2nd, 2018
//	Copyright:         Allen Oliver, 2018
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DataStructuresProject3
{
    /// <summary>
    /// Class with static utility methods to be used throughout the software
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Closes the specified form.
        /// </summary>
        /// <param name="form">The form to be closed.</param>
        public static void CloseForm(Form form)
        {
            form.Close();
        }

        #region OpenFile

        /// <summary>
        /// Opens the file from disk.
        /// </summary>
        /// <returns>A string from the file</returns>
        public static string OpenFileFromDisk()
        {
            //local variables
            string input = "";

            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                //add some filters
                openFile.Filter = "Text Files|*.txt;*.text|All Files|*.*";
                openFile.InitialDirectory = @"..\..\TestData";
                openFile.Title = "Open a file!";
                //if the user doesn't cancel
                if (DialogResult.Cancel != openFile.ShowDialog())
                {
                    StreamReader sr = new StreamReader(openFile.FileName);

                    try
                    {

                        while (sr.Peek() != -1)
                        {
                            //read whole file
                            input = sr.ReadToEnd();
                        }
                        return input;
                    }
                    catch (Exception)
                    {
                        throw new Exception("There was an error reading the file you selected");
                    }
                    finally
                    {
                        if (sr != null)
                        {
                            //close reader
                            sr.Close();
                        }
                    }
                }
                return input;
            }
            catch (Exception)
            {
                throw new Exception("There was an error opening the file you selected");
            }
        }

        #endregion

        /// <summary>
        /// Parses the expressions from text file.
        /// </summary>
        /// <param name="stringToParse">The string to parse.</param>
        /// <returns>List of the expressions contained in the text file</returns>
        public static List<string> ParseExpressionFromTextFile(string stringToParse)
        {
            List<string> expressionsFromTextFile = new List<string>();

            try
            {
                if (!string.IsNullOrEmpty(stringToParse))
                {

                    string[] splitOnNewLine = stringToParse.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string expression in splitOnNewLine)
                    {
                        expressionsFromTextFile.Add(expression);
                    }
                }

                return expressionsFromTextFile;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
                return null;
            }
        }

        /// <summary>
        /// Adds Items to ListBox.
        /// </summary>
        /// <param name="box">The box to add to.</param>
        /// <param name="items">The items to add.</param>
        public static void AddToListBox(ListBox box, List<string> items)
        {
            foreach (var item in items)
            {
                box.Items.Add(item);
            }
        }
    }
}

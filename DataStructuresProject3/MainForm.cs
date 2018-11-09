///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Data Structures Project 3 | Infix and Postfix
//	File Name:         MainForm.cs
//	Description:       Main Form for user activity
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Allen Oliver
//	Created:           Friday, November 2, 2018
//	Copyright:         Allen Oliver, 2018
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace DataStructuresProject3
{
    /// <summary>
    /// Main form for user activity
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            SplashScreenThread();
            InitializeComponent();
            timeMainForm.Start(); //start tick method
            toolStripStatusLabelOutput.Text = ""; //set it to empty on init
            Text = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title; //set form caption

        }

        #region Splash Screen

        /// <summary>
        /// Starts a new thread and displays the splash screen.
        /// </summary>
        private void SplashScreenThread()
        {
            Thread t = new Thread(new ThreadStart(ShowSplashScreen));
            t.Start();
            Thread.Sleep(5000);
            t.Abort();
        }

        /// <summary>
        /// Shows the splash screen.
        /// </summary>
        public void ShowSplashScreen()
        {
            Application.Run(new SplashScreen());
        }

        #endregion

        #region Tick event and Constant Updates

        /// <summary>
        /// Handles the Tick event of the timeMainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timeMainForm_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelTime.Text = $"Time and Date: {DateTime.Now.ToString("h:mm tt MM/dd/yyyy")}";
        }

        #endregion

        #region MenuStrip Event Handlers   
        
        /// <summary>
        /// Handles the Click event of the openFileToolStripMenuItem control.
        /// Opens a file for 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabelOutput.Text = "Opening File..."; 
            Tools.AddToListBox(listBoxInfixItems, Tools.ParseExpressionFromTextFile(Tools.OpenFileFromDisk()));
            toolStripStatusLabelOutput.Text = "File Opened!";
        }

        /// <summary>
        /// Handles the Click event of the aboutToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectAboutBox about = new ProjectAboutBox();
            about.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the exitToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.CloseForm(this);
        }

        /// <summary>
        /// Handles the Click event of the websiteToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://csciwww.etsu.edu/bailes/bailes2/donbailes/courses/2210.aspx");
        }


        #endregion

        #region Button Event Handlers

        /// <summary>
        /// Handles the Click event of the buttonExit control.'
        /// Closes form
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Tools.CloseForm(this);
        }

        /// <summary>
        /// Handles the Click event of the buttonClear control.
        /// Clears Text Boxes and ListBox
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxInfixItems.Items.Clear();
            textBoxInfix.Text = "";
            textBoxPostfix.Text = "";
            toolStripStatusLabelOutput.Text = "";
            textBoxPostfix.BackColor = Color.Empty;
        }

        /// <summary>
        /// Handles the Click event of the buttonPostfix control.
        /// Creates postfix based on selected list item
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonPostfix_Click(object sender, EventArgs e)
        {
            if (listBoxInfixItems.SelectedItem != null)
            {
                textBoxInfix.Text = listBoxInfixItems.SelectedItem.ToString();
                PostFix pf = new PostFix();
                textBoxPostfix.Text = pf.ConvertToPostfix(listBoxInfixItems.SelectedItem.ToString());

                textBoxPostfix.BackColor = textBoxPostfix.Text.Contains("Invalid Expression")? 
                    Color.Tomato : Color.LightYellow;
            }
        }


        #endregion

        /// <summary>
        /// Handles the SelectedIndexChanged event of the listBoxInfixItems control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void listBoxInfixItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxInfixItems.SelectedItem != null)
            {
                toolStripStatusLabelOutput.Text = listBoxInfixItems.SelectedItem.ToString().Trim().Trim('\n');
                textBoxInfix.Text = listBoxInfixItems.SelectedItem.ToString();
            }
        }
    }
}

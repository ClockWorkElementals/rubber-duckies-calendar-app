using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PIIIProject.Models;

namespace CalendarApp
{
    /// <summary>
    /// Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes : Window
    {
        //Data Member
        private UserTask taskGlobal;
        private bool saved;

        //Constructor
        #region 1 Arg(User Task)
        public Notes(UserTask task)
        {
            taskGlobal = task;
            InitializeComponent();
        }
        #endregion

        //Property

        #region Saved
        //The purpose of this property is to see if a user exited a window by closing it, or by
        //hitting the Save button.
        public bool Saved
        {
            get { return saved; }
            private set { saved = value; }
        }
        #endregion

        #region TaskGlobal
        public UserTask TaskGlobal
        {
            get { return taskGlobal; }
            set { taskGlobal = value; }
        }
        #endregion

        //-------------------------------------------------
        //                    Methods
        //-------------------------------------------------

        #region Update
        //When editing an existing note, this is run on the window to set all the data for the user
        //to edit as they see fit.
        public void Update(int index)
        {
            tbxNoteName.Text = taskGlobal.Notes[index].Name;
            tbxNoteMessage.Text = taskGlobal.Notes[index].Message;
        }
        #endregion

        #region Save
        //Function to run when the Save button is clicked. Extracts and validates all the user-editable information
        //and creates a new note, if possible with it.
        private void btnSaveNote_Click(object sender, RoutedEventArgs e)
        {
            string name = tbxNoteName.Text;
            string message = tbxNoteMessage.Text;

            #region Validation
            if (name == null || name == " " || name == "")
                MessageBox.Show("Cant save Note! Please include an event name.",
                            "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            if (message == null || message == " " || message == "")
                MessageBox.Show("Can't save note! Please include a message.",
                                "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            #endregion

            #region Finishing Up
            else
            {
                Note note = new Note(name, message);
                TaskGlobal.Notes.Add(note);

                Saved = true;
                Close();

            }
            #endregion
        }
        #endregion

        #region Clear
        //When the clear button is clicked, all data on the page is removed.
        private void btnClearNote_Click(object sender, RoutedEventArgs e)
        {
            tbxNoteName.Text = "";
            tbxNoteMessage.Text = "";
        }
        #endregion
    }
}

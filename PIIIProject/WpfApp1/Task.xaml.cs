using System;
using System.Windows;
using PIIIProject.Models;

namespace CalendarApp
{
    /// <summary>
    /// Interaction logic for Task.xaml
    /// </summary>
    public partial class Task : Window
    {
        //Data Members
        private DateTime time = DateTime.Now;
        private bool saved;

        //Constructor
        #region No Args
        public Task()
        {
            InitializeComponent();
            lblTaskName.Content = "New Task";
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

        #region Time
        private DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
        #endregion

        //-------------------------------------------------
        //                    Methods
        //-------------------------------------------------

        #region Update
        //When editing an existing task, this is run on the window to set all the data for the user
        //to edit as they see fit.
        public void Update(UserTask task)
        {
            saved = false;
            lblTaskName.Content = task.Name;
            tbxEditName.Text = task.Name;
            dtpDueDate.SelectedDate = task.DueDate;
            tbxEditDetails.Text = task.Details;
            cbxRepeatable.IsChecked = task.IsRepeating;
            cbxCompleted.IsChecked = task.IsCompleted;
        }
        #endregion

        #region Save
        //Function to run when the Save button is clicked. Extracts and validates all the user-editable information
        //and creates a new task, if possible with it.
        private void btnSaveTaskEdit_Click(object sender, RoutedEventArgs e)
        {
            //Tasks must have a name and date, minimum. Everything else, up to them
            if (tbxEditName.Text == null || dtpDueDate.SelectedDate == null)
                MessageBox.Show("Can't save task! Please include a name and due date.",
                                "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                // Can explicitly cast the datetime since it can't be null anyway
                string name = tbxEditName.Text;
                DateTime due = (DateTime)dtpDueDate.SelectedDate;
                string details = tbxEditDetails.Text;

                #region Bottom Checkbox Checks/Setting
                //Null is invalid for bools, so set them to false to save
                if (cbxRepeatable.IsChecked == null)
                    cbxRepeatable.IsChecked = false;
                if (cbxCompleted.IsChecked == null)
                    cbxCompleted.IsChecked = false;

                bool isRepeated = (bool)cbxRepeatable.IsChecked;
                bool isComplete = (bool)cbxCompleted.IsChecked;
                #endregion

                #region Making a Task
                UserTask newTask = new UserTask(name, due, details);

                if (isRepeated)
                    newTask = new UserTask(name, due, RepeatInterval.WEEKLY, details);
                #endregion

                Agenda.AddTask(newTask);

                #region Agenda Checks
                //Complete tasks are saved different than tasks to be done still, so the app gives
                //The least amount of information needed as possible. Also, many Agenda checks
                //Rely on the Entries property, to not waste resources checking dates with no data.
                //That 2nd if statement is to help ensure Entries is up to date.
                if(isComplete)
                {
                    int index = Agenda.Tasks.Count - 1;
                    Agenda.CompleteTask(index);
                }
                //If a completed task is being edited to incomplete, this else if is run to move it out of the completed
                //tasks and back to the to-do task list.
                else if (Agenda.CompleteTasks.Contains(newTask))
                {
                    int index = Agenda.CompleteTasks.IndexOf(newTask);
                    Agenda.TaskIncomplete(index);
                }
                if (Agenda.Entries.Contains(due) == false)
                    Agenda.Entries.Add(due);
                #endregion

                Saved = true;
                Close();
            }

        }
        #endregion

        #region Clear
        //When the clear button is clicked, all data on the page is removed.
        private void btnClearTaskEdit_Click(object sender, RoutedEventArgs e)
        {
            tbxEditName.Text = "";
            dtpDueDate.SelectedDate = null;
            tbxEditDetails.Text = "";
            cbxRepeatable.IsChecked = false;
            cbxCompleted.IsChecked = false;
        }
        #endregion
    }
}

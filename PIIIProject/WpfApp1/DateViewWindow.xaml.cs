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
using WpfApp1;
using PIIIProject;
using PIIIProject.Models;

namespace CalendarApp
{
    public partial class DateViewWindow : Window
    {
        //Data Members

        private DateTime time;
        private List<UserTask> todayTasks;
        private List<Event> todayEvents;

        //Constructor

        #region No Args FOR NOW THIS NEEDS TO BE CHANGED AAAAA
        public DateViewWindow(DateTime date)
        {
            InitializeComponent();
            Time = date;
            lblDateTitle.Content = Time.ToString("D");
            TodayTasks = Agenda.TasksOfTheDay(time);
            TodayEvents = Agenda.EventsOfTheDay(time);
            
            lbxTasks.ItemsSource = TodayTasks;
            lbxEvents.ItemsSource = TodayEvents;
            
        }
        #endregion

        //Properties

        #region Time
        public DateTime Time
        {
            get { return time; }
            private set { time = value; }
        }
        #endregion

        #region Today Tasks
        public List<UserTask> TodayTasks
        {
            get { return todayTasks; }
            private set { todayTasks = value; }
        }
        #endregion

        #region Today Events
        public List<Event> TodayEvents
        {
            get { return todayEvents; }
            set { todayEvents = value; }
        }
        #endregion

        //-------------------------------------------------
        //                    Methods
        //-------------------------------------------------

        #region Refresh
        /// <summary>
        /// Every time something is changed by the UI, refresh all elements of the current window.
        /// </summary>
        private void Refresh()
        {
            lblDateTitle.Content = Time.ToString("D");
            TodayTasks = Agenda.TasksOfTheDay(time);
            TodayEvents = Agenda.EventsOfTheDay(time);
            lbxTasks.ItemsSource = TodayTasks;
            lbxEvents.ItemsSource = TodayEvents;

            if (lbxTasks.SelectedItem != null)
                lbxNotes.ItemsSource = TodayTasks[lbxTasks.SelectedIndex].Notes;
        }
        #endregion

        #region Change Date Buttons

        #region Left
        private void btnLeftChangeDate_Click(object sender, RoutedEventArgs e)
        {
            Time = Time.AddDays(-1);
            Refresh();
        }
        #endregion

        #region Right
        private void btnRightChangeDate_Click(object sender, RoutedEventArgs e)
        {
            Time = Time.AddDays(1);
            Refresh();
        }
        #endregion

        #endregion

        #region Task Buttons

        #region Add Task
        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            Task newTask = new Task();
            newTask.ShowDialog();
            Refresh();
        }
        #endregion

        #region Edit Task
        private void btnEditTask_Click(object sender, RoutedEventArgs e)
        {
            //Making sure that the user is trying to edit a task on the screen
            if (lbxTasks.SelectedItem != null)
            {
                //Simplifying variable setting
                int currentIndex = lbxTasks.SelectedIndex;
                int lastIndex = Agenda.Tasks.Count - 1;

                #region New Task Window Open
                Task newTask = new Task();
                newTask.Update(TodayTasks[currentIndex]);
                newTask.ShowDialog();
                #endregion

                #region If the Save button was clicked:
                if (newTask.Saved)
                {
                    Agenda.Tasks[lastIndex].Notes = TodayTasks[currentIndex].Notes;
                    Agenda.Tasks.Remove(TodayTasks[currentIndex]);
                }
                #endregion

                Refresh();
            }
        }
        #endregion

        #region Delete Task
        private void btnRemoveTask_Click(object sender, RoutedEventArgs e)
        {
            if (lbxTasks.SelectedItem != null)
            {
                int index = lbxTasks.SelectedIndex;
                Agenda.Tasks.Remove(TodayTasks[index]);
            }
            Refresh();
        }
        #endregion

        #endregion

        #region Event Buttons

        #region Add Event
        private void btnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            CalEvent newEvent = new CalEvent();
            newEvent.ShowDialog();
            Refresh();
        }
        #endregion

        #region Edit Event
        private void btnEditEvent_Click(object sender, RoutedEventArgs e)
        {
            if (lbxEvents.SelectedItem != null) 
            {
                int currentIndex = lbxEvents.SelectedIndex;

                #region New Event Window Open
                CalEvent newEvent = new CalEvent();
                newEvent.Update(TodayEvents[currentIndex]);
                newEvent.ShowDialog();
                #endregion

                #region If Save Event was Clicked:
                if (newEvent.Saved)
                {
                    if (Agenda.Events.Contains(TodayEvents[currentIndex]))
                        MessageBox.Show("Error! Default events cannot be edited by the user.");
                    else
                        Agenda.UserEvents.Remove(TodayEvents[currentIndex]);
                }
                #endregion

                Refresh();
            }
        }
        #endregion

        #region Remove Event
        private void btnRemoveEvent_Click(object sender, RoutedEventArgs e)
        {
            int currentIndex = lbxEvents.SelectedIndex;

            if (lbxEvents.SelectedItem != null)
            {
                if (Agenda.Events.Contains(TodayEvents[currentIndex]))
                    MessageBox.Show("Error! Default events cannot be deleted by the user.");
                else
                    Agenda.UserEvents.Remove(TodayEvents[currentIndex]);
            }
            Refresh();
        }
        #endregion

        #endregion

        #region Note Buttons

        #region Add Note
        private void btnAddNote_Click(object sender, RoutedEventArgs e)
        {
            if (lbxTasks.SelectedItem != null)
            {
                Notes note = new Notes(TodayTasks[lbxTasks.SelectedIndex]);
                note.ShowDialog();
            }
            Refresh();
        }
        #endregion

        #region Edit Note
        private void btnEditNote_Click(object sender, RoutedEventArgs e)
        {
            if (lbxNotes.SelectedItem != null)
            {
                int currentIndex = lbxNotes.SelectedIndex;
                //int noteIndex = todayTasks[lbxTasks.SelectedIndex].Notes[ ;

                #region Nev Note Window Open
                Notes noteEdit = new Notes (TodayTasks[lbxTasks.SelectedIndex]);
                noteEdit.Update(currentIndex);
                noteEdit.ShowDialog();
                #endregion

                #region If Save Note was Clicked:
                if (noteEdit.Saved)
                    TodayTasks[lbxTasks.SelectedIndex].Notes.RemoveAt(currentIndex);
                #endregion
            }
            Refresh();
        }
        #endregion

        #region Remove Note
        private void btnRemoveNote_Click(object sender, RoutedEventArgs e)
        {

            if (lbxTasks.SelectedItem != null && lbxNotes.SelectedItem != null)
            {
                TodayTasks[lbxTasks.SelectedIndex].Notes.RemoveAt(lbxNotes.SelectedIndex);
                lbxNotes.ItemsSource = TodayTasks[lbxTasks.SelectedIndex].Notes;
            }

            Refresh();
        }
        #endregion

        #endregion

        #region Selection Change Methods
        //If any list box on the window detects a selection change, the page is refreshed.
        private void lbxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void lbxEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void lbxNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
        #endregion
    }
}

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
    /// Interaction logic for Event.xaml
    /// </summary>
    public partial class CalEvent : Window
    {
        //Data Member
        private bool saved;

        //Constructor
        #region No Args
        public CalEvent()
        {
            InitializeComponent();
            lblEventTitle.Content = "New Event";
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

        //-------------------------------------------------
        //                    Methods
        //-------------------------------------------------

        #region Update
        //When editing an existing event, this is run on the window to set all the data for the user
        //to edit as they see fit.
        public void Update(Event currentEvent)
        {
            saved = false;
            lblEventTitle.Content = currentEvent.Name;
            tbxEventName.Text = currentEvent.Name;
            dtpEventDate.SelectedDate = currentEvent.Date;
            tbxEventDescription.Text = currentEvent.Description;
        }
        #endregion

        #region Save
        //Function to run when the Save button is clicked. Extracts and validates all the user-editable information
        //and creates a new event, if possible with it.
        private void btnSaveEvent_Click(object sender, RoutedEventArgs e)
        {
            string name = tbxEventName.Text;
            string description = tbxEventDescription.Text;

            #region Validation
            //Nothing can be null or empty. Throw an error on any possible null value.
            if (name == null || name == "")
                MessageBox.Show("Cant save event! Please include an event name.",
                            "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            if (dtpEventDate.SelectedDate == null)
                MessageBox.Show("Can't save event! Please indicate an event date.",
                            "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            if (description == null || description == "")
                MessageBox.Show("Can't save event! Please include a description.",
                                "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            #endregion
            else
            {
                //Explicit casting after validation because null is never possible.
                DateTime date = (DateTime)dtpEventDate.SelectedDate;

                #region Finishing Up
                //Create new event, update Agenda's data, set Saved property to True, then close.
                Event newEvent = new Event(name, date, description);
                Agenda.UserEvents.Add(newEvent);
                Agenda.Entries.Add(date);

                Saved = true;
                Close();
                #endregion
            }

        }
        #endregion

        #region Clear
        //When the clear button is clicked, all data on the page is removed.
        private void btnClearEvent_Click(object sender, RoutedEventArgs e)
        {
            tbxEventName.Text = "";
            dtpEventDate.SelectedDate = null;
            tbxEventDescription.Text = "";

        }
        #endregion
    }
}

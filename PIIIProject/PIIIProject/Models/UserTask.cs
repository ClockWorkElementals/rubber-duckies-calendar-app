using System;
using System.Collections.Generic;
using System.Text;

namespace PIIIProject.Models
{
    public class UserTask
    {
        //-------------------------------------------------
        //                 Data Members
        //      
        //-------------------------------------------------
        private string _name;
        private DateTime _dueDate;
        private string _details;

        private List<Note> _notes;

        private bool _isCompleted;
        private DateTime _completedTime;

        // Conditional Data Members if a task should show up more than once
        private bool _isRepeating;
        private RepeatInterval _type;
        //-------------------------------------------------
        //                 Constructors
        //-------------------------------------------------

        #region 2 Args (Task Name and dueDate)
        public UserTask (string name, DateTime dueDate)
        {
            Name = name;
            DueDate = dueDate;
            Notes = new List<Note>();
            IsCompleted = false;

            IsRepeating = false;
            Type = RepeatInterval.NO_REPEAT;

        }
        #endregion

        #region 3 Args (Task Name, Due Date, and Repeat Interval)
        public UserTask (string name, DateTime dueDate, RepeatInterval interval)
            : this(name, dueDate)
        {
            IsRepeating = true;
            _type = interval;
        }
        #endregion

        #region 3 Args (Task Name, Due Date, and Details)
        public UserTask (string name, DateTime dueDate, string details)
            : this(name, dueDate)
        {
            Details = details;
        }
        #endregion

        #region 4 Args (Task Name, Due Date, Repeat Interval, and Details)
        public UserTask (string name, DateTime dueDate, RepeatInterval interval, string details)
            : this(name, dueDate, interval)
        {
            Details = details;
        }
        #endregion

        //-------------------------------------------------
        //                 Properties
        //-------------------------------------------------
        #region Name
        public string Name
        {
            get { return _name; }
            private set { _name = value; }                          
        }
        #endregion

        #region DueDate
        public DateTime DueDate
        {
            get { return _dueDate; }
            private set { _dueDate = value; }
        }
        #endregion

        #region Details
        public string Details
        {
            get { return _details; }
            private set { _details = value; }
        }
        #endregion

        #region Notes
        public List<Note> Notes
        {
            get { return _notes; }
            set { _notes = value; }                                         
        }
        #endregion

        #region IsCompleted
        public bool IsCompleted
        {
            get { return _isCompleted; }
            private set { _isCompleted = value; }
        }
        #endregion

        #region Completed Time
        public DateTime CompletedTime
        {
            get { return _completedTime; }
            private set { _completedTime = value; }
        }
        #endregion

        // Conditional Properties

        #region IsRepeated
        public bool IsRepeating
        {
            get { return _isRepeating; }
            private set { _isRepeating = value; }
        }
        #endregion

        #region Type
        public RepeatInterval Type
        {
            get { return _type; }
            private set { _type = value; }
        }
        #endregion

        // Calculated Properties

        #region Is Overdue
        public bool IsOverdue
        {
            get { return (IsCompleted == false && DateTime.Now > DueDate) ? true : false; }
        }
        #endregion

        #region Was Overdue
        public bool WasOverdue
        {
            get { return (CompletedTime > DueDate) ? true : false; }
        }
        #endregion

        //-------------------------------------------------
        //                    Methods
        //-------------------------------------------------

        #region Complete Task
        /// <summary>
        /// Void function that applies to a current task, so that when it is called, this task is flagged as complete
        /// and won't show up in lists of incomplete tasks.
        /// </summary>
        public void CompleteTask(DateTime completion)
        {
            IsCompleted = true;
            CompletedTime = completion;
        }
        #endregion

    }

    #region Repeat Interval Enum
    //BIWEEKLY means every 2 weeks
    public enum RepeatInterval
    {
        NO_REPEAT, DAILY, WEEKLY, BIWEEKLY, MONTHLY, SEASONALLY, YEARLY
    }
    #endregion
}

using System;
using System.Collections.Generic;

namespace PIIIProject.Models
{
    public class UserAgenda
    {
        /* NOTE:
         *          THIS CLASS IS NOT MEANT TO BE USED, AT ALL.
         *          The class' existence is solely to put user-editable information from the default Agenda to something
         *          I can serialize and deserialize, to allow users to save and load their agenda. Nothing about this
         *          should be accessible, if I can help it.
         */



        //-------------------------------------------------
        //                 Data Members
        //-------------------------------------------------
        private List<UserTask> _tasks = Agenda.Tasks;
        private List<UserTask> _completeTasks  = Agenda.CompleteTasks;
        private List<DateTime> _entries  = Agenda.Entries;
        private List<Event> _events = Agenda.UserEvents;
        private List<UserTask> _repeatTasks = Agenda.RepeatTasks;


        //-------------------------------------------------
        //                 Constructors
        //-------------------------------------------------
        #region No Args
        public UserAgenda()
        {
            
        }
        #endregion
        //-------------------------------------------------
        //                 Properties
        //-------------------------------------------------
        #region Tasks
        public List<UserTask> Tasks
        {
            get { return _tasks; }
        }
        #endregion

        #region CompleteTasks
        public List<UserTask> CompleteTasks
        {
            get { return _completeTasks; }
        }
        #endregion

        #region Entries
        public List<DateTime> Entries
        {
            get { return _entries; }
        }
        #endregion

        #region Events
        public List<Event> Events
        {
            get { return _events; }
        }
        #endregion

        #region Repeat Tasks
        public List<UserTask> RepeatTasks
        {
            get { return _repeatTasks; }
        }
        #endregion
    }
}

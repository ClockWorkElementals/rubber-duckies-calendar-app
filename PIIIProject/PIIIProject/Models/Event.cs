using System;

namespace PIIIProject.Models
{
    public class Event
    {
        //-------------------------------------------------
        //                 Data Members
        //-------------------------------------------------
        private string _name;
        private DateTime _date;
        private string _description;

        //-------------------------------------------------
        //                 Constructors
        //-------------------------------------------------
        #region 3 Args (Event Name, Event Date, Description
        public Event (string name, DateTime date, string description)
        {
            Name = name;
            Date = date;
            Description = description;
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

        #region Date
        public DateTime Date
        {
            get { return _date; }
            private set { _date = value; }
        }
        #endregion

        #region Description
        public string Description
        {
            get { return _description; }
            private set { _description = value; }
        }
        #endregion

    }
}

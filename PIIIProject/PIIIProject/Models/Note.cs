namespace PIIIProject.Models
{
    public class Note
    {

        //-------------------------------------------------
        //                 Data Members
        //-------------------------------------------------
        private string _name;
        private string _message;
        //-------------------------------------------------
        //                 Constructors
        //-------------------------------------------------
        #region 2 Args (name, message)
        public Note (string name, string message)
        {
            Name = name;
            Message = message;
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

        #region Message
        public string Message
        {
            get { return _message; }
            private set { _message = value; }
        }
        #endregion

        //-------------------------------------------------
        //                    Methods
        //-------------------------------------------------

    }
}

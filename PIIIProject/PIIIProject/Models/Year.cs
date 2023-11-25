using System;

namespace PIIIProject.Models
{
    public class Year
    {

        //-------------------------------------------------
        //                 Data Members
        //-------------------------------------------------
        private int _currentYear;
        private DateTime[][] _calendar;

        //-------------------------------------------------
        //                 Constructors
        //-------------------------------------------------
        #region 1 Arg (Current Year)
        public Year(int year)
        {
            CurrentYear = year;
            Calendar = GenerateCalendar();
        }
        #endregion

        //-------------------------------------------------
        //                 Properties
        //-------------------------------------------------
        #region CurrentYear
        public int CurrentYear
        {
            get { return _currentYear; }
            private set { _currentYear = value; }
        }
        #endregion

        #region Calendar
        public DateTime[][] Calendar
        {
            get { return _calendar; }
            set { _calendar = value; }
        }
        #endregion

        //Calculated Properties

        #region IsLeapYear
        public bool IsLeapYear
        {
            get { return DateTime.IsLeapYear(CurrentYear); }
        }
        #endregion

        //-------------------------------------------------
        //                    Methods
        //-------------------------------------------------

        #region GenerateCalendar
        private DateTime[][] GenerateCalendar()
        {
            DateTime[][] cal = new DateTime[12][];

            #region Set array lengths based on month lengths (includes Leap Year Feb)
            cal[0] = new DateTime[31];
            cal[1] = IsLeapYear ? new DateTime[29] : new DateTime[28];
            cal[2] = new DateTime[31];
            cal[3] = new DateTime[30];
            cal[4] = new DateTime[31];
            cal[5] = new DateTime[30];
            cal[6] = new DateTime[31];
            cal[7] = new DateTime[31];
            cal[8] = new DateTime[30];
            cal[9] = new DateTime[31];
            cal[10] = new DateTime[30];
            cal[11] = new DateTime[31];
            #endregion


            #region Save DateTimes
            //Save a datetime for each index of the jagged array
            for (int i = 0; i < cal.Length; i++)
                for (int j = 0; j < cal[i].Length; j++)
                    cal[i][j] = new DateTime(CurrentYear, i + 1, j + 1);
            #endregion
            return cal;
        }
        #endregion
    }
}

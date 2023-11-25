using System;
using System.Collections.Generic;

namespace PIIIProject.Models
{
    public static class Agenda
    {
        private static List<Year> _decade;
        private static List<UserTask> _tasks = new List<UserTask>();
        private static List<UserTask> _completeTasks = new List<UserTask>();
        private static List<DateTime> _entries = new List<DateTime>();
        private static List<Event> _events = new List<Event>();
        private static List<Event> _userEvents = new List<Event>();
        private static List<UserTask> _repeatTasks = new List<UserTask>();


        //-------------------------------------------------
        //                 Properties
        //-------------------------------------------------

        #region Decade
        public static List<Year> Decade
        {
            get { return _decade; }
            private set { _decade = value; }
        }
        #endregion

        #region Tasks
        public static List<UserTask> Tasks
        {
            get { return _tasks; }
            private set { _tasks = value; }
        }
        #endregion

        #region CompleteTasks
        public static List<UserTask> CompleteTasks
        {
            get { return _completeTasks; }
            private set { _completeTasks = value; }
        }
        #endregion

        #region Entries
        public static List<DateTime> Entries
        {
            get { return _entries; }
            private set { _entries = value; }
        }
        #endregion

        #region Events
        public static List<Event>Events
        {
            get { return _events; }
            private set { _events = value; }
        }
        #endregion

        #region UserEvents
        public static List<Event> UserEvents
        {
            get { return _userEvents; }
            private set { _events = value; }
        }
        #endregion

        #region RepeatTasks
        public static List<UserTask> RepeatTasks
        {
            get { return _repeatTasks; }
            private set { _repeatTasks = value; }
        }
        #endregion


        //-------------------------------------------------
        //                    Methods
        //-------------------------------------------------

        #region GenerateDecades
        /// <summary>
        /// When an Agenda is created with a year, this code generates a list of Year classes that correspond to that year's decade.
        /// Also creates an event for every year of the decade.
        /// </summary>
        /// <param name="year">Any year, to build a decade around it.</param>
        public static void GenerateDecade()
        {
            int year = DateTime.Now.Year;
            List<Year> currentDecade = new List<Year>();
            int decade = year / 10 * 10;

            for(int i = 0; i < 10; i++)
            {
                currentDecade.Add(new Year(decade));
                GenerateEvents(decade);
                decade++;
            }

            Decade = currentDecade;
        }
        #endregion

        #region GenerateEvents
        /// <summary>
        /// Generates a list of static events to slot into a user's agenda This list of events cannot be edited by the
        /// user in any way.
        /// </summary>
        private static void GenerateEvents(int year)
        {
            #region Creating Events
            #region International Women's Day
            Event WomensDay = new Event("International Women's Day", new DateTime(year, 3, 8), "International Women's Day (March 8) is a global day celebrating the social, economic, cultural, " +
                "and political achievements of women.The day also marks a call to action for accelerating women's equality.");
            #endregion

            #region Ukraine's Independence Day
            Event UkraineIndependence = new Event("Ukraine's Independence Day", new DateTime(year, 8, 24), "Independence Day of Ukraine is the main state holiday in modern Ukraine, celebrated " +
                "on 24 August in commemoration of the Declaration of Independence of 1991.");
            #endregion

            #region Stonewall Riots
            Event StoneWallRiots = new Event("Stonewall Riots Anniversary", new DateTime(year, 6, 28), "The Stonewall riots  were a series of spontaneous protests by members of the gay community in response " +
                "to a police raid that began in the early morning hours of June 28, 1969, at the Stonewall Inn in the Greenwich Village neighborhood ofLower Manhattan in New York City. Patrons of the Stonewall, " +
                "other Village lesbian and gay bars, and neighborhood street people fought back when thepolice became violent.The riots are widely considered the watershed event that transformed the gay " +
                "liberation movement and the twentieth-century fight for LGBT rights in the United States.");
            #endregion

            #region Polytechnique Shooting
            Event Polytechnique = new Event("Polytechnique Shooting", new DateTime(year, 12, 6), "The École Polytechnique massacre  was an antifeminist mass shooting that occurred on December 6, 1989 " +
                "at the École Polytechnique de Montréal in Montreal, Quebec. Fourteen women were murdered; another ten women and four men were injured.The massacre is now widely regarded as an anti-feminist " +
                "attack and representative of wider societal violence against women; the anniversary of the massacre is commemorated as the National Day of Remembrance and Action on Violence Against Women.");
            #endregion

            #region National Day for Truth and Reconciliation
            Event TruthAndReconcilition = new Event("National Day for Truth and Reconciliation", new DateTime(year, 9, 30), "Each year, September 30 marks the National Day for Truth and Reconciliation. " +
                "The day honours the children who never returned home and Survivors of residential schools, as well as their families and communities.Public commemoration of the tragic and painful " +
                "history and ongoing impacts of residential schools is a vital component of the reconciliation process.");
            #endregion

            #region Beltane
            Event Beltane = new Event("Beltane", new DateTime(year, 5, 1), "Beltane is the Gaelic May Day festival. Commonly observed on the first of May, the festival falls midway between the spring equinox " +
                "and summer solstice in the northern hemisphere. The festival name is synonymous with the month marking the start of summer in Ireland, May being Mí na Bealtaine. Historically, it was widely " +
                "observed throughout Ireland, Scotland, and the Isle of Man.");
            #endregion

            #region National Indigenous Peoples' Day
            Event IndigenousPeoplesDay = new Event("National Indigenous Peoples' Day", new DateTime(year, 6, 21), "National Indigenous Peoples Day is a day recognizing and celebrating the cultures and contributions " +
                "of the First Nations, Inuit, and Métis Indigenous peoples of Canada. The day was first celebrated in 1996, after it was proclaimed that year by then Governor General of Canada Roméo LeBlanc, to be " +
                "celebrated annually on 21 June. This date was chosen as the statutory holiday for many reasons, including its cultural significance as the Summer solstice, and the fact that it is a day on which many " +
                "Indigenous peoples and communities traditionally celebrate their heritage.");
            #endregion

            #region National Trans Day of Rememberence
            Event TransDayOfRememberance = new Event("National Trans Day of Rememberance", new DateTime(year, 11, 20), "Transgender Day of Remembrance (TDOR) is an annual observance on November 20 that honors the memory " +
                "of the transgender people whose lives were lost in acts of anti-transgender violence.");
            #endregion

            #region National Suicide Prevention Day
            Event SuiPreventionDay = new Event("National Suicide Prevention Day", new DateTime(year, 9, 10), "World Suicide Prevention Day (WSPD) is an awareness day observed on 10 September every year, in order to provide worldwide " +
                "commitment and action to prevent suicides, with various activities around the world since 2003. The International Association for Suicide Prevention (IASP) collaborates with the World Health Organization (WHO) and the " +
                "World Federation for Mental Health (WFMH) to host World Suicide Prevention Day.");
            #endregion

            #region Lovelace Day
            Event LovelaceDay = new Event("National Lovelace Day", new DateTime(year, 10, 13), "Ada Lovelace Day on October 13 highlights the achievements of women in science, technology, engineering, and mathematics. Launched in 2009 " +
                "as a celebration of women in science, the event promotes programs that encourage girls and women to pursue careers in STEM.");
            #endregion

            #endregion

            #region Adding Events to Agenda
            Events.Add(WomensDay);
            Events.Add(UkraineIndependence);
            Events.Add(StoneWallRiots);
            Events.Add(Polytechnique);
            Events.Add(TruthAndReconcilition);
            Events.Add(Beltane);
            Events.Add(IndigenousPeoplesDay);
            Events.Add(TransDayOfRememberance);
            Events.Add(SuiPreventionDay);
            Events.Add(LovelaceDay);
            #endregion

            #region Adding event dates to Agenda Entries
            Entries.Add(new DateTime(year, 3, 8));
            Entries.Add(new DateTime(year, 6, 28));
            Entries.Add(new DateTime(year, 8, 24));
            Entries.Add(new DateTime(year, 12, 6));
            Entries.Add(new DateTime(year, 12, 19));
            Entries.Add(new DateTime(year, 9, 30));
            Entries.Add(new DateTime(year, 5, 1));
            Entries.Add(new DateTime(year, 6, 21));
            Entries.Add(new DateTime(year, 11, 20));
            Entries.Add(new DateTime(year, 9, 10));
            Entries.Add(new DateTime(year, 10, 13));
            #endregion

        }
        #endregion

        #region AddTask
        public static void AddTask(UserTask newTask)
        {
            Tasks.Add(newTask);
            if (newTask.IsRepeating)
                RepeatTask(newTask);

            if (!Entries.Contains(newTask.DueDate))
                Entries.Add(newTask.DueDate);
        }
        #endregion

        #region RepeatTask
        /// <summary>
        /// If a task is flagged to be repeated, create 20 versions of it into the future.
        /// </summary>
        public static void RepeatTask(UserTask newTask)
        {
            DateTime due = newTask.DueDate;

            for(int i = 0; i < 4; i++)
            {
                due = due.AddDays(7);
                UserTask repeatIteration = new UserTask(newTask.Name, due, newTask.Details);
                
                RepeatTasks.Add(repeatIteration);

                if (Entries.Contains(due) == false)
                    Entries.Add(due);
            }
        }
        #endregion

        #region CompleteTask
        /// <summary>
        /// Void function to flag a task as completed in the agenda, so the agenda seperates it from still-due tasks to its own
        /// list.
        /// </summary>
        /// <param name="index"></param>
        public static void CompleteTask(int index)
        {
            CompleteTasks.Add(Tasks[index]);
            Tasks[index].CompleteTask(DateTime.Now);
            Tasks.RemoveAt(index);
        }
        #endregion

        #region TaskIncomplete
        /// <summary>
        /// If a task used to be completed, then this method grabs it from the completed list, and moves it back
        /// to the active tasks list.
        /// </summary>
        /// <param name="index">the index that the task is located in the CompleteTasks list.</param>
        public static void TaskIncomplete(int index)
        {
            Tasks.Add(CompleteTasks[index]);
            CompleteTasks.RemoveAt(index);
        }
        #endregion

        #region TasksOfTheDay
        /// <summary>
        /// Generate a list of tasks based on the day of the year passed to the function.
        /// </summary>
        /// <param name="date">date to look through the tasks for.</param>
        /// <returns>A list of tasks due on the day currently being looked at.</returns>
        public static List<UserTask> TasksOfTheDay(DateTime date)
        {
            List<UserTask> todaysTasks = new List<UserTask>();

            //If there isn't an entry for the day, method ends.
            if (!Entries.Contains(date.Date))
                return todaysTasks;

            foreach(UserTask task in Tasks)
            {
                if (task.DueDate.Date == date.Date)
                    todaysTasks.Add(task);
            }
            foreach(UserTask task in RepeatTasks)
            {
                if (task.DueDate.Date == date.Date)
                    todaysTasks.Add(task);
            }

            return todaysTasks;
        }
        #endregion

        #region EventsOfTheDay
        /// <summary>
        /// Generate a list of events based on the day of the year passed to the function.
        /// First, looks for static events, then looks for user-created events.
        /// </summary>
        /// <param name="date">date to look through the ebents for.</param>
        /// <returns>A list of events happening on the day currently being looked at.</returns>
        public static List<Event> EventsOfTheDay(DateTime date)
        {
            List<Event> todayEvents = new List<Event>();

            //If there's no agenda entry for the day, method ends.
            if (!Entries.Contains(date.Date))
                return todayEvents;

            #region For Each Static Event
            foreach (Event currentEvent in Events)
            {
                if (currentEvent.Date.Date == date.Date)
                    todayEvents.Add(currentEvent);
            }
            #endregion

            #region For Each User Event
            foreach (Event currentEvent in UserEvents)
            {
                if (currentEvent.Date.Date == date.Date)
                    todayEvents.Add(currentEvent);
            }
            #endregion

            return todayEvents;
        }
        #endregion

        #region Update
        /// <summary>
        /// When a user loads a JSON file with a UserAgenda class in it, update all the info in the agenda to contain the user's data as well.
        /// </summary>
        /// <param name="userData">a JSON file with Agenda list information.</param>
        public static void Update(UserAgenda userData)
        {
            Tasks = userData.Tasks;
            CompleteTasks = userData.CompleteTasks;
            RepeatTasks = userData.RepeatTasks;
            Events.AddRange(userData.Events);
            #region Update Agenda Entries by adding, not replacing
            foreach (DateTime dateEntry in userData.Entries)
            {
                if (Entries.Contains(dateEntry) == false)
                    Entries.Add(dateEntry);
            }
            #endregion
        }
        #endregion
    }
}

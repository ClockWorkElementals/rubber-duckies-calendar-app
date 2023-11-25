using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PIIIProject.Models;
using System.Text.Json;
using System.IO;
using Microsoft.Win32;
using CalendarApp;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime time = DateTime.Now;
        DateTime firstDayOfMonth;
        
        public MainWindow()
        {
            Agenda.GenerateDecade();
            InitializeComponent();

            try
            {
                lblCalendarMonth.Content = $"{time.ToString("MMMM")} {time.Year}";

                //Testing for agenda
                Agenda.AddTask(new UserTask("Prog III Project", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)));
                Agenda.AddTask(new UserTask("Prog II Project", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)));
                Note meep = new Note("Test Note", "This is a test note for a new task!");
                Agenda.Tasks[1].Notes.Add(meep);
                //Agenda.CompleteTask(1);
                Agenda.AddTask(new UserTask("Prog I Project", new DateTime(2023, 1, 2)));

                int firstDay = GetFirstDayOfMonth();
                LoadCalendarDates(firstDay);
                LoadCalendarListBoxes(firstDay);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error encountered" , MessageBoxButton.OK, MessageBoxImage.Error);
            }
                
        }

        private Label[] GetLabelElementsInCalendar(Label[] labelArr)
        {
            const int NBOFHEADERLABELS = 6;
            int foo = 0;

            //Grabs all the label elements in the calendar grid and stores them in an array
            foreach (UIElement element in grdCalendar.Children)
            {
                if (element is Label)
                {
                    //Skips headers labels in the calendar (Monday, Tuesday...)
                    if (foo > NBOFHEADERLABELS)
                        labelArr[foo - (NBOFHEADERLABELS + 1)] = element as Label;
                    foo++;
                }
            }

            return labelArr;
        }

        private int GetNumberOfDaysPerMonth()
        {
            Year year = new Year(DateTime.Now.Year);
            return year.Calendar[time.Month - 1].Length;
        }

        public void LoadCalendarDates(int firstDay)
        {
            //Initializing array that contains all date labels and populating it
            const int NBOFDATELABELS = 35;

            Label[] labelArr = new Label[NBOFDATELABELS];
            labelArr = GetLabelElementsInCalendar(labelArr);

            bool firstDayPlaced = false; //bool flag for when the first date is set

            int date = 1; //which date was last set on the calendar
            int weekDay = 1; //represents numerically what day of the week the loop is currently on (Monday, Tuesday...)
            int nbOfDaysInMonth = GetNumberOfDaysPerMonth() + 1;

            //Loops through each label element in the array
            for (int i = 0; i < labelArr.Length; i++)
            {
                if (firstDayPlaced)
                {
                    if (date < nbOfDaysInMonth)
                    {
                        labelArr[i].Content = date.ToString();
                        date++;
                    }
                    else
                        break;
                }

                if (weekDay == firstDay && !firstDayPlaced)
                {
                    labelArr[i].Content = date.ToString();
                    firstDayPlaced = true;
                    date++;
                }

                //Resets the weekday counter
                if (weekDay >= 7)
                    weekDay = 1;
                else
                    weekDay++;
            }
        }

        private ListBox[] GetListBoxElementsInCalendar(ListBox[] listBoxArr)
        {
            int foo = 0;

            //Grabs all the label elements in the calendar grid and stores them in an array
            foreach (UIElement element in grdCalendar.Children)
            {
                if (element is ListBox)
                {
                    if (foo < listBoxArr.Length)
                    {
                        listBoxArr[foo] = element as ListBox;
                        foo++;
                    }   
                }
            }

            return listBoxArr;
        }

        public void LoadCalendarListBoxes(int firstDay)
        {
            //Initializing array that will contain all listbox elements in the calendar
            ListBox[] listBoxArr = new ListBox[GetNumberOfDaysPerMonth()];
            listBoxArr = GetListBoxElementsInCalendar(listBoxArr);

            int weekDay = 1; 
            int nbOfDaysPerMonth = GetNumberOfDaysPerMonth();
            int date = 1;

            bool firstDayFilled = false;
            DateTime officialDate; 

            //Looping through the ListBox elements
            for (int i = 0; i < listBoxArr.Length; i++)
            {
                if (firstDayFilled)
                {
                    if (date <= nbOfDaysPerMonth)
                    {
                        officialDate = new DateTime(time.Year, time.Month, date);
                        listBoxArr[i].ItemsSource = Agenda.TasksOfTheDay(officialDate);
                        listBoxArr[i].DisplayMemberPath = "Name";
                        date++;
                    }
                    else
                        break;
                }

                if (weekDay == firstDay && !firstDayFilled)
                {
                    officialDate = new DateTime(time.Year, time.Month, date);
                    listBoxArr[i].ItemsSource = Agenda.TasksOfTheDay(officialDate);
                    firstDayFilled = true;
                    date++;
                }

                weekDay++;
            }
        }

        public void ClearCalendarValues()
        {
            int index = 0;
            foreach (UIElement element in grdCalendar.Children)
            {
                if (element is Label)
                {
                    if (index > 6)
                        ((Label)element).Content = "";
                    index++;
                }

                if (element is ListBox)
                    ((ListBox)element).ItemsSource = "";

            }
        }

        private int GetFirstDayOfMonth()
        {
            firstDayOfMonth = time.AddDays(-time.Day + 1);

            switch (firstDayOfMonth.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return 1;

                case DayOfWeek.Monday:
                    return 2;

                case DayOfWeek.Tuesday:
                    return 3;

                case DayOfWeek.Wednesday:
                    return 4;

                case DayOfWeek.Thursday:
                    return 5;

                case DayOfWeek.Friday:
                    return 6;

                case DayOfWeek.Saturday:
                    return 7;

                default:
                    return -1;
            }
        }

        #region Button Event Handlers
        private void btnLeftChangeMonth_Click(object sender, RoutedEventArgs e)
        {
            time = time.AddMonths(-1);
            firstDayOfMonth = time.AddDays(-time.Day + 1);
            lblCalendarMonth.Content = $"{time.ToString("MMMM")} {time.Year}";

            ClearCalendarValues();

            int firstDay = GetFirstDayOfMonth();
            LoadCalendarDates(firstDay);
            LoadCalendarListBoxes(firstDay);
        }

        private void btnRightChangeMonth_Click(object sender, RoutedEventArgs e)
        {
            time = time.AddMonths(1);
            firstDayOfMonth = time.AddDays(-time.Day + 1);
            lblCalendarMonth.Content = $"{time.ToString("MMMM")} {time.Year}";

            ClearCalendarValues();

            int firstDay = GetFirstDayOfMonth();
            LoadCalendarDates(firstDay);
            LoadCalendarListBoxes(firstDay);
        }
        
        private void btnSaveToFile_Click(object sender, RoutedEventArgs e)
        {
            UserAgenda userData = new UserAgenda();

            string JSON = JsonSerializer.Serialize<UserAgenda>(userData);
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.ShowDialog();
            if (saveFile.FileName != null && saveFile.FileName != "")
                File.WriteAllText(saveFile.FileName, JSON);
        }

        private void btnUploadFile_Click(object sender, RoutedEventArgs e)
        {
        
            OpenFileDialog openFile = new OpenFileDialog();

            if(openFile.ShowDialog() == true)
            {
                string JSON = File.ReadAllText(openFile.FileName);
                UserAgenda userData = JsonSerializer.Deserialize<UserAgenda>(JSON);
                Agenda.Update(userData);
            }
        
        }

        private void lbl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Label clickedLabel = sender as Label;
            DateTime officialDate;

            if (Int32.TryParse(clickedLabel.Content.ToString(), out int date))
            {
                officialDate = new DateTime(time.Year, time.Month, date);
                DateViewWindow clickedDate = new DateViewWindow(officialDate);
                clickedDate.Show();
            }
        }

        #endregion
    }
}

# Personal Agenda C#

What we need, according to Aref:

- Organize Activities
- Set a deadline for Activity
- Generate report of what is due today
- Generate report of overdue activities
- Save activities to a file, with the ability to open them again


## Task Class:

- Name (Can't be Null) - Pass 1 Done
- Due Date (Can't be Null) - Pass 1 Done
- Notes (Can be Null) - Pass 1 Done
- Completion Status (T/F) - Pass 1 Done
- Repeat Status - Pass 1 Done
- Method: Update Task
- Method: Complete Task
- Method: Repeat Task
    - What days should be repeated?


## Agenda Class:

- Collection of Tasks (Can be Null)
    - Should be accessible from a file
- Current Day (Can't be Null)
- Array of Today's Tasks
- Array of Overdue Tasks
- Array of Complete Tasks
    - Task Order: Complete, Today, Overdue.
- Method: Create New Task
- Method: Generate Today's Tasks
    - Method: Generate Today and Future Tasks
- Method: Generate Overdue Tasks
- Method: Generate Completed Tasks
- Method: Generate Repeatable Tasks
- Method: Retrieve from File
- Method: Save to File


## Ideas:

- I might want to save tasks via serialization for easy moving
- It would be nice if there was a visual strikethrough for completed tasks
- All above I feel makes a functional app. We'll work on that, then go through other ideas.

## Future Features:

- Calendar view, so you can see what is due when
- Notes for a day, possibly link them to specific tasks
- Diary/Journal
- Dark/Light Mode toggle
- Holidays/Important Dates
    - User Customizable Dates
- 



## Year Class:
- int year
- bool IsLeapYear
- DateTimeArray Jan = [31]
    - DateTimes in each box
- repeat for each month
- feb's depends on leap year

- Mega-Array for all days


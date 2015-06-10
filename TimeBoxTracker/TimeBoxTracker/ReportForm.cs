/*
 * Created by SharpDevelop.
 * User: joseantonio
 * Date: 10/05/2015
 * Time: 13:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using TimeBoxTracker.BusinessRules;
using TimeBoxTracker.Entities;

namespace TimeBoxTracker
{
	/// <summary>
	/// Description of ReportForm.
	/// </summary>
	public partial class ReportForm : Form
	{
		MonthView monthView;
		Calendar calendar;
		TimeBox timeBox;
		
		public ReportForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			monthView = new MonthView();
			monthView.Dock = DockStyle.Fill;
			monthView.SelectionMode = MonthView.MonthViewSelection.Day;
			splitContainer2.Panel1.Controls.Add(monthView);
			
			monthView.SelectionChanged += monthView_SelectionChanged;
			
			calendar = new Calendar();
			calendar.Dock = DockStyle.Fill;
			calendar.AllowItemEdit = false;
			calendar.AllowItemResize = false;
			calendar.ItemSelected += calendar_ItemSelected;
			
			splitContainer1.Panel2.Controls.Add(calendar);
			
			btnSave.Enabled = false;
			
			LoadTimeBoxesForDay(DateTime.Today);
		}

		void monthView_SelectionChanged(object sender, EventArgs e)
		{
			LoadTimeBoxesForDay(monthView.SelectionStart);
		}
		
		void LoadTimeBoxesForDay(DateTime day)
		{
			DateTime dateStart = day.Date;
			DateTime dateEnd = day.Date.AddHours(23).AddMinutes(59);
			calendar.SetViewRange(dateStart, dateEnd);
			IList<TimeBox> timeBoxes = TimeboxLogic.GetByDateTimeRange(dateStart, dateEnd);
			foreach(TimeBox timeBox in timeBoxes)
			{
				Task task = TaskLogic.GetById(timeBox.TaskId);
				Project project = ProjectLogic.GetById(task.ProjectId);
				string itemTitle = task.Name + " (" + project.Name + ")";
				CalendarItem timeBoxCalendarItem = new CalendarItem(calendar, timeBox.StartTime, timeBox.EndTime, itemTitle);
				timeBoxCalendarItem.Tag = timeBox;
				calendar.Items.Add(timeBoxCalendarItem);
			}
			if (timeBoxes.Count > 0)
			{
				calendar.EnsureVisible(calendar.GetTimeUnit(timeBoxes[0].EndTime));
			}
			calendar.Focus();
		}

		void calendar_ItemSelected(object sender, CalendarItemEventArgs e)
		{
			timeBox = e.Item.Tag as TimeBox;
			Task task = TaskLogic.GetById(timeBox.TaskId);
			Project project = ProjectLogic.GetById(task.ProjectId);
			projectSelector.Project = project;
			taskSelector.Project = project;
			taskSelector.Task = task;
			txtStartTime.Text = timeBox.StartTime.ToString("HH:mm");
			txtEndTime.Text = timeBox.EndTime.ToString("HH:mm");
			btnSave.Enabled = true;
		}
		
		void BtnSaveClick(object sender, EventArgs e)
		{
			timeBox.TaskId = taskSelector.Task.Id;
			TimeSpan newStartTime;
			if (TimeSpan.TryParse(txtStartTime.Text, out newStartTime))
			{
				timeBox.StartTime = calendar.ViewStart.Add(newStartTime);
			}
			TimeSpan newEndTime;
			if (TimeSpan.TryParse(txtEndTime.Text, out newEndTime))
			{
				timeBox.EndTime = calendar.ViewStart.Add(newEndTime);
			}
			TimeboxLogic.Update(timeBox);
			btnSave.Enabled = false;
			LoadTimeBoxesForDay(calendar.ViewStart);
		}
		
		void ProjectSelectorSelectionChanged(object sender, EventArgs e)
		{
			taskSelector.Project = projectSelector.Project;
			btnSave.Enabled = taskSelector.Task != null;
		}
		
		void TaskSelectorSelectionChanged(object sender, EventArgs e)
		{
			btnSave.Enabled = taskSelector.Task != null;
		}
	}
}

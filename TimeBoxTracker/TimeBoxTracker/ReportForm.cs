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
			calendar.ItemCreated += calendar_ItemCreated;
			calendar.ItemSelected += calendar_ItemSelected;
			calendar.ItemDeleting += calendar_ItemDeleting;
			calendar.ItemDeleted += calendar_ItemDeleted;
			
			splitContainer1.Panel2.Controls.Add(calendar);
			
			btnSave.Enabled = false;
			
			LoadTimeBoxesForDay(DateTime.Today);
			ShowTimeBoxDetails();
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
			IList<TimeBox> timeBoxes = TimeBoxLogic.GetByDateTimeRange(dateStart, dateEnd);
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

		void calendar_ItemCreated(object sender, CalendarItemCancelEventArgs e)
		{
			timeBox = new TimeBox();
			timeBox.StartTime = e.Item.StartDate;
			timeBox.EndTime = e.Item.EndDate;
			e.Item.Tag = timeBox;
		}
		
		void calendar_ItemDeleting(object sender, CalendarItemCancelEventArgs e)
		{
			e.Cancel =
				MessageBox.Show("Are you sure you want to delete this timebox?", "TimeBoxTracker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
		}

		void calendar_ItemDeleted(object sender, CalendarItemEventArgs e)
		{
			if (timeBox != null)
			{
				TimeBoxLogic.Delete(timeBox);
				timeBox = null;
				ShowTimeBoxDetails();
			}
		}
		
		void calendar_ItemSelected(object sender, CalendarItemEventArgs e)
		{
			timeBox = e.Item.Tag as TimeBox;
			ShowTimeBoxDetails();
		}
		
		void BtnSaveClick(object sender, EventArgs e)
		{
			bool validationOK = true;
			if (taskSelector.Task != null)
			{
				timeBox.TaskId = taskSelector.Task.Id;
			}
			else
			{
				validationOK = false;
			}
			TimeSpan newStartTime;
			if (TimeSpan.TryParse(txtStartTime.Text, out newStartTime))
			{
				timeBox.StartTime = calendar.ViewStart.Add(newStartTime);
			}
			else
			{
				validationOK = false;
			}
			TimeSpan newEndTime;
			if (TimeSpan.TryParse(txtEndTime.Text, out newEndTime))
			{
				timeBox.EndTime = calendar.ViewStart.Add(newEndTime);
			}
			else
			{
				validationOK = false;
			}
			if (validationOK)
			{
				if (timeBox.Id == 0)
				{
					TimeBoxLogic.Insert(timeBox);
				}
				else
				{
					TimeBoxLogic.Update(timeBox);
				}
				btnSave.Enabled = false;
				LoadTimeBoxesForDay(calendar.ViewStart);
			}
			else
			{
				MessageBox.Show("Some of the values are not correct", "TimeBoxTracker", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
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
		
		void ShowTimeBoxDetails()
		{
			if (timeBox != null)
			{
				Task task = TaskLogic.GetById(timeBox.TaskId);
				Project project = null;
				if (task != null)
				{
					project = ProjectLogic.GetById(task.ProjectId);
					projectSelector.Project = project;
					taskSelector.Project = project;
					taskSelector.Task = task;
				}
				projectSelector.ReadOnly = false;
				taskSelector.ReadOnly = false;
				txtStartTime.Text = timeBox.StartTime.ToString("HH:mm");
				txtStartTime.ReadOnly = false;
				txtEndTime.Text = timeBox.EndTime.ToString("HH:mm");
				txtEndTime.ReadOnly = false;
				btnSave.Enabled = true;
			}
			else
			{
				projectSelector.Project = null;
				projectSelector.ReadOnly = true;
				taskSelector.Project = null;
				taskSelector.ReadOnly = true;
				txtStartTime.Text = String.Empty;
				txtStartTime.ReadOnly = true;
				txtEndTime.Text = String.Empty;
				txtEndTime.ReadOnly = true;
				btnSave.Enabled = false;
			}
		}
	}
}

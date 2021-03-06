﻿/*
 * Created by SharpDevelop.
 * User: joseantonio
 * Date: 26/04/2015
 * Time: 11:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using TimeBoxTracker.Entities;
using TimeBoxTracker.BusinessRules;
using System.ComponentModel;

namespace TimeBoxTracker
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private TaskTimer TaskTimer { get; set; }
		
		private TimeBox TimeBox { get; set; }
		
		public MainForm()
		{
			Application.ThreadException += Application_ThreadException;
			AppDomain.CurrentDomain.UnhandledException += AppDomain_CurrentDomain_UnhandledException;
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			TaskTimer = new TaskTimer();
			TaskTimer.Tick += TaskTimer_Tick;
			TaskTimer.Started += TaskTimer_Started;
			TaskTimer.Stopped += TaskTimer_Stopped;
			TaskTimer.Resumed += TaskTimer_Resumed;
			TaskTimer.Paused += TaskTimer_Paused;
			
			Reset();
		}

		void AppDomain_CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			BeginInvoke(new MethodInvoker(() => MessageBox.Show(e.ExceptionObject.ToString())));
		}
		
		void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			if (TaskTimer.IsRunning)
			{
				TaskTimer.Stop();
			}
			MessageBox.Show(e.Exception.ToString());
		}
		
		private void Reset()
		{
			TaskTimer.RemainingTime = TimeSpan.FromMinutes(25);
			TaskTimer.ElapsedTime = TimeSpan.FromSeconds(0);
			Refresh(TaskTimer.RemainingTime, TaskTimer.ElapsedTime);
		}
		
		private static string TimeSpanToString(TimeSpan timeSpan)
		{
			return timeSpan.Minutes.ToString().PadLeft(2,'0') + ":" + timeSpan.Seconds.ToString().PadLeft(2,'0');
		}
		
		private static TimeSpan StringToTimeSpan(string timeSpanString, TimeSpan defaultValue)
		{
			TimeSpan parsedTime;
			if (TimeSpan.TryParse("0:" + timeSpanString, out parsedTime))
			{
				return parsedTime;
			}
			return defaultValue;
		}
		
		private void Refresh(TimeSpan remainingTime, TimeSpan elapsedTime)
		{
			txtRemainingTime.Text = TimeSpanToString(remainingTime);
			txtElapsedTime.Text = TimeSpanToString(elapsedTime);
			Icon = TimerIconGenerator.Create(remainingTime);
		}

		void TaskTimer_Paused(object sender, EventArgs e)
		{
			BeginInvoke(new MethodInvoker(
				delegate()
				{
					btnPauseResume.Text = "Resume";
					EnableTimeBoxEdition();
				}));
		}
		
		void TaskTimer_Resumed(object sender, EventArgs e)
		{
			BeginInvoke(new MethodInvoker(
				delegate()
				{
					btnPauseResume.Text = "Pause";
					DisableTimeBoxEdition();
				}));
			TimeBox.TaskId = taskSelector.Task.Id;
		}
		
		void TaskTimer_Stopped(object sender, EventArgs e)
		{
			BeginInvoke(new MethodInvoker(
				delegate()
				{
					btnStartStop.Text = "Start";
					btnPauseResume.Enabled = false;
					EnableTimeBoxEdition();
					Reset();
				}));
			SaveCurrentTimebox();
			TimeBox = null;
		}
		
		void SaveCurrentTimebox()
		{
			TimeBox.EndTime = DateTime.Now;
			TimeBox.StartTime = TimeBox.EndTime.Subtract(TaskTimer.ElapsedTime);
			TimeBox.Pauses = TaskTimer.Pauses;
			TimeBoxLogic.Insert(TimeBox);		
		}
		
		void TaskTimer_Started(object sender, EventArgs e)
		{
			BeginInvoke(new MethodInvoker(
				delegate()
				{
				    btnStartStop.Text = "Stop";
				    btnPauseResume.Enabled = true;
				    DisableTimeBoxEdition();
				}));
			TimeBox newTimeBox = new TimeBox();
			newTimeBox.TaskId = taskSelector.Task.Id;
			newTimeBox.StartTime = DateTime.Now;
			TimeBox = newTimeBox;
		}
		
		void EnableTimeBoxEdition()
		{
			txtRemainingTime.ReadOnly = false;
			txtElapsedTime.ReadOnly = false;
			projectSelector.ReadOnly = false;
			taskSelector.ReadOnly = false;
		}
		
		void DisableTimeBoxEdition()
		{
			txtRemainingTime.ReadOnly = true;
			txtElapsedTime.ReadOnly = true;
			projectSelector.ReadOnly = true;
			taskSelector.ReadOnly = true;
		}
		
		void TaskTimer_Tick(object sender, TaskTimerTickEventArgs e)
		{
			BeginInvoke(new MethodInvoker(() => Refresh(e.RemainingTime, e.ElapsedTime)));
		}
		
		void BtnStartClick(object sender, EventArgs e)
		{
			if (TaskTimer.State == TaskTimerState.Stopped)
			{
				TaskTimer.RemainingTime = StringToTimeSpan(txtRemainingTime.Text, TaskTimer.RemainingTime);
				TaskTimer.ElapsedTime = StringToTimeSpan(txtElapsedTime.Text, TaskTimer.ElapsedTime);
				Refresh(TaskTimer.RemainingTime, TaskTimer.ElapsedTime);
				TaskTimer.Start();
			}
			else
			{
				TaskTimer.Stop();
			}
		}

		void BtnPauseClick(object sender, EventArgs e)
		{
			if (TaskTimer.State == TaskTimerState.Started)
			{
				TaskTimer.Pause();
			}
			else
			{
				TaskTimer.RemainingTime = StringToTimeSpan(txtRemainingTime.Text, TaskTimer.RemainingTime);
				TaskTimer.ElapsedTime = StringToTimeSpan(txtElapsedTime.Text, TaskTimer.ElapsedTime);
				Refresh(TaskTimer.RemainingTime, TaskTimer.ElapsedTime);
				TaskTimer.Resume();
			}
		}
		
		void BtnReportClick(object sender, EventArgs e)
		{
			ReportForm reportForm = new ReportForm();
			reportForm.Show();
		}
		
		void ProjectSelectorSelectionChanged(object sender, EventArgs e)
		{
			taskSelector.Project = projectSelector.Project;
		}
		
		void TaskSelectorSelectionChanged(object sender, EventArgs e)
		{
			btnStartStop.Enabled = taskSelector.Task != null;
			btnPauseResume.Enabled = TimeBox != null && taskSelector.Task != null;
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{	
			if (TimeBox != null)
			{
				e.Cancel = (MessageBox.Show("Are you sure you want to stop the current timebox?", "TimeboxTracker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No);
			}
		}
		
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			if (TimeBox != null)
			{
				SaveCurrentTimebox();
			}
		}
	}
}

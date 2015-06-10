/*
 * Created by SharpDevelop.
 * User: joseantonio
 * Date: 29/05/2015
 * Time: 20:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using TimeBoxTracker.Entities;
using TimeBoxTracker.BusinessRules;
using System.Windows.Forms;

namespace TimeBoxTracker
{
	/// <summary>
	/// Description of TaskSelector.
	/// </summary>
	public partial class TaskSelector : ItemSelector<Task>
	{
		public TaskSelector()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			btnChangeSelection.Enabled = Enabled;
			EnabledChanged += TaskSelector_EnabledChanged;
		}

		void TaskSelector_EnabledChanged(object sender, EventArgs e)
		{
			btnChangeSelection.Enabled = Enabled;
		}
		
		private Task task;
		
		public Task Task
		{
			get
			{
				return task;
			}
			set
			{
				if (value != null)
				{
					if (Project == null || value.ProjectId != Project.Id)
					{
						throw new InvalidOperationException("The selected task must belong to the selected project");
					}
					lblSelection.Text = value.Name;
				}
				else
				{
					lblSelection.Text = String.Empty;
				}
				task = value;
				if (SelectionChanged != null)
				{
					SelectionChanged(this, EventArgs.Empty);
				}
			}
		}
		
		private Project project;
		
		public Project Project 
		{ 
			get
			{
				return project;
			}
			set
			{
				if (project != value)
				{
					project = value;
					Task = null;
				}
			}
		}
		
		void BtnChangeSelectionClick(object sender, EventArgs e)
		{
			if (Project != null)
			{
				ShowDialog(Task, TaskLogic.GetByProjectId(Project.Id));
			}
		}
		
		protected override void DeleteItem(Task item)
		{
			TaskLogic.Delete(item);
		}
		
		protected override void UpdateItem(Task item)
		{
			TaskLogic.Update(item);
		}
		
		protected override void InsertItem(Task item)
		{
			item.ProjectId = Project.Id;
			TaskLogic.Insert(item);
		}
		
		protected override void SetNewSelectedItem(Task item)
		{
			Task = item;
		}
		
		public event EventHandler SelectionChanged;
	}
}

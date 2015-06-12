/*
 * Created by SharpDevelop.
 * User: joseantonio
 * Date: 29/05/2015
 * Time: 18:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TimeBoxTracker.Entities;
using TimeBoxTracker.BusinessRules;

namespace TimeBoxTracker
{
	/// <summary>
	/// Description of ProjectSelector.
	/// </summary>
	public partial class ProjectSelector : ItemSelector<Project>
	{
		public ProjectSelector()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		private bool readOnly = false;
		
		public bool ReadOnly
		{
			get
			{
				return readOnly;
			}
			set
			{
				readOnly = value;
				btnChangeSelection.Visible = !readOnly;
				lblSelection.Dock = readOnly ? DockStyle.Fill : DockStyle.None;
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
				project = value;
				if (project != null)
				{
					lblSelection.Text = project.Name;
				}
				else
				{
					lblSelection.Text = String.Empty;
				}
				if (SelectionChanged != null)
				{
					SelectionChanged(this, EventArgs.Empty);
				}
			}
		}
		
		void BtnChangeSelectionClick(object sender, EventArgs e)
		{
			ShowDialog(Project, ProjectLogic.GetAll());
		}
		
		protected override void DeleteItem(Project item)
		{
			ProjectLogic.Delete(item);
		}
		
		protected override void UpdateItem(Project item)
		{
			ProjectLogic.Update(item);
		}
		
		protected override void InsertItem(Project item)
		{
			ProjectLogic.Insert(item);
		}
		
		protected override void SetNewSelectedItem(Project item)
		{
			Project = item;
		}
		
		public event EventHandler SelectionChanged;
	}
}

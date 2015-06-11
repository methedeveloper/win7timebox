/*
 * Created by SharpDevelop.
 * User: joseantonio
 * Date: 10/05/2015
 * Time: 13:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TimeBoxTracker
{
	partial class ReportForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.MaskedTextBox txtEndTime;
		private System.Windows.Forms.MaskedTextBox txtStartTime;
		private System.Windows.Forms.Button btnSave;
		private TimeBoxTracker.ProjectSelector projectSelector;
		private TimeBoxTracker.TaskSelector taskSelector;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		private void InitializeComponent()
		{
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.label2 = new System.Windows.Forms.Label();
			this.projectSelector = new TimeBoxTracker.ProjectSelector();
			this.label1 = new System.Windows.Forms.Label();
			this.taskSelector = new TimeBoxTracker.TaskSelector();
			this.label3 = new System.Windows.Forms.Label();
			this.txtStartTime = new System.Windows.Forms.MaskedTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtEndTime = new System.Windows.Forms.MaskedTextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(1032, 590);
			this.splitContainer1.SplitterDistance = 255;
			this.splitContainer1.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.label2);
			this.splitContainer2.Panel2.Controls.Add(this.projectSelector);
			this.splitContainer2.Panel2.Controls.Add(this.label1);
			this.splitContainer2.Panel2.Controls.Add(this.taskSelector);
			this.splitContainer2.Panel2.Controls.Add(this.label3);
			this.splitContainer2.Panel2.Controls.Add(this.txtStartTime);
			this.splitContainer2.Panel2.Controls.Add(this.label4);
			this.splitContainer2.Panel2.Controls.Add(this.txtEndTime);
			this.splitContainer2.Panel2.Controls.Add(this.btnSave);
			this.splitContainer2.Size = new System.Drawing.Size(255, 590);
			this.splitContainer2.SplitterDistance = 368;
			this.splitContainer2.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 30);
			this.label2.TabIndex = 16;
			this.label2.Text = "Project:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// projectSelector
			// 
			this.projectSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.projectSelector.Location = new System.Drawing.Point(96, 3);
			this.projectSelector.Name = "projectSelector";
			this.projectSelector.Project = null;
			this.projectSelector.Size = new System.Drawing.Size(156, 24);
			this.projectSelector.TabIndex = 2;
			this.projectSelector.SelectionChanged += new System.EventHandler(this.ProjectSelectorSelectionChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 30);
			this.label1.TabIndex = 17;
			this.label1.Text = "Task:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// taskSelector
			// 
			this.taskSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.taskSelector.Location = new System.Drawing.Point(96, 33);
			this.taskSelector.Name = "taskSelector";
			this.taskSelector.Project = null;
			this.taskSelector.Size = new System.Drawing.Size(156, 24);
			this.taskSelector.TabIndex = 3;
			this.taskSelector.Task = null;
			this.taskSelector.SelectionChanged += new System.EventHandler(this.TaskSelectorSelectionChanged);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(3, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 26);
			this.label3.TabIndex = 18;
			this.label3.Text = "Start:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtStartTime
			// 
			this.txtStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtStartTime.Location = new System.Drawing.Point(96, 63);
			this.txtStartTime.Mask = "00:00";
			this.txtStartTime.Name = "txtStartTime";
			this.txtStartTime.Size = new System.Drawing.Size(156, 20);
			this.txtStartTime.TabIndex = 4;
			this.txtStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtStartTime.ValidatingType = typeof(System.DateTime);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(3, 86);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(87, 26);
			this.label4.TabIndex = 19;
			this.label4.Text = "End:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEndTime
			// 
			this.txtEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtEndTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtEndTime.Location = new System.Drawing.Point(96, 89);
			this.txtEndTime.Mask = "00:00";
			this.txtEndTime.Name = "txtEndTime";
			this.txtEndTime.Size = new System.Drawing.Size(156, 20);
			this.txtEndTime.TabIndex = 5;
			this.txtEndTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtEndTime.ValidatingType = typeof(System.DateTime);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Location = new System.Drawing.Point(177, 115);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 6;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
			// 
			// ReportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1032, 590);
			this.Controls.Add(this.splitContainer1);
			this.Icon = global::TimeBoxTracker.Properties.Resources.analog_clock_148148_640;
			this.Name = "ReportForm";
			this.Text = "ReportForm";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			this.splitContainer2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}

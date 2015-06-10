/*
 * Created by SharpDevelop.
 * User: joseantonio
 * Date: 26/04/2015
 * Time: 11:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TimeBoxTracker
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btnStartStop;
		private System.Windows.Forms.Button btnPauseResume;
		private System.Windows.Forms.MaskedTextBox txtRemainingTime;
		
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
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnStartStop = new System.Windows.Forms.Button();
			this.btnPauseResume = new System.Windows.Forms.Button();
			this.txtRemainingTime = new System.Windows.Forms.MaskedTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnReport = new System.Windows.Forms.Button();
			this.txtElapsedTime = new System.Windows.Forms.MaskedTextBox();
			this.projectSelector = new TimeBoxTracker.ProjectSelector();
			this.taskSelector = new TimeBoxTracker.TaskSelector();
			this.SuspendLayout();
			// 
			// btnStartStop
			// 
			this.btnStartStop.Enabled = false;
			this.btnStartStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnStartStop.Location = new System.Drawing.Point(350, 12);
			this.btnStartStop.Name = "btnStartStop";
			this.btnStartStop.Size = new System.Drawing.Size(75, 23);
			this.btnStartStop.TabIndex = 5;
			this.btnStartStop.Text = "Start";
			this.btnStartStop.UseVisualStyleBackColor = true;
			this.btnStartStop.Click += new System.EventHandler(this.BtnStartClick);
			// 
			// btnPauseResume
			// 
			this.btnPauseResume.Enabled = false;
			this.btnPauseResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPauseResume.Location = new System.Drawing.Point(350, 41);
			this.btnPauseResume.Name = "btnPauseResume";
			this.btnPauseResume.Size = new System.Drawing.Size(75, 23);
			this.btnPauseResume.TabIndex = 6;
			this.btnPauseResume.Text = "Pause";
			this.btnPauseResume.UseVisualStyleBackColor = true;
			this.btnPauseResume.Click += new System.EventHandler(this.BtnPauseClick);
			// 
			// txtRemainingTime
			// 
			this.txtRemainingTime.BackColor = System.Drawing.SystemColors.Control;
			this.txtRemainingTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtRemainingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 95F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtRemainingTime.Location = new System.Drawing.Point(12, 13);
			this.txtRemainingTime.Mask = "00:00";
			this.txtRemainingTime.Name = "txtRemainingTime";
			this.txtRemainingTime.Size = new System.Drawing.Size(330, 144);
			this.txtRemainingTime.TabIndex = 1;
			this.txtRemainingTime.ValidatingType = typeof(System.DateTime);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 212);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 23);
			this.label1.TabIndex = 14;
			this.label1.Text = "Task:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 185);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 23);
			this.label2.TabIndex = 15;
			this.label2.Text = "Project:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 160);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 23);
			this.label3.TabIndex = 16;
			this.label3.Text = "Elapsed time:";
			// 
			// btnReport
			// 
			this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnReport.Location = new System.Drawing.Point(350, 237);
			this.btnReport.Name = "btnReport";
			this.btnReport.Size = new System.Drawing.Size(75, 23);
			this.btnReport.TabIndex = 7;
			this.btnReport.Text = "Report";
			this.btnReport.UseVisualStyleBackColor = true;
			this.btnReport.Click += new System.EventHandler(this.BtnReportClick);
			// 
			// txtElapsedTime
			// 
			this.txtElapsedTime.BackColor = System.Drawing.SystemColors.Control;
			this.txtElapsedTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtElapsedTime.Location = new System.Drawing.Point(100, 160);
			this.txtElapsedTime.Mask = "00:00";
			this.txtElapsedTime.Name = "txtElapsedTime";
			this.txtElapsedTime.Size = new System.Drawing.Size(100, 13);
			this.txtElapsedTime.TabIndex = 2;
			this.txtElapsedTime.ValidatingType = typeof(System.DateTime);
			// 
			// projectSelector
			// 
			this.projectSelector.Location = new System.Drawing.Point(97, 185);
			this.projectSelector.Name = "projectSelector";
			this.projectSelector.Project = null;
			this.projectSelector.Size = new System.Drawing.Size(324, 24);
			this.projectSelector.TabIndex = 3;
			this.projectSelector.SelectionChanged += new System.EventHandler(this.ProjectSelectorSelectionChanged);
			// 
			// taskSelector
			// 
			this.taskSelector.Location = new System.Drawing.Point(97, 212);
			this.taskSelector.Name = "taskSelector";
			this.taskSelector.Project = null;
			this.taskSelector.Size = new System.Drawing.Size(328, 24);
			this.taskSelector.TabIndex = 4;
			this.taskSelector.Task = null;
			this.taskSelector.SelectionChanged += new System.EventHandler(this.TaskSelectorSelectionChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(436, 270);
			this.Controls.Add(this.taskSelector);
			this.Controls.Add(this.projectSelector);
			this.Controls.Add(this.txtElapsedTime);
			this.Controls.Add(this.btnReport);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtRemainingTime);
			this.Controls.Add(this.btnPauseResume);
			this.Controls.Add(this.btnStartStop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = global::TimeBoxTracker.Properties.Resources.analog_clock_148148_640;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "TimeBoxTracker";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnReport;
		private System.Windows.Forms.MaskedTextBox txtElapsedTime;
		private TimeBoxTracker.ProjectSelector projectSelector;
		private TimeBoxTracker.TaskSelector taskSelector;
	}
}

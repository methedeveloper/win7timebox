/*
 * Created by SharpDevelop.
 * User: joseantonio
 * Date: 29/05/2015
 * Time: 18:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TimeBoxTracker
{
	partial class ProjectSelector
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label lblSelection;
		private System.Windows.Forms.Button btnChangeSelection;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.lblSelection = new System.Windows.Forms.Label();
			this.btnChangeSelection = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblSelection
			// 
			this.lblSelection.Location = new System.Drawing.Point(32, 0);
			this.lblSelection.Name = "lblSelection";
			this.lblSelection.Size = new System.Drawing.Size(118, 24);
			this.lblSelection.TabIndex = 0;
			this.lblSelection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnChangeSelection
			// 
			this.btnChangeSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnChangeSelection.Location = new System.Drawing.Point(0, 0);
			this.btnChangeSelection.Name = "btnChangeSelection";
			this.btnChangeSelection.Size = new System.Drawing.Size(26, 23);
			this.btnChangeSelection.TabIndex = 1;
			this.btnChangeSelection.Text = "...";
			this.btnChangeSelection.UseVisualStyleBackColor = true;
			this.btnChangeSelection.Click += new System.EventHandler(this.BtnChangeSelectionClick);
			// 
			// ProjectSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnChangeSelection);
			this.Controls.Add(this.lblSelection);
			this.Name = "ProjectSelector";
			this.Size = new System.Drawing.Size(150, 24);
			this.ResumeLayout(false);

		}
	}
}

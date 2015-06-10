namespace TimeBoxTracker
{
	partial class FilteredEditableListBox
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.btnOperation = new System.Windows.Forms.Button();
			this.txtItem = new System.Windows.Forms.TextBox();
			this.lstItems = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanel1.Controls.Add(this.btnOperation, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.txtItem, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.lstItems, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(178, 199);
			this.tableLayoutPanel1.TabIndex = 3;
			// 
			// btnOperation
			// 
			this.btnOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOperation.Location = new System.Drawing.Point(101, 3);
			this.btnOperation.Name = "btnOperation";
			this.btnOperation.Size = new System.Drawing.Size(74, 23);
			this.btnOperation.TabIndex = 4;
			this.btnOperation.Text = "Add";
			this.btnOperation.UseVisualStyleBackColor = true;
			this.btnOperation.Click += new System.EventHandler(this.BtnOperationClick);
			// 
			// txtItem
			// 
			this.txtItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtItem.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtItem.Location = new System.Drawing.Point(3, 3);
			this.txtItem.Name = "txtItem";
			this.txtItem.Size = new System.Drawing.Size(92, 20);
			this.txtItem.TabIndex = 8;
			this.txtItem.TextChanged += new System.EventHandler(this.TxtItemTextChanged);
			this.txtItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtItemKeyUp);
			// 
			// lstItems
			// 
			this.lstItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tableLayoutPanel1.SetColumnSpan(this.lstItems, 2);
			this.lstItems.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstItems.FormattingEnabled = true;
			this.lstItems.Location = new System.Drawing.Point(3, 32);
			this.lstItems.Name = "lstItems";
			this.lstItems.Size = new System.Drawing.Size(172, 164);
			this.lstItems.Sorted = true;
			this.lstItems.TabIndex = 6;
			this.lstItems.SelectedIndexChanged += new System.EventHandler(this.LstItemsSelectedIndexChanged);
			this.lstItems.DoubleClick += new System.EventHandler(this.lstItems_DoubleClick);
			this.lstItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstItems_KeyDown);
			this.lstItems.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstItems_KeyPress);
			// 
			// FilteredEditableListBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "FilteredEditableListBox";
			this.Size = new System.Drawing.Size(178, 199);
			this.Load += new System.EventHandler(this.FilteredEditableListBox_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ListBox lstItems;
		private System.Windows.Forms.Button btnOperation;
		private System.Windows.Forms.TextBox txtItem;

	}
}

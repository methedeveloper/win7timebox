/*
 * Created by SharpDevelop.
 * User: joseantonio
 * Date: 03/06/2015
 * Time: 20:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using TimeBoxTracker;

namespace TimeBoxTracker
{
	/// <summary>
	/// Description of ItemSelector.
	/// </summary>
	public class ItemSelector<T>: UserControl where T: class
	{
		private Form currentSelectionDialog;
		
		protected void ShowDialog(T selectedItem, IList<T> itemList, string dialogTitle)
		{
			using (currentSelectionDialog = new Form())
			{
				currentSelectionDialog.Text = dialogTitle;
				currentSelectionDialog.Icon = Properties.Resources.analog_clock_148148_640;
				FilteredEditableListBox selector = new FilteredEditableListBox();
				selector.Dock = DockStyle.Fill;
				selector.DisplayMember = "Name";
				selector.DataSource = new BindingList<T>(itemList);
				selector.SelectedItem = selectedItem;
				selector.ItemOperation += selector_ItemOperation;
				Button btnCancel = new Button();
				btnCancel.FlatStyle = FlatStyle.Flat;
				btnCancel.Text = "Cancel";
				btnCancel.Click += btnCancel_Click;
				Button btnAccept = new Button();
				btnAccept.FlatStyle = FlatStyle.Flat;
				btnAccept.Text = "OK";
				btnAccept.Click += btnAccept_Click;
				TableLayoutPanel panel = new TableLayoutPanel();
				panel.Dock = DockStyle.Fill;
				panel.RowCount = 2;
				panel.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.Percent, 100));
				panel.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.AutoSize));
				panel.ColumnCount = 1;
				FlowLayoutPanel bottomPanel = new FlowLayoutPanel();
				bottomPanel.AutoSize = true;
				bottomPanel.Dock = DockStyle.Right;
				bottomPanel.FlowDirection = FlowDirection.RightToLeft;
				bottomPanel.Controls.Add(btnCancel);
				bottomPanel.Controls.Add(btnAccept);
				panel.Controls.Add(selector,0,0);
				panel.Controls.Add(bottomPanel,0,1);
				currentSelectionDialog.Controls.Add(panel);
				if (currentSelectionDialog.ShowDialog() == DialogResult.OK)
				{
					SetNewSelectedItem(selector.SelectedItem as T);
				}
				selector.ItemOperation -= selector_ItemOperation;
				btnAccept.Click -= btnAccept_Click;
				btnCancel.Click -= btnCancel_Click;
			}
		}
		
		protected virtual void UpdateItem(T item)
		{
			
		}
		
		protected virtual void InsertItem(T item)
		{
			
		}
		
		protected virtual void DeleteItem(T item)
		{
			
		}
		
		protected virtual void SetNewSelectedItem(T item)
		{
			
		}

		void selector_ItemOperation(object sender, FilteredEditableListBox.ItemOperationEventArgs e)
		{
			switch (e.Operation)
			{
				case FilteredEditableListBox.ItemOperationType.Add:
					InsertItem(e.Item as T);
					break;
				case FilteredEditableListBox.ItemOperationType.Delete:
					DeleteItem(e.Item as T);
					break;
				case FilteredEditableListBox.ItemOperationType.Edit:
					UpdateItem(e.Item as T);
					break;
			}
		}
		
		void btnCancel_Click(object sender, EventArgs args)
		{
			currentSelectionDialog.DialogResult = DialogResult.Cancel;
			currentSelectionDialog.Close();
		}
		
		void btnAccept_Click(object sender, EventArgs args)
		{
			currentSelectionDialog.DialogResult = DialogResult.OK;
			currentSelectionDialog.Close();
		}
	}
}

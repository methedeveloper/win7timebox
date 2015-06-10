using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

namespace TimeBoxTracker
{
	public partial class FilteredEditableListBox : UserControl
	{
		const int delta = 5;
		private System.Windows.Forms.TextBox editBox;
		int itemSelected = -1;
		
		public event EventHandler<ItemOperationEventArgs> ItemOperation;
		
		public FilteredEditableListBox()
		{
			InitializeComponent();
		}

		private IBindingList dataSource;
		
		public IBindingList DataSource
		{
			get { return dataSource; }
			set 
			{ 
				dataSource = value;
				txtItem.Text = String.Empty;
				SetListItemsDataSource();
			}
		}

		public string DisplayMember { get; set; }
		
		public object SelectedItem
		{
			get
			{
				return lstItems.SelectedItem;
			}
			set
			{
				txtItem.Text = value != null ? GetSelectedItemValue(value) : String.Empty;
			}
		}

		private void lstItems_DoubleClick(object sender, System.EventArgs e)
		{
			CreateEditBox(sender);
		}
		
		private void CreateEditBox(object sender)
		{
			itemSelected = lstItems.SelectedIndex;
			Rectangle r = lstItems.GetItemRectangle(itemSelected);
			string itemText = GetSelectedItemValue(lstItems.SelectedItem);

			editBox.Location = new System.Drawing.Point(r.X + delta, r.Y + delta);
			editBox.Size = new System.Drawing.Size(r.Width - 10, r.Height - delta);
			editBox.Show();
			lstItems.Controls.AddRange(new System.Windows.Forms.Control[] { this.editBox });
			editBox.Text = itemText;
			editBox.Focus();
			editBox.SelectAll();
			editBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editBox_EditOver);
			editBox.LostFocus += new System.EventHandler(this.editBox_FocusOver);
		}

		private void editBox_FocusOver(object sender, System.EventArgs e)
		{
			SetSelectedItemValue(lstItems.SelectedItem, editBox.Text);
			editBox.Hide();
		}

		private void editBox_EditOver(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
			{
				SetSelectedItemValue(lstItems.SelectedItem, editBox.Text);
				editBox.Hide();
			}

			if (e.KeyChar == 27)
				editBox.Hide();
		}

		private void lstItems_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				CreateEditBox(sender);
		}

		private void lstItems_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyData == Keys.F2)
				CreateEditBox(sender);
			else if (e.KeyData == Keys.Delete)
				DeleteSelectedItem();
		}

		private void FilteredEditableListBox_Load(object sender, EventArgs e)
		{
			editBox = new System.Windows.Forms.TextBox();
			editBox.Location = new System.Drawing.Point(0, 0);
			editBox.Size = new System.Drawing.Size(0, 0);
			editBox.Hide();
			lstItems.Controls.AddRange(new System.Windows.Forms.Control[] { this.editBox });
			editBox.Text = String.Empty;
			editBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editBox_EditOver);
			editBox.LostFocus += new System.EventHandler(this.editBox_FocusOver);
			editBox.BorderStyle = BorderStyle.FixedSingle;
		}
		
		private string GetSelectedItemValue(object selectedItem)
		{
			if (selectedItem != null)
			{
				return selectedItem.GetType().GetProperty(DisplayMember).GetValue(selectedItem, null) as string;
			}
			return null;
		}
		
		private void SetSelectedItemValue(object selectedItem, string value)
		{
			string oldValue = GetSelectedItemValue(selectedItem);
			if (selectedItem != null && oldValue != value)
			{
				selectedItem.GetType().GetProperty(DisplayMember).SetValue(selectedItem, value, null);
				txtItem.Text = GetSelectedItemValue(selectedItem);
				SetListItemsDataSource();
				OnItemOperation(selectedItem, ItemOperationType.Edit);
			}
		}
		
		void BtnOperationClick(object sender, EventArgs e)
		{
			DoOperation();
		}
		
		void DoOperation()
		{
			if (btnOperation.Text == "Add")
			{
				AddNewItem();
			}
			else if (btnOperation.Text == "Delete")
			{
				DeleteSelectedItem();
			}			
		}
		
		void AddNewItem()
		{
			object itemToAdd = DataSource.AddNew();
			SetSelectedItemValue(itemToAdd, txtItem.Text);
			SetListItemsDataSource();
			OnItemOperation(itemToAdd, ItemOperationType.Add);		
		}
		
		void DeleteSelectedItem()
		{
			object itemToDelete = lstItems.SelectedItem;
			DataSource.Remove(itemToDelete);
			txtItem.Text = GetSelectedItemValue(lstItems.SelectedItem);
			SetListItemsDataSource();
			OnItemOperation(itemToDelete, ItemOperationType.Delete);
		}
		
		void OnItemOperation(object item, ItemOperationType operation)
		{
			if (ItemOperation != null)
			{
				ItemOperation(this, new ItemOperationEventArgs(item, operation));
			}				
		}
		
		void LstItemsSelectedIndexChanged(object sender, EventArgs e)
		{
			if (!txtItem.Focused)
			{
				txtItem.Text = GetSelectedItemValue(lstItems.SelectedItem);
			}
			OnItemOperation(lstItems.SelectedItem, ItemOperationType.Select);
		}
		
		protected override void OnEnabledChanged(EventArgs e)
		{
			txtItem.Enabled = Enabled;
			lstItems.Enabled = Enabled;
			btnOperation.Enabled = Enabled;
			base.OnEnabledChanged(e);
		}
		
		void SetListItemsDataSource()
		{
			if (!String.IsNullOrEmpty(txtItem.Text))
			{
				var q = from object item in DataSource
					where GetSelectedItemValue(item).StartsWith(txtItem.Text)
					select item;
				lstItems.DataSource = q.ToList();
			}
			else
			{
				lstItems.DataSource = DataSource;
			}
			lstItems.DisplayMember = DisplayMember;
			if (GetSelectedItemValue(lstItems.SelectedItem) != txtItem.Text)
				lstItems.SelectedItem = null;
		}
		
		void TxtItemKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter)
			{
				SetListItemsDataSource();
			}
			else
			{
				DoOperation();
			}
		}
		
		void TxtItemTextChanged(object sender, EventArgs e)
		{
			btnOperation.Enabled = !String.IsNullOrEmpty(txtItem.Text);
			btnOperation.Text = GetSelectedItemValue(lstItems.SelectedItem) == txtItem.Text ? "Delete" : "Add";
		}

		public class ItemOperationEventArgs: EventArgs
		{
			public object Item { get; private set; }
			public ItemOperationType Operation { get; private set; }
			
			public ItemOperationEventArgs(object item, ItemOperationType operation)
			{
				Item = item;
				Operation = operation;
			}
		}
		
		public enum ItemOperationType
		{
			Add, Edit, Delete, Select	
		}
	}
}

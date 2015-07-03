/*
 * Created by SharpDevelop.
 * User: JoseAA
 * Date: 28/04/2015
 * Time: 18:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TimeBoxTracker.Entities
{
	/// <summary>
	/// Description of TimeBox.
	/// </summary>
	public class TimeBox: Entity
	{
		private int id;
		public int Id 
		{ 
			get
			{
				return id;
			}
			set
			{
				if (id != value)
				{
					EntityState = EntityState.Dirty;
					id = value;
					OnPropertyChanged(this, "Id");
				}
			}
		}
		
		private DateTime startTime;
		public DateTime StartTime 
		{ 
			get
			{
				return startTime;
			}
			set
			{
				if (startTime != value)
				{
					EntityState = EntityState.Dirty;
					startTime = value;
					OnPropertyChanged(this, "StartTime");
				}
			}
		}
			
		private DateTime endTime;
		public DateTime EndTime 
		{ 
			get
			{
				return endTime;
			}
			set
			{
				if (endTime != value)
				{
					EntityState = EntityState.Dirty;
					endTime = value;
					OnPropertyChanged(this, "EndTime");
				}
			}
		}
		
		private int pauses;
		public int Pauses 
		{ 
			get
			{
				return pauses;
			}
			set
			{
				if (pauses != value)
				{
					EntityState = EntityState.Dirty;
					pauses = value;
					OnPropertyChanged(this, "Pauses");
				}
			}
		}
		
		private int taskId;
		public int TaskId 
		{ 
			get
			{
				return taskId;
			}
			set
			{
				if (taskId != value)
				{
					EntityState = EntityState.Dirty;
					taskId = value;
					OnPropertyChanged(this, "TaskId");
				}
			}
		}

		#region Equals and GetHashCode implementation
		
		public override bool Equals(object obj)
		{
			TimeBox other = obj as TimeBox;
				if (other == null)
					return false;
				return this.id == other.id;
		}

		public override int GetHashCode()
		{
			return id.GetHashCode();
		}

		#endregion
	}
}

/*
 * Created by SharpDevelop.
 * User: JoseAA
 * Date: 28/04/2015
 * Time: 18:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TimeBoxTracker.Entities
{
	/// <summary>
	/// Description of Task.
	/// </summary>
	public class Task: Entity
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
		
		private string name;
		public string Name
		{ 
			get
			{
				return name;
			}
			set
			{
				if (name != value)
				{
					EntityState = EntityState.Dirty;
					name = value;
					OnPropertyChanged(this, "Name");
				}
			}
		}
	
		private int projectId;
		public int ProjectId
		{ 
			get
			{
				return projectId;
			}
			set
			{
				if (projectId != value)
				{
					EntityState = EntityState.Dirty;
					projectId = value;
					OnPropertyChanged(this, "ProjectId");
				}
			}
		}

	}
}

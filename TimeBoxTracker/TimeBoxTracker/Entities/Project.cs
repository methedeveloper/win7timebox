﻿/*
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
	/// Description of Project.
	/// </summary>
	public class Project: Entity
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
		
		#region Equals and GetHashCode implementation
		
		public override bool Equals(object obj)
		{
			Project other = obj as Project;
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

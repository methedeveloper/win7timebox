/*
 * Created by SharpDevelop.
 * User: joseantonio
 * Date: 01/05/2015
 * Time: 19:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;

namespace TimeBoxTracker.Entities
{
	/// <summary>
	/// Description of Entity.
	/// </summary>
	public class Entity: INotifyPropertyChanged
	{
		public EntityState EntityState { get; set; }
		
		public Entity()
		{
			EntityState = EntityState.UpToDate;
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
 
        protected void OnPropertyChanged(object sender,string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender,new PropertyChangedEventArgs(propertyName));
            }
        }

	}
	
	public enum EntityState
	{
		New, Dirty, UpToDate, Deleted
	}
}

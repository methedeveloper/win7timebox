/*
 * Created by SharpDevelop.
 * User: joseantonio
 * Date: 01/05/2015
 * Time: 19:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Collections.Generic;
using TimeBoxTracker.Entities;

namespace TimeBoxTracker.BusinessRules
{
	/// <summary>
	/// Description of TimeBoxLogic.
	/// </summary>
	public static class TimeBoxLogic
	{
		public static void Insert(TimeBox timeBox)
		{
			using(var connection = DataAccessLayer.GetConnection())
			{
				connection.Open();
				using (IDbTransaction transaction = connection.BeginTransaction())
				{
					string insertSQL = 
						String.Format("insert into timebox (starttime, endtime, pauses, id_task) values (strftime('%s','{0}'), strftime('%s','{1}'), {2}, {3})", 
						              timeBox.StartTime.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"),
						              timeBox.EndTime.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"),
						              timeBox.Pauses,
						              timeBox.TaskId);
					DataAccessLayer.ExecuteNonQuery(insertSQL, connection, transaction);
					timeBox.Id = Convert.ToInt32(DataAccessLayer.ExecuteScalar("select last_insert_rowid()", connection, transaction));
					transaction.Commit();
					timeBox.EntityState = EntityState.UpToDate;
				}
			}
		}
		
		public static void Delete(TimeBox timeBox)
		{
			string deleteSQL = String.Format("delete from timebox where id={0}", timeBox.Id);
			DataAccessLayer.ExecuteNonQuery(deleteSQL);
			timeBox.EntityState = EntityState.Deleted;
		}
		
		public static void Update(TimeBox timeBox)
		{
			string updateSQL = 
				String.Format("update timebox set starttime=strftime('%s','{0}'), endtime=strftime('%s','{1}'), pauses={2}, id_task={3} where id={4}", 
							  timeBox.StartTime.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"),
						      timeBox.EndTime.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"),
						      timeBox.Pauses,
						      timeBox.TaskId, 
				              timeBox.Id);
			DataAccessLayer.ExecuteNonQuery(updateSQL);
			timeBox.EntityState = EntityState.UpToDate;
		}
		
		public static IList<TimeBox> GetByDateTimeRange(DateTime startRange, DateTime endRange)
		{
			string selectSQL = String.Format("select id, datetime(starttime, 'unixepoch') starttime, datetime(endtime, 'unixepoch') endtime, pauses, id_task from timebox where starttime>=strftime('%s','{0}') and endtime<=strftime('%s','{1}')", 
			                                startRange.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"),
			                                endRange.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"));
			return DataAccessLayer.ExecuteReader<TimeBox>(selectSQL, GetTimeBoxFromReader);
		}
		
		private static TimeBox GetTimeBoxFromReader(IDataReader reader)
		{
			TimeBox timeBox = new TimeBox();
			timeBox.Id = Convert.ToInt32(reader["id"]);
			timeBox.StartTime = Convert.ToDateTime(reader["starttime"]).ToLocalTime();
			timeBox.EndTime = Convert.ToDateTime(reader["endtime"]).ToLocalTime();
			timeBox.Pauses = Convert.ToInt32(reader["pauses"]);
			timeBox.TaskId = Convert.ToInt32(reader["id_task"]);
			return timeBox;
		}
	}
}

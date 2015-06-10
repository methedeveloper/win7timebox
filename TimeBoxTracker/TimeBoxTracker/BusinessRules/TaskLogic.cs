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
	/// Description of TaskLogic.
	/// </summary>
	public static class TaskLogic
	{
		public static void Insert(Task task)
		{
			using(var connection = DataAccessLayer.GetConnection())
			{
				connection.Open();
				using (IDbTransaction transaction = connection.BeginTransaction())
				{
					string insertSQL = String.Format("insert into task (name, id_project) values ('{0}', {1})", task.Name, task.ProjectId);
					DataAccessLayer.ExecuteNonQuery(insertSQL, connection, transaction);
					task.Id = Convert.ToInt32(DataAccessLayer.ExecuteScalar("select last_insert_rowid()", connection, transaction));
					transaction.Commit();
					task.EntityState = EntityState.UpToDate;
				}
			}
		}
		
		public static void Delete(Task task)
		{
			TimeboxLogic.DeleteByTaskId(task.Id);
			string deleteSQL = String.Format("delete from task where id={0}", task.Id);
			DataAccessLayer.ExecuteNonQuery(deleteSQL);
			task.EntityState = EntityState.Deleted;
		}
		
		public static void Update(Task task)
		{
			string updateSQL = String.Format("update task set name='{0}' and id_project={1} where id={2}", task.Name, task.ProjectId, task.Id);
			DataAccessLayer.ExecuteNonQuery(updateSQL);
			task.EntityState = EntityState.UpToDate;
		}
		
		public static Task GetById(int id)
		{
			string selectSQL = String.Format("select * from task where id={0}", id);
			IList<Task> taskList = DataAccessLayer.ExecuteReader<Task>(selectSQL, GetTaskFromReader);
			if (taskList.Count > 0)
				return taskList[0];
			return null;
		}
		
		public static IList<Task> GetByProjectId(int projectId)
		{
			string selectSQL = String.Format("select * from task where id_project={0}", projectId);
			return DataAccessLayer.ExecuteReader<Task>(selectSQL, GetTaskFromReader);
		}
		
		private static Task GetTaskFromReader(IDataReader reader)
		{
			Task task = new Task();
			task.Id = Convert.ToInt32(reader["id"]);
			task.Name = Convert.ToString(reader["name"]);
			task.ProjectId = Convert.ToInt32(reader["id_project"]);
			return task;
		}
	}
}

/*
 * Created by SharpDevelop.
 * User: joseantonio
 * Date: 30/04/2015
 * Time: 20:30
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
	/// Description of ProjectLogic.
	/// </summary>
	public static class ProjectLogic
	{
		public static void Insert(Project project)
		{
			using(var connection = DataAccessLayer.GetConnection())
			{
				connection.Open();
				using (IDbTransaction transaction = connection.BeginTransaction())
				{
					string insertSQL = String.Format("insert into project (name) values ('{0}')", project.Name);
					DataAccessLayer.ExecuteNonQuery(insertSQL, connection, transaction);
					project.Id = Convert.ToInt32(DataAccessLayer.ExecuteScalar("select last_insert_rowid()", connection, transaction));
					transaction.Commit();
					project.EntityState = EntityState.UpToDate;
				}
			}
		}
		
		public static void Delete(Project project)
		{
			foreach (Task task in TaskLogic.GetByProjectId(project.Id))
			{
				TaskLogic.Delete(task);
			}
			string deleteSQL = String.Format("delete from project where id={0}", project.Id);
			DataAccessLayer.ExecuteNonQuery(deleteSQL);
			project.EntityState = EntityState.Deleted;
		}
		
		public static void Update(Project project)
		{
			string updateSQL = String.Format("update project set name='{0}' where id={1}", project.Name, project.Id);
			DataAccessLayer.ExecuteNonQuery(updateSQL);
			project.EntityState = EntityState.UpToDate;
		}
		
		public static IList<Project> GetAll()
		{
			return DataAccessLayer.ExecuteReader<Project>("select * from project", GetProjectFromReader);
		}
		
		public static Project GetById(int id)
		{
			string selectSQL = String.Format("select * from project where id={0}", id);
			IList<Project> projectList = DataAccessLayer.ExecuteReader<Project>(selectSQL, GetProjectFromReader);
			if (projectList.Count > 0)
				return projectList[0];
			return null;
		}
		
		private static Project GetProjectFromReader(IDataReader reader)
		{
			Project project = new Project();
			project.Id = Convert.ToInt32(reader["id"]);
			project.Name = Convert.ToString(reader["name"]);
			return project;
		}
	}
}

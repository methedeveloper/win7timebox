/*
 * Created by SharpDevelop.
 * User: joseantonio
 * Date: 30/04/2015
 * Time: 20:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using TimeBoxTracker.Entities;

namespace TimeBoxTracker.BusinessRules
{
	/// <summary>
	/// Description of DataAccessLayer.
	/// </summary>
	internal static class DataAccessLayer
	{
		internal static IDbConnection GetConnection()
		{
			string connString = ConfigurationManager.ConnectionStrings["TimeBoxTrackerDB"].ConnectionString;
			return new SQLiteConnection(connString);
		}
		
		internal static IList<T> ExecuteReader<T>(string commandText, GetEntityFromReaderHandler<T> getEntityFromReader) where T: Entity
		{
			using (IDbConnection connection = GetConnection())
			{
				connection.Open();
				using (IDbCommand command = connection.CreateCommand())
				{
					command.CommandText = commandText;
					using (IDataReader reader = command.ExecuteReader())
					{
						IList<T> entityCollection = new List<T>();
						while (reader.Read())
						{
							T entity = getEntityFromReader(reader);
							entity.EntityState = EntityState.UpToDate;
							entityCollection.Add(entity);
						}
						return entityCollection;
					}
				}				
			}
		}
		
		internal static void ExecuteNonQuery(string commandText)
		{
			using (IDbConnection connection = GetConnection())
			{
				connection.Open();
				ExecuteNonQuery(commandText, connection, null);
			}		
		}
		
		internal static void ExecuteNonQuery(string commandText, IDbConnection connection, IDbTransaction transaction)
		{
			using (IDbCommand command = connection.CreateCommand())
			{
				command.CommandText = commandText;
				command.Transaction = transaction;
				command.ExecuteNonQuery();
			}
		}
		
		internal static object ExecuteScalar(string commandText)
		{
			using (IDbConnection connection = GetConnection())
			{
				connection.Open();
				return ExecuteScalar(commandText, connection, null);
			}		
		}
		
		internal static object ExecuteScalar(string commandText, IDbConnection connection, IDbTransaction transaction)
		{
			using (IDbCommand command = connection.CreateCommand())
			{
				command.CommandText = commandText;
				command.Transaction = transaction;
				return command.ExecuteScalar();
			}
		}
	}
	
	public delegate T GetEntityFromReaderHandler<T>(IDataReader reader) where T: Entity;
}

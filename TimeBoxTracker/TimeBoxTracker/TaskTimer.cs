/*
 * Created by SharpDevelop.
 * User: joseantonio
 * Date: 26/04/2015
 * Time: 12:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Timers;

namespace TimeBoxTracker
{
	/// <summary>
	/// Description of Timer.
	/// </summary>
	public class TaskTimer
	{
		private Timer Timer { get; set; }
		public TimeSpan ElapsedTime { get; set; }
		public TaskTimerState State { get; private set; }
		public int Pauses { get; private set; }
		public TimeSpan RemainingTime { get; set; }
		
		public event EventHandler Started;
		public event EventHandler Stopped;
		public event EventHandler Paused;
		public event EventHandler Resumed;
		public event EventHandler<TaskTimerTickEventArgs> Tick;
		
		public TaskTimer()
		{
			Timer = new Timer(1000);
			Timer.Elapsed += Timer_Elapsed;	
			State = TaskTimerState.Stopped;
			Pauses = 0;
		}
		
		public bool IsRunning 
		{ 
			get
			{
				return Timer.Enabled;
			}
		}

		void Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			ElapsedTime = ElapsedTime.Add(TimeSpan.FromSeconds(1));
			RemainingTime = RemainingTime.Subtract(TimeSpan.FromSeconds(1));
			if (RemainingTime.Ticks < 0)
			{
				Stop();
			}
			else
			{
				RaiseTickEvent();
			}
		}
		
		public void Start()
		{
			Timer.Start();
			State = TaskTimerState.Started;
			RaiseStartedEvent();
		}
		
		public void Stop()
		{
			Timer.Stop();
			State = TaskTimerState.Stopped;
			RaiseStoppedEvent();
		}
		
		public void Pause()
		{
			Timer.Stop();
			State = TaskTimerState.Paused;
			Pauses++;
			RaisePausedEvent();
		}
		
		public void Resume()
		{
			Timer.Start();
			State = TaskTimerState.Started;
			RaiseResumedEvent();
		}
		
		private void RaiseStartedEvent()
		{
			if (Started != null)
			{
				Started(this, EventArgs.Empty);
			}
		}
		
		private void RaiseStoppedEvent()
		{
			if (Stopped != null)
			{
				Stopped(this, EventArgs.Empty);
			}
		}
		
		private void RaisePausedEvent()
		{
			if (Paused != null)
			{
				Paused(this, EventArgs.Empty);
			}
		}
		
		private void RaiseResumedEvent()
		{
			if (Resumed != null)
			{
				Resumed(this, EventArgs.Empty);
			}
		}
		
		private void RaiseTickEvent()
		{
			if (Tick != null)
			{
				Tick(this, new TaskTimerTickEventArgs(ElapsedTime, RemainingTime));
			}
		}
	}
	
	public enum TaskTimerState
	{
		Stopped,
		Started,
		Paused
	}
	
	public class TaskTimerTickEventArgs: EventArgs 
	{
		public TimeSpan ElapsedTime;
		public TimeSpan RemainingTime;
		
		public TaskTimerTickEventArgs(TimeSpan elapsedTime, TimeSpan remainingTime)
		{
			ElapsedTime = elapsedTime;
			RemainingTime = remainingTime;
		}
	}
}

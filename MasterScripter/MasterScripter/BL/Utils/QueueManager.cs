using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using MasterScripter.DAL.Models;
using MasterScripter.Models;
using Microsoft.Ajax.Utilities;

namespace MasterScripter.BL.Utils
{

    public sealed class QueueManager
    {
        private static readonly QueueManager instance = new QueueManager();
        private Queue<Execution> ExecutionsQueue { get; set; }
        private List<Execution> ScheduledExecution { get; set; }
        private MasterScripterContext db = new MasterScripterContext();
        private Random RandomNumber = new Random();
        private bool IsRunning { get; set; }
        private readonly int SLEEP_TIME = 1000 * 3;

        private readonly int MIN_TIME = 3;
        private readonly int MAX_TIME = 20;

        private readonly int MAX_PARALLEL_TASKS = 2;
        private int CurrentRunningTasks { get; set; }
        private List<LogMessage> LogMessages { get; set; }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static QueueManager()
        {
        }

        private QueueManager()
        {
            ExecutionsQueue = new Queue<Execution>();
            ScheduledExecution = new List<Execution>();

            IsRunning = false;
            CurrentRunningTasks = 0;
            LogMessages = new List<LogMessage>();

            LogMessages.Add(new LogMessage("Init Queue Manager"));
        }

        public static QueueManager Instance => instance;

        public void Start()
        {
            if (IsRunning == false)
            {
                IsRunning = true;
                LogMessages.Add(new LogMessage("Queue Manager started"));

                new Thread(() =>
                {
                    while (IsRunning)
                    {
                        if (CurrentRunningTasks < MAX_PARALLEL_TASKS)
                        {
                            new Thread(ExecuteScheduledOrRegularTask).Start();
                        }
                        else
                        {
                            LogMessages.Add(new LogMessage("No available thread to run tasks  " + CurrentRunningTasks + " (" + MAX_PARALLEL_TASKS + "/" + MAX_PARALLEL_TASKS + ")"));
                        }

                        Thread.Sleep(SLEEP_TIME);
                    }
                }).Start();
            }
        }

        private void ExecuteScheduledOrRegularTask()
        {
            Execution execution = ScheduledExecution.FirstOrDefault(e => e.ScheduleTime <= DateTime.Now);

            if (execution != null)
            {
                LogMessages.Add(new LogMessage("Start to execute scheduled task"));

               ExecuteTask(execution);
            }
            else if (ExecutionsQueue.Count > 0)
            {
                LogMessages.Add(new LogMessage("Start to execute regular task"));
                execution = ExecutionsQueue.Dequeue();
                ExecuteTask(execution);
            }
        }


        private void ExecuteTask(Execution execution)
        {
            execution.Status = Status.Running;
            execution.SrartTime = DateTime.Now;
            CurrentRunningTasks++;
            LogMessages.Add(new LogMessage("Starting new task " + execution.Id + ". tasks left: " + ExecutionsQueue.Count));
            LogMessages.Add(new LogMessage("Current running tasks  " + CurrentRunningTasks + "/" + MAX_PARALLEL_TASKS));

     //       db.Entry(execution).State = EntityState.Modified;
            db.SaveChanges();

            execution.Status = Status.Running;

            foreach (ExecutionsScripts executionsScripts in execution.ExecutionsScriptses)
            {
                executionsScripts.Status = Status.Running;
                executionsScripts.SrartTime = DateTime.Now;
               // db.Entry(executionsScripts).State = EntityState.Modified;
               db.SaveChanges();

                try
                {
                    LogMessages.Add(new LogMessage("Starting run new sub task of task  " + execution.Id));

                    ExecuteSingleTask(executionsScripts);
                    executionsScripts.Status = Status.Succeeded;
                }
                catch (Exception e)
                {
                    executionsScripts.Status = Status.Failed;
                    execution.Status = Status.Failed;
                    LogMessages.Add(new LogMessage("Error with run sub task of task  " + execution.Id, MessageType.Error));
                }
                finally
                {
                    execution.Status = execution.Status== Status.Failed? Status.Failed : Status.Succeeded;
                    executionsScripts.EndTime = DateTime.Now;
                 //   db.Entry(executionsScripts).State = EntityState.Modified;
                    db.SaveChanges();
                    LogMessages.Add(new LogMessage("Finished run sub task of task  " + execution.Id + " Total time:" + (executionsScripts.EndTime - executionsScripts.SrartTime).Value.Seconds + " Seconds", MessageType.Success));
                }
            }

            execution.EndTime = DateTime.Now;
            db.Entry(execution).State = EntityState.Modified;
            db.SaveChanges();
            LogMessages.Add(new LogMessage("Finished working on task " + execution.Id + " Total time:" + (execution.EndTime - execution.SrartTime).Value.Minutes + " Minutes", MessageType.Success));

            CurrentRunningTasks--;
            LogMessages.Add(new LogMessage("Current running tasks  " + CurrentRunningTasks));
        }

        private void ExecuteSingleTask(ExecutionsScripts executionsScript)
        {
            Thread.Sleep(RandomNumber.Next(MIN_TIME, MAX_TIME) * 1000);

            if (RandomNumber.Next(0, 10) == 7)
                throw new Exception("Error");
        }

        public void AddTask(Execution execution)
        {
            if (execution.ScheduleTime == null)
                ExecutionsQueue.Enqueue(execution);
            else
                ScheduledExecution.Add(execution);

            LogMessages.Add(new LogMessage("Added " + (execution.ScheduleTime == null ? "" : "Scheduled ") + " task  " +
                                           execution.Id + " with " + execution.ExecutionsScriptses.Count +
                                           " sub tasks"));
        }

        public void Stop()
        {
            IsRunning = false;
            LogMessages.Add(new LogMessage("Queue Manager stopped"));

        }

        public Status GetStatus()
        {
            return IsRunning  ? Status.Running : Status.Waiting;
        }

        public int GetCurrentRunningTasks()
        {
            return CurrentRunningTasks;
        }

        public int GetAvailableThreads()
        {
            return MAX_PARALLEL_TASKS - CurrentRunningTasks;
        }

        public List<LogMessage> GetLogMessages()
        {
            List<LogMessage> log = new List<LogMessage>();
            LogMessages.CopyItemsTo(log);
            LogMessages.Clear();

            return log;
        }
    }
}


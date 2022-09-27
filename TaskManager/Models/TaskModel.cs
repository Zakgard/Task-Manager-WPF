using System;

namespace TaskManager.Models
{
    internal class TaskModel
    {
        private bool _isTaskFinished;
        private string _additionalTaskInformation;
        private string _taskPriorityLevel;
        private string _taskDescription;    
        private string _taskTitle;
       
        public DateTime taskCreationTime { get;  set; }= DateTime.Now;
        public bool IsTaskFinished
        {
            get { return _isTaskFinished; }
            set { _isTaskFinished = value; }
        }

        public string TaskDescription
        {
            get { return _taskDescription; }
            set { _taskDescription = value; }
        }

        public string TaskTitle
        {
            get { return _taskTitle; }
            set { _taskTitle = value; }
        }

        public string AdditionalTaskInfo
        {
            get { return _additionalTaskInformation; }
            set { _additionalTaskInformation = value; }
        }

        public string PriorityLevel
        {
            get { return _taskPriorityLevel; }
            set { _taskPriorityLevel = value; }
        }
    }
}

using System.ComponentModel;
using TaskManager.Models;
using System.IO;
using System.Text;
using System;
using System.Collections.Generic;

namespace TaskManager.Services
{
    internal class FileIO
    {
        private readonly string _path;
        private StringBuilder _stringBuilder=new StringBuilder();
        private string _textFromFile=String.Empty;
        private List<string> _lines = new List<string>();
        public delegate BindingList<TaskModel> DataLoadDelegate();
        
        public void RecordtasksIntoFile(BindingList<TaskModel> TaskModelList)
        {
            ChecklIfFileExists();
            for (int i = 0; i < TaskModelList.Count; i++)
            {
                _stringBuilder.Append(TaskModelList[i].TaskTitle.ToString());
                _stringBuilder.Append("|");
                _stringBuilder.Append(TaskModelList[i].TaskDescription.ToString());
                _stringBuilder.Append("|");
                _stringBuilder.Append(TaskModelList[i].IsTaskFinished.ToString());
                _stringBuilder.Append("|");
                _stringBuilder.Append(TaskModelList[i].PriorityLevel.ToString());
                _stringBuilder.Append("|");
                _stringBuilder.Append(TaskModelList[i].taskCreationTime.ToString());
                _stringBuilder.Append("|");
                _stringBuilder.Append(TaskModelList[i].AdditionalTaskInfo.ToString());
                _stringBuilder.Append("\n");
            }
            File.AppendAllText(_path,_stringBuilder.ToString());                                            
        }       

        public FileIO(string path)
        {
            _path = path;
        }

        private void ChecklIfFileExists()
        {
            bool isFileExists=File.Exists(_path);
            if (!isFileExists)
            {
                File.Create(_path).Dispose();
                return;
            }
            else
            {
                return;
            }
        }
        
        private void ReadTextFromFIle()
        {
            ChecklIfFileExists();
            StreamReader reader = new StreamReader(_path);
            while (!reader.EndOfStream)
            {
                _lines.Add(reader.ReadLine());
            }
            reader.Close();
            File.Delete(_path);
        }

         public BindingList<TaskModel> ConvertTExtFromFileIntoList()
        {
            ReadTextFromFIle();
            BindingList<TaskModel> list = new BindingList<TaskModel>();            
            foreach (string line in _lines)
            {
                var lineArray = line.Split('|');
                list.Add(new TaskModel() { TaskTitle = lineArray[0].ToString(), TaskDescription = lineArray[1].ToString(), IsTaskFinished = Convert.ToBoolean(lineArray[2].ToString()), PriorityLevel = lineArray[3].ToString(), taskCreationTime = Convert.ToDateTime(lineArray[4]), AdditionalTaskInfo = lineArray[5].ToString() });
            }
            
            return list;
        }
    }
}

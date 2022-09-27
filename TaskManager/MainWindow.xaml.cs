using System.ComponentModel;
using System.Windows;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _taskName=string.Empty;
        private string _taskDescription=string.Empty;
        private string _taskAdditionalInfo=string.Empty;
        private string _priorityLevel;
        private FileIO fileIO= new FileIO(@"..\..\TaskFile\TaskFile.txt");
        private BindingList<TaskModel> _taskModelList;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RecordTextBoxIntoStrings();
            AddTask();
            RecordDataIntoFile();
        }

        private void RecordTextBoxIntoStrings()
        {
            _taskName=TaskNameTextBox.Text;
            _taskDescription=DescriptionTextBox.Text;
            _taskAdditionalInfo=AdditionalInfoTextBox.Text;
            _priorityLevel = PriorityTable.Text;           
        }
     
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            _taskModelList=fileIO.ConvertTExtFromFileIntoList();         
            TaskToDoList.ItemsSource = _taskModelList;
        }

        private void AddTask()
        {
            _taskModelList.Add(new TaskModel() { TaskDescription = _taskDescription, TaskTitle = _taskName, IsTaskFinished = false, AdditionalTaskInfo = _taskAdditionalInfo, PriorityLevel = _priorityLevel });
        }
      

        private void RecordDataIntoFile()
        {
            fileIO.RecordtasksIntoFile(_taskModelList);
        }
    }
}

using Microsoft.Samples.Kinect.InteractionGallery.Models;
using Microsoft.Samples.Kinect.InteractionGallery.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;

namespace QuestionManager
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<QuestionModel> questionList;

        public ObservableCollection<QuestionModel> QuestionList
        {
            get { return  questionList; }
            set {  questionList = value; }
        }
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            qList.ItemsSource = QuestionList;
            qs.ItemsSource = QuestionList;
            QuestionList = new ObservableCollection<QuestionModel>();
            QuestionModel model = new QuestionModel();
            model.Title = "abc";
            model.RightChoiceIndex = 1;
            model.ExplainText = "def";
            model.Type = Microsoft.Samples.Kinect.InteractionGallery.Models.QuestionModel.QuestionType.TextOnly;
            var list = new List<QuestionChoiceModel>();
            list.Add(new QuestionChoiceModel(){Text="1"});
            list.Add(new QuestionChoiceModel(){Text="2"});
            list.Add(new QuestionChoiceModel(){Text="3"});
            model.Answers = list;

            
            using (FileStream fs = new FileStream("Questions.xaml", FileMode.Open))
            {
                if(fs.Length>0)
                {
                    QuestionList = XamlServices.Load(fs) as ObservableCollection<QuestionModel>;
                }
                
            }

            
            
        }
    }
}

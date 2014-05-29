using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xaml;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using Microsoft.Samples.Kinect.InteractionGallery.Models;
using Microsoft.Samples.Kinect.InteractionGallery.Navigation;
using Microsoft.Samples.Kinect.InteractionGallery.Services;
using Microsoft.Samples.Kinect.InteractionGallery.Utilities;

namespace Microsoft.Samples.Kinect.InteractionGallery.ViewModels
{
    [ExportNavigable(NavigableContextName = DefaultNavigableContexts.QuestionScreen)]
    class QuestionScreenViewModel : ViewModelBase
    {
        internal const int EachTimeQuestionsCount = 4;//change here to change the question each user to answer
        internal readonly double ResizeRatio ;//compared to 1920*1080


        private List<QuestionModel> AllQustions { get; set; }
        private List<QuestionModel> CurrentQuestionGroup { get; set; }

        private QuestionModel currentQuestion;

        public QuestionModel CurrentQuestion
        {
            get { return currentQuestion; }
            set
            {
                currentQuestion = value;
                OnPropertyChanged("CurrentQuestion");
            }
        }

        private ObservableCollection<KinectTileButton> currentChoices;
        public ObservableCollection<KinectTileButton> CurrentChoices
        {
            get { return currentChoices; }
            set
            {
                currentChoices = value;
                OnPropertyChanged("CurrentChoices");
            }
        }

        private ObservableCollection<KinectTileButton> currentChoicesLayout2;
        public ObservableCollection<KinectTileButton> CurrentChoicesLayout2
        {
            get { return currentChoicesLayout2; }
            set
            {
                currentChoicesLayout2 = value;
                OnPropertyChanged("CurrentChoicesLayout2");
            }
        }




        private double leftScrollLen;

        public double LeftScrollLen
        {
            get { return leftScrollLen; }
            set
            {
                leftScrollLen = value;
                OnPropertyChanged("LeftScrollLen");
            }
        }

        private double rightScrollLen;

        public double RightScrollLen
        {
            get { return rightScrollLen; }
            set
            {
                rightScrollLen = value;
                OnPropertyChanged("RightScrollLen");
            }
        }

        private double leftMaskLen;

        public double LeftMaskLen
        {
            get { return leftMaskLen; }
            set
            {
                leftMaskLen = value;
                OnPropertyChanged("LeftMaskLen");
            }
        }

        private double leftMaskEnd;

        public double LeftMaskEnd
        {
            get { return leftMaskEnd; }
            set
            {
                leftMaskEnd = value;
                OnPropertyChanged("LeftMaskEnd");
            }
        }

        private double scrollHeight;

        public double ScrollHeight
        {
            get { return scrollHeight; }
            set
            {
                scrollHeight = value;
                OnPropertyChanged("ScrollHeight");
            }
        }







        private KeyTime ammitTime;

        public KeyTime AnmitTime
        {
            get { return ammitTime; }
            set
            {
                ammitTime = value;
                this.OnPropertyChanged("AnmitTime");
            }
        }

      

        private Visibility choicesVisibility;

        public Visibility ChoicesVisibility
        {
            get { return choicesVisibility; }
            set
            {
                choicesVisibility = value;
                OnPropertyChanged("ChoicesVisibility");
            }
        }


        private Visibility explainVisibility;

        public Visibility ExplainVisibility
        {
            get { return explainVisibility; }
            set
            {
                explainVisibility = value;
                OnPropertyChanged("ExplainVisibility");
            }
        }


        private string explainText;

        public string ExplainText
        {
            get { return explainText; }
            set
            {
                explainText = value;
                OnPropertyChanged("ExplainText");
            }
        }


        private string currentResultText;

        public string CurrentResultText
        {
            get { return currentResultText; }
            set
            {
                currentResultText = value;
                OnPropertyChanged("CurrentResultText");
            }
        }

        private int timeLeft;

        public int TimeLeft
        {
            get { return timeLeft; }
            set
            {
                timeLeft = value;
                OnPropertyChanged("TimeLeft");
            }
        }



        private string upTimeMsg;

        public string UpTimeMsg
        {
            get { return upTimeMsg; }
            set
            {
                upTimeMsg = value;
                OnPropertyChanged("UpTimeMsg");
            }
        }


        private int currentIndex;

        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                currentIndex = value;
                OnPropertyChanged("CurrentIndex");
            }
        }

        private int rightCount;

        public int RightCount
        {
            get { return rightCount; }
            set
            {
                rightCount = value;
                OnPropertyChanged("RightCount");
            }
        }

        private int wrongCount;

        public int WrongCount
        {
            get { return wrongCount; }
            set
            {
                wrongCount = value;
                OnPropertyChanged("WrongCount");
            }
        }

        private double buttonWidth;

        public double ButtonWidth   
        {
            get { return buttonWidth; }
            set
            {
                buttonWidth = value;
                OnPropertyChanged("ButtonWidth");
            }
        }


        private double nextButtonWidth;

        public double NextButtonWidth
        {
            get { return nextButtonWidth; }
            set
            {
                nextButtonWidth = value; 
                OnPropertyChanged("NextButtonWidth");
            }
        }

        private double nextButtonHeight;

        public double NextButtonHeight
        {
            get { return nextButtonHeight; }
            set
            {
                nextButtonHeight = value;
                OnPropertyChanged("NextButtonHeight");
            }
        }

        private double downButtonWidth;

        public double DownButtonWidth
        {
            get { return downButtonWidth; }
            set
            {
                downButtonWidth = value; 
                OnPropertyChanged("DownButtonWidth");
            }
        }

        private double downButtonHeight;

        public double DownButtonHeight
        {
            get { return downButtonHeight; }
            set
            {
                downButtonHeight =value;
                OnPropertyChanged("DownButtonHeight");
            }
        }


        private double brushWidth;

        public double BrushWidth
        {
            get { return brushWidth; }
            set
            {
                brushWidth = value;
                OnPropertyChanged("BrushWidth");
            }
        }

        private double brushHeight;

        public double BrushHeight
        {
            get { return brushHeight; }
            set
            {
                brushHeight = value;
                OnPropertyChanged("BrushHeight");
            }
        }

        private double brushMoveX;

        public double BrushMoveX
        {
            get { return brushMoveX; }
            set
            {
                brushMoveX = value;
                OnPropertyChanged("BrushMoveX");
            }
            
        }

        private double brushMoveY;

        public double BrushMoveY
        {
            get { return brushMoveY; }
            set
            {
                brushMoveY = value;
                OnPropertyChanged("BrushMoveY");
            }

        }
        
        
        
        

        private ImageSource leftMaskImage;

        public ImageSource LeftMaskImage
        {
            get { return leftMaskImage; }
            set
            {
                leftMaskImage = value;
                OnPropertyChanged("LeftMaskImage");
            }
        }



        private ImageSource rightContentImage;

        public ImageSource RightContentImage
        {
            get { return rightContentImage; }
            set
            {
                rightContentImage = value;
                OnPropertyChanged("RightContentImage");
            }
        }

        private ImageSource nextButtonImage;

        public ImageSource NextButtonImage
        {
            get { return nextButtonImage; }
            set
            {
                nextButtonImage = value;
                OnPropertyChanged("NextButtonImage");
            }
        }


        private Visibility firstLayoutVisibility;

        public Visibility FirstLayoutVisibility
        {
            get { return firstLayoutVisibility; }
            set
            {
                SecondLayoutVisibility = value == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                firstLayoutVisibility = value; 
                OnPropertyChanged("FirstLayoutVisibility");
            }
        }

        private Visibility secondLayoutVisibility;

        public Visibility SecondLayoutVisibility
        {
            get { return secondLayoutVisibility; }
            set
            {
                secondLayoutVisibility = value;
                OnPropertyChanged("SecondLayoutVisibility");
            }
        }

        private double downScrollWidth;

        public double DownScrollWidth
        {
            get { return downScrollWidth; }
            set
            {
                downScrollWidth = value; 
                OnPropertyChanged("DownScrollWidth");
            }
        }

        private double downScrollLen;

        public double DownScrollLen
        {
            get { return downScrollLen; }
            set
            {
                downScrollLen = value; 
                OnPropertyChanged("DownScrollLen");
            }
        }

        private double downContentLen;

        public double DownContentLen
        {
            get { return downContentLen; }
            set
            {
                downContentLen = value;
                OnPropertyChanged("DownScrollLen");
            }
        }

        private ImageSource downContentImage;

        public ImageSource DownContentImage
        {
            get { return downContentImage; }
            set
            {
                downContentImage = value;
                OnPropertyChanged("DownContentImage");
            }
        }

        private double downContentHeight;

        public double DownContentHeight
        {
            get { return downContentHeight; }
            set
            {
                downContentHeight = value; 
                OnPropertyChanged("DownContentHeight");
            }
        }
        
        

        private readonly RelayCommand nextCommand;
        public ICommand NextCommand
        {
            get { return this.nextCommand; }
        }

        private readonly RelayCommand backCommand;
        public ICommand BackCommand
        {
            get { return this.backCommand; }
        }




        /// <summary>
        /// Initializes a new instance of the AttractScreenViewModel class that loads model content from the given Uri
        /// </summary>
        /// <param name="modelContentUri">Uri to the collection of AttractScreenImage models to be loaded</param>
        public QuestionScreenViewModel()
            : base()
        {

            RightScrollLen = (SystemParameters.FullPrimaryScreenWidth) * ((960 - 196) / 960.0) * 0.5;
            LeftScrollLen = -RightScrollLen+6;
            LeftMaskLen = SystemParameters.FullPrimaryScreenWidth / 2;
            LeftMaskEnd = LeftMaskLen + LeftScrollLen;
            ScrollHeight = (585.0 / 766.0) * RightScrollLen;

            CurrentChoices = new ObservableCollection<KinectTileButton>();
            CurrentChoicesLayout2 = new ObservableCollection<KinectTileButton>();
            currentIndex = 0;
            CurrentQuestionGroup=new List<QuestionModel>();

            this.LoadModels();

            ResizeRatio = RightScrollLen / 766;


            const string rightContentPath = "/Content/QuestionScreen/rightContent.png";
            RightContentImage = ImageHelper.ChangeSize(rightContentPath, (int)RightScrollLen, (int)ScrollHeight,
            ImageHelper.AdjustMode.W);

            const string leftMaskPath = "/Content/QuestionScreen/leftBg.png";
            LeftMaskImage = ImageHelper.ChangeSize(leftMaskPath,ResizeRatio,ImageHelper.AdjustMode.W);

            const string downContentPath = "/Content/QuestionScreen/downContent.png";
            DownContentImage = ImageHelper.ChangeSize(downContentPath, ResizeRatio, ImageHelper.AdjustMode.W);

            ButtonWidth = 460.0*ResizeRatio;

            BrushWidth = 147*ResizeRatio;
            BrushHeight = 345*ResizeRatio;
            BrushMoveX = -236*ResizeRatio;
            BrushMoveY = -297*ResizeRatio;

            NextButtonWidth = 366*ResizeRatio;
            NextButtonHeight = 240*ResizeRatio;

            DownScrollWidth = 598*ResizeRatio;
            DownScrollLen = 900*ResizeRatio;
            DownContentLen = DownScrollLen + 65*ResizeRatio;

            DownButtonWidth = 460*ResizeRatio;
            DownButtonHeight = 214*ResizeRatio;
            DownContentHeight = 261*ResizeRatio;

            this.nextCommand = new RelayCommand(this.SwitchQuestion);
            this.backCommand = new RelayCommand(()=> this.NavigationManager.NavigateToHome(DefaultNavigableContexts.AttractScreen2));
        }

        private void SwitchQuestion()
        {
            if (CurrentIndex < EachTimeQuestionsCount)
            {
                ChoicesVisibility = Visibility.Visible;
                ExplainVisibility = Visibility.Collapsed;
                CurrentQuestion = CurrentQuestionGroup[CurrentIndex];
                CurrentIndex++;
                if (CurrentQuestion.Type == QuestionModel.QuestionType.TitleWithImage)
                {
                    CurrentChoicesLayout2.Clear();
                    FirstLayoutVisibility = Visibility.Collapsed;//Change FirstLayoutVisibility will change SecondLayoutVisibility automatically
                    for (int i = 0; i < CurrentQuestion.ChoiceCount; i++)
                    {
                        var ktb = new KinectTileButton();
                        ktb.Tag = i;

                        ktb.HorizontalAlignment=HorizontalAlignment.Center;
                        ktb.VerticalAlignment = VerticalAlignment.Center;
                        ktb.HorizontalLabelAlignment = HorizontalAlignment.Center;           
                        ktb.VerticalLabelAlignment = VerticalAlignment.Center;
                        ktb.LabelBackground = new SolidColorBrush(Colors.Transparent);

                        ktb.Click += ktb_Click;
                        ktb.Height = DownContentHeight;
                        ktb.Width = DownButtonWidth;

                        ktb.BorderThickness = new Thickness(0, 0, 0, 0);

                        ktb.Label = CurrentQuestion.Answers[i].Text;
                        ImageSource frameSource = new BitmapImage(new Uri("pack://application:,,,/Content/QuestionScreen/frame2.png"));
                        Image frame = new Image();

                        frame.Source = frameSource;
                        frame.Stretch = Stretch.Fill;
                        ktb.Content = frame;

                        double margin = ((RightScrollLen * 2 - CurrentQuestion.ChoiceCount * DownButtonWidth) /
                                        CurrentQuestion.ChoiceCount) / 2;
                        margin = margin - margin / 4;
                        ktb.Margin = new Thickness(0,margin, 0, margin);

                        ImageBrush backBrush = new ImageBrush(new BitmapImage(new Uri(
                                "pack://application:,,,/Content/QuestionScreen/answerbg" + (i + 1) + ".png")));
                        backBrush.Opacity = 0.4;
                        backBrush.Stretch = Stretch.Fill;
                        ktb.Background = backBrush;

                        CurrentChoicesLayout2.Add(ktb);

                    }
                    if (CurrentIndex == EachTimeQuestionsCount)
                    {
                        NextButtonImage = new BitmapImage(new Uri("pack://application:,,,/Content/QuestionScreen/buttonResult2.png"));
                    }
                    else
                    {
                        NextButtonImage = new BitmapImage(new Uri("pack://application:,,,/Content/QuestionScreen/buttonDown2.png"));
                    }
                }
                else
                {
                    CurrentChoices.Clear();
                    FirstLayoutVisibility = Visibility.Visible;//Change FirstLayoutVisibility will change SecondLayoutVisibility automatically
                    for (int i = 0; i < CurrentQuestion.ChoiceCount; i++)
                    {
                        var ktb = new KinectTileButton();
                        ktb.Tag = i;


                        ktb.HorizontalLabelAlignment = HorizontalAlignment.Center;
                        ktb.VerticalLabelAlignment = VerticalAlignment.Center;

                        ktb.Click += ktb_Click;

                        ktb.Width = ButtonWidth;
                        ktb.Height = ButtonWidth/1.5;

                        //ktb.LabelBackground =new SolidColorBrush( );
                        ktb.BorderThickness = new Thickness(0, 0, 0, 0);

                        ktb.Label = CurrentQuestion.Answers[i].Text;

                        ImageSource frameSource = new BitmapImage(new Uri("pack://application:,,,/Content/QuestionScreen/frame.png"));
                        Image frame = new Image();

                        frame.Source = frameSource;
                        frame.Stretch = Stretch.Fill;
                        ktb.Content = frame;

                        double margin = ((RightScrollLen * 2 - CurrentQuestion.ChoiceCount * ButtonWidth) /
                                        CurrentQuestion.ChoiceCount) / 2;
                        margin = margin - margin / 4;

                        ktb.Margin = new Thickness(margin, 0, margin, 0);

                        ImageBrush backBrush;
                        if (CurrentQuestion.Answers[i].AttachImage != null)
                        {
                            ktb.VerticalLabelAlignment = VerticalAlignment.Bottom;

                            //ktb.Height = img.Height;                       
                            backBrush = new ImageBrush(CurrentQuestion.Answers[i].AttachImage);

                        }
                        else
                        {

                            backBrush = new ImageBrush(new BitmapImage(new Uri(
                                "pack://application:,,,/Content/QuestionScreen/answerbg" + (i + 1) + ".png")));
                            backBrush.Opacity = 0.4;
                        }
                        backBrush.Stretch = Stretch.Fill;
                        ktb.Background = backBrush;
                        CurrentChoices.Add(ktb);
                    }
                    if (CurrentIndex == EachTimeQuestionsCount)
                    {
                        NextButtonImage = new BitmapImage(new Uri("pack://application:,,,/Content/QuestionScreen/buttonResult.png"));
                    }
                    else
                    {
                        NextButtonImage = new BitmapImage(new Uri("pack://application:,,,/Content/QuestionScreen/buttonDown.png"));
                    }
                }              
  
            }
            else
            {
                NavigationManager.NavigateToHome(DefaultNavigableContexts.ResultScreen);
            }

            
        }


        protected void LoadModels()
        { 
            AllQustions = (new XamlDataService()).GetAllQuestions();
        }

        private void PickQuestions()
        {
            if (EachTimeQuestionsCount > AllQustions.Count)
            {
                throw new Exception("总问题数大于每次问答题目");
            }

            CurrentQuestionGroup.Clear();
            while (CurrentQuestionGroup.Count<EachTimeQuestionsCount)
            {
                Random random=new Random();
                QuestionModel temp = AllQustions[random.Next(0, AllQustions.Count)];
                if (!CurrentQuestionGroup.Contains(temp))
                {
                    CurrentQuestionGroup.Add(temp);
                }
            }
        }


        private void ktb_Click(object sender, RoutedEventArgs e)
        {
            ExplainVisibility = Visibility.Visible;
            ChoicesVisibility = Visibility.Collapsed;
            var ktb = sender as KinectTileButton;
            if ((int)ktb.Tag == CurrentQuestion.RightChoiceIndex)
            {
                //(App)System.Windows.Application.Current.Properties.
                RightCount++;
                (Application.Current as App).Result.RightCount = RightCount;
                CurrentResultText = "恭喜你答对了";
            }
            else
            {
                WrongCount++;
                (Application.Current as App).Result.WrongCount = WrongCount;
                CurrentResultText = "很遗憾你答错了";
            }
            ExplainText = CurrentQuestion.ExplainText;

            if (CurrentIndex == EachTimeQuestionsCount)
            {
                UpTimeMsg = "查看结果";
            }
            else
            {
                UpTimeMsg = "下一题";

            }
            //todo fix this to auto switch
            //TimeLeft = 11;
            //timmer=new DispatcherTimer();
            //timmer.Interval = TimeSpan.FromSeconds(1);
            //timmer.Tick += (a, b) =>
            //{
            //    TimeLeft--;
            //    UpTimeMsg = string.Format("下一题({0})", TimeLeft);
            //    if (TimeLeft == 0)
            //    {
            //        timmer.Stop();
            //SwitchQuestion();
            //        //MessageBox.Show("TimeUp");
            //    }
            //};
            //timmer.Start();

        }






        public override void OnNavigatedTo()
        {
            base.OnNavigatedTo();

            (Application.Current as App).Result.RightCount = 0;
            (Application.Current as App).Result.WrongCount = 0;
            PickQuestions();
            SwitchQuestion();
            RightCount = 0;
            WrongCount = 0;

            //FirstLayoutVisibility = Visibility.Visible;

        }

       

        ///// <summary>
        ///// Stops the timer iterating through the image collection. 
        ///// Called when this view model is navigated away from.
        ///// </summary>
        public override void OnNavigatedFrom()
        {
            base.OnNavigatedFrom();
            CurrentIndex = 0;        
        }

       
        
    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Kinect.Toolkit;
using Microsoft.Samples.Kinect.InteractionGallery.Navigation;

namespace Microsoft.Samples.Kinect.InteractionGallery.ViewModels
{
    [ExportNavigable(NavigableContextName = DefaultNavigableContexts.ResultScreen)]
    class ResultScreenViewModel:ViewModelBase
    {


        private string resultText;

        public string ResultText
        {
            get { return resultText; }
            set
            {
                resultText = value;
                OnPropertyChanged("ResultText");
            }
        }
        
      
        private readonly RelayCommand restartCommand;
        public ICommand RestartCommand
        {
            get { return this.restartCommand; }
        }

        private readonly RelayCommand backCommand;
        public ICommand BackCommand
        {
            get { return this.backCommand; }
        }

        public ResultScreenViewModel()
        {
            restartCommand = new RelayCommand(Restart);
            backCommand = new RelayCommand(GoBack);
            

        }

        public override void OnNavigatedTo()
        {
            base.OnNavigatedTo();
            int rightCount = (Application.Current as App).Result.RightCount;
            int wrongCount = (Application.Current as App).Result.WrongCount;

            //todo change text here according to the count
            ResultText = string.Format("您一共回答了{0}道问题，其中回答正确{1}道，错误{2}道，谢谢参与！", rightCount + wrongCount, rightCount, wrongCount);
        }

        private void Restart()
        {
            NavigationManager.NavigateToHome(DefaultNavigableContexts.QuestionScreen);
        }

        private void GoBack()
        {
            NavigationManager.NavigateToHome(DefaultNavigableContexts.AttractScreen2);
        }
    }

}

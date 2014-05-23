using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Kinect.Toolkit;
using Microsoft.Samples.Kinect.InteractionGallery.Models;
using Microsoft.Samples.Kinect.InteractionGallery.Navigation;
using Microsoft.Samples.Kinect.InteractionGallery.Properties;

namespace Microsoft.Samples.Kinect.InteractionGallery.ViewModels
{
    [ExportNavigable(NavigableContextName = DefaultNavigableContexts.PuzzleScreen)]
    class PuzzleViewModel:ViewModelBase
    {
        PuzzleViewModel()
        {
             Title = "Puzzle";
            ButtonClicked = new RelayCommand(this.OnButtonClicked);
        }

        //private Size _puzzleSize;
        //private PuzzleGrid _puzzleGrid;
        //public override void Initialize(Uri parameter)
        //{
            //base.Initialize(parameter);
            


            //_stylingPuzzle = true;
            //MediaTypeNames.Image masterImage = (MediaTypeNames.Image)this.Resources["TableImage"];
            //_elementToChopUp = masterImage;
            //BitmapSource bitmap = (BitmapSource)masterImage.Source;

            //BitmapImage img = new BitmapImage(new Uri(@"Content/PuzzleScreen/flower.jpg"));
            //_puzzleSize = new Size(img.PixelWidth / 1.5, img.PixelHeight / 1.5);


        //}

        
        private void OnButtonClicked()
        {
            MessageBox.Show("FUck");
        }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                this.OnPropertyChanged("Title");
            }
        }

        private RelayCommand ButtonClicked;

        public ICommand ButtonClickCommand
        {
            get { return this.ButtonClicked; }
        }
    }
}

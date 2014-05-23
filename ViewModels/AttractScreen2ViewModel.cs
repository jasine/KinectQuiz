using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xaml;
using Microsoft.Samples.Kinect.InteractionGallery.Models;
using Microsoft.Samples.Kinect.InteractionGallery.Navigation;
using Microsoft.Samples.Kinect.InteractionGallery.Utilities;

namespace Microsoft.Samples.Kinect.InteractionGallery.ViewModels
{
    [ExportNavigable(NavigableContextName = DefaultNavigableContexts.AttractScreen2)]

    class AttractScreen2ViewModel:ViewModelBase
    {
        internal const string DefaultAttractScreen2ModelContent = "Content/AttractScreen2/AttractScreen2Content.xaml";
        internal const double strenthRatio=0.35;//change here to change the img height
        internal const double amnitRatio = 50;//change here to change the speed of the anmition,the biger the slower
        

        private double imgWidth;
        public double ImgWidth
        {
            get { return imgWidth; }
            set
            {
                imgWidth = value; 
                this.OnPropertyChanged("ImgWidth");
            }
        }

        private double imgHeight;

        public double ImgHeight
        {
            get { return imgHeight; }
            set
            {
                imgHeight = value; 
                OnPropertyChanged("ImgHeight");
            }
        }


        private double toLeftLen;

        public double ToLeftLen
        {
            get { return toLeftLen; }
            set
            {
                toLeftLen = value;
                this.OnPropertyChanged("ToLeftLen");
            }
        }

        private double toRightLen;

        public double ToRightLen
        {
            get { return toRightLen; }
            set
            {
                toRightLen = value;
                this.OnPropertyChanged("ToRightLen");
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
        


        private ImageSource backgroundImage;

        public ImageSource BackgroundImage
        {
            get { return backgroundImage; }
            set
            {
                backgroundImage = value; 
                OnPropertyChanged("BackgroundImage");
            }
        }


        private ImageSource coverImage;

        public ImageSource CoverImage
        {
            get { return coverImage; }
            set
            {
                coverImage = value;
                OnPropertyChanged("CoverImage");
            }
        }


          

        /// <summary>
        /// Initializes a new instance of the AttractScreenViewModel class that loads model content from the given Uri
        /// </summary>
        public AttractScreen2ViewModel()
            : base()
        {
            
            BackgroundImage = new BitmapImage(PackUriHelper.CreatePackUri("/Content/AttractScreen2/background.png"));
            CoverImage = new BitmapImage(PackUriHelper.CreatePackUri("/Content/AttractScreen2/cover.png"));
            ImgHeight = SystemParameters.FullPrimaryScreenHeight*strenthRatio;
            ImgWidth = (ImgHeight/CoverImage.Height)*CoverImage.Width;

            toRightLen = (ImgWidth - SystemParameters.FullPrimaryScreenWidth);
            ToLeftLen = -ToRightLen;

            AnmitTime = TimeSpan.FromSeconds((ImgHeight/CoverImage.Height)*amnitRatio);
        
        }


      
        
    }
}

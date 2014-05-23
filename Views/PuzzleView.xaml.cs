using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Samples.Kinect.InteractionGallery.Controls;

namespace Microsoft.Samples.Kinect.InteractionGallery.Views
{
    /// <summary>
    /// PuzzleView.xaml 的交互逻辑
    /// </summary>
    public partial class PuzzleView : UserControl
    {


        private PuzzleGrid _puzzleGrid;
        private UIElement _elementToChopUp;
        private Size _puzzleSize;
        private bool _stylingPuzzle;
        private int _numRows=3;


        public PuzzleView()
        {
            InitializeComponent();

            _stylingPuzzle = true;
            Image masterImage = (Image)this.Resources["TableImage"];
            _elementToChopUp = masterImage;
            BitmapSource bitmap = (BitmapSource)masterImage.Source;
            _puzzleSize = new Size(bitmap.PixelWidth / 1.5, bitmap.PixelHeight / 1.5);

            NewPuzzleGrid();

        }


        




        private void OnMoveMade(object sender, HandledEventArgs e)
        {
            // Blur or unblur based on whether the move was a valid one.
            BlurEffect blur = new BlurEffect();
            blur.Radius = 2;
            //BlurBitmapEffect blur = (BlurBitmapEffect)ControlPanel.BitmapEffect;
            //ControlPanel.Effect.SetValue();
            ControlPanel.Effect = blur;
            if (blur != null)
            {
                if (e.Handled)
                {
                    if (blur.Radius >= 2.0)
                    {
                        blur.Radius -= 2.0;
                    }
                    StatusLabel.Content = "";
                }
                else
                {
                    blur.Radius += 2.0;
                    StatusLabel.Content = "Bad Move!";
                }
            }
        }


        private void NewPuzzleGrid()
        {
            if (_puzzleGrid != null)
            {
                PuzzleHostingPanel.Children.Remove(_puzzleGrid);
            }
            _puzzleGrid = new PuzzleGrid();
            _puzzleGrid.PuzzleWon += delegate(object sender, EventArgs e)
            {
                StatusLabel.Content = "Got it!!!";
            };

            _puzzleGrid.MoveMade += new EventHandler<HandledEventArgs>(OnMoveMade);

            _puzzleGrid.IsApplyingStyle = _stylingPuzzle;
            _puzzleGrid.NumRows = 3;

            _puzzleGrid.ElementToChopUp = _elementToChopUp;
            _puzzleGrid.PuzzleSize = _puzzleSize;

            _puzzleGrid.ShowNumbers(false);

            _puzzleGrid.ShouldAnimateInteractions = true;

            PuzzleHostingPanel.Children.Add(_puzzleGrid);
            StatusLabel.Content = "New " + _numRows + "x" + _numRows + " game";
        }

        #region Less Consequential Event Handlers

        private void OnMixUp(object sender, RoutedEventArgs e)
        {
            _puzzleGrid.MixUpPuzzle();

            
        }

        private void OnResetPuzzle(object sender, RoutedEventArgs e)
        {
            NewPuzzleGrid();
        }

        

        #endregion

    }


}

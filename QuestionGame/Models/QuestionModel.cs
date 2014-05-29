using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Microsoft.Samples.Kinect.InteractionGallery.Models
{
    public class QuestionModel
    {
        public enum QuestionType
        {
            TextOnly,
            TitleWithImage,
            ChoiceWithImage
        }

        
        public string Title { get; set; }

        public  QuestionType Type { get; set; }
        public int  RightChoiceIndex { get; set; }

        public int ChoiceCount { get; private set; }

        public BitmapImage AttachImage { get; set; }

        public string ExplainText { get; set; }

        private List<QuestionChoiceModel> answers;

        public List<QuestionChoiceModel> Answers
        {
            get { return answers; }
            set
            {
                answers = value;
                ChoiceCount = value.Count;
            }
        }


        
    }

    
}

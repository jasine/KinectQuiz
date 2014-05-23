using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.InteractionGallery.Models
{
    public class QuestionModel
    {
        public string Title { get; set; }

        public int  RightChoiceIndex { get; set; }

        public int ChoiceCount { get; private set; }

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

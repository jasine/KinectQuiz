using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Samples.Kinect.InteractionGallery.Models;

namespace Microsoft.Samples.Kinect.InteractionGallery.Services
{
    public interface IQuestionDataService
    {
        List<QuestionModel>  GetAllQuestions();
    }
}

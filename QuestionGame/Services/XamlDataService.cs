using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xaml;
using Microsoft.Samples.Kinect.InteractionGallery.Models;
using Microsoft.Samples.Kinect.InteractionGallery.Utilities;

namespace Microsoft.Samples.Kinect.InteractionGallery.Services
{
    public class XamlDataService:IQuestionDataService
    {
        internal const string DefaultQuestionScreenModelContent = "Content/QuestionScreen/QustionScreenContent.xaml";
      

        public List<QuestionModel> GetAllQuestions()
        {
            Uri patUri = PackUriHelper.CreatePackUri(DefaultQuestionScreenModelContent);
            List<QuestionModel> Questions = new List<QuestionModel>();

            using (Stream questionModelsStream = Application.GetResourceStream(patUri).Stream)
            {
                Questions = XamlServices.Load(questionModelsStream) as List<QuestionModel>;
            }
            if (Questions == null)
            {
                throw new NullReferenceException("未找到问题列表或问题列表格式错误");
            }
            return Questions;
        }
    }
}

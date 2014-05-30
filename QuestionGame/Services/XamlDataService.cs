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
        internal const string DefaultQuestionScreenModelContent = "pack://siteoforigin:,,,/Questions/QuestionList.xaml";
      

        public List<QuestionModel> GetAllQuestions()
        {
            Uri patUri = new Uri(DefaultQuestionScreenModelContent);// PackUriHelper.CreatePackUri(DefaultQuestionScreenModelContent);
            List<QuestionModel> Questions = new List<QuestionModel>();
            FileStream fs = new FileStream("Questions/QuestionList.xaml", FileMode.Open);

            //using (Stream questionModelsStream = Application.GetResourceStream(patUri).Stream)
            using (Stream questionModelsStream =fs)
            {

                try
                {
                    Questions = XamlServices.Load(questionModelsStream) as List<QuestionModel>;

                }
                catch (Exception)
                {
                    new Exception("无法加载问题列表或列表格式错误");
                }
            }
            if (Questions == null)
            {
                throw new NullReferenceException("未找到问题列表或问题列表格式错误");
            }
            return Questions;
        }
    }
}

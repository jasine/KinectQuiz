using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Microsoft.Samples.Kinect.InteractionGallery.Services
{
    class XmlCountService:IEachTimeQuestionCount
    {

        public int GetCount()
        {
            string xmlFileName = System.IO.Path.Combine(Environment.CurrentDirectory, @"app.config");
            XDocument xDoc = XDocument.Load(xmlFileName);
            int count;
            if(!(int.TryParse(xDoc.Descendants("configuration").Descendants("appSettings").Descendants("add").ElementAt(0).LastAttribute.Value,out count)))
            {
                throw new Exception("配置文件错误，请修改app.config文件");
            }
            return count;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Tridion.EventHandlers.AssemblyUpload.Model
{
    class ParameterSchema
    {
        private String ResourceName { get; set; }
        private String Content { get; set; }

        public String Title {
            get
            {
                return Regex.Match(ResourceName, @"[\w ]*(?=\.xsd$)").Value;
            }
        }

        public XmlElement Xsd
        {
            get
            {
                var doc = new XmlDocument();
                doc.LoadXml(Content);
                return doc.DocumentElement;
            }
        }

        public ParameterSchema(string resourceName, string content)
        {
            ResourceName = resourceName;
            Content = content;
        }
    }
}

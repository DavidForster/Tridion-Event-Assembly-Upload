using System;
using Tridion.ContentManager.Templating;
using Tridion.ContentManager.Templating.Assembly;

namespace DavidForster.Tridion.EventHandlers.AssemblyUpload.TestTemplates
{
    [TcmTemplateTitle("Template With Title Attribute Specified")]
    public class TemplateWithTitleAttributeSpecified : ITemplate
    {
        public void Transform(Engine engine, Package package)
        {
            throw new NotImplementedException();
        }
    }
}

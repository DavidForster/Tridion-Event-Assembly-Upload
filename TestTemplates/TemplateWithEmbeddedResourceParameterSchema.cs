using System;
using Tridion.ContentManager.Templating;
using Tridion.ContentManager.Templating.Assembly;

namespace DavidForster.Tridion.EventHandlers.AssemblyUpload.TestTemplates
{
    [TcmTemplateParameterSchema("source:DavidForster.Tridion.EventHandlers.AssemblyUpload.TestTemplates.ParameterSchemas.Embedded Resource Paramer Schema.xsd")]
    class TemplateWithEmbeddedResourceParameterSchema : ITemplate
    {
        public void Transform(Engine engine, Package package)
        {
            throw new NotImplementedException();
        }
    }
}

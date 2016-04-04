using System;
using Tridion.ContentManager.Templating;

namespace Tridion.EventHandlers.AssemblyUpload.TestTemplates
{
    public class ConcreteTemplate : AbstractTemplate
    {
        public override void Transform(Engine engine, Package package)
        {
            throw new NotImplementedException();
        }
    }
}

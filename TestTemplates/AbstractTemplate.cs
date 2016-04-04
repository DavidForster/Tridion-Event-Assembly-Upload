using Tridion.ContentManager.Templating;
using Tridion.ContentManager.Templating.Assembly;

namespace Tridion.EventHandlers.AssemblyUpload.TestTemplates
{
    public abstract class AbstractTemplate : ITemplate
    {
        public abstract void Transform(Engine engine, Package package);
    }
}

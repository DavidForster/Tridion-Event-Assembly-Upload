using Tridion.ContentManager.CommunicationManagement;

namespace Tridion.EventHandlers.AssemblyUpload
{
    static class ExtensionMethods
    {
        public static bool IsAssemblyTemplateBuildingBlock(this TemplateBuildingBlock templateBuildingBlock)
        {
            return templateBuildingBlock.TemplateType == TemplateTypes.AssemblyTemplate;
        }
    }
}

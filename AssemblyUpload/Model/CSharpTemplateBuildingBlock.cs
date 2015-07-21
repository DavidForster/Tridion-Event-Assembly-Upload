using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tridion.ContentManager.Templating.Assembly;

namespace DavidForster.Tridion.EventHandlers.AssemblyUpload.Model
{
    class CSharpTemplateBuildingBlock
    {
        public CSharpTemplateBuildingBlock(Type type)
        {
            Title = GetTitle(type);
            ClassName = type.FullName;
            ParameterSchema = GetParameterSchema(type);
        }

        private string GetParameterSchema(Type type)
        {
            var parameterSchemaAttribute = type.GetCustomAttribute<TcmTemplateParameterSchema>();
            return parameterSchemaAttribute != null ? parameterSchemaAttribute.ParameterSchema : null;
        }

        public String Title { get; private set; }
        public String ClassName { get; private set; }
        public String ParameterSchema { get; private set; }

        private static string GetTitle(Type type)
        {
            var titleAttribute = type.GetCustomAttribute<TcmTemplateTitle>();
            return titleAttribute == null ? type.Name : titleAttribute.Title;
        }

    }
}

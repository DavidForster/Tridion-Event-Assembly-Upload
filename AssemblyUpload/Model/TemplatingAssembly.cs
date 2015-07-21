using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Tridion.ContentManager.CommunicationManagement;
using Tridion.ContentManager.Templating.Assembly;

namespace DavidForster.Tridion.EventHandlers.AssemblyUpload.Model
{
    class TemplatingAssembly
    {
        private readonly Assembly _assembly;
        private IEnumerable<CSharpTemplateBuildingBlock> _buildingBlocks;
        private IEnumerable<ParameterSchema> _parameterSchemas;

        public String Id { get; private set; }

        public IEnumerable<CSharpTemplateBuildingBlock> CSharpTemplateBuildingBlocks {
            get { return _buildingBlocks ?? (_buildingBlocks = LoadBuildingBlocks()); }
        }

        public IEnumerable<ParameterSchema> EmbeddedParameterSchemas {
            get { return _parameterSchemas ?? (_parameterSchemas = LoadParameterSchemas()); }
        }

        public TemplatingAssembly(TemplateBuildingBlock templateBuildingBlock)
        {
            _assembly = Assembly.Load(templateBuildingBlock.BinaryContent.GetByteArray());
            Id = templateBuildingBlock.Id;
        }

        private IEnumerable<CSharpTemplateBuildingBlock> LoadBuildingBlocks()
        {
            var buildingBlocks = new List<CSharpTemplateBuildingBlock>();

            foreach (var type in _assembly.GetTypes())
            {
                if (type.IsAbstract)
                    continue;

                if (!(type.GetInterfaces().Contains(typeof(ITemplate))))
                    continue;

                buildingBlocks.Add(new CSharpTemplateBuildingBlock(type));
            }

            return buildingBlocks;
        }

        private IEnumerable<ParameterSchema> LoadParameterSchemas()
        {
            var parameterSchemas = new List<ParameterSchema>();

            foreach (var cSharpTemplateBuildingBlock in CSharpTemplateBuildingBlocks)
            {
                if (cSharpTemplateBuildingBlock.ParameterSchema != null && cSharpTemplateBuildingBlock.ParameterSchema.ToLower().StartsWith("resource:"))
                {
                    var resourceName = cSharpTemplateBuildingBlock.ParameterSchema.Replace("resource:", "");

                    using (var stream = _assembly.GetManifestResourceStream(resourceName))
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var result = reader.ReadToEnd();
                            parameterSchemas.Add(new ParameterSchema(resourceName, result));
                        }
                    }
                }
            }

            return parameterSchemas;
        }
    }
}

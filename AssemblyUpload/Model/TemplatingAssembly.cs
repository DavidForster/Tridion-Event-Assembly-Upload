using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tridion.ContentManager.CommunicationManagement;
using Tridion.ContentManager.Templating.Assembly;

namespace DavidForster.Tridion.EventHandlers.AssemblyUpload.Model
{
    class TemplatingAssembly
    {
        private readonly Assembly _assembly;
        private List<CSharpTemplateBuildingBlock> _buildingBlocks;

        public TemplatingAssembly(TemplateBuildingBlock templateBuildingBlock)
        {
            _assembly = Assembly.Load(templateBuildingBlock.BinaryContent.GetByteArray());
            Id = templateBuildingBlock.Id;
        }

        public String Id { get; private set; }

        public IEnumerable<CSharpTemplateBuildingBlock> CSharpTemplateBuildingBlocks {
            get
            {
                if (_buildingBlocks == null)
                {
                    LoadBuildingBlocks();
                }
                return _buildingBlocks;
            }
        }

        private void LoadBuildingBlocks()
        {
            _buildingBlocks = new List<CSharpTemplateBuildingBlock>();

            foreach (var type in _assembly.GetTypes())
            {
                //If the class is not concrete
                if (type.IsAbstract)
                    continue;

                //If the class does not implement ITemplate
                if (!(type.GetInterfaces().Contains(typeof(ITemplate))))
                    continue;

                _buildingBlocks.Add(new CSharpTemplateBuildingBlock(type));
            }
        }
    }
}

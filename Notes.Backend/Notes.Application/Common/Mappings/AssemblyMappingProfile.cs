using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Notes.Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assemby) => ApplyMappingFromAssembly(assemby);

        private List<Type> SearchTypesForMapping(Assembly assembly) => assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

        private void ApplyMappingFromAssembly(Assembly assembly)
        {
            var types = SearchTypesForMapping(assembly);

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}

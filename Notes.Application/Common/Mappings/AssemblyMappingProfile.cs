﻿using AutoMapper;
using System.Reflection;

namespace Notes.Application.Common.Mappings
{
    public class AssemblyMappingProfile:Profile
    {
        public AssemblyMappingProfile(Assembly assembly) => ApplyMappingFromAssebly(assembly);

        private void ApplyMappingFromAssebly(Assembly assembly)
        {
            //Получение списка всех классов сборки, которые реализуют интерфейс IMapWith<T>
            var types = assembly.GetExportedTypes().Where(type => type.GetInterfaces()
            .Any(i=>i.IsGenericType && 
            i.GetGenericTypeDefinition() == typeof(IMapWith<>))).ToList();
            
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type); //Что-то типа "a = new ()"
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] {this});
            }
        }
    }
}

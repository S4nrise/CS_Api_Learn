using AutoMapper;

namespace Notes.Application.Common.Mappings
{
    public interface IMapWith<T>
    {
        //Создает конфигурацию из типа Т и предназначения
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}

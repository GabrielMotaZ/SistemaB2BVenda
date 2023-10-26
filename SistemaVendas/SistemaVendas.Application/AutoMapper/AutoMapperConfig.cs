using AutoMapper;

namespace SistemaVendas.AutoMapper
{
    public class AutoMapperConfig 
    {
        public static void RegisterMappings()
        {
            //Mapper.Initialize(x =>
            //{
            //    x.AddProfile<DomainToViewModelMappingProfile>();
            //    x.AddProfile<ViewModelToDomainMappingProfile>();
            //});


            var configuration = new MapperConfiguration(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                

            });


        }
    }
}

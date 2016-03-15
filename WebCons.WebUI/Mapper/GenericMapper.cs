
namespace Cruisenet.Audit.Mit.Web.Mapper
{
    using AutoMapper;
  

    internal static class GenericMapperExtensions
    {
        static GenericMapperExtensions()
        {

        }

        internal static T ToEntity<TViewModel, T>(this TViewModel tViewModel)
            where T : class
            where TViewModel : class
        {

            Mapper.CreateMap<TViewModel, T>();

            return Mapper.Map<TViewModel, T>(tViewModel);
        }


        internal static TViewModel ToViewModel<T, TViewModel>(this T entity) where T : class
        {
            Mapper.CreateMap<T, TViewModel>();
            return Mapper.Map<T, TViewModel>(entity);
        }


        internal static T UpdateFromViewModel<T, TViewModel>(this T entity, TViewModel viewModel)
            where T : class
            where TViewModel : class
        {
            Mapper.CreateMap<TViewModel, T>();
            return Mapper.Map(viewModel, entity);
        }

    }

}
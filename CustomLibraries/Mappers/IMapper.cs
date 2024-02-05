namespace CustomLibraries.Mappers
{
    public interface IMapper
    {
        TDto ToDto<TDto>(object entity);
        TEntity ToEntity<TEntity>(object dto);
        IEnumerable<TDto> ToDtoList<TDto>(IEnumerable<object> entityList);
        IEnumerable<TEntity> ToEntityList<TEntity>(IEnumerable<object> dtoList);
        void DiscardProperties(IEnumerable<string> propertyNames);
    }
}

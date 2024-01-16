namespace ApplicationCore.Mappers
{
    public interface IMapper
    {
        TDto ToDto<TDto>(object entity);
        TEntity ToEntity<TEntity>(object dto);
    }
}

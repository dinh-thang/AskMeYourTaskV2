namespace ApplicationCore.Mappers
{
    public interface IMapper
    {
        /// <summary>
        /// Map the input entity to a new DTO object of type TDto. The properties with similar name in the DTO and the entity will be mapped
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="entity"></param>
        /// <returns>Return a new DTO based on the input entity state</returns>
        TDto ToDto<TDto>(object entity);
        TEntity ToEntity<TEntity>(object dto);
        IEnumerable<TDto> ToDtoList<TDto>(IEnumerable<object> entityList);
        IEnumerable<TEntity> ToEntityList<TEntity>(IEnumerable<object> dtoList);

        /// <summary>
        /// Remove the selected property/properties from the mapping process. The scrObject is the object that contains the properties specified.
        /// </summary>
        /// <param name="propertyNames"></param>
        /// <param name="srcObject"></param>
        void DiscardProperties(IEnumerable<string> propertyNames);
    }
}

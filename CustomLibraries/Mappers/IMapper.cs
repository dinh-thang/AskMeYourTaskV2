namespace CustomLibraries.Mappers
{
    public interface IMapper
    {
        /// <summary>
        /// Convert an entity to a DTO. Properties with similar names are mapped.
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="srcEntity"></param>
        /// <returns>The result DTO.</returns>
        /// <exception cref="PropertyNotFoundException"></exception>
        TDto ToDto<TDto>(object entity);

        /// <summary>
        /// Convert a DTO to an entity. Properties with similar names are mapped.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="srcDto"></param>
        /// <returns>The result entity.</returns>
        /// <exception cref="PropertyNotFoundException"></exception>
        TEntity ToEntity<TEntity>(object dto);

        /// <summary>
        /// Convert an enumerable of entities to an enumerable of DTOs. 
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="entityList"></param>
        /// <returns>An enumerable of DTOs.</returns>
        IEnumerable<TDto> ToDtoList<TDto>(IEnumerable<object> entityList);

        /// <summary>
        /// Convert an enumerable of DTOs to an enumerable of entities. 
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="entityList"></param>
        /// <returns>An enumerable of entities.</returns>
        IEnumerable<TEntity> ToEntityList<TEntity>(IEnumerable<object> dtoList);

        /// <summary>
        /// Discard a property (properties) from being mapped.
        /// </summary>
        /// <param name="propertyNames"></param>
        void DiscardProperties(IEnumerable<string> propertyNames);
    }
}

using ApplicationCore.Exceptions;
using System.Reflection;

namespace ApplicationCore.Mappers
{
    /// <summary>
    /// A DTO - entity 2 ways mapper. The properties are automatically mapped if their names and types are similar. For example, "Title" prop's value in entity a will be mapped to "Title" prop in DTO b.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Mapper : IMapper
    {
        private List<string> _discardedProps;
        private List<PropertyInfo> _dtoProps;
        private List<PropertyInfo> _entityProps;

        public Mapper()
        {
            _discardedProps = new List<string>();
            _dtoProps = new List<PropertyInfo>();
            _entityProps = new List<PropertyInfo>();
        }

        public TDto ToDto<TDto>(object srcEntity)
        {
            PropertyInfo currentDtoProp;
            PropertyInfo currentEntityProp;
            Type dtoType = typeof(TDto);
            // Get the constructor of the given type. Can't be null since every object has a default constructor.
            ConstructorInfo dtoConstructor = dtoType.GetConstructor(Type.EmptyTypes)!;

            // Create a new object of type TDto. The constructor above is invoked, new, object[0] is the default value for a parameterless ctor.
            object dtoObject = dtoConstructor.Invoke(new object[0]);
            
            // Get all props in the TDto type.
            _dtoProps = dtoType.GetProperties().ToList();

            for (int i = 0; i < _dtoProps.Count; i++)
            {
                // current dto property
                currentDtoProp = _dtoProps[i];
                
                // cancel if the current property is discarded
                if (_discardedProps.Contains(currentDtoProp.Name))
                {
                    Console.WriteLine("true");
                    continue;
                }

                // get the corresponding property from the srcEntity
                var targetProp = srcEntity.GetType().GetProperty(currentDtoProp.Name);
                
                if (targetProp == null)
                {
                    throw new PropertyNotFoundException($"Couldn't find property name {currentDtoProp.Name} in {srcEntity.ToString}");
                }
                currentEntityProp = targetProp;


                // current entity value (nullable)
                var entityValue = currentEntityProp.GetValue(srcEntity);

                if (entityValue != null) 
                {
                    if (currentDtoProp.PropertyType != entityValue.GetType())
                    {
                        continue;
                    }
                }
                // set the value for the current prop of the dto
                currentDtoProp.SetValue(dtoObject, entityValue);
            }
            return (TDto)dtoObject;
        }


        public TEntity ToEntity<TEntity>(object srcDto)
        {
            PropertyInfo currentDtoProp;
            PropertyInfo currentEntityProp;
            Type dtoType = srcDto.GetType();
            Type entityType = typeof(TEntity);
            ConstructorInfo entityConstructor = entityType.GetConstructor(Type.EmptyTypes)!;

            object entity = entityConstructor.Invoke(new object[0]);

            // get all properties of the dto
            _dtoProps = dtoType.GetProperties().ToList();
            _entityProps = entityType.GetProperties().ToList();

            // loop for those types, assign the data from dto to the entity object
            for (int i = 0; i < _dtoProps.Count; i++) 
            {
                currentDtoProp = _dtoProps[i];
                
                // cancel if the current property is discarded
                if (_discardedProps.Contains(currentDtoProp.Name))
                {
                    continue;
                }

                // find the current property in the entity prop list
                var targetProp = _entityProps.FirstOrDefault(prop => prop.Name == currentDtoProp.Name);

                if (targetProp == null)
                {
                    throw new PropertyNotFoundException($"Couldn't find property name {currentDtoProp.Name} in {srcDto.ToString}");
                }
                currentEntityProp = targetProp;


                var dtoValue = currentDtoProp.GetValue(srcDto);

                if (currentEntityProp.CanWrite)
                {
                    if (dtoValue != null)
                    {
                        if (currentEntityProp.PropertyType != dtoValue.GetType())
                        {
                            continue;
                        }
                    }
                    currentEntityProp.SetValue(entity, dtoValue);
                }
            }
            return (TEntity)entity;
        }
        public IEnumerable<TDto> ToDtoList<TDto>(IEnumerable<object> entityList)
        {
            List<TDto> resultList = new List<TDto>();

            foreach (object entity in entityList) 
            {
                resultList.Add(ToDto<TDto>(entity));
            }
            return resultList;
        }

        public IEnumerable<TEntity> ToEntityList<TEntity>(IEnumerable<object> dtoList)
        {
            List<TEntity> resultList = new List<TEntity>();

            foreach (object dto in dtoList)
            {
                resultList.Add(ToDto<TEntity>(dto));
            }
            return resultList;
        }

        public void DiscardProperties(IEnumerable<string> propertyNames)
        {
            foreach (string prop in propertyNames) 
            {
                _discardedProps.Add(prop);
            }
        }

    }
}

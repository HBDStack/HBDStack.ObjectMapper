using Mapster;

namespace HBDStack.ObjectMapper.Mapster;

public abstract class BaseDto<TDto,TEntity>:IRegister
{
    private TypeAdapterConfig _config;
    public void Register(TypeAdapterConfig config)
    {
        _config = config;
        Config();
    }

    /// <summary>
    /// Config mapping for Dto to Entity
    /// </summary>
    /// <returns></returns>
    protected  TypeAdapterSetter<TDto,TEntity> ConfigDto() => _config.ForType<TDto, TEntity>();
    
    /// <summary>
    /// Config mapping for Entity to Dto
    /// </summary>
    /// <returns></returns>
    protected  TypeAdapterSetter<TEntity,TDto> ConfigEntity() => _config.ForType<TEntity, TDto>();
    
    protected abstract void Config();
}
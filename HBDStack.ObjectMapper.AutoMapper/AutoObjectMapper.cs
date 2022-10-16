

using System.Linq.Expressions;
using AutoMapper;
using HBDStack.ObjectMapper.Abstraction;

namespace HBDStack.ObjectMapper.AutoMapper;

internal class AutoObjectMapper:IObjectMapper
{
    private readonly IMapper _mapper;

    public AutoObjectMapper(IMapper mapper) => _mapper = mapper;

    public TDestination Map<TDestination>(object source) => _mapper.Map<TDestination>(source);

    public TDestination Map<TSource, TDestination>(TSource source)=> _mapper.Map<TSource,TDestination>(source);

    public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)=> _mapper.Map(source,destination);

    public object Map(object source, Type sourceType, Type destinationType)=> _mapper.Map(source,sourceType,destinationType);

    public object Map(object source, object destination, Type sourceType, Type destinationType)=> _mapper.Map(source,destination, sourceType,destinationType);

    public dynamic ConfigurationProvider => _mapper.ConfigurationProvider;
    
    public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source)
        => _mapper.ProjectTo(source,parameters: null, membersToExpand:Array.Empty<Expression<Func<TDestination, object>>>());
}
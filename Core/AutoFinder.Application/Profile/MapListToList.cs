using AutoMapper;

namespace AutoFinder.Application.Profile
{
    public class MappingListToList<TSource, TDestination>
    {
        private readonly IMapper _mapper;
        private static MappingListToList<TSource, TDestination>? _instance = null;
        public static MappingListToList<TSource, TDestination>? Instance
        {
            get { return _instance; }
        }

        public MappingListToList(IMapper mapper)
        {
            _mapper = mapper;
            _instance ??= this;
        }
        public List<TDestination> Convert(List<TSource> sourceList) => sourceList.Select(f => _mapper.Map<TDestination>(f)).ToList();
    }
}

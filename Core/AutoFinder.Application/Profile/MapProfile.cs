using AutoFinder.Application.DTO;
using AutoFinder.Domain.Entities;
using System.Globalization;

namespace AutoFinder.Application.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<RdwAutoModel, RdwAutoViewModel>()
                    //Property map example
                    .ForMember(d => d.Bouwjaar, s => s.MapFrom(src => GetDateTime(src.Datum_eerste_toelating_dt)));
        }

        private DateTime GetDateTime(string date)
        {
            string input = date;
            string[] formats = new string[] { "yyyy-MM-ddTHH:mm:ss.fff" };
            IFormatProvider provider = CultureInfo.InvariantCulture.DateTimeFormat;
            DateTime.TryParseExact(input, formats, provider, DateTimeStyles.None, out DateTime result);
            return result;
        }
    }
}

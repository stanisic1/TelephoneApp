using AutoMapper;

namespace TelephoneApp.Models
{
    public class TelephoneProfile : Profile
    {
        public TelephoneProfile()
        {
            CreateMap<Telephone, TelephoneDTO>();
        }
    }
}

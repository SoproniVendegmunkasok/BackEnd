using AutoMapper;
using GuestHibajelentesEvvegi.Models;

namespace GuestHibajelentesEvvegi.Data
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}

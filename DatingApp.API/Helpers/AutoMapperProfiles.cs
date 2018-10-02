using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForDetailedDto>()
                // Age
                .ForMember(dest => dest.Age, opt => {
                    opt.ResolveUsing(u => u.DateOfBirth.CalculateAge());
                })
                // PhotoUrl
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                });
            
            CreateMap<User, UserForListDto>()
                // Age
                .ForMember(dest => dest.Age, opt => {
                    opt.ResolveUsing(u => u.DateOfBirth.CalculateAge());
                })
                // PhotoUrl
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                });
            
            CreateMap<Photo, PhotosForDetailedDto>();

            // Unmapped members were found.
            // Age, PhotoUrl
        }
    }
}

// [UserForListDto]
// {
//     "id": 10,
//     "username": "melton",
//     "gender": "male",
//     "age": 0,
//     "knownAs": "Melton",
//     "created": "2017-06-20T00:00:00",
//     "lastActive": "2017-06-20T00:00:00",
//     "city": "Magnolia",
//     "country": "Grenada",
//     "photoUrl": null
// }

// [UserForDetailedDto]
// {
//     "id": 10,
//     "username": "melton",
//     "gender": "male",
//     "age": 0,
//     "knownAs": "Melton",
//     "created": "2017-06-20T00:00:00",
//     "lastActive": "2017-06-20T00:00:00",
//     "introduction": "Cillum aliqua id eiusmod culpa deserunt eiusmod enim ullamco qui id laboris. Occaecat reprehenderit elit consectetur sint sint est aliqua qui non officia irure. Sunt elit voluptate ex dolor. Nulla sint Lorem officia consectetur qui consectetur dolore dolor. Deserunt incididunt dolore id proident aute tempor qui.\r\n",
//     "lookingFor": "Aliqua consectetur sit proident eiusmod incididunt elit aliqua aliquip in occaecat id velit sint. Laboris ut consequat consectetur et qui incididunt non consectetur dolor. Reprehenderit incididunt occaecat in mollit eiusmod culpa exercitation laboris nulla id fugiat minim laboris. Nostrud elit deserunt reprehenderit elit id veniam esse. Enim tempor aliquip nostrud ad proident mollit. Eu anim elit pariatur adipisicing commodo ea enim dolor veniam fugiat dolor.\r\n",
//     "interests": "Et irure in irure consectetur adipisicing sint qui aute laboris.",
//     "city": "Magnolia",
//     "country": "Grenada",
//     "photoUrl": null,
//     "photos": [
//         {
//             "id": 10,
//             "url": "https://randomuser.me/api/portraits/men/92.jpg",
//             "description": "Ex dolore duis minim qui enim duis ea esse ullamco sint ipsum officia et nostrud.",
//             "dateAdded": "0001-01-01T00:00:00",
//             "isMain": true,
//             "user": {
//                 "id": 10,
//                 "username": "melton",
//                 "passwordHash": "xdiOJJWMnQ5Bh5ci8AKmh2g1yO8vhRWTpRzqf3Xh+RgVrlCMUFgxz5k0eQk4POW1no2dnFqN/RbJEshEwV4sew==",
//                 "passwordSalt": "UMN/tmvp+/hYszr0doPfHUOonaEwYwP0UGvC5ztMOahGPOeVMRQjNAhFvYtZgTcoTKgUzjyJRGAUefFmr9xAUuIWJT3CJFr6chHY+sDjEd+btiEO2SbbcPXiARv3zqhDGmdRAzuMUNrTb8M+KJyWwcYvx1VHl24EADkjr6OgbME=",
//                 "gender": "male",
//                 "dateOfBirth": "1987-12-19T00:00:00",
//                 "knownAs": "Melton",
//                 "created": "2017-06-20T00:00:00",
//                 "lastActive": "2017-06-20T00:00:00",
//                 "introduction": "Cillum aliqua id eiusmod culpa deserunt eiusmod enim ullamco qui id laboris. Occaecat reprehenderit elit consectetur sint sint est aliqua qui non officia irure. Sunt elit voluptate ex dolor. Nulla sint Lorem officia consectetur qui consectetur dolore dolor. Deserunt incididunt dolore id proident aute tempor qui.\r\n",
//                 "lookingFor": "Aliqua consectetur sit proident eiusmod incididunt elit aliqua aliquip in occaecat id velit sint. Laboris ut consequat consectetur et qui incididunt non consectetur dolor. Reprehenderit incididunt occaecat in mollit eiusmod culpa exercitation laboris nulla id fugiat minim laboris. Nostrud elit deserunt reprehenderit elit id veniam esse. Enim tempor aliquip nostrud ad proident mollit. Eu anim elit pariatur adipisicing commodo ea enim dolor veniam fugiat dolor.\r\n",
//                 "interests": "Et irure in irure consectetur adipisicing sint qui aute laboris.",
//                 "city": "Magnolia",
//                 "country": "Grenada",
//                 "photos": []
//             },
//             "userId": 10
//         }
//     ]
// }
using AirBnB.Api.Models.DTOs;
using AirBnB.Domain.Entities;
using AutoMapper;

namespace AirBnB.Api.Mappers;

/// <summary>
/// AutoMapper profile for mapping between AccessToken and AccessTokenDto.
/// </summary>
public class AccessTokenMapper : Profile
{
    /// <summary>
    /// Initializes a new instance of the AccessTokenMapper class and configures the mapping between AccessToken and AccessTokenDto.
    /// </summary>
    public AccessTokenMapper()
    {
        // Configure mapping from AccessToken to AccessTokenDto and enable reverse mapping.
        CreateMap<AccessToken, AccessTokenDto>().ReverseMap();
    }
}

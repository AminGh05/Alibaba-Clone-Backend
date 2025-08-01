﻿using AlibabaClone.Application.DTOs.CityDTOs;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Framework.Interfaces;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.LocationRepositories;
using AutoMapper;

namespace AlibabaClone.Application.Services
{
	public class CityService : ICityService
	{
		private readonly ICityRepository _cityRepository;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public CityService(ICityRepository cityRepository, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_cityRepository = cityRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<Result<IEnumerable<CityDto>>> GetCitiesAsync()
		{
			var result = await _cityRepository.GetAllAsync();

			if (result.Any())
			{
				var dto = _mapper.Map<IEnumerable<CityDto>>(result);
				return Result<IEnumerable<CityDto>>.Success(dto);
			}

			return Result<IEnumerable<CityDto>>.NotFound();
		}
	}
}

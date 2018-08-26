﻿using System.Collections.Generic;
using Tekus.Domain.Countries;

namespace Tekus.Application.Services.Contract
{
    public interface ICountriesServiceController
    {
        /// <summary>
        /// Returns all countries 
        /// </summary>
        /// <returns>List all countries</returns>
        IEnumerable<Country> GetCountries();

        /// <summary>
        /// Returns country that match with input parameter
        /// </summary>
        /// <param name="countryId">Country number</param>
        /// <returns>Country entity</returns>
        Country GetCountryById(int countryId);
    }
}

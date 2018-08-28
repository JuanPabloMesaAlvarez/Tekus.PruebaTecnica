﻿using System.Collections.Generic;
using Tekus.Domain.Countries;
using Tekus.Domain.Utils.Cache;

namespace Tekus.DomainServices.DomainServices.Contract
{
    public interface ICountriesServices : ICacheMode
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

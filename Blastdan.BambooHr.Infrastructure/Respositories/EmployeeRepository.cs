using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Blastdan.BambooHr.Infrastructure.Dto;
using Blastdan.Goals.Domain.Repositories;
using Blastdan.Goals.Domain.Models;
using Blastdan.BambooHr.Infrastructure.Extensions;

namespace Blastdan.BambooHr.Infrastructure.Respositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IHttpClientFactory httpFactory;
        private readonly HttpClient httpClient;
        public EmployeeRepository(IHttpClientFactory httpFactory)
        {
            this.httpFactory = httpFactory;
            this.httpClient = httpFactory.CreateClient(BambooHrConfiguration.Section);
        }

        /// <summary>
        /// Gets a simple user class based on who owns the API Key set during configuration
        /// </summary>
        /// <returns>The employee found</returns>
        /// <exception cref="HttpRequestException">When a non success status code is returned</exception>
        public async Task<Employee> GetApiKeyUser()
        {
            var response = await this.httpClient.GetAsync("employees/0/?fields=firstName%2ClastName");
            response.EnsureSuccessStatusCode();
            var dal = await response.Content.ReadFromJsonAsync<EmployeeDto>() ?? new EmployeeDto();
            return dal.ToEmployee();
        }
    }
}

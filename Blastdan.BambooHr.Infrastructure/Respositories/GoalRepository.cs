using System;
using System.Net.Http.Json;
using Blastdan.BambooHr.Infrastructure.Dto;
using Blastdan.Goals.Domain.Commands;
using MediatR;

namespace Blastdan.BambooHr.Infrastructure.Respositories
{
    public interface IGoalRepository
    {
        Task GetAllAggregateGoalInfo(long employeeId = 0);
    }

    public class GoalRepository : IGoalRepository
    {
        private readonly IHttpClientFactory httpFactory;
        private readonly IMediator mediator;
        private readonly HttpClient httpClient;
        public GoalRepository(IHttpClientFactory httpFactory, IMediator mediator)
        {
            this.httpFactory = httpFactory;
            this.mediator = mediator;
            this.httpClient = httpFactory.CreateClient(BambooHrConfiguration.Section);
        }

        public async Task GetAllAggregateGoalInfo(long employeeId = 0)
        {
            if (employeeId == 0)
            {
                var command = new SetCurrentUserCommand();
                employeeId = await mediator.Send(command);
            }

            var url = $"performance/employees/{employeeId}/goals/aggregate";

            var response = await this.httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var dal = await response.Content.ReadFromJsonAsync<AllAggregateGoalInfoDto>() ?? new AllAggregateGoalInfoDto();
        }
    }
}

using System.Net.Http.Json;
using Blastdan.BambooHr.Infrastructure.Dto;
using Blastdan.BambooHr.Infrastructure.Extensions;
using Blastdan.Goals.Domain.Commands;
using Blastdan.Goals.Domain.Models;
using Blastdan.Goals.Domain.Repositories;
using MediatR;

namespace Blastdan.BambooHr.Infrastructure.Respositories
{
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

        public async Task<Goal> Create(Goal goal)
        {
            var currentUser = await GetAndSetCurrentUser();
            var url = $"performance/employees/{currentUser}/goals";
            var request = new CreateGoalRequestDto(goal);
            var response = await httpClient.PostAsJsonAsync(url, request);

            response.EnsureSuccessStatusCode();

            var responseDto = await response.Content.ReadFromJsonAsync<CreateGoalResponseDto>() ?? new CreateGoalResponseDto();
            return responseDto.ToGoal();
        }

        public async Task<GoalSummaries> GetGoalSummaries(long employeeId = 0)
        {
            var dto = await GetAllAggregateGoalInfoRemote(employeeId);
            var employeesTasks = dto.Persons.Select(GetEmployeesFromPersonDto).ToArray();
            Task.WaitAll(employeesTasks);
            var employees = employeesTasks.Select(t => t.Result);
            var goals = dto.Goals.Select(g => g.ToGoal());

            return new GoalSummaries(goals, employees);
        }

        public async Task<IEnumerable<Goal>> GetAllAggregateGoalInfo(long employeeId = 0)
        {
            var dto = await GetAllAggregateGoalInfoRemote(employeeId);
            return dto.ToGoalList();
        }

        private async Task<AllAggregateGoalInfoDto> GetAllAggregateGoalInfoRemote(long employeeId)
        {
            employeeId = await GetAndSetCurrentUser(employeeId);

            var url = $"performance/employees/{employeeId}/goals/aggregate";

            var response = await this.httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var dto = await response.Content.ReadFromJsonAsync<AllAggregateGoalInfoDto>() ?? new AllAggregateGoalInfoDto();
            return dto;
        }

        private async Task<long> GetAndSetCurrentUser(long employeeId = 0)
        {
            if (employeeId == 0)
            {
                var command = new SetCurrentUserCommand();
                employeeId = await mediator.Send(command);
            }

            return employeeId;
        }

        private async Task<Employee> GetEmployeesFromPersonDto(PersonDto person)
        {
            var response = await this.httpClient.GetAsync(person.PhotoUrl);
            response.EnsureSuccessStatusCode();
            var image = await response.Content.ReadAsByteArrayAsync();

            return new Employee(person.EmployeeId, person.DisplayFirstName, person.LastName, image);
        }
    }
}

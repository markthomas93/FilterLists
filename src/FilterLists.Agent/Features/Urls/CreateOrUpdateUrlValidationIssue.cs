﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FilterLists.Agent.Core.Interfaces.Clients;
using FilterLists.Agent.Extensions;
using FilterLists.Agent.Features.Urls.Models.ValidationResults;
using MediatR;
using Octokit;

namespace FilterLists.Agent.Features.Urls
{
    public static class CreateOrUpdateUrlValidationIssue
    {
        public class Command : IRequest
        {
            public Command(IEnumerable<DataFileUrlValidationResults> dataFileUrlValidationResults)
            {
                DataFileUrlValidationResults = dataFileUrlValidationResults;
            }

            public IEnumerable<DataFileUrlValidationResults> DataFileUrlValidationResults { get; }
        }

        public class Handler : AsyncRequestHandler<Command>
        {
            private const string AgentBotLabel = "agent bot";
            private const string HelpWantedLabel = "help wanted";
            private const string DataLabel = "data";
            private const string IssueTitle = "BOT: url validation errors";
            private readonly IAgentGitHubClient _gitHubClient;
            private readonly IMediator _mediator;

            public Handler(IAgentGitHubClient agentGitHubClient, IMediator mediator)
            {
                _gitHubClient = agentGitHubClient;
                _mediator = mediator;
            }

            protected override async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var issue = await GetOpenIssueOrNull() ?? await CreateBaseIssue();
                await UpdateIssue(issue, request.DataFileUrlValidationResults, cancellationToken);
            }

            private async Task<Issue> GetOpenIssueOrNull()
            {
                var issueRequest = new RepositoryIssueRequest
                {
                    Filter = IssueFilter.All,
                    State = ItemStateFilter.Open,
                    Labels = {AgentBotLabel}
                };
                return (await _gitHubClient.GetAllIssuesAsync(issueRequest)).FirstOrDefault();
            }

            private async Task<Issue> CreateBaseIssue()
            {
                var newIssue = new NewIssue(IssueTitle);
                return await _gitHubClient.CreateIssueAsync(newIssue);
            }

            private async Task UpdateIssue(Issue issue,
                IEnumerable<DataFileUrlValidationResults> dataFileUrlValidationResults,
                CancellationToken cancellationToken)
            {
                var updateIssue = issue.ToUpdate();
                updateIssue.AddLabel(HelpWantedLabel);
                updateIssue.AddLabel(AgentBotLabel);
                updateIssue.AddLabel(DataLabel);
                updateIssue.Body = await _mediator.Send(new BuildGitHubIssueBody.Command(dataFileUrlValidationResults),
                    cancellationToken);
                await _gitHubClient.UpdateIssueAsync(issue.Number, updateIssue);
            }
        }
    }
}
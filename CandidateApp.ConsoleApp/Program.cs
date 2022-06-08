// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using CandidateApp.ConsoleApp.Brokers.Loggings;
using CandidateApp.ConsoleApp.Brokers.StorageBrokers;
using CandidateApp.ConsoleApp.Models.Candidate;
using CandidateApp.ConsoleApp.Services.Foundations.Candidates;
using Microsoft.Extensions.Logging;
using System;

namespace CandidateApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var storageBroker = new StorageBroker();
            var loggerFactory = new LoggerFactory();
            var logger = new Logger<LoggingBroker>(loggerFactory);
            var loggingBroker = new LoggingBroker(logger);
            var candidateService = new CandidateService(storageBroker,loggingBroker);

            var inputCandidate = new Candidate
            {
                Id = 21,
                FirstName = "gsgds",
                LastName = "ghkh"
            };

            candidateService.AddCandidate(inputCandidate);

        }
    }
}

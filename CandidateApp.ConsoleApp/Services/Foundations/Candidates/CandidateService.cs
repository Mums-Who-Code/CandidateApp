// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using CandidateApp.ConsoleApp.Brokers.Loggings;
using CandidateApp.ConsoleApp.Brokers.StorageBrokers;
using CandidateApp.ConsoleApp.Models.Candidate;

namespace CandidateApp.ConsoleApp.Services.Foundations.Candidates
{
    public partial class CandidateService : ICandidateService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public CandidateService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public Candidate AddCandidate(Candidate candidate) =>
        TryCatch(() =>
        {
            ValidateCandidate(candidate);

            return this.storageBroker.InsertCandidate(candidate);
        });
    }
}

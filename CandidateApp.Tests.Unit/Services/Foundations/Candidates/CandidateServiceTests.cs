// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using CandidateApp.ConsoleApp.Brokers.Loggings;
using CandidateApp.ConsoleApp.Brokers.StorageBrokers;
using CandidateApp.ConsoleApp.Models.Candidate;
using CandidateApp.ConsoleApp.Services.Foundations.Candidates;
using Moq;
using System;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using Xeptions;

namespace CandidateApp.Tests.Unit.Services.Foundations.Candidates
{
    public partial class CandidateServiceTests
    {
        private readonly ICandidateService candidateService;
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;

        public CandidateServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();
            this.candidateService = new CandidateService(
                this.storageBrokerMock.Object,
                this.loggingBrokerMock.Object);
        }
        private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException)
        {
            return actualException =>
                actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message
                && (actualException.InnerException as Xeption).DataEquals(expectedException.InnerException.Data);
        }

        private Candidate CreateRandomCandidate() =>
            CreateCandidateFiller().Create();

        private static Filler<Candidate> CreateCandidateFiller() =>
          new Filler<Candidate>();
    }
}

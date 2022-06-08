// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using CandidateApp.ConsoleApp.Models.Candidate;
using CandidateApp.ConsoleApp.Models.Candidates.Exceptions;
using Moq;
using System;
using Xunit;

namespace CandidateApp.Tests.Unit.Services.Foundations.Candidates
{
    public partial class CandidateServiceTests
    {
        [Fact]
        public void ShouldThrowServiceExceptionOnAddIfServiceErrorOccursAndLogIt()
        {
            //given
            Candidate someCandidate = CreateRandomCandidate();
            var serviceException = new Exception();

            var failedCandidateServiceException =
                new FailedCandidateServiceException(serviceException);

            var expectedCandidateServiceException =
                new CandidateServiceException(
                    failedCandidateServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertCandidate(It.IsAny<Candidate>()))
                       .Throws(serviceException);

            //when
            Action addCandidateAction = () => this.candidateService.AddCandidate(someCandidate);

            //then
            Assert.Throws<CandidateServiceException>(addCandidateAction);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertCandidate(It.IsAny<Candidate>()),
                Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                 broker.LogError(It.Is(SameExceptionAs(
                     expectedCandidateServiceException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}

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
        public void ShouldThrowValidationExceptionOnAddIfCandidateIsNullAndLogit()
        {
            //given
            Candidate nullCandidate = null;
            var nullCandidateException = new NullCandidateException();

            var expectedCandidateValidationException =
                new CandidateValidationException(nullCandidateException);

            //when
            Action addCandidateAction = () => this.candidateService.AddCandidate(nullCandidate);

            //then
            Assert.Throws<CandidateValidationException>(addCandidateAction);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                expectedCandidateValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertCandidate(It.IsAny<Candidate>()),
                Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void ShouldThrowValidationExceptionOnAddIfCandidateIsInvalidAndLogit(
            string invalidText)
        {

            // given
            Candidate invalidCandidate = new Candidate
            {
                FirstName = invalidText,
                LastName = invalidText,
            };

            var invalidCandidateException = new InvalidCandidateException();

            invalidCandidateException.AddData(
                key: nameof(Candidate.Id),
                values: "Id is required.");

            invalidCandidateException.AddData(
                key: nameof(Candidate.FirstName),
                values: "Text is required.");

            invalidCandidateException.AddData(
                key: nameof(Candidate.LastName),
                values: "Text is required.");

            var expectedCandidateValidationException =
                new CandidateValidationException(invalidCandidateException);

            // when
            Action addCandidateAction = () => this.candidateService.AddCandidate(invalidCandidate);

            // then
            Assert.Throws<CandidateValidationException>(addCandidateAction);

            this.loggingBrokerMock.Verify(broker =>
                 broker.LogError(It.Is(SameExceptionAs(
                 expectedCandidateValidationException))),
                     Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertCandidate(It.IsAny<Candidate>()),
                Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}

// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using CandidateApp.ConsoleApp.Models.Candidate;
using CandidateApp.ConsoleApp.Models.Candidates.Exceptions;
using System;
using Xeptions;

namespace CandidateApp.ConsoleApp.Services.Foundations.Candidates
{
    public partial class CandidateService
    {
        private delegate Candidate ReturningCandidateFunction();

        private Candidate TryCatch(ReturningCandidateFunction returningCandidateFunction)
        {
            try
            {
                return returningCandidateFunction();
            }
            catch (NullCandidateException nullCandidateException)
            {
                throw CreateAndLogValidationExcecption(nullCandidateException);
            }
            catch (InvalidCandidateException invalidCandidateException)
            {
                throw CreateAndLogValidationExcecption(invalidCandidateException);
            }
            catch(Exception exception)
            {
                var failedCandidateServiceException = 
                    new FailedCandidateServiceException(exception);

                throw CreateAndLogServiceException(failedCandidateServiceException);
            }
        }

        private CandidateValidationException CreateAndLogValidationExcecption(Xeption exception)
        {
            var candidateValidationException = new CandidateValidationException(exception);
            this.loggingBroker.LogError(candidateValidationException);

            return candidateValidationException;
        }

        private CandidateServiceException CreateAndLogServiceException(Xeption exception)
        {
            var candidateServiceException = new CandidateServiceException(exception);
            this.loggingBroker.LogError(candidateServiceException);

            return candidateServiceException;
        }
    }
}

// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using CandidateApp.ConsoleApp.Models.Candidate;
using CandidateApp.ConsoleApp.Models.Candidates.Exceptions;
using System;

namespace CandidateApp.ConsoleApp.Services.Foundations.Candidates
{
    public partial class CandidateService
    {
        private static void ValidateCandidate(Candidate candidate)
        {
            ValidateCandidateIsNotNull(candidate);

            Validate(
                (Rule: IsInvalid(candidate.Id), Parameter: nameof(Candidate.Id)),
                (Rule: IsInvalid(candidate.FirstName), Parameter: nameof(Candidate.FirstName)),
                (Rule: IsInvalid(candidate.LastName), Parameter: nameof(Candidate.LastName)));
        }

        private static dynamic IsInvalid(int id) => new
        {
            Condition = id == default,
            Message = "Id is required.",
        };

        private static dynamic IsInvalid(string name) => new
        {
            Condition = String.IsNullOrWhiteSpace(name),
            Message = "Text is required.",
        };


        private static void ValidateCandidateIsNotNull(Candidate candidate)
        {
            if (candidate == null)
            {
                throw new NullCandidateException();
            }
        }

        public static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidCandidateException = new InvalidCandidateException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidCandidateException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidCandidateException.ThrowIfContainsErrors();
        }
    }
}

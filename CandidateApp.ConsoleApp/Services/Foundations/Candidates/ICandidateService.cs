// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using CandidateApp.ConsoleApp.Models.Candidate;

namespace CandidateApp.ConsoleApp.Services.Foundations.Candidates
{
    public interface ICandidateService
    {
        Candidate AddCandidate(Candidate candidate);
    }
}

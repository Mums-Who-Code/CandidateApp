// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace CandidateApp.ConsoleApp.Models.Candidates.Exceptions
{
    public class InvalidCandidateException : Xeption
    {
        public InvalidCandidateException()
            : base("Candidate is invalid, fix the errors and try again.")
        { }
    }
}

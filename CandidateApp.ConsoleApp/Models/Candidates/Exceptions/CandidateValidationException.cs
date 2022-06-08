// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------
using Xeptions;

namespace CandidateApp.ConsoleApp.Models.Candidates.Exceptions
{
    public class CandidateValidationException : Xeption
    {
        public CandidateValidationException(Xeption innerException)
            : base(message: "Candidate validation error occured, fix the errors and try again.",
                  innerException)
        { }
    }
}

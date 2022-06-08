// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace CandidateApp.ConsoleApp.Models.Candidates.Exceptions
{
    public class NullCandidateException : Xeption
    {
        public NullCandidateException()
            : base(message: "Candidate is null ")
        { }
    }
}

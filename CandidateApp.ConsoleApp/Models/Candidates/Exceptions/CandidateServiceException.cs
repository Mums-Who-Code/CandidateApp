// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using Xeptions;

namespace CandidateApp.ConsoleApp.Models.Candidates.Exceptions
{
    public class CandidateServiceException : Xeption
    {
        public CandidateServiceException(Exception innerException)
            : base(message: "Candidate service exception error occurred, contact support.",
                 innerException)
        { }
    }
}

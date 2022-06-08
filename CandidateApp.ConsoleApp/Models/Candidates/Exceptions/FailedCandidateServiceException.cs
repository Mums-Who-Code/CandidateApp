// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using Xeptions;

namespace CandidateApp.ConsoleApp.Models.Candidates.Exceptions
{
    public class FailedCandidateServiceException : Xeption
    {
        public FailedCandidateServiceException(Exception innerException)
            : base(message: "Failed candidate service error occurred, contact support.",
                  innerException)
        { }
    }
}

// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using CandidateApp.ConsoleApp.Models.Candidate;
using System.Collections.Generic;

namespace CandidateApp.ConsoleApp.Brokers.StorageBrokers
{
    public partial interface IStorageBroker
    {
       Candidate InsertCandidate(Candidate candidate);

        List<Candidate> SelectAllCandidates();
    }
}

using System;

namespace ESoftPlus.Api.Queries
{
    public class BrowseCompanies : PagedQuery
    {
        public Guid UserId { get; }
    }
}
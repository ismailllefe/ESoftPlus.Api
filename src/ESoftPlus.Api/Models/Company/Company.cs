using System;
using System.Collections.Generic;

namespace ESoftPlus.Api.Models.Company
{
    public class Company
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Guid> UserIds { get; set; }
    }
}
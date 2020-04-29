using System;

namespace ESoftPlus.Api.Models.Country
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
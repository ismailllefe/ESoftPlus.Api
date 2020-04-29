using System;

namespace ESoftPlus.Api.Models.City
{
    public class City
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //test
    }
}
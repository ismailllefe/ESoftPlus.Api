using System;

namespace ESoftPlus.Api.Models.Field
{
    public class Field
    {
        public Guid CompanyId { get; set; }
        public Guid CityId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
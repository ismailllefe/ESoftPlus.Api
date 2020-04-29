using ESoftPlus.Common.Messages;
using Newtonsoft.Json;
using System;

namespace ESoftPlus.Api.Messages.Commands.Cities
{
    [MessageNamespace("fields")]
    public class UpdateField : ICommand
    {
        public Guid Id { get; }
        public Guid CompanyId { get; }
        public Guid CityId { get; }
        public string Code { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Latitude { get; }
        public decimal Longitude { get; }

        [JsonConstructor]
        public UpdateField(Guid id, Guid companyId, Guid cityId, string name, string description, decimal latitude, decimal longitude)
        {
            Id = id;
            CompanyId = companyId;
            CityId = cityId;
            Name = name;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
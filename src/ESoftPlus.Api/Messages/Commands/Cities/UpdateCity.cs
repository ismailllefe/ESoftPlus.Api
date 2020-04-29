using ESoftPlus.Common.Messages;
using Newtonsoft.Json;
using System;

namespace ESoftPlus.Api.Messages.Commands.Cities
{
    [MessageNamespace("cities")]
    public class UpdateCity : ICommand
    {
        public Guid Id { get; }
        public Guid CountryId { get; }
        public string Name { get; }
        public string Description { get; }

        [JsonConstructor]
        public UpdateCity(Guid id, Guid countryId, string name, string description)
        {
            Id = id;
            CountryId = countryId;
            Name = name;
            Description = description;
        }
    }
}
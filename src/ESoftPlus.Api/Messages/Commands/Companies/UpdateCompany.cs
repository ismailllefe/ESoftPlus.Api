using ESoftPlus.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ESoftPlus.Api.Messages.Commands.Companies
{
    [MessageNamespace("companies")]
    public class UpdateCompany : ICommand
    {
        public Guid Id { get; }
        public Guid CityId { get; }
        public string Name { get; }
        public string Description { get; }
        public List<Guid> UserIds { get; }

        [JsonConstructor]
        public UpdateCompany(Guid id, Guid cityId, string name, string description, List<Guid> userIds)
        {
            Id = id;
            CityId = cityId;
            Name = name;
            Description = description;
            UserIds = userIds;
        }
    }
}
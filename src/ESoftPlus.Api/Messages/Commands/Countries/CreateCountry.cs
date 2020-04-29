using ESoftPlus.Common.Messages;
using Newtonsoft.Json;
using System;

namespace ESoftPlus.Api.Messages.Commands.Countries
{
    [MessageNamespace("countries")]
    public class CreateCountry : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }

        [JsonConstructor]
        public CreateCountry(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
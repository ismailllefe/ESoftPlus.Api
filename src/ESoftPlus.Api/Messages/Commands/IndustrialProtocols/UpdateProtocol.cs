using ESoftPlus.Common.Messages;
using Newtonsoft.Json;
using System;

namespace ESoftPlus.Api.Messages.Commands.Cities
{
    [MessageNamespace("industrialProtocols")]
    public class UpdateIndustrialProtocol : ICommand
    {
        public Guid Id { get; }
        public string Code { get; }
        public string Name { get; }
        public string Description { get; }

        [JsonConstructor]
        public UpdateIndustrialProtocol(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
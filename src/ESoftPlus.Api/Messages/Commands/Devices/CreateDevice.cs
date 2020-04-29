using ESoftPlus.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ESoftPlus.Api.Messages.Commands.Devices
{
    [MessageNamespace("devices")]
    public class CreateDevice : ICommand
    {
        public Guid Id { get; }
        public Guid ParentDeviceId { get; }
        public Guid FieldId { get; }
        public string Code { get; }
        public string Name { get; }
        public string Description { get; }
        public List<Guid> Tags { get; }
        public Guid IndustrialProtocol { get; }

        [JsonConstructor]
        public CreateDevice(Guid id, Guid parentDeviceId, Guid fieldId, string code, string name, string description, List<Guid> tags, Guid industrialProtocol)
        {
            Id = id;
            ParentDeviceId = parentDeviceId;
            FieldId = fieldId;
            Code = code;
            Name = name;
            Description = description;
            Tags = tags;
            IndustrialProtocol = industrialProtocol;
        }
    }
}
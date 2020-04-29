using ESoftPlus.Common.Messages;
using Newtonsoft.Json;
using System;

namespace ESoftPlus.Api.Messages.Commands.Devices
{
    [MessageNamespace("devices")]
    public class DeleteDevice : ICommand
    {
        public Guid Id { get; }

        [JsonConstructor]
        public DeleteDevice(Guid id)
        {
            Id = id;
        }
    }
}
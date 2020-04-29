using ESoftPlus.Common.Messages;
using Newtonsoft.Json;
using System;

namespace ESoftPlus.Api.Messages.Commands.Cities
{
    [MessageNamespace("industrialProtocols")]
    public class DeleteIndustrialProtocol : ICommand
    {
        public Guid Id { get; }

        [JsonConstructor]
        public DeleteIndustrialProtocol(Guid id)
        {
            Id = id;
        }
    }
}
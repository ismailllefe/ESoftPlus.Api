using ESoftPlus.Common.Messages;
using Newtonsoft.Json;
using System;

namespace ESoftPlus.Api.Messages.Commands.Cities
{
    [MessageNamespace("fields")]
    public class DeleteField : ICommand
    {
        public Guid Id { get; }

        [JsonConstructor]
        public DeleteField(Guid id)
        {
            Id = id;
        }
    }
}
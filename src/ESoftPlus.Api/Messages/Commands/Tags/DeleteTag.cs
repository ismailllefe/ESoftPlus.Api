using ESoftPlus.Common.Messages;
using Newtonsoft.Json;
using System;

namespace ESoftPlus.Api.Messages.Commands.Cities
{
    [MessageNamespace("tags")]
    public class DeleteTag : ICommand
    {
        public Guid Id { get; }

        [JsonConstructor]
        public DeleteTag(Guid id)
        {
            Id = id;
        }
    }
}
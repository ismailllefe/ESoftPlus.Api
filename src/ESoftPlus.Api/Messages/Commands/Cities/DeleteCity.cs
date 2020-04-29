using ESoftPlus.Common.Messages;
using Newtonsoft.Json;
using System;

namespace ESoftPlus.Api.Messages.Commands.Cities
{
    [MessageNamespace("cities")]
    public class DeleteCity : ICommand
    {
        public Guid Id { get; }

        [JsonConstructor]
        public DeleteCity(Guid id)
        {
            Id = id;
        }
    }
}
using ESoftPlus.Common.Messages;
using Newtonsoft.Json;
using System;

namespace ESoftPlus.Api.Messages.Commands.Countries
{
    [MessageNamespace("countries")]
    public class DeleteCountry : ICommand
    {
        public Guid Id { get; }

        [JsonConstructor]
        public DeleteCountry(Guid id)
        {
            Id = id;
        }
    }
}
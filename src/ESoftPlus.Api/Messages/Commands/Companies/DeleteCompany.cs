using ESoftPlus.Common.Messages;
using Newtonsoft.Json;
using System;

namespace ESoftPlus.Api.Messages.Commands.Companies
{
    [MessageNamespace("companies")]
    public class DeleteCompany : ICommand
    {
        public Guid Id { get; }

        [JsonConstructor]
        public DeleteCompany(Guid id)
        {
            Id = id;
        }
    }
}
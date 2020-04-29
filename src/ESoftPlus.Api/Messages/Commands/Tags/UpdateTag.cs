using ESoftPlus.Common.Messages;
using Newtonsoft.Json;
using System;

namespace ESoftPlus.Api.Messages.Commands.Cities
{
    [MessageNamespace("tags")]
    public class UpdateTag : ICommand
    {
        public Guid Id { get; }
        public string Code { get; }
        public string Name { get; }
        public string Description { get; }
        public string Address { get; }
        public string Formula { get; }
        public string Unit { get; }

        [JsonConstructor]
        public UpdateTag(Guid id, string code, string name, string description, string address, string formula, string unit)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
            Address = address;
            Formula = formula;
            Unit = unit;
        }
    }
}
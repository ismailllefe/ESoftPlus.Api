using System;
using System.Collections.Generic;

namespace ESoftPlus.Api.Models.Device
{
    public class Device
    {
        public Guid ParentDeviceId { get; set; }
        public Guid FieldId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Guid> Tags { get; set; }
        public Guid IndustrialProtocol { get; set; }
    }
}
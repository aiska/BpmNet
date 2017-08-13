using System;

namespace BPMNET.EntityCore
{
    public interface IBaseElement
    {
        Guid Key { get; set; }
        string Id { get; set; }
        string Name { get; set; }
    }
}

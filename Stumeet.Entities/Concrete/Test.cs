using Stumeet.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stumeet.Entities.Concrete
{
    public class Test:IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}

namespace AutoHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoHub.Data.Common.Models;

    public class Make : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}

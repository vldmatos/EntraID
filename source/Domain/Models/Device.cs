using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Device
    {
        public string? Name { get; set; }

        public double Signal { get; set; }

        public void ChangeSignal()
        {
            Signal = Random.Shared.NextDouble();
        }
    }
}

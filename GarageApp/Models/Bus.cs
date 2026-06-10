using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApp.Models
{
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public Bus(
            string registrationNumber,
            string color,
            int numberOfWheels,
            int numberOfSeats)
            : base(registrationNumber, color, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApp.Models
{
    public class Car :Vehicle
    {
            public string FuelType { get; set; }

            public Car(
                string registrationNumber,
                string color,
                int numberOfWheels,
                string fuelType)
                : base(registrationNumber, color, numberOfWheels)
            {
                FuelType = fuelType;
            }
        }
    }


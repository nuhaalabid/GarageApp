using GarageApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GarageApp
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T?[] vehicles;
        public Garage(int capacity)
        {
            vehicles = new T?[capacity];
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    yield return vehicle;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Parkerar ett fordon i garaget.
        public bool Park(T vehicle)
        {
            //Kontrollera att registreringsnumret inte redan finns
            foreach (var existingVehicle in vehicles)
            {
                if (existingVehicle != null &&
                    existingVehicle.RegistrationNumber.Equals(
                        vehicle.RegistrationNumber,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
            // Hitta första lediga plats i garaget
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    return true;
                }
            }
            // Garaget är fullt
            return false;
        }
        public bool Remove(string registrationNumber)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] != null &&
                    vehicles[i].RegistrationNumber.Equals(
                        registrationNumber,
                        StringComparison.OrdinalIgnoreCase))
                {
                    vehicles[i] = null;
                    return true;
                }
            }
            return false;
        }
        // Hittar ett fordon via registreringsnummer.
        public T? FindByRegistrationNumber(string registrationNumber)
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null &&
                    vehicle.RegistrationNumber.Equals(
                        registrationNumber,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return vehicle;
                }
            }
            return null;
        }

        // Räknar hur många fordon av varje typ som finns i garaget
        public Dictionary<string, int> GetVehicleTypeCount()
        {
            Dictionary<string, int> vehicleTypes = new Dictionary<string, int>();

            foreach (var vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    string typeName = vehicle.GetType().Name;

                    if (vehicleTypes.ContainsKey(typeName))
                    {
                        vehicleTypes[typeName]++;
                    }
                    else
                    {
                        vehicleTypes[typeName] = 1;
                    }
                }
            }
            return vehicleTypes;
        }

        // Söker efter fordon baserat på färg och antal hjul
        public IEnumerable<T> Search(string color, int? numberOfWheels)
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    bool colorMatches = string.IsNullOrWhiteSpace(color) ||
                        vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase);

                    bool wheelsMatch = numberOfWheels == null ||
                        vehicle.NumberOfWheels == numberOfWheels;

                    if (colorMatches && wheelsMatch)
                    {
                        yield return vehicle;
                    }
                }

            }
        }
    }
}




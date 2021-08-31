namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GarageManager
    {
        private readonly Dictionary<string, GarageCustomer> r_GarageData;

        public GarageManager()
        {
            r_GarageData = new Dictionary<string, GarageCustomer>();
        }

        public enum eCarStatus
        {
            InFix,
            Fixed,
            Paid
        }

        public Dictionary<string, GarageCustomer> GarageData => r_GarageData;

        public bool AddVehicleToGarage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            bool success = false;

            GarageCustomer garageCustomer = new GarageCustomer(i_Vehicle, i_OwnerName, i_OwnerPhone);
            GarageData.Add(i_Vehicle.LicenseNumber, garageCustomer);

            if (GarageData.ContainsKey(i_Vehicle.LicenseNumber))
            {
                success = true;
            }

            return success;
        }

        public bool ChangeExistsCarStatus(string i_LicenseNumber)
        {
            bool success = false;
            GarageData[i_LicenseNumber].CarStatus = eCarStatus.InFix;
            if (GarageData[i_LicenseNumber].CarStatus == eCarStatus.InFix)
            {
                success = true;
            }

            return success;
        }

        public List<string> GetCarsLicenseNumbers()
        {
            List<string> licenseNumbers = new List<string>();

            Dictionary<string, GarageCustomer> garageData = GarageData;
            foreach (KeyValuePair<string, GarageCustomer> item in garageData)
            {
                licenseNumbers.Add(item.Key);
            }

            return licenseNumbers;
        }

        public List<string> GetCarsLicenseNumbersByStatus(eCarStatus i_CarStatus)
        {
            List<string> licenseNumbersFilter = new List<string>();

            Dictionary<string, GarageCustomer> garageData = GarageData;
            foreach (KeyValuePair<string, GarageCustomer> item in garageData)
            {
                if (item.Value.CarStatus == i_CarStatus)
                {
                    licenseNumbersFilter.Add(item.Key);
                }
            }

            return licenseNumbersFilter;
        }

        public bool ChangeVehicleStatus(string i_LicenseNumber, eCarStatus i_NewStatus)
        {
            bool success = false;
            GarageData[i_LicenseNumber].CarStatus = i_NewStatus;
            success = GarageData[i_LicenseNumber].CarStatus == i_NewStatus;
            return success;
        }

        public bool InflateAirToMax(string i_LicenseNumber)
        {
            List<Wheel> wheels = GarageData[i_LicenseNumber].Vehicle.Wheels;
            foreach (Wheel wheel in wheels)
            {
                float airToInflate = wheel.MaxAirPressure - wheel.CurrentAirPressure;
                if (airToInflate == 0)
                {
                    return false;
                }

                wheel.InflateAir(airToInflate);
            }

            return true;
        }

        public bool RefuelPetrolVehicle(string i_LicenseNumber, PetrolEngine.eFuelType i_FuelType, float i_FuelAmount)
        {
            bool success = false;

            Vehicle vehicle = GarageData[i_LicenseNumber].Vehicle;
            if (vehicle.EngineType is PetrolEngine petrolEngine)
            {
                if (petrolEngine.FuelType == i_FuelType)
                {
                    petrolEngine.Refuel(i_FuelAmount);
                    vehicle.RemainingEnergyPercentage =
                        (100 * petrolEngine.CurrentFuelAmount) / petrolEngine.MaxFuelCapacity;
                    success = true;
                }
                else
                {
                    throw new ArgumentException("Error! Fuel type not match");
                }
            }
            else
            {
                throw new ArgumentException("Error! You try to refuel an electric car");
            }

            return success;
        }

        public bool ChargingElectricVehicle(string i_LicenseNumber, float i_CountOfMinutes)
        {
            bool success = false;

            Vehicle vehicle = GarageData[i_LicenseNumber].Vehicle;
            if (vehicle.EngineType is ElectricEngine electricEngine)
            {
                electricEngine.BatteryCharge(i_CountOfMinutes / 60);
                vehicle.RemainingEnergyPercentage = (100 * electricEngine.RemainingBatteryTime)
                                                    / electricEngine.MaxBatteryTime;
                success = true;
            }
            else
            {
                throw new ArgumentException("Error! You try to charge an petrol car");
            }

            return success;
        }

        public StringBuilder GetVehicleFullInfo(string i_LicenseNumber)
        {
            StringBuilder vehicleDetails = new StringBuilder();

            GarageCustomer fullDetails = GarageData[i_LicenseNumber];

            vehicleDetails.Append(fullDetails);

            return vehicleDetails;
        }

        public bool IsCarExists(string i_LicenseNumber)
        {
            return GarageData.ContainsKey(i_LicenseNumber);
        }
    }
}
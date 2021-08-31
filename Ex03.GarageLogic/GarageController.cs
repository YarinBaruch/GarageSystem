namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GarageController
    {
        private readonly GarageManager r_GarageManager;

        public GarageController()
        {
            r_GarageManager = new GarageManager();
        }

        public GarageManager GarageManager => r_GarageManager;

        public bool AddVehicleToGarage(List<object> i_VehicleDataList, string i_VehicleType)
        {
            bool isSucceed = false;
            string ownerName = i_VehicleDataList[0].ToString();
            string ownerPhone = i_VehicleDataList[1].ToString();
            string licenseNumber = i_VehicleDataList[2].ToString();
            string modelName = i_VehicleDataList[3].ToString();
            string wheelManufacturer = i_VehicleDataList[4].ToString();
            string engineType = i_VehicleDataList[5].ToString();
            Engine.eEngineType engine;
            engine = engineType.Equals("Electric") ? Engine.eEngineType.Electric : Engine.eEngineType.Petrol;

            try
            {
                if (i_VehicleType.Contains("Car"))
                {
                    string color = i_VehicleDataList[6].ToString();
                    string numOfDoors = i_VehicleDataList[7].ToString();

                    Car.eColors carColor = (Car.eColors)Enum.Parse(typeof(Car.eColors), color);
                    Car.eDoorsNumber doorsNumber = (Car.eDoorsNumber)Enum.Parse(typeof(Car.eDoorsNumber), numOfDoors);

                    Car car = new Car(modelName, licenseNumber, engine, wheelManufacturer, doorsNumber, carColor);
                    isSucceed = r_GarageManager.AddVehicleToGarage(car, ownerName, ownerPhone);
                }

                if (i_VehicleType.Contains("Motorcycle"))
                {
                    string licenseType = i_VehicleDataList[6].ToString();
                    int engineCapacity = int.Parse(i_VehicleDataList[7].ToString());

                    Motorcycle.eLicenseType license = (Motorcycle.eLicenseType)Enum.Parse
                        (typeof(Motorcycle.eLicenseType), licenseType);

                    Motorcycle motorcycle = new Motorcycle(
                        modelName,
                        licenseNumber,
                        engine,
                        wheelManufacturer,
                        engineCapacity,
                        license);
                    isSucceed = r_GarageManager.AddVehicleToGarage(motorcycle, ownerName, ownerPhone);
                }

                if (i_VehicleType.Equals("Truck"))
                {
                    float cargoVolume = float.Parse(i_VehicleDataList[6].ToString());
                    bool isDangerousMaterials = bool.Parse(i_VehicleDataList[7].ToString());

                    Truck truck = new Truck(
                        modelName,
                        licenseNumber,
                        wheelManufacturer,
                        cargoVolume,
                        isDangerousMaterials);
                    isSucceed = r_GarageManager.AddVehicleToGarage(truck, ownerName, ownerPhone);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Parsing Error..");
            }

            return isSucceed;
        }

        public bool InflateAirToMax(string i_LicenseNumber)
        {
            return r_GarageManager.InflateAirToMax(i_LicenseNumber);
        }

        public List<string> GetCarsLicenseNumbers()
        {
            return r_GarageManager.GetCarsLicenseNumbers();
        }

        public List<string> GetCarsLicenseNumbersFilter(string i_Status)
        {
            GarageManager.eCarStatus status = (GarageManager.eCarStatus)Enum.Parse(typeof(GarageManager.eCarStatus), i_Status);
            return r_GarageManager.GetCarsLicenseNumbersByStatus(status);
        }

        public bool ChangeVehicleStatus(string i_LicenseNumber, string i_NewStatus)
        {
            GarageManager.eCarStatus status = (GarageManager.eCarStatus)Enum.Parse(typeof(GarageManager.eCarStatus), i_NewStatus);
            return r_GarageManager.ChangeVehicleStatus(i_LicenseNumber, status);
        }

        public bool RefuelPetrolVehicle(string i_LicenseNumber, string i_FuelType, float i_FuelAmount)
        {
            PetrolEngine.eFuelType fuelType = (PetrolEngine.eFuelType)Enum.Parse(typeof(PetrolEngine.eFuelType), i_FuelType);
            return r_GarageManager.RefuelPetrolVehicle(i_LicenseNumber, fuelType, i_FuelAmount);
        }

        public bool ChargingElectricVehicle(string i_LicenseNumber, float i_CountOfMinutes)
        {
            return r_GarageManager.ChargingElectricVehicle(i_LicenseNumber, i_CountOfMinutes);
        }

        public StringBuilder GetVehicleFullInfo(string i_LicenseNumber)
        {
            return r_GarageManager.GetVehicleFullInfo(i_LicenseNumber);
        }

        public bool ChangeExistsCarStatus(string i_LicenseNumber)
        {
            return GarageManager.ChangeExistsCarStatus(i_LicenseNumber);
        }

        public bool IsCarExists(string i_LicenseNumber)
        {
            return r_GarageManager.IsCarExists(i_LicenseNumber);
        }
    }
}
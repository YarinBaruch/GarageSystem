namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ex03.GarageLogic;
    
    public class ConsoleUtil
    {
        private readonly GarageController r_Controller;

        public ConsoleUtil(GarageController i_Controller)
        {
            r_Controller = i_Controller;
        }

        public GarageController Controller => r_Controller;

        public void ShowMainMenu()
        {
            string menu = string.Format($@"

                       WELCOME TO THE GARAGE SYSTEM

            ***************************************************

                              CHOOSE OPTION:

                1.   Add Vehicle To Garage
                2.   Get All Cars License Numbers
                3.   Change Vehicle Status
                4.   Inflate Air To Maximum
                5.   Refuel Petrol Vehicle
                6.   Charging Electric Vehicle
                7.   Get Vehicle Full Info
                8.   Exit

            ***************************************************");
            Console.WriteLine(menu);
        }

        public bool HandleUserChoice(int i_UserChoice)
        {
            bool exitKey = false;

            switch (i_UserChoice)
            {
                case 1:
                    AddVehicleToGarage();
                    break;
                case 2:
                    GetAllCarsLicenseNumbers();
                    break;
                case 3:
                    ChangeVehicleStatus();
                    break;
                case 4:
                    InflateAirToMax();
                    break;
                case 5:
                    RefuelPetrolVehicle();
                    break;
                case 6:
                    ChargingElectricVehicle();
                    break;
                case 7:
                    GetVehicleFullInfo();
                    break;
                default:
                    exitKey = true;
                    break;
            }

            return exitKey;
        }

        public void GetVehicleFullInfo()
        {
            string licenseNumber = GetNumericData("Enter license number: ");
            if (!r_Controller.IsCarExists(licenseNumber))
            {
                Console.WriteLine("This car is not exists in the garage ..");
            }
            else
            {
                StringBuilder vehicleFullData = new StringBuilder();
                vehicleFullData = r_Controller.GetVehicleFullInfo(licenseNumber);
                Console.WriteLine(vehicleFullData);
            }
        }

        public void ChargingElectricVehicle()
        {
            bool isSucceed = false;
            string licenseNumber = GetNumericData("Enter license number: ");
            if (!r_Controller.IsCarExists(licenseNumber))
            {
                Console.WriteLine("This car is not exists in the garage ..");
            }
            else
            {
                try
                {
                    float minutesCount = float.Parse(GetNumericData("Enter minutes to charge: "));
                    isSucceed = r_Controller.ChargingElectricVehicle(licenseNumber, minutesCount);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error in parse to float");
                }
                catch (ValueOutOfRangeException voore)
                {
                    Console.WriteLine(voore.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                Console.WriteLine(isSucceed
                    ? "The charging made successfully "
                    : "Error while charging the vehicle ");
            }
        }

        public void RefuelPetrolVehicle()
        {
            bool isSucceed = false;
            string licenseNumber = GetNumericData("Enter license number: ");
            if (!r_Controller.IsCarExists(licenseNumber))
            {
                Console.WriteLine("This car is not exists in the garage ..");
            }
            else
            {
                try
                {
                    string fuelType = GetFuelType();
                    float fuelAmount = float.Parse(GetNumericData("Enter Fuel Amount: "));
                    isSucceed = r_Controller.RefuelPetrolVehicle(licenseNumber, fuelType, fuelAmount);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error in parse to float");
                }
                catch (ValueOutOfRangeException voore)
                {
                    Console.WriteLine(voore.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                Console.WriteLine(isSucceed
                    ? "The refuel made successfully "
                    : "Error while refuel the vehicle ");
            }
        }

        public string GetFuelType()
        {
            string question = string.Format($@"
Choose Fuel Type:
1.   Octan98
2.   Octan96
3.   Octan95
4.   Soler");

            Console.WriteLine(question);
            GetUserOption(out int userChoice, 4);

            switch (userChoice)
            {
                case 1:
                    return "Octan98";
                case 2:
                    return "Octan96";
                case 3:
                    return "Octan95";
                default:
                    return "Soler";
            }
        }

        public void InflateAirToMax()
        {
            bool isSucceed = false;
            string licenseNumber = GetNumericData("Enter license number: ");
            if (!r_Controller.IsCarExists(licenseNumber))
            {
                Console.WriteLine("This car is not exists in the garage ..");
            }
            else
            {
                isSucceed = r_Controller.InflateAirToMax(licenseNumber);
            }

            Console.WriteLine(isSucceed
                ? "The wheels air was inflate to maximum .."
                : "The wheels are already inflated to maximum ..");
        }

        public void ChangeVehicleStatus()
        {
            string licenseNumber = GetNumericData("Enter license number: ");

            if (!r_Controller.IsCarExists(licenseNumber))
            {
                Console.WriteLine("This car is not exists in the garage ..");
            }
            else
            {
                string newStatus = GetCarStatus();
                bool isSucceed = r_Controller.ChangeVehicleStatus(licenseNumber, newStatus);

                if (isSucceed)
                {
                    Console.WriteLine("The car status was change successfully.");
                    Console.WriteLine("The new status is: {0}", newStatus);
                }
                else
                {
                    Console.WriteLine("There was a problem to change the car status..");
                }
            }
        }

        public void GetUserOption(out int i_Choice, int i_MaxRange)
        {
            bool isValid = false;
            i_Choice = 0;

            while (!isValid)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (input != null)
                    {
                        i_Choice = int.Parse(input);
                    }

                    if (i_Choice >= 1 && i_Choice <= i_MaxRange)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Range Error... Enter only number between 1-{0}", i_MaxRange);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input... Enter only number between 1-{0}", i_MaxRange);
                }
            }
        }

        public void AddVehicleToGarage()
        {
            string licenseNumber = GetNumericData("Enter Vehicle License Number: ");

            if (r_Controller.IsCarExists(licenseNumber))
            {
                Console.WriteLine("This car is already exists in the garage ..");
                bool successfullyModified = Controller.ChangeExistsCarStatus(licenseNumber);
                Console.WriteLine(successfullyModified
                    ? "The current status is: InFix"
                    : "The Car status change has failed ..");
            }
            else
            {
                string ownerPhone = GetNumericData("Enter The Owner Phone Number: ");
                string ownerName = GetStringFromUser("Enter The Owner Name: ");
                string modelName = GetStringFromUser("Enter Vehicle Model Name: ");
                string vehicleType = GetVehicleType();
                string engineType = "Petrol";
                string wheelManufacturer = GetStringFromUser("Enter Wheel Manufacturer Name: ");
                List<object> vehicleData = new List<object>
                {
                    ownerName,
                    ownerPhone,
                    licenseNumber,
                    modelName,
                    wheelManufacturer
                };

                if (vehicleType.Contains("Electric"))
                {
                    engineType = "Electric";
                }

                vehicleData.Add(engineType);

                if (vehicleType.Contains("Car"))
                {
                    string color = GetCarColor();
                    int numOfDoors = GetNumOfDoors();

                    vehicleData.Add(color);
                    vehicleData.Add(numOfDoors);
                }

                if (vehicleType.Contains("Motorcycle"))
                {
                    string licenseType = GetLicenseType();
                    string engineCapacity = GetNumericData("Enter Engine Capacity:");

                    vehicleData.Add(licenseType);
                    vehicleData.Add(engineCapacity);
                }

                if (vehicleType.Equals("Truck"))
                {
                    string cargoVolume = GetNumericData("Enter cargo volume: ");
                    bool isDangerousMaterials = GetYesNoAnswer(string.Format($@"
Is Dangerous Materials?
1.   Yes
2.   No"));
                    vehicleData.Add(cargoVolume);
                    vehicleData.Add(isDangerousMaterials);
                }

                bool added = r_Controller.AddVehicleToGarage(vehicleData, vehicleType);
                if (added)
                {
                    Console.WriteLine("The Vehicle Added Successfully");
                }
            }
        }

        public void GetAllCarsLicenseNumbers()
        {
            List<string> licenseNumbers = r_Controller.GetCarsLicenseNumbers();
            if (licenseNumbers.Count < 1)
            {
                Console.WriteLine("There is no cars in the garage..");
            }
            else
            {
                foreach (string number in licenseNumbers)
                {
                    Console.WriteLine(number);
                }

                bool toFilter = GetYesNoAnswer(string.Format($@"
Do You Want to Filter Data By Car Status?
1.   Yes
2.   No"));

                if (toFilter)
                {
                    string status = GetCarStatus();
                    licenseNumbers = r_Controller.GetCarsLicenseNumbersFilter(status);

                    if (licenseNumbers.Count < 1)
                    {
                        Console.WriteLine("There is no cars in the garage..");
                    }
                    else
                    {
                        foreach (string number in licenseNumbers)
                        {
                            Console.WriteLine(number);
                        }
                    }
                }
            }
        }

        public string GetCarStatus()
        {
            string question = string.Format($@"
Choose Status:
1.   InFix
2.   Fixed
3.   Paid");

            Console.WriteLine(question);
            GetUserOption(out int userChoice, 3);

            switch (userChoice)
            {
                case 1:
                    return "InFix";
                case 2:
                    return "Fixed";
                default:
                    return "Paid";
            }
        }

        public bool GetYesNoAnswer(string i_Question)
        {
            Console.WriteLine(i_Question);
            GetUserOption(out int userChoice, 2);

            switch (userChoice)
            {
                case 1:
                    return true;
                default:
                    return false;
            }
        }

        public string GetLicenseType()
        {
            string question = string.Format($@"
Choose License Type:
1.   A
2.   A1
3.   A2
4.   B");

            Console.WriteLine(question);
            GetUserOption(out int userChoice, 4);

            switch (userChoice)
            {
                case 1:
                    return "A";
                case 2:
                    return "A1";
                case 3:
                    return "A2";
                default:
                    return "B";
            }
        }

        public int GetNumOfDoors()
        {
            string question = string.Format($@"
Number of Doors:
1.   Two
2.   Three
3.   Four
4.   Five");

            Console.WriteLine(question);
            GetUserOption(out int userChoice, 4);

            switch (userChoice)
            {
                case 1:
                    return 2;
                case 2:
                    return 3;
                case 3:
                    return 4;
                default:
                    return 5;
            }
        }

        public string GetCarColor()
        {
            string question = string.Format($@"
Choose Car Color:
1.   Yellow
2.   White
3.   Black
4.   Blue");

            Console.WriteLine(question);
            GetUserOption(out int userChoice, 4);

            switch (userChoice)
            {
                case 1:
                    return "Yellow";
                case 2:
                    return "White";
                case 3:
                    return "Black";
                default:
                    return "Blue";
            }
        }

        public string GetStringFromUser(string i_Question)
        {
            bool isValid = false;
            string input = null;

            Console.WriteLine(i_Question);
            while (!isValid)
            {
                try
                {
                    input = Console.ReadLine();
                    if (input != null)
                    {
                        isValid = input.Length > 0;
                    }

                    if (!isValid)
                    {
                        Console.WriteLine("Name can't be empty...");
                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Name can't be empty...");
                }
            }

            return input;
        }

        public string GetNumericData(string i_Question)
        {
            bool isValid = false;
            string input = null;

            Console.WriteLine(i_Question);

            while (!isValid)
            {
                input = Console.ReadLine();
                if (NumbersValidation(input))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input ... Enter only numbers");
                }
            }

            return input;
        }

        public bool NumbersValidation(string i_NumberStr)
        {
            if (i_NumberStr.Length < 1)
            {
                return false;
            }

            foreach (char ch in i_NumberStr)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }

        public string GetVehicleType()
        {
            string question = string.Format($@"

Choose Vehicle Type:
1.   Car
2.   Electric Car
3.   Motorcycle
4.   Electric Motorcycle
5.   Truck ");

            Console.WriteLine(question);
            GetUserOption(out int userChoice, 5);

            switch (userChoice)
            {
                case 1:
                    return "Car";
                case 2:
                    return "ElectricCar";
                case 3:
                    return "Motorcycle";
                case 4:
                    return "ElectricMotorcycle";
                default:
                    return "Truck";
            }
        }
    }
}
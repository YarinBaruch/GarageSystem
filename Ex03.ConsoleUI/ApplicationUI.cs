namespace Ex03.ConsoleUI
{
    using System;
    using Ex03.GarageLogic;
    
    public class ApplicationUI
    {
        private readonly ConsoleUtil r_ConsoleUtil;
        private readonly GarageController r_Controller;

        public ApplicationUI()
        {
            r_Controller = new GarageController();
            r_ConsoleUtil = new ConsoleUtil(r_Controller);
            StartProgram();
        }

        public ConsoleUtil ConsoleUtil => r_ConsoleUtil;

        public void StartProgram()
        {
            bool exitKey = false;
            while (!exitKey)
            {
                r_ConsoleUtil.ShowMainMenu();
                r_ConsoleUtil.GetUserOption(out int userChoice, 8);
                exitKey = r_ConsoleUtil.HandleUserChoice(userChoice);
            }

            Console.WriteLine("Bye Bye!");
        }
    }
}

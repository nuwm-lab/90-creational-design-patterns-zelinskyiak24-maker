using System;

    
    class SmartHome
    {
        public void TurnOnLight()
        {
            Console.WriteLine("Світло увімкнено");
        }

        public void TurnOffLight()
        {
            Console.WriteLine("Світло вимкнено");
        }
    }

    
    interface ISmartHomeController
    {
        void ExecuteCommand(string command);
    }

    
    class SmsAdapter : ISmartHomeController
    {
        private SmartHome smartHome;

        public SmsAdapter(SmartHome smartHome)
        {
            this.smartHome = smartHome;
        }

        public void ExecuteCommand(string command)
        {
            if (command == "LIGHT_ON")
            {
                smartHome.TurnOnLight();
            }
            else if (command == "LIGHT_OFF")
            {
                smartHome.TurnOffLight();
            }
            else
            {
                Console.WriteLine("Невідома SMS-команда");
            }
        }
    }

   
    class Program
    {
        static void Main(string[] args)
        {
            SmartHome home = new SmartHome();
            ISmartHomeController controller = new SmsAdapter(home);

        
            controller.ExecuteCommand("LIGHT_ON");
            controller.ExecuteCommand("LIGHT_OFF");

            Console.ReadLine();
        }
    }


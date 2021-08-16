using System;

namespace T20Cricket.Service
{
    public class InputFormateService
    {
        private static readonly InputFormateService instance;

        private InputFormateService() { }

        static InputFormateService()
        {
            instance = new InputFormateService();
        }

        public static InputFormateService GetInstance
        {
            get
            {
                return instance;
            }
        }
        public string[] GetInput()
        {
            string[] input = Console.ReadLine().Trim().Split();
            return input;
        }
    }
}
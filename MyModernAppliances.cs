using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            Console.WriteLine("Enter the item number of an appliance: ");
            long itemNumber = long.Parse(Console.ReadLine());
            Appliance? foundAppliance = null;
            foreach (Appliance appliance in Appliances)
            {
                if (appliance.ItemNumber == itemNumber)
                {
                    foundAppliance = appliance;
                    break;
                }
            }
            if (foundAppliance == null)
            {
                Console.WriteLine("No appliances found with that item number.");
            }
            else
            {
                if (foundAppliance.IsAvailable)
                {
                    foundAppliance.Checkout();
                    Console.WriteLine("Appliance has been checked out");
                }
                else
                {
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }
        }
        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            Console.WriteLine("Enter brand to search for:");
            string brandSearch = Console.ReadLine();
            List<Appliance> found = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
            {
                if (appliance.Brand.Contains(brandSearch))
                {
                    found.Add(appliance);
                }
            }
            DisplayAppliancesFromList(found, 0);
        }
        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("2 - Double doors");
            Console.WriteLine("3 - Three doors");
            Console.WriteLine("4 - Four doors");
            Console.WriteLine("Enter number of doors: ");

            string numdoors = Console.ReadLine();
            int numberOfDoors = int.Parse(numdoors);
            List<Appliance> foundappliance = new List<Appliance>();
            //short wanted = short.Parse(numdoors);
            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Refrigerator)
                {
                    Refrigerator refrigerator = (Refrigerator)appliance;

                    if (refrigerator.Doors == numberOfDoors)
                    {
                        foundappliance.Add(appliance);
                    }
                }
            }
            DisplayAppliancesFromList(foundappliance, 0);
        }
        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Residential");
            Console.WriteLine("2 - Commercial");
            Console.WriteLine("Enter grade:");

            string input = Console.ReadLine();
            int inputgrade = int.Parse(input);
            string grade;
            if (inputgrade == 0)
            {
                grade = "Any";
            }
            if (inputgrade == 1)
            {
                grade = "Residential";
            }
            if (inputgrade == 2)
            {
                grade = "Commercial";
            }
            else
            {
                Console.WriteLine("Invalid option");
                return;
            }

            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - 18 Volt");
            Console.WriteLine("2 - 24 Volt");
            Console.WriteLine("Enter voltage:");

            string voltsInput = Console.ReadLine();
            int voltage = 0;
            if (voltsInput == "0")
            {
                voltage = 0;
            }
            else if (voltsInput == "1")
            {
                voltage = 18;
            }
            else if (voltsInput == "2")
            {
                voltage = 24;
            }
            else
            {
                Console.WriteLine("Invalid Option");
                return;
            }
            List<Appliance> foundappliance = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Vacuum)
                {
                    Vacuum vacuum = (Vacuum)appliance;
                    if (vacuum.Grade == grade || vacuum.BatteryVoltage == voltage)
                    {
                        foundappliance.Add(appliance);
                        break;
                    }
                }
            }
            DisplayAppliancesFromList(foundappliance, 0);
        }
        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Kitchen");
            Console.WriteLine("2 - Work site");
            Console.WriteLine("Enter room type:");

            string userinput = Console.ReadLine();
            char roomtype;
            if (userinput == "0")
            {
                roomtype = 'A';
            }
            else if (userinput == "1")
            {
                roomtype = 'K';
            }
            else if (userinput == "2")
            {
                roomtype = 'W';
            }
            else
            {
                Console.WriteLine("Invalid Option");
                return;
            }
            List<Appliance> found = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Microwave)
                {
                    Microwave microwave = (Microwave)appliance;
                    if (microwave.RoomType == roomtype)
                    {
                        found.Add(appliance);
                        break;
                    }
                }
            }
            DisplayAppliancesFromList(found, 0);
        }
        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Quietest");
            Console.WriteLine("2 - Quieter");
            Console.WriteLine("3 - Quiet");
            Console.WriteLine("4 - Moderate");
            Console.WriteLine("Enter sound rating:");

            string userinput = Console.ReadLine();
            string soundrating;
            if (userinput == "0")
            {
                soundrating = "Any";
            }
            else if (userinput == "1")
            {
                soundrating = "Qt";
            }
            else if (userinput == "2")
            {
                soundrating = "Qr";
            }
            else if (userinput == "3")
            {
                soundrating = "Qu";
            }
            else if (userinput == "4")
            {
                soundrating = "M";
            }
            else
            {
                Console.WriteLine("Invalid Option");
                return;
            }
            List<Appliance> found = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Dishwasher)
                {
                    Dishwasher dishwasher = (Dishwasher)appliance;
                    if (dishwasher.SoundRating == soundrating)
                    {
                        found.Add(appliance);
                        break;
                    }
                }
            }
            DisplayAppliancesFromList(found, 0);
        }
        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");
            Console.WriteLine("Enter type of appliance:");
            string inputtype = Console.ReadLine();
            string type;

            Console.WriteLine("Enter number of appliances: ");
            string inputnum = Console.ReadLine();
            int num = int.Parse(inputnum);

            List<Appliance> found = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
            {
                if (inputtype == "0")
                {
                    found.Add(appliance);
                }
                else if (inputtype == "1")
                {
                    if (appliance is Refrigerator)
                    {
                        found.Add(appliance);
                    }
                }
                else if (inputtype == "2")
                {
                    if (appliance is Vacuum)
                    {
                        found.Add(appliance);
                    }
                }
                else if (inputtype == "3")
                {
                    if (appliance is Microwave)
                    {
                        found.Add(appliance);
                    }
                }
                else if (inputtype == "4")
                {
                    if (appliance is Dishwasher)
                    {
                        found.Add(appliance);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Option");
                    return;
                }
            }
            found.Sort(new RandomComparer());
            DisplayAppliancesFromList(found, num);
        }
    }
}
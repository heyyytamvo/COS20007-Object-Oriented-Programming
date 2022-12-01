using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Runtime.Serialization;
using Newtonsoft.Json;
namespace ISStracking
{
	public class MainProgram
	{
        
        //-------------pure fabrication for list of astronaut-----------------
        public class Person
        {
            public string name { get; set; }
            public string craft { get; set; }
        }

        public class RootPeople
        {
            public int number { get; set; }
            public List<Person> people { get; set; }
            public string message { get; set; }
        }
        //-------------pure fabrication for list of astronaut-----------------



        //-------------pure fabrication for iss postition-----------------
        public class IssPosition
        {
            public string latitude { get; set; }
            public string longitude { get; set; }
        }

        public class RootISS
        {
            public int timestamp { get; set; }
            public IssPosition iss_position { get; set; }
            public string message { get; set; }
        }
        //-------------pure fabrication for iss position------------------

        //-----------------------MAIN PROGRAM-----------------------------
        public static void Main(string[] args)
        {
            //because the list of astronaut does not change, so we will load all the data of astronaut to a list

            //----------sending HTTP requests and desearializing JSON Object----------
            string url_astronauts = "http://api.open-notify.org/astros.json";
            var request_astronauts = WebRequest.Create(url_astronauts);
            request_astronauts.Method = "GET";

            using var webResponseForAstronauts = request_astronauts.GetResponse();
            using var webStreamForAstronauts = webResponseForAstronauts.GetResponseStream();

            using var readerAstronauts = new StreamReader(webStreamForAstronauts);
            var dataAstronautsFromInternet = readerAstronauts.ReadToEnd();

            RootPeople decodedDataAstronauts = JsonConvert.DeserializeObject<RootPeople>(dataAstronautsFromInternet);
            //----------sending HTTP requests and desearializing JSON Object----------

            //contructing, declaring list of astronauts and the ISS craft
            List<Astronaut> _ListOfAstronaut = new List<Astronaut>();
            Craft myCraft;

            //declaring command lines
            //
            AstronautCommand _astronautCommand;
            CraftCommand _craftCommand;

            //Function to get the current ISS position from the internet
            RootISS CurrentLocation()
            {
                string url_current_ISS = "http://api.open-notify.org/iss-now.json";
                var request_current_ISS = WebRequest.Create(url_current_ISS);
                request_current_ISS.Method = "GET";

                using var webResponseForISS = request_current_ISS.GetResponse();
                using var webStreamForISS = webResponseForISS.GetResponseStream();

                using var readerISS = new StreamReader(webStreamForISS);
                var dataISSFromInternet = readerISS.ReadToEnd();

                RootISS decodedDataISS = JsonConvert.DeserializeObject<RootISS>(dataISSFromInternet);
                return decodedDataISS;
            }

            //------setting all the astronaut into the _ListOfAstronaut-------
            foreach (Person person in decodedDataAstronauts.people)
            {
                Astronaut newAstronaut = new Astronaut(person.name, true, new string[] { person.name }, person.craft);
                _ListOfAstronaut.Add(newAstronaut);    
            }
            //------setting all the astronaut into the _ListOfAstronaut-------


            //when the user commands to track the ISS, at that time we need to construct the myCraft object
            Console.WriteLine("-------Welcome to the International Space Station tracking-----------");
            
            while (true)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Type '1' to track the current position of the International Space Station");
                Console.WriteLine("Type '2' to list all the astronaut in the database");
                Console.WriteLine("Type '3' to track the International Space Station for 10 times");
                Console.WriteLine("Your command: ");
                string user_command = Console.ReadLine().ToLower();
                if (user_command == "1")
                {
                    RootISS DecodedISS = CurrentLocation();
                    //constructing the craft with the data above
                    myCraft = new Craft("ISS", false, new string[] { "iss" }, DecodedISS.iss_position.latitude, DecodedISS.iss_position.longitude);
                    _craftCommand = new CraftCommand();
                    Console.WriteLine(_craftCommand.Execute(myCraft));
                    continue;
                }

                if (user_command == "2")
                {
                    _astronautCommand = new AstronautCommand();
                    Console.WriteLine(_astronautCommand.Execute(_ListOfAstronaut));
                    continue;
                }
                if (user_command == "3")
                {
                    int COUNT = 10;
                    for (int times = 0; times < COUNT; times++)
                    {
                        RootISS DecodedISS = CurrentLocation();
                        //constructing the craft with the data above
                        myCraft = new Craft("ISS", false, new string[] { "iss" }, DecodedISS.iss_position.latitude, DecodedISS.iss_position.longitude);
                        _craftCommand = new CraftCommand();
                        Console.WriteLine(_craftCommand.Execute(myCraft));
                        Thread.Sleep(2000);
                    }
                    continue;
                }
           
                Console.WriteLine("I do not understand your command");
            }
        }
	}
}
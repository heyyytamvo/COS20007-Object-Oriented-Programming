using System;
using System.Net;
using Newtonsoft.Json;
using ISStracking;
namespace ISStracking
{
    public class CraftCommand : Command
    {
        //-------------pure fabrication-----------------
        public class AdminCodes1
        {
            public string ISO3166_2 { get; set; }
        }

        public class Geoname
        {
            public string adminCode1 { get; set; }
            public string lng { get; set; }
            public string distance { get; set; }
            public int geonameId { get; set; }
            public string toponymName { get; set; }
            public string countryId { get; set; }
            public string fcl { get; set; }
            public int population { get; set; }
            public string countryCode { get; set; }
            public string name { get; set; }
            public string fclName { get; set; }
            public AdminCodes1 adminCodes1 { get; set; }
            public string countryName { get; set; }
            public string fcodeName { get; set; }
            public string adminName1 { get; set; }
            public string lat { get; set; }
            public string fcode { get; set; }
        }

        public class RootLand
        {
            public List<Geoname> geonames { get; set; }
        }
        //-------------pure fabrication-----------------


        //-------------pure fabrication-----------------

        public class Ocean
        {
            public string distance { get; set; }
            public int geonameId { get; set; }
            public string name { get; set; }
        }

        public class RootOcean
        {
            public Ocean ocean { get; set; }
        }

        //-------------pure fabrication-----------------

        public CraftCommand() 
		{
		}

        public string Execute(Craft craft)
        {
            string _latitude = craft.Latitude().ToString();
            string _longtitude = craft.Longtitude().ToString();

            string urlForLand = "http://api.geonames.org/findNearbyJSON?lat=" + _latitude + "&lng=" + _longtitude + "&username=heytamvo";
            string urlForOcean = "http://api.geonames.org/oceanJSON?lat=" + _latitude + "&lng=" + _longtitude + "&username=heytamvo";

            RootLand landRoot;
            RootOcean oceanRoot;
            string result;


            var requestForLand = WebRequest.Create(urlForLand);
            requestForLand.Method = "GET";

            using var webResposeForLand = requestForLand.GetResponse();
            using var webStreamForLand = webResposeForLand.GetResponseStream();

            using var Landreader = new StreamReader(webStreamForLand);
            var landData = Landreader.ReadToEnd();

            landRoot = JsonConvert.DeserializeObject<RootLand>(landData);


            if (landRoot.geonames.Count == 0)
            {
                var requestOcean = WebRequest.Create(urlForOcean);
                requestOcean.Method = "GET";

                using var webResponseOcean = requestOcean.GetResponse();
                using var webStreamOcean = webResponseOcean.GetResponseStream();

                using var readerOcean = new StreamReader(webStreamOcean);
                var dataOceanFromInternet = readerOcean.ReadToEnd();

                oceanRoot = JsonConvert.DeserializeObject<RootOcean>(dataOceanFromInternet);

                if (oceanRoot.ocean == null)
                {
                    return "error";
                }
                else
                {
                    result = craft.Location() + " (over " + oceanRoot.ocean.name + ")";
                    return result;
                }
            }
            else
            {
                result = craft.Location() + " (over " + landRoot.geonames[0].name + ", " + landRoot.geonames[0].countryName + ")";
                return result;
            }

            return "error";
        }        
	}
}


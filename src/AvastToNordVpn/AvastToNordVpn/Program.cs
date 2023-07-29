using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

using AvastToNordVpn.Models;
using AvastToNordVpn.Extensions;


namespace AvastToNordVpn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFileName = @"redacted";
            string outputFileName = @"redacted";

            string rawJson = File.ReadAllText(inputFileName);
            var json = JsonConvert.DeserializeObject<AvastPws>(rawJson);

            WriteCsvFile(json, outputFileName);

            Console.WriteLine("done. Press Any key to end.");
            Console.ReadKey();
        }

        static void WriteCsvFile(AvastPws pws, string outputFileName)
        {
            List<string> lines = new List<string>();
            
            // header line
            lines.Add("name,url,username,password,note,cardholdername,cardnumber,cvc,expirydate,zipcode,folder,full_name,phone_number,email,Address1,Address2,City,Country,State");
            
            foreach(var pw in pws.logins)
            {
                lines.Add($"{pw.ToNordCsv()}");
            }

            if(File.Exists(outputFileName)) { File.Delete(outputFileName); }
            File.WriteAllLines(outputFileName,lines.ToArray());
        }


    }
}
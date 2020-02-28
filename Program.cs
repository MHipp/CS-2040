using System;
using System.Collections.Generic;

namespace URLEncoder
{
    class Program
    {
        static string urlFormatString = "https://companyserver.com/content/{0}/files/{1}/{1}Report.pdf";

        static Dictionary<string, string> characterMap = new Dictionary<string, string>
        {
            {" ", "%20"}, {"<", "%3C"}, {">", "%3E"}, {"#", "%23"}, {"\"", "%22"}, 
            {";", "%3B"}, {"/", "%2F"}, {"?", "%3F"}, {":", "%3A"}, {"@", "%40"}, 
            {"&", "%26"}, {"=", "%3D"}, {"+", "%2B"}, {"$", "%24"}, {",", "%2C"}, 
            {"{", "%7B"}, {"}", "%7D"}, {"|", "%7C"}, {"\\", "%5C"}, {"^", "%5E"}, 
            {"[", "%5B"}, {"]", "%5D"}, {"`", "%60"}
        };
        static void Main(string[] args)
        {
            Console.WriteLine("URL Encoder");

            do
            {
                Console.Write("\nProject name: ");
                string projectName = GetUserInput();
                Console.Write("Activity name: ");
                string activityName = GetUserInput();

                Console.WriteLine(CreateURL(projectName, activityName));

                Console.Write("Would you like to do another? (y/n): ");
            } while (Console.ReadLine().ToLower().Equals("y"));
        }

        static string CreateURL(string projectName, string activityName) {
            // create the URL string and return it
            return String.Format(urlFormatString, Encode(projectName), Encode(activityName));
        }

        static string GetUserInput()                             
        {
            // get valid input from the user
            // disallow strings with control characters
            // IsValid() below is used to check if input is valid
            string input = "";
	        do
	        {   
		        input = Console.ReadLine();
		        if (IsValid(input)) return input;
		        Console.Write("The input contains invalid characters. Enter again: ");
	        } while (true);
        }

        static bool IsValid(string input) {
            // check if the string is valid and does not
            // contain control characters
            // if valid, return true
            // if not valid, return false
            foreach (char character in input.ToCharArray()) {
	            // check each character to see if it matches any of the not-allowed control characters
                if ((character >= 0x00 && character <= 0x1F) || character == 0x7F ) {
                    return false;
	            // do something about the character being 0x1F
                }
            }
            return true;
        }

        static string Encode(string value)
        {
            // return an encoded version of the 
            // string provided in value
            string encodedValue = "";
	        foreach (char character in value.ToCharArray()) {
		        // build the encodedValue string by getting each character
		        // in the original string and adding it to encodedValue if the original is ok
		        // OR changing it to an encoded value and adding the encoded value to the string
		        // if it is one of the values that needs to change
                string characterString = character.ToString();
                encodedValue += characterMap.GetValueOrDefault(characterString, characterString);
	        }
	        return encodedValue;
        }
    }
}
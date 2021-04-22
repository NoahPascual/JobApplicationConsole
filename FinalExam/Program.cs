// Noah Pascual 
// MIS 3013- 995
// Final Part 1 JobApplicationConsole

// *** Excluding the use of classes and methods ***
// *** Each of the following should be stored in a type of collection (all 3 types of collections must be used: dictionary, list, parallel arrays) ***

// Job Application Console will be asking for the user to input:
// First, Last, Middle Name.
// Prior Employer and Time worked there.
// School and current GPA.

// Output all information and ask applicant to verify all of the information. If all is correct thank them, otherwise, start the application over.
// *** Assume that all applicants have an address in the U.S.
// *** Number fields must be validated for size and type
// *** All string inputs must account for whitespace (and casing where applicable)

using System;
using System.Collections.Generic;
using System.Linq;

namespace JobApplicationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Job Application Console Variables:
            // (Address, Name, Phone Number (as "long"), Validation, User Input, & Final Validation Variables).
            string streetAddress;
            string city;
            string state;
            int zipCode = 0;

            string firstName;
            string middleName;
            string lastName;

            long phoneNumber = 0;

            string userInput;
            bool isTrue = false; // For Zip, Phone Number, the number of months the user worked at their previous job, & users GPA.
            bool isFinal = false;

            // State Validation:
            List<string> States = new List<string>(){"AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA",
                "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE",
                "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT",
                "VT", "VA", "WA", "WV", "WI", "WY"};

            // *** Each of the following should be stored in a type of collection (all 3 types of collections must be used: dictionary, list, parallel arrays) ***

            // Users job application references (List)
            List<string> userReferences = new List<string>();


            // Months worked at a company (Dictionary):
            Dictionary<string, int> userCompanyWork = new Dictionary<string, int>();

            // Users name of school & their GPA (Parallel Arrays)
            string[] usersSchool = new string[1];
            double[] usersGPA = new double[1];

            string title = "--- Job Application Console ---\n\r";
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
            Console.WriteLine(title);

            while (!isFinal)
            {
                // Asking user for their first name:
                Console.WriteLine("Please enter your first name: >>>");
                userInput = Console.ReadLine().Trim();
                firstName = char.ToUpper(userInput[0]) + userInput.Substring(1); // Casing (ToUpper)
                // Asking user for their middle name:
                Console.WriteLine("Please enter your middle name: >>>");
                userInput = Console.ReadLine().Trim();
                middleName = char.ToUpper(userInput[0]) + userInput.Substring(1); // Casing (ToUpper)
                // Asking user for their last name:
                Console.WriteLine("Please enter your last name: >>>");
                userInput = Console.ReadLine().Trim();
                lastName = char.ToUpper(userInput[0]) + userInput.Substring(1); // Casing (ToUpper)

                // User Address (Street Address)
                Console.WriteLine("Please enter your street address below: >>>");
                userInput = Console.ReadLine().Trim();
                streetAddress = userInput;
                // User Address (City)
                Console.WriteLine("Please enter your city below: >>>");
                userInput = Console.ReadLine().Trim();
                city = userInput;
                // User Address (Zip) [Verify if it an actual Zip Code (isTrue)]
                while (!isTrue)
                {
                    Console.WriteLine("Please enter your zip code below: >>>");
                    userInput = Console.ReadLine().Trim();
                    isTrue = Int32.TryParse(userInput, out zipCode); // Using bool isTrue and Int32.TrParse to check if Int.
                    if (userInput.Length != 5) // Validating that the user input is actually a 5 digit Zip.
                    {
                        isTrue = false;
                    }
                }
                isTrue = false; // Reset if the users input is not a actual Zip Code.
                // User Address (State) [From State Validation]
                while (!States.Contains(userInput))
                {
                    Console.WriteLine("Please enter the two digit abbreviation for your state below (Ex. CA, OK, FL, etc.): >>>");
                    userInput = Console.ReadLine().ToUpper().Trim(); // State as Capitalized.
                }
                state = userInput;
                // User Phone Number [Verify if it an actual Phone Number (isTrue)]
                while (!isTrue)
                {
                    Console.WriteLine("Please enter your phone number as 10 digits below (Ex 1234567890): >>>");
                    userInput = Console.ReadLine().Trim();
                    isTrue = Int64.TryParse(userInput, out phoneNumber); // Using bool isTrue and Int64.TrParse to check if Int.
                    if (userInput.Length != 10) // Validating that the user input is actually a 10 digit number.
                    {
                        isTrue = false;
                    }
                }
                isTrue = false; // Reset if the users input is not a actual phone number.

                // Education history information: School name and GPA
                // User school name.
                Console.WriteLine("Please enter the name of the school you are currently attending: >>>");
                usersSchool[0] = Console.ReadLine().Trim();
                // Users GPA
                Console.WriteLine("Please enter your current GPA below: >>>");
                while (!isTrue)
                {
                    isTrue = Double.TryParse(Console.ReadLine().Trim(), out usersGPA[0]); // Using bool isTrue and Double.TrParse to check if Double.
                }
                isTrue = false; // Reset if the users input is not an accurate GPA.

                // Work history information: Company and months worked at that company
                // Users previous company name:
                Console.WriteLine("Please enter the company that you previously worked at: >>>");
                string previousCompany = Console.ReadLine().Trim();
                // Amount of months user worked at previous company.
                // Variable for months worked:
                int monthsWorked = 0;
                while (!isTrue)
                {
                    Console.WriteLine("Please enter the number of months you worked for at your previous company: >>>");
                    isTrue = Int32.TryParse(Console.ReadLine(), out monthsWorked); // Using bool isTrue and Int32.TrParse to check if Int.
                }
                userCompanyWork.Add(previousCompany, monthsWorked);

                // References information: Full name of reference
                // Reference First Name:
                Console.WriteLine("Please enter the first name of your 1st reference: >>>");
                userInput = Console.ReadLine().Trim();
                string firstNameReference1 = char.ToUpper(userInput[0]) + userInput.Substring(1); // Casing (ToUpper)
                // Reference Middle Name:
                Console.WriteLine("Please enter the middle name of your 1st reference: >>>");
                userInput = Console.ReadLine().Trim();
                string middleNameReference1 = char.ToUpper(userInput[0]) + userInput.Substring(1); // Casing (ToUpper)
                // Reference Last Name:
                Console.WriteLine("Please enter the last name of your 1st reference: >>>");
                userInput = Console.ReadLine().Trim();
                string lastNameReference1 = char.ToUpper(userInput[0]) + userInput.Substring(1); // Casing (ToUpper)

                Console.WriteLine("Please enter the first name of your 2nd reference: >>>");
                userInput = Console.ReadLine().Trim();
                string firstNameReference2 = char.ToUpper(userInput[0]) + userInput.Substring(1); // Casing (ToUpper)
                // Reference Middle Name:
                Console.WriteLine("Please enter the middle name of your 2nd reference: >>>");
                userInput = Console.ReadLine().Trim();
                string middleNameReference2 = char.ToUpper(userInput[0]) + userInput.Substring(1); // Casing (ToUpper)
                // Reference Last Name:
                Console.WriteLine("Please enter the last name of your 2nd reference: >>>");
                userInput = Console.ReadLine().Trim();
                string lastNameReference2 = char.ToUpper(userInput[0]) + userInput.Substring(1); // Casing (ToUpper)

                // Reference Full Name add to List:
                string reference1 = firstNameReference1 + " " + middleNameReference1 + " " + lastNameReference1;
                userReferences.Add(reference1); // Adding users reference to list.

                string reference2 = firstNameReference2 + " " + middleNameReference2 + " " + lastNameReference2;
                userReferences.Add(reference2); // Adding users reference to list.

                // Output Data to User:
                Console.WriteLine("\nThere is no more further data we need. Please verify all data we have is accurate >>>");
                // Output Data (Users whole name, address, & phone number).
                Console.WriteLine($"\n   \t-- Applicant First Name:     {firstName} "
                                  + $"\n \t-- Applicant Middle Name:    {middleName} "
                                  + $"\n \t-- Applicant Last Name:      {lastName} "
                                  + $"\n \t-- Applicant Street Address: {streetAddress} " 
                                  + $"\n \t-- Applicant City:           {city} " 
                                  + $"\n \t-- Applicant State:          {state} " 
                                  + $"\n \t-- Applicant ZipCode:        {zipCode} " 
                                  + $"\n \t-- Applicant Phone Number:   {phoneNumber} ");
                // Output Data (Users previous job and time spent (months). *** FROM DICTIONARY ***
                foreach (var pair in userCompanyWork)
                {
                    Console.WriteLine($"\t-- Applicant Previous Job: {pair.Key}" +
                        $"\n \t-- Applicant's Time Spent at Previous Job: {pair.Value} (Months)");
                }
                // Output Data (Users reference (whole name). *** FROM LIST ***
                foreach (string i in userReferences)
                {
                    Console.WriteLine($"\t-- Applicant's References {i}");
                }
                // Output Data (Users school). *** FROM PARALLEL ARRAY ***
                foreach (var i in usersSchool)
                {
                    Console.WriteLine($"\t-- Applicant's School Name: {i}");
                }
                // Output Data (Users GPA). *** FROM PARALLEL ARRAY ***
                foreach (var i in usersGPA)
                {
                    Console.WriteLine($"\t-- Applicant's GPA: {i}");
                }

                // Final Validation (for user)
                Console.WriteLine("\nIf the information above is all correct, press Yes (Y). If not, press No (N) >>>");
                userInput = Console.ReadLine().Trim().ToUpper();
                if (userInput.Equals("Y"))
                {
                    isFinal = true;
                }
            }

            string end = "\n--- Thank you for applying to through our JobApplicationConsole. Press any button to exit. ---";
            Console.SetCursorPosition((Console.WindowWidth - end.Length) / 2, Console.CursorTop);
            Console.WriteLine(end);

            Console.ReadKey();

        }
    }
}
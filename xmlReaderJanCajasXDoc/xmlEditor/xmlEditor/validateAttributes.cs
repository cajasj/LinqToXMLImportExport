using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace xmlEditor
{
    class validateAttributes:fileValidations
    {
        
        private bool attributeValidation;
        private bool traverseBool = true;
        private string dateFormat = "yyyy-MM-ddTHH:mm:ss";
        private DateTime newDate;
        private string errorMessage;

        public override bool CheckFileAttribute(XDocument xmlValidate, int length, int startIndex, int elIndex, string[] validAttribtues, string[] validElements)
        {
            var regexItem = new Regex(@"^[a-zA-Z]*[\s?][a-zA-Z][a-z]*$");

            attributeValidation = base.CheckFileAttribute(xmlValidate, length, startIndex, elIndex, validAttribtues, validElements);
            if (!attributeValidation)
            {
                errorMessage += base.Errors();

                return false;
            }
            
            int i = 0;
            List<bool> checkFormat = new List<bool>() {true,true,true };
            foreach (var ele in xmlValidate.Descendants(validElements[2]))
            {
                foreach (var attrib in ele.Attributes())
                {
                    checkFormat = new List<bool>(){regexItem.IsMatch(attrib.Value),
                        DateTime.TryParseExact(attrib.Value, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out newDate),
                        int.TryParse(attrib.Value, out int widgetNumber)};
                 
                    if (!checkFormat[i])
                    {
                        Console.WriteLine("not valid");
                        errorMessage += $"{attrib.Value}is formated incorrectly\n";
                        traverseBool = false;
                     
                    }
                    i++;
                }
                i = 0;
            }
            attributeValidation = traverseBool;
            return attributeValidation;
        }
        public string getErrorMessage()
        {
            return errorMessage;
        }
    }
}

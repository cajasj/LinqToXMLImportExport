using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace xmlEditor
{
    class validateWeb : fileValidations
    {
        private bool webValidation=true;

        private bool traverseBool = true;
        public string errorMessage = "";
        private string[] websites = { "http://www.w3.org/2001/XMLSchema-instance", "http://www.w3.org/2001/XMLSchema" };
        public override bool CheckFileAttribute(XDocument xmlValidate, int length, int startIndex, int elIndex, string[] validAttribtues, string[] validElements)
        {
            int i = 0;
            //

            webValidation = base.CheckFileAttribute(xmlValidate, length, startIndex, elIndex, validAttribtues, validElements);
            if (!webValidation)
            {
                
                errorMessage += base.Errors();
                return false;
            }
            foreach (var ele in xmlValidate.Descendants(validElements[0]))
            {
               
                foreach (var attrib in ele.Attributes())
                {
                    Console.WriteLine(ele.Attributes().Count());
                   
                    if (attrib.Value != websites[i])
                    {
                        Console.WriteLine("not valid");
                        errorMessage += $"{attrib.Value} does not match with {websites[i]}\n";
                        traverseBool = false; 
                    }
                    i++;
                }
                i = 0;
            }
            webValidation = traverseBool;
            return webValidation;
            
        }
        public string getErrorMessage()
        {
            return errorMessage;
        }
    }
}

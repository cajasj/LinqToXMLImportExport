using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace xmlEditor
{
    internal class fileValidations
    {
        private string missingElement;
        
        bool validation = true;
        public fileValidations()
        {
             
        }

        
        public virtual bool CheckFileAttribute(XDocument xmlValidate, int length, int startIndex, int elIndex, string[] validAttribtues, string[] validElements)
        { 
            int i = startIndex;
            int e = elIndex;
            int k = 0;
            var regexItem = new Regex(@"^[a-zA-Z]*[\s?][a-zA-Z][a-z]*$");
            string dateFormat = "yyyy-MM-ddTHH:mm:ss";
            foreach (var ele in xmlValidate.Descendants(validElements[e]))
            {
                foreach (var attrib in ele.Attributes())
                {
                    Console.WriteLine(attrib.Value);
                    //validation= regexItem.IsMatch(attrib.Value);
                    if (ele.Attributes().Count() - 1 > length)
                    {

                        missingElement += $"There is { ele.Attributes().Count() - 1 - length } extra attirbutes for {ele.Name.LocalName}\n";
                        
                        validation = false;
                        break;
                    }
                    else if (ele.Attributes().Count() - 1 < length)
                    {
                        missingElement += $"Missing attirbutes {length - ele.Attributes().Count() + 1 } for {ele.Name.LocalName}\n";
                        validation = false;
                        break;
                    }
                    else if (attrib.Name.LocalName != validAttribtues[i]&&i<length)
                    
                    {
                        missingElement += $"No element with: {attrib.Name.LocalName} exist\n";
                        validation = false;
                        break;
                    }
                    i++;
                }
                i = startIndex;
                k = 0;
            }
            Console.WriteLine(missingElement);
            return validation;
        }

        internal bool GetValidation()
        {
            return validation;
        }

        public string Errors()
        {
            return missingElement;
        }
    }
     
   
}
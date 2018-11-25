using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace xmlEditor
{
    public partial class Form1 : Form
    {
        public string[] editItems = new string[3];
        private ListViewItem listview;
        private string[] grandChildAttributes = new string[3];
        private string[] elementName; 
        private string[] parentValue = new string[2];
        private string[] validElements = { "ExampleObjectContainer", "Objects", "ExampleObject"};
        private string[] validAttribtues = { "xsi", "xsd" ,"Name", "DOB", "NumberOfWidgets"};
        
        private string missingElement;
        DateTime newDate;
        
        private bool validateSites;
        private fileValidations validateFiles;
        private validateWeb validateContainer;
        private validateAttributes validateAttribs; 
        public Form1()
        {
            InitializeComponent();
        }

        private void browseXML_Click(object sender, EventArgs e)
        {
            missingElement = "check the format of the XML file has an unvalid field or attribute:\n";
            OpenFileDialog search = new OpenFileDialog();
            search.Filter = "XML|*.xml";
           
            if (search.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               
                pathName.Text = search.FileName;
                parseXML.Items.Clear();

                if (validateXML(search.FileName))
                {
                    importXML(search.FileName);
                   
                }
                else
                {
                    MessageBox.Show(missingElement);
                }
            }


        }
        private bool validateXML(string path)
        {
            try
            {
                XDocument xmlValidate;
                IEnumerable<XElement> attributeQuery= new List<XElement>();
                xmlValidate = XDocument.Load(path);

                int length = 1;
                int index = 0;
                int elIndex = 0;
                bool validateAttributes;
                bool validateLength;
                validateFiles = new fileValidations();
                validateLength = validateFiles.CheckFileAttribute(xmlValidate, length, index, elIndex, 
                    validAttribtues, validElements); 
                Console.WriteLine(missingElement);

               
                validateContainer = new validateWeb();
                validateSites = validateContainer.CheckFileAttribute(xmlValidate, length, index, elIndex, 
                    validAttribtues, validElements);

                missingElement += validateContainer.getErrorMessage();
                Console.WriteLine(missingElement);
                index = length = 0;
                elIndex  = 1 ;
                validateLength = validateFiles.CheckFileAttribute(xmlValidate, length, index, elIndex,
                    validAttribtues, validElements);
                length = 2;
                index =elIndex= 2;
                validateAttribs = new validateAttributes();
                validateAttributes = validateAttribs.CheckFileAttribute(xmlValidate, length, index, elIndex, validAttribtues, validElements);
                missingElement += validateAttribs.getErrorMessage();

                var elementValid = checkFileElement(xmlValidate);
                if ((elementValid && validateLength)&&validateAttributes && validateSites)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(System.Xml.XmlException e)
            {
                missingElement=e.Message;
                return false;
            }

        }

      

        

        private bool checkFileElement(XDocument xmlValidate)
        {
            int i = 0;
            foreach (var ele in xmlValidate.Descendants())
            {
                while (i < validElements.Count())
                {
                    if (ele.Name.LocalName == validElements[i])
                    {
                        break;
                    }
                    else 
                    {
                        i++;
                    }
                }
                if (i >= validElements.Count())
                {
                    missingElement += ele.Name.LocalName;
                    return false;
                }
            }
            return true;
            
        }

        private void importXML(string path)
        {
            XDocument xmlFile;
            xmlFile = XDocument.Load(path);

            int i = 0;
            int k = 0;
            elementName = new string[xmlFile.Descendants().Count()];
            Console.WriteLine(xmlFile.Descendants().Count());
            foreach (var ele in xmlFile.Descendants())
            {
                elementName[i] = ele.Name.LocalName;
                Console.WriteLine(ele.Name.LocalName);
                foreach (var attrib in ele.Attributes())
                {
                    if (ele.Attributes().Count() == 3)
                    {
                        
                        grandChildAttributes[k] = attrib.Name.LocalName;
                        k++;

                    }else if(ele.Attributes().Count() == 2)
                    { 
                        parentValue[k] = attrib.Value;
                        k++;
                    }
                    
                }
                k = 0;
                i++;
            }
            var result = from query in xmlFile.Descendants(elementName[2])
                         select new
                         {
                             Name = query.Attribute(grandChildAttributes[0]).Value,
                             DoB = query.Attribute(grandChildAttributes[1]).Value,
                             Widget = query.Attribute(grandChildAttributes[2]).Value
                         };

         
            foreach (var attribute in result)
            {
                listview = new ListViewItem(new[] { attribute.Name, attribute.DoB, attribute.Widget });
                parseXML.Items.Add(listview);
            }
           
        }
        private void edit_Click(object sender, EventArgs e)
        {
            if (parseXML.SelectedItems.Count > 0)
            {
                int listIndex = parseXML.FocusedItem.Index;
                for (int x = 0; x < parseXML.Items[listIndex].SubItems.Count; x++)
                {
                    editItems[x] = parseXML.Items[listIndex].SubItems[x].Text;
                }
                addItems editData = new editNode(editItems);
                editData.checkFormat();
                editData.ShowDialog();
                string[] newEditItems = { editData.getName(), editData.getBirth(), editData.getWidget() };

                for (int k = 0; k < parseXML.Items[listIndex].SubItems.Count; k++)
                {
                    parseXML.Items[listIndex].SubItems[k].Text = newEditItems[k];
                }
            }
            else
            {
                MessageBox.Show("must click on a name to edit");
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (parseXML.Items.Count > 0)
            {
                addItems addData = new addNodes();
                addData.checkFormat();
                addData.ShowDialog();
                string[] appendRow = { addData.getName(), addData.getBirth(), addData.getWidget() };
                if (checkSpaces(appendRow))
                {
                    listview = new ListViewItem(appendRow);
                    parseXML.Items.Add(listview);
                }
            }
            else
            {
                MessageBox.Show("parse an xml first!");
            }
        }
        private bool checkSpaces(string[] row)
        {
            foreach (String text in row)
            {
                if (text == null)
                {
                    return false;
                }else if (text.Length == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (parseXML.SelectedItems.Count > 0)
            {
                int listIndex = parseXML.FocusedItem.Index;
                parseXML.Items.RemoveAt(listIndex);
            }
            else
            {
                MessageBox.Show("must click on a name to edit");
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "XML|*.xml";


            if (parseXML.Items.Count==0)
            {
                MessageBox.Show("import xml file!");
            }
            else if(saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                exportXML(saveFile.FileName);
            }
        }
        private void exportXML(string fileName)
        {
            string[] items =new string[3]; 
            XDocument saveXML = new XDocument(
                new XElement(elementName[0],
                    new XAttribute(XNamespace.Xmlns + "xsi",parentValue[0]),
                    new XAttribute(XNamespace.Xmlns + "xsd",parentValue[1])
                    )
                );
            XElement child = new XElement(elementName[1]);
            
            saveXML.Root.Add(child);
            Console.WriteLine(elementName[1]);
            foreach (ListViewItem item in parseXML.Items)
            {
                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    items[i]=item.SubItems[i].Text;
                    if (i == 2) {
                        saveXML.Root.Element(elementName[1]).Add(
                        new XElement(elementName[2], 
                            new XAttribute(grandChildAttributes[0], items[0]),
                            new XAttribute(grandChildAttributes[1], items[1]),
                            new XAttribute(grandChildAttributes[2], items[2])
                            )
                        );
                    }
                }
            }
            Console.WriteLine(saveXML);
            saveXML.Save(fileName, SaveOptions.None);
        }
    }
}


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

namespace xmlEditor
{
    public partial class addItems : Form
    {
        
        private int widgetNumber;
        private bool[] isFormated = new bool[3] { true, true, true };
        private string[] myItems = new string[3];
        internal void editNode(string[] editItems)
        {
            nameTextBox.Text= myItems[0] = editItems[0];
            birthTextBox.Text= myItems[1] = editItems[1];
            widgetTextBox.Text=myItems[2] = editItems[2];
        }
        private string error=" ";
        private string dateFormat = "yyyy-MM-ddTHH:mm:ss";
        protected string[] errorList = new string[3] {"Last name is missing, name has number or special character ",
            " \ndate not formated to yyyy - MM - ddTHH:mm:ss"," \nwidget isn't a number" };
        private string birthDate = "";
        private string newName = "";
        private string widgetCount = "";
        private bool firstRunTime = true;
        private bool errorBool;
        public addItems()
        {
            InitializeComponent();
        }

        public virtual void checkFormat(){

            error = " ";
            var regexItem = new Regex(@"^[a-zA-Z]*[\s?][a-zA-Z][a-z]*$");
           
            
            isFormated[0] = regexItem.IsMatch(nameTextBox.Text);
          
            error += returnError(isFormated[0], errorList[0]);
            
           
            DateTime newDate;
            
            
            isFormated[1] = DateTime.TryParseExact(birthTextBox.Text, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out newDate);
            error += returnError(isFormated[1], errorList[1]);
            isFormated[2] = int.TryParse(widgetTextBox.Text, out int widgetNumber);
            error += returnError(isFormated[2], errorList[2]);


            errorBool = errorHandler();
            
            if (!errorBool && !firstRunTime)
            {
                MessageBox.Show(error);
            }
            
            firstRunTime = false;


        }
        public virtual bool errorHandler()
        {
            if (isFormated.Contains(false))
            {
                //where the error message is
                return false;
            }
            else if (!firstRunTime)
            {
                birthDate = birthTextBox.Text;
                newName = nameTextBox.Text;
                widgetCount = widgetTextBox.Text;
                return true;
            }
            return false;
        }
        private string returnError(bool formating, string errorMessage)
        {
            if (formating==false)
            {
                return errorMessage;
            }
            else {
                return " ";
            }
        }
        private void saveChange_Click(object sender, EventArgs e)
        {
            checkFormat();
            if (errorBool)
            {
                this.Close();
            }
        }
         
        public string getBirth()
        {
                return birthDate;
        }

        public string getName()
        {
                return newName;
        }

        public string getWidget()
        {
                return widgetCount;
            
        }

        private void addItems_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (errorHandler())
            {

                birthDate = birthTextBox.Text;
                newName = nameTextBox.Text;
                widgetCount = widgetTextBox.Text;
            }
            else
            {
                newName = myItems[0];
                birthDate = myItems[1];
                widgetCount = myItems[2];
            }
        }
    }
}

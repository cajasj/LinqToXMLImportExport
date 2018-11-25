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
    class addNodes : addItems
    {
        public override void checkFormat()
        {

            Console.WriteLine("in the add class"); 
            base.checkFormat();
            

        }
    }
}

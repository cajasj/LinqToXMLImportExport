using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xmlEditor
{
    class editNode:addItems
    {
        private string[] editItems;
        private bool runOnce = true;
        public editNode(string[] editItems)
        {
            this.editItems = editItems;
            
        }

        public override void checkFormat()
        {

            Console.WriteLine("in the edit node class");

            base.checkFormat();
            if (runOnce)
            {
                base.editNode(editItems);
            }
            runOnce = false;
            
        }
       
    }
}

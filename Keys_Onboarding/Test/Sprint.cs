using Keys_Onboarding.Global;
using Keys_Onboarding.Pages.Owners.Properties;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keys_Onboarding.Test
{
    class Sprint 
    {
      [TestFixture]
      [Category("Sprint1")]
       class Tenant : Base
       {
        
            [Test]
            public void PO_AddNewProperty()
            {
               // Creates a toggle for the given test, adds all log events under it    
               test = extent.CreateTest("Search for a Property");

               // Create an class and object to call the method
               MyPropertiesPage myProperties = new MyPropertiesPage();
               myProperties.SearchdAPropertySuccessfully("ddd");

            }


        }
    }
}

﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Apex.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class GivenPersonViewModel
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        private PersonViewModel personViewModel;

        [TestInitialize()]
        public void Given()
        {
            personViewModel = new PersonViewModel();
        }

        [TestMethod]
        public void GetNotifyingPropertiesReturnsAllNotifyingProperties()
        {
            var notifyingProperties = personViewModel.GetNotifyingProperties().ToList();

            //  Assert we have the properties we'd expect.
            Assert.IsTrue(notifyingProperties.Count == 2, "Incorrect number of notifying properties..");
            Assert.IsTrue(notifyingProperties.Count(np => np.Name == "FirstName") > 0, "FirstName property is missing.");
            Assert.IsTrue(notifyingProperties.Count(np => np.Name == "SecondName") > 0, "SecondName property is missing.");
        }

        [TestMethod]
        public void NotifyPropertyChangedWorks()
        {
            //  Create a handler.
            bool called = false;
            string propertyName = null;
            personViewModel.PropertyChanged += (sender, args) => 
            {
                propertyName = args.PropertyName;
                called = true; 
            }; 

            //  Change a value.
            personViewModel.FirstName = "Homer Simpson";

            //  Assert it's changed.
            Assert.IsTrue(personViewModel.FirstName == "Homer Simpson", "Failed to save property.");

            //  Assert notify property changed is called.
            Assert.IsTrue(called == true, "Notify property changed was not called.");

            //  Assert the property name was passed.
            Assert.IsTrue(propertyName == "FirstName", "Property name was not passed correctly.");
        }
    }
}
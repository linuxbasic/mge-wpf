using Microsoft.VisualStudio.TestTools.UnitTesting;
using me.basig.linus.mge;
using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;

namespace UnitTestProject1
{
    [TestClass]
    public class CustomerViewModelTests
    {
        [TestMethod]
        public void TestPreventSelectionDuringCreation()
        {
            var Service = new LibraryAdminService("http://localhost:8080");
            var ViewModel = new CustomerViewModel(Service);
            ViewModel.LoadCustomers();
            Customer OldCustomer  = ViewModel.AllCustomers[0];
            ViewModel.NewCustomer();
            Customer NewCustomer = ViewModel.CustomerInEditor;
            ViewModel.EditorName = "test";
            ViewModel.CustomerInEditor = OldCustomer;

            Assert.AreEqual(ViewModel.CustomerInEditor, NewCustomer);
        }


        [TestMethod]
        public void TestPreventSelectionWhenHasUnsavedChanges()
        {
            var Service = new LibraryAdminService("http://localhost:8080");
            var ViewModel = new CustomerViewModel(Service);
            ViewModel.LoadCustomers();
            Customer CustomerA = ViewModel.AllCustomers[0];
            Customer CustomerB = ViewModel.AllCustomers[1];
            ViewModel.CustomerInEditor = CustomerA;
            ViewModel.EditorName = "test";
            ViewModel.CustomerInEditor = CustomerB;

            Assert.AreEqual(ViewModel.CustomerInEditor, CustomerA);
        }


        [TestMethod]
        public void TestPreventResetAfterCreationWhenHasUnsavedChanges()
        {
            var Service = new LibraryAdminService("http://localhost:8080");
            var ViewModel = new CustomerViewModel(Service);
            ViewModel.LoadCustomers();
            Customer CustomerA = ViewModel.AllCustomers[0];
            ViewModel.CustomerInEditor = CustomerA;
            var TEST_NAME = "test";
            ViewModel.EditorName = TEST_NAME;
            ViewModel.NewCustomer();

            Assert.AreEqual(ViewModel.CustomerInEditor, CustomerA);
            Assert.AreEqual(ViewModel.EditorName, TEST_NAME);
        }


        [TestMethod]
        public void TestSetEditrValues()
        {
            var Service = new LibraryAdminService("http://localhost:8080");
            var ViewModel = new CustomerViewModel(Service);
            ViewModel.LoadCustomers();
            Customer CustomerA = ViewModel.AllCustomers[0];
            ViewModel.CustomerInEditor = CustomerA;

            Assert.AreEqual(ViewModel.EditorStudentnumber, CustomerA.Studentnumber);
            Assert.AreEqual(ViewModel.EditorName, CustomerA.Name);
            Assert.AreEqual(ViewModel.EditorEmail, CustomerA.Email);
            Assert.AreEqual(ViewModel.EditorStudentnumber, CustomerA.Studentnumber);
        }
    }
}
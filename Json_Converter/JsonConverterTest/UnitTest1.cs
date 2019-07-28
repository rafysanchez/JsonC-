using System;
using System.Collections.Generic;
using JsonConverterTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonPluto;

namespace JsonConverterTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// To Get a instance of object Company
        /// </summary>
        /// <returns>instance of company</returns>
        private Comapany GetCompanyObject()
        {
            return new Comapany
            {
                Name = "CSG Solutions India Pvt Ltd",
                TotalEmployee = 50,
                Established = DateTime.Now,
                IsGovtOrganisation = false,
                TotalAsset = 20000000,
                Branches = new List<Branch>
                {
                    new Branch
                    {
                        Country = "India",
                        State = "Karnataka",
                        Address = new Location
                        {
                            BuildingName = "Sri Hari Tower",
                            Street = "2nd Main Road",
                            ZipCode = 560016
                        }
                    },
                    new Branch
                    {
                        Country = "USA",
                        State = "Germantown",
                        Address = new Location
                        {
                            BuildingName = "Zinc Tower",
                            Street = "Germantown Road",
                            ZipCode = 50001
                        }
                    }
                },
                Departments = new Dictionary<string, Department>
                {
                    { "Engineering", new Department { DeptId = 001, DeptName = "Super Engineers" } },
                    { "Support", new Department { DeptId = 002, DeptName = "24*7 Tech Support" } },
                    { "Marketings", new Department { DeptId = 003, DeptName = "Tech Mavens" } }
                },
                Management = new Management { CEO = "Tarun Kumar Rajak", Founder = "Ashok Kisku" }
            };
        }

        /// <summary>
        /// To Test Serialize functionality
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            var json = JsonConverter.Serialize(GetCompanyObject());
            System.IO.File.WriteAllText(@"C:\Users\Public\Documents\Company.json", json);
        }
    }
}

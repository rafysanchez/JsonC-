using System;
using System.Collections.Generic;

namespace JsonConverterTest.Models
{
    public class Comapany
    {
        public string Name { get; set; }
        public double TotalAsset { get; set; }
        public int TotalEmployee { get; set; }
        public bool IsGovtOrganisation { get; set; }
        public DateTime Established { get; set; }
        public List<Branch> Branches { get; set; }
        public Dictionary<string,Department> Departments { get; set; }
        public Management Management { get; set; }

    }

    public class Branch
    {
        public string Country { get; set; }
        public string State { get; set; }
        public Location Address { get; set; }

    }

    public class Location
    {
        public string BuildingName { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }
    }

    public class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }

    public class Management
    {
        public string CEO { get; set; }
        public string Founder { get; set; }
    }
}

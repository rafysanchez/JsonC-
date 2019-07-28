using System;
using System.Collections.Generic;
using System.Linq;
using JSON_CRUD.Models;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.Hosting;
using System.IO;
using Newtonsoft.Json;

namespace JSON_CRUD.Controllers
{
    public class PersonController : Controller
    {

        public IActionResult Index()
        {
            List<PersonModel> people = new List<PersonModel>();
            JSONReadWrite readWrite = new JSONReadWrite();
            people = JsonConvert.DeserializeObject<List<PersonModel>>(readWrite.Read("people.json", "data"));

            return View(people);
        }

        [HttpPost]
        public IActionResult Index(PersonModel personModel)
        {
            List<PersonModel> people = new List<PersonModel>();
            JSONReadWrite readWrite = new JSONReadWrite();
            people = JsonConvert.DeserializeObject<List<PersonModel>>(readWrite.Read("people.json", "data"));

            PersonModel person = people.FirstOrDefault(x => x.Id == personModel.Id);

            if (person == null)
            {
                people.Add(personModel);
            }
            else
            {
                int index = people.FindIndex(x => x.Id == personModel.Id);
                people[index] = personModel;
            }

            string jSONString = JsonConvert.SerializeObject(people);
            readWrite.Write("people.json", "data", jSONString);

            return View(people);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            List<PersonModel> people = new List<PersonModel>();
            JSONReadWrite readWrite = new JSONReadWrite();
            people = JsonConvert.DeserializeObject<List<PersonModel>>(readWrite.Read("people.json", "data"));

            int index = people.FindIndex(x => x.Id == id);
            people.RemoveAt(index);

            string jSONString = JsonConvert.SerializeObject(people);
            readWrite.Write("people.json", "data", jSONString);

            return RedirectToAction("index", "Person");
        }
    }

    public class JSONReadWrite
    {
        public JSONReadWrite() { }

        public string Read(string fileName, string location)
        {
            string root = "wwwroot";
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                root,
                location,
                fileName);

            string jsonResult;

            using (StreamReader streamReader = new StreamReader(path))
            {
                jsonResult = streamReader.ReadToEnd();
            }
            return jsonResult;
        }

        public void Write(string fileName, string location, string jSONString)
        {
            string root = "wwwroot";
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                root,
                location,
                fileName);

            using (var streamWriter = File.CreateText(path))
            {
                streamWriter.Write(jSONString);
            }
        }
    }
}
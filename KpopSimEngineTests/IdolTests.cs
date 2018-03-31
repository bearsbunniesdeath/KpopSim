using System;
using System.IO;
using KpopSimEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace KpopSimEngineTests
{
    [TestClass]
    public class IdolTests
    {
        [TestMethod]
        public void CanJSONSerialize()
        {
            Idol taeyeon = IdolFactory.CreateDummyIdol();
            Assert.AreEqual("{\"Name\":\"Taeyeon\",\"FullName\":\"Kim Taeyeon\",\"Gender\":1,\"DOB\":\"1989-03-09T00:00:00\"}", taeyeon.ToJson());
        }

        [TestMethod]
        public void CanJSONDeserialize()
        {
            string json = "{\"Name\":\"Taeyeon\",\"FullName\":\"Kim Taeyeon\",\"Gender\":1,\"DOB\":\"1989-03-09T00:00:00\"}";
            Idol taeyeon = IdolFactory.CreateIdol(json);
            
            Assert.AreEqual("Taeyeon", taeyeon.Name);
            Assert.AreEqual("Kim Taeyeon", taeyeon.FullName);
            Assert.AreEqual(Gender.Female, taeyeon.Gender);
        }

        [TestMethod]
        public void CreateIdolWithRandomReportCard()
        {
            IdolRegistration reg = new IdolRegistration();

            reg.Name = "Eunji";
            reg.FullName = "Jeong Eunji";
            reg.Gender = Gender.Female;
            reg.DOB = new DateTime(1993, 8, 18);

            Idol eunji = IdolFactory.CreateIdol(reg);

            Assert.AreEqual("Eunji", eunji.Name);
            Assert.AreEqual("Jeong Eunji", eunji.FullName);
            Assert.AreEqual(Gender.Female, eunji.Gender);
            Assert.AreEqual(reg.DOB, eunji.DOB);

            Assert.IsNotNull(eunji.VisualRating);
            Assert.IsNotNull(eunji.SingingRating);
            Assert.IsNotNull(eunji.DancingRating);
            Assert.IsNotNull(eunji.SocialRating);
        }
    }
}

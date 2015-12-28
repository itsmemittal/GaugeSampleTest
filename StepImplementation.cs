using System;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;

namespace GaugeSampleTest
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    public class StepImplementation
	{
        [Step("A context step which gets executed before every scenario")]
        public void Context()
        {
            IWebDriver d = new FirefoxDriver();
            d.Manage().Window.Maximize();
            d.Navigate().GoToUrl("http://www.google.com");
            Console.Write(d.Title.Contains("Google"));
            Console.WriteLine("This is a sample context");
        }

        [Step("Say <what> to <who>")]
        public void SaySomething(string what, string who)
        {
            Console.WriteLine("{0}, {1}!", what, who);
        }

        [Step("Step that takes a table <table>")]
        public void ReadTable(Table table)
        {
            table.GetColumnNames().ForEach(Console.Write);
            var rows = table.GetTableRows();
            foreach (var row in rows)
            {
                Console.WriteLine("{0}|{1}", row.GetCell("Product"), row.GetCell("Description"));
            }
        }
	}
}

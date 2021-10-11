using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GeneralKnowledge.Test.App.Tests
{
	public class SamplePoints
	{
		public List<Samples> Samples { get; set; }
	}

	public class Samples
	{
		//public DateTime Date { get; set; }
		public decimal? Temperature { get; set; }
		public decimal? PH { get; set; }
		public decimal? Chloride { get; set; }
		public decimal? Phosphate { get; set; }
		public decimal? Nitrate { get; set; }
	}

	/// <summary>
	/// Basic data retrieval from JSON test
	/// </summary>
	public class JsonReadingTest : ITest
	{
		public string Name { get { return "JSON Reading Test"; } }

		public void Run()
		{
			var jsonData = Resources.SamplePoints;
			PrintOverview(jsonData);
		}

		private void PrintOverview(byte[] data)
		{
			var samplePoints = JsonConvert.DeserializeObject<SamplePoints>(Encoding.UTF8.GetString(data));
			PropertyInfo[] properties = typeof(Samples).GetProperties();
			var samples = samplePoints.Samples;
			foreach (PropertyInfo property in properties)
			{
				var maximum = samples.Max(x => x.GetType().GetProperty(property.Name).GetValue(x, null));
				var minimum = samples.Min(x => x.GetType().GetProperty(property.Name).GetValue(x, null));
				var average = samples.Average(x => (decimal?)x.GetType().GetProperty(property.Name).GetValue(x, null));
				Console.WriteLine($"{property.Name}	Minimum: {minimum}	Average: {Math.Round(average.Value,2)}	Maximum: {maximum}");
			}
		}
	}
}

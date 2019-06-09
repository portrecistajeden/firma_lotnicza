using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp2;

namespace Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void CzyLotMaDobrzeUstawionyCzasPodrozy()
		{
			var lot = new Lot(new Trasa(), new Samolot(), 2, 5, 7);
			var czasLotu = lot.getGodzinaprzylotu() - lot.getGodzinawylotu();

			Assert.AreEqual(czasLotu, lot.getCzaspodrozy());
		}
	}
}

using Moq;
using NUnit.Framework;
using ReversiMvcApp;
using ReversiMvcApp.Controllers;
using ReversiRestApi.Controllers;
using ReversiRestApi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReversiTests
{
	public class APITests
	{
		ISpelRepository spelRepository;
		SpelAPIController spelController;
		Mock<ISpelRepository> mockedSpelRepository;
		SpelAPIController mockedSpelController;

		[SetUp]
		public void Setup()
		{
			spelRepository = new SpelRepository();
			//spelController = new SpelController(spelRepository);
			mockedSpelRepository = new Mock<ISpelRepository>();
			//mockedSpelController = new SpelController(mockedSpelRepository.Object);
		}

		[Test]
		public void SpelController_NieuwSpel()
		{
			//spelController.AddNieuwSpel("123", "test", "een nieuwe spel");

			//Spel spel = spelRepository.GetSpel("test");
			//Assert.IsNotNull(spel);
			//Assert.AreEqual(spel.Token, "test");
			//Assert.AreEqual(spel.Speler1Token, "123");
			//Assert.AreEqual(spel.Omschrijving, "een nieuwe spel");
		}
	}
}

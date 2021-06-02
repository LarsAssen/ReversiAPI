﻿using Moq;
using NUnit.Framework;
using ReversiMVC.Models;
using ReversiRestApi.Controllers;
using ReversiRestApi.Spel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReversiTests
{
	public class APITests
	{
		ISpelRepository spelRepository;
		SpelController spelController;
		Mock<ISpelRepository> mockedSpelRepository;
		SpelController mockedSpelController;

		[SetUp]
		public void Setup()
		{
			spelRepository = new SpelRepository();
			spelController = new SpelController(spelRepository);
			mockedSpelRepository = new Mock<ISpelRepository>();
			mockedSpelController = new SpelController(mockedSpelRepository.Object);
		}

		[Test]
		public void SpelController_NieuwSpel()
		{
			spelController.AddNieuwSpel("123", "test", "een nieuwe spel");

			Spel spel = spelRepository.GetSpel("test");
			Assert.IsNotNull(spel);
			Assert.AreEqual(spel.Token, "test");
			Assert.AreEqual(spel.Speler1Token, "123");
			Assert.AreEqual(spel.Omschrijving, "een nieuwe spel");
		}
	}
}
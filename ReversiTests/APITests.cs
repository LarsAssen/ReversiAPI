using Moq;
using NUnit.Framework;
using ReversiMVC.Models;
using ReversiRestApi.Controllers;
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
	}
}

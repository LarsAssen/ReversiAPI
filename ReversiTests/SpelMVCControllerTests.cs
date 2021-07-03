using Moq;
using ReversiMvcApp.Controllers;
using ReversiRestApi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReversiTests
{
	public class SpelMVCControllerTests
	{
		ISpelRepository spelRepository;
		SpelController spelController;
		Mock<ISpelRepository> mockedSpelRepository;
		SpelController mockedSpelController;
	}
}

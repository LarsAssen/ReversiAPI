using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ReversiMvcApp.ClassHelpers
{
	public static class KeyHelper
	{
		public static string GenerateBase64String(int length)
		{
			return Convert.ToBase64String(GenerateRandombytes(length));
		}

		private static byte[] GenerateRandombytes(int length)
		{
			RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
			byte[] randomBytes = new byte[length];
			rngCryptoServiceProvider.GetBytes(randomBytes);

			return randomBytes;
		}
	}
}

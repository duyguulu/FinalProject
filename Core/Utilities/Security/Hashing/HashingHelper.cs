using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
	public class HashingHelper
	{
		public static void CreatePasswordHash(string password,out byte[] passwordHash, out byte[] passwordSalt) //hash oluşturur
			//bir password vereceğiz ve out ile iki yapıyı dışarı aktaracagız.
		{
			using (var hmac= new System.Security.Cryptography.HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
			}

		}

		//buradaki parola kullanıcının tekrardan sisteme giriş yapmaya calısırken kullandığı parola
		public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) //hash oluşturur
		{
			using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
			{
				var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
				for (int i = 0; i < computedHash.Length; i++)
				{
					if (computedHash[i]!=passwordHash[i])
					{
						return false;
					}
				}

				return true;
			}
		}
	}
}

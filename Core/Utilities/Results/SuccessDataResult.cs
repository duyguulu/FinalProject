using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
	public class SuccessDataResult<T>:DataResult<T>
	{
		public SuccessDataResult(T data, string message):base(data,true) //mesaj ve data döndürülen
		{

		}
		public SuccessDataResult(T data) : base(data, true) //sadece data
		{

		}
		public SuccessDataResult( string message) : base(default,true,message) //sadece mesaj ve datayı default haliyle göndermek
		{

		}
		public SuccessDataResult() : base(default, true) //sadece datayı default data olarak gönderme
		{

		}

	}
}

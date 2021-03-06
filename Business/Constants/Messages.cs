using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
	public static class Messages
	{
		public static string ProductAdded = "Ürün eklendi";
		public static string ProductNameInvalid = "Ürün ismi geçersiz";
		public static string MaintenanceTime= "Sistem bakımda";
		public static string ProductListed = "Ürünler listelendi";
		public static string ProductCountOfCategoryError="Bir kategoride en fazla 10 ürün olabilir";
		public static string ProductNameAlreadyExist= "Bu isimde zaten başka bir ürün var";
		public static string CategoryLimitExeeded="Kategori limiti aşıldığı için yeni ürün eklenemiyor";
		public static string AuthorizationDenied="Yetkinzi yok";
		public static string UserRegistered="Kayıt bulunamadı";
		public static string UserNotFound="Kullanıcı bulunamadı";
		public static string PasswordError="Parola hatası";
		public static string SuccessfulLogin="Başarılı giriş";
		public static string UserAlreadyExists="Bu kullanıcı mevcut";
		internal static string AccessTokenCreated="Token oluşturuldu";
	}
}

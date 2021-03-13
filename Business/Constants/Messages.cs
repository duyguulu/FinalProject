﻿using Core.Entities.Concrete;
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
		public static string AuthorizationDenied="Yetkiniz yok";
		public static string UserRegistered="Kullanıcı başarıyla kaydedildi";
		public static string UserNotFound="Kullanıcı bulunamadı";
		public static string PasswordError="Parola hatası";
		public static string SuccessfulLogin="Sisteme giriş başarılı giriş";
		public static string UserAlreadyExists="Bu kullanıcı zaten mevcut";
		internal static string AccessTokenCreated="Token oluşturuldu";
	}
}

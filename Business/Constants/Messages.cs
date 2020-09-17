using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string SuccessAdded = "Ekleme başarılı";
        public static string SuccessUpdated = "Güncelleme başarılı";
        public static string SuccessDeleted = "Silme başarılı";
        public static string SuccessGetById = "Kayıt getirme başarılı";
        public static string SuccessGetList = "Listeleme başarılı";

        public static string ErrorAdded = "Ekleme başarısız";
        public static string ErrorUpdated = "Güncelleme başarısız";
        public static string ErrorDeleted = "Silme başarısız";
        public static string ErrorGetById = "Kayıt getirme başarısız";
        public static string ErrorGetList = "Listeleme başarısız";

        public static string UserAlreadyExist = "kullanıcı mevcut";
        public static string UserNotFound = "kullanıcı bulunamadı";

        public static string ErrorLogin = "Giriş başarısız";
        public static string SuccessfulyLogin = "Giriş başarılı";
        public static string ErrorRegistered = "Kayıt başarısız";
        public static string SuccessRegistered = "Kayıt başarılı";

        public static string ErrorGetClaims = "Roleler getirilemedi";
        public static string CreateToken="Token oluşturuldu";
    }
}
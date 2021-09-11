using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car Added Succesfully";
        public static string CarUpdated = "Car Updated Succesfully";
        public static string CarDeleted = "Car Deleted Succesfully";
        public static string UserNotFound = "User Not Found";
        public static string PasswordError = "Password Is Incorrect";
        public static string SuccessfulLogin = "Login Is Successful";
        public static string UserAlreadyExists = "User Already Exists";
        public static string UserRegistered = "User Succesfully Registered";
        public static string AccessTokenCreated = "Access Token Created Successfully";
        public static string AuthorizationDenied = "Authorization Denied";
    }
}

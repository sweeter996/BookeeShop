﻿using BookeeShop.Areas.Admin.Models;
using BookeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using PagedList;

namespace BookeeShop.Areas.Admin.Data_Access
{
    public static class CustomerDAO
    {
        public static Boolean IsNullCutomer(string email)
        {
            CustomerModel existUser = new BookeeDb().Customers.FirstOrDefault(search => search.Email == email);
            return existUser == null ? true : false;
        }
        public static string encryptPassword(string inputPassword)
        {
            //Tạo MD5
            MD5 encrypt = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(inputPassword);
            //mã hóa chuỗi đã chuyển
            byte[] hash = encrypt.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder outputPassword = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                outputPassword.Append(hash[i].ToString("x2"));
            }
            return outputPassword.ToString();
        }
        public static Boolean InsertOnMock(cast_RegisterCustomerModel user)
        {
            const string URL = "http://5b423711e6d38000147feee8.mockapi.io/";
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri(URL);
            var postTask = http.PostAsJsonAsync<cast_RegisterCustomerModel>("Customers", user);
            postTask.Wait();
            var result = postTask.Result;
            //if success return true else false
            if (result.IsSuccessStatusCode)
            {
                return result.IsSuccessStatusCode;
            }
            else
            {
                return false;
            }
            //ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
        }

        public static cast_RegisterCustomerModel GetUserOnMock(int userId)
        {
            cast_RegisterCustomerModel user = new cast_RegisterCustomerModel(); ;
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri("http://5b423711e6d38000147feee8.mockapi.io/");
                HttpResponseMessage response = http.GetAsync("/Customers/" + userId).Result;
                if (response.IsSuccessStatusCode)
                {
                    var readContent = response.Content.ReadAsAsync<cast_RegisterCustomerModel>();
                    readContent.Wait();
                    user = readContent.Result;
                }
                return user;
            }
        }

        public static IEnumerable<castBookModel> pagingnationList(int page, int size)
        {
            using (var db = new BookeeDb())
            {
                var list = from book in db.BookInformation
                           orderby book.BookAddedDate descending
                           select new castBookModel
                           {
                               BookID = book.BookID,
                               BookName = book.BookName,
                               BookAuthor = book.Bookauthor,
                               BookCover = book.BookCoverImage,
                               BookPrice = book.BookPrice
                           };
                return list.ToPagedList(page, size);
            }
        }
    }
}
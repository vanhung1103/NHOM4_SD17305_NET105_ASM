using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHOM5_NET105_SD17305.Data.Models
{
    public static class SissionServices
    {
        public static List<Product> GetObjFromSession(ISession session, string key)
        {
            // Bước 1: Lấy string data từ session ở dạng json
            string jsonData = session.GetString(key);
            if (jsonData == null) return new List<Product>();
            // Nếu dữ liệu null thì tạo mới 1 list rỗng
            // bước 2: Convert về List
            var products = JsonConvert.DeserializeObject<List<Product>>(jsonData);
            return products;
        }
        // Ghi dữ liệu từ 1 list vào session
        public static void SetObjToSession(ISession session, string key, object values)
        {
            var jsonData = JsonConvert.SerializeObject(values);
            session.SetString(key, jsonData);
        }
        public static bool CheckExistProduct(int id, List<Product> products)
        {
            return products.Any(x => x.Id == id);
        }
    }
}

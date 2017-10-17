using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public byte[] Content { get; set; }

        public int Sorting { get; set; }

        public string Src { get; set; }

        public static string ByteToString(byte[] content)
        {
            var base64 = Convert.ToBase64String(content);
            return $"data:image/gif;base64,{base64}";
        }
    }
}
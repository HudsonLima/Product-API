using System;
using System.IO;

namespace ProductAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Unit { get; set; }

        public Int32 Quantity { get; set; }

        public decimal Price { get; set; }

        public Boolean Active { get; set; }

        public Int32 Brand_Id { get; set; }

        public static MemoryStream GenerateTxt(int number)
        {
            MemoryStream memoryStream = new MemoryStream();
            TextWriter tw = new StreamWriter(memoryStream);

            tw.WriteLine("Total Products");
            tw.WriteLine(number);
            tw.Flush();
            tw.Close();

            return memoryStream;
        }

    }

}

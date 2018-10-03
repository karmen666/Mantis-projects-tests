using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace MantisTests
{
   public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]

        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            if (l == 0)
            {
                l = 1;
            }
            StringBuilder builder = new StringBuilder();
            string chars = "1234567890abcdefghijklmnopqrstuvwxyz1234567890_ABCDEFGHIJKLMNOPQRSTUVWXYZ-&";
            for (int i = 0; i < l; i++)
            {
                int num = rnd.Next(0, chars.Length - 1);
                builder.Append(chars[num]);
            }
            return builder.ToString();
        }

    }
}

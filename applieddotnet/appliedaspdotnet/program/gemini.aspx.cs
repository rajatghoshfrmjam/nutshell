
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appliedaspdotnet.ServiceRef1;


namespace appliedaspdotnet.program
{
    
    public partial class gemini : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //DisplayPrimesCount();
            Go();
            LocateWcf();

            byte[] val = { };
            // val is a byte[] from the database
            string fileExtension = PictureHelper.TryGetExtension(val);

            // check if a valid file extension was found
            if (fileExtension != null)
            {
                // it is a valid image file, write it to disk for further processing
                string fileName = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + "." + fileExtension);
                File.WriteAllBytes(fileName, val);
            }

        }

        void Go()
        {
            string result = string.Empty;
            for (int i = 1; i < 5; i++)
                result += GetPrimesCount(i * 1000000, 1000000) +
                  " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1) +  "</br>";
            Print(result);
        }

        int GetPrimesCount(int start, int count)
        {
            return ParallelEnumerable.Range(start, count).Count(n =>
            Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
        }

        async void DisplayPrimesCount()
        {
            int result = await GetPrimesCountAsync(2, 1000000);
            Print(result);
        }

        Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() =>
              ParallelEnumerable.Range(start, count).Count(n =>
                Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }

        private void LocateWcf()
        {
            var client = new Service1Client();
            string resp = client.GetData(5);
            Print(resp);
        }

        private void Print(string text)
        {
            Response.Write(text);
        }
        private void Print(Object text)
        {
            Response.Write(text);
        }
    }
}
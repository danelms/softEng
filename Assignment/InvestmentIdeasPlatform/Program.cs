using InvestmentIdeasPlatform.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestmentIdeasPlatform
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Test();

            Application.Run(new HomePage());
        }

        /// <summary>
        /// Used to test functionality
        /// </summary>
        private static void Test()
        {
            Client test = new Client("John Doe", "isitDoe123", "password123", 1);

            Console.WriteLine(test.getName());
            Console.WriteLine(test.getProfilePicture());

            FundAdministrator testFA = new FundAdministrator("Jane Doe", "DoezyCow123", "password!", 3);

            Console.WriteLine(testFA.getName());
            Console.WriteLine(testFA.getProfilePicture());
            Form form = new Form();
            form.Show();
            PictureBox pb = new PictureBox();
            pb.Image = new Bitmap(testFA.getProfilePicture());
            pb.Size = new Size(500, 500);
            form.Controls.Add(pb);
        }
    }

}

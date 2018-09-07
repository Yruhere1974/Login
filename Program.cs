//Green text is comments it wil have two slashed on the front or be surrounded in /*   */
//Hi Clark this is a new change


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
	class Program
	{
		static string myBatchFileName { get { return "brainstart.bat"; } } //This is the name of the file we are going to run.  We have made it static which means ir
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome!!");
			Console.Write("Enter User Name:");
			string UserName = Console.ReadLine();
			Console.Write("Enter Password:");
			string Password = Console.ReadLine();
			string Permission = Security.TestCredentials(UserName, Password);
			Console.WriteLine("Permission Level:" + Permission);
			if (Permission == "ADMIN")
			{
				AdminPermissions();
			}
			if (Permission == "NORMAL")
			{
				RunBatchFile();
			}

		}
		static void AdminPermissions()
		{
			Console.WriteLine("1   Add Login");
			Console.WriteLine("2   Run File");
			Console.Write("Choice:");
			ConsoleKeyInfo key = Console.ReadKey();
			Console.WriteLine(key.KeyChar);
			if (key.KeyChar =='1')
			{
				AddUser();
			}
			else
			{
				RunBatchFile();
			}
			
			
			


		}
		static void RunBatchFile()
		{
			System.Diagnostics.Process.Start(myBatchFileName);
		}
		static void AddUser()
		{
			Console.WriteLine("------Add User--------");
			Console.Write("Enter New User Name:");
			string UserName = Console.ReadLine();
			Console.Write("Enter New Password:");
			string Password = Console.ReadLine();
			Console.Write("Permission Level ADMIN/NORMAL:");
			string Permission = Console.ReadLine();


			Security.CreateLogin(UserName, Password,Permission.ToUpper());
			AdminPermissions();


		}





	}


}

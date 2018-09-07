using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
	public static class Security
	{
		public static string FilePath { get { return "Users.bin"; } }
		public static void CreateLogin(string User,string Pass,string Perm)
		{
			List<Login> Logins;
			Login newLogin = new Login() { UserName = User, Password = Pass, Permissions = Perm };
			if (File.Exists(FilePath))
			{
				Logins = GetLogins();
			}
			else
			{
				Logins = new List<Login>();
			}
				
			Logins.Add(newLogin);
			writeLogins(Logins);
		}
		public static void CreateDefault()
		{
			CreateLogin("Clark","DaddyLovesYou","ADMIN");
		}
		public static List<Login> GetLogins()
		{

			if (!File.Exists(FilePath)) { CreateDefault(); }
			List<Login> Logins;
			Logins = new List<Login>();
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				Logins= (List<Login>)binaryFormatter.Deserialize(fs);
			}
			return Logins;
		}
		public static void writeLogins(List<Login> Logins)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			using (FileStream fs = new FileStream(FilePath,FileMode.Create))
			{
				binaryFormatter.Serialize(fs, Logins);
			}
		}

		public static string TestCredentials(string UserName, string Password)
		{
			List<Login> Logins = GetLogins();
			Logins = Logins.Where(p => p.UserName.ToUpper() == UserName.ToUpper()).ToList();
			Logins = Logins.Where(p => p.Password == Password).ToList();

			if (Logins.Count >0)
			{ return Logins[0].Permissions; }
			else
			{
				return "No Permission";
			}
		}

	}

	[Serializable]
	public class Login
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Permissions { get; set; }

	}
}

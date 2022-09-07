using Newtonsoft.Json;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace server
{
	class Program
	{
		/*				COLORS
		 *				
		 *				1 - White
		 *				2 - Blue
		 *				3 - Red
		 *				4 - Green
		 *				5 - Yellow
		 *				6 - DarkYellow
		 *				7 - Gray
		 *				8 - DarkGray
		 *				
		 *				ENCRYPTION KEY: 1c25497f6c5f90a0878e4f5bab53b37d
		 * */

		class Client {
			public ushort id;
			public TcpClient tcp;
			public string name;
			public bool is_admin = false;

			public Client(TcpClient _tcp, string _name, bool _is_admin)
			{
				tcp = _tcp;
				name = _name;
				is_admin = _is_admin;
			}
		}
		static List<Client> clients = new List<Client>(10000);

		static Client get_client_by_tcp(TcpClient tcp)
		{
			foreach(Client client in clients)
			{
				if (client.tcp == tcp)
					return client;
			}
			return null;
		}

		static Client get_client_by_id(int id)
		{
			foreach (Client client in clients)
			{
				if (client.id == id)
					return client;
			}
			return null;
		}

		static Client get_client_by_name(string name)
		{
			foreach (Client client in clients)
			{
				if (client.name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
					return client;
			}
			return null;
		}

		static ushort get_available_id()
		{
			for(ushort i = 1; i < clients.Capacity; i++)
			{
				if (get_client_by_id(i) == null) return i;
			}
			return 0;
		}

		static SimpleTcpServer server;
        static void Main(string[] args)
        {
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
			Console.Title = "Saitan Chat - Server";
            Thread main_thrd = new Thread(new ThreadStart(MainThread));
            main_thrd.IsBackground = true;
            main_thrd.Start();
			try
			{
				server = new SimpleTcpServer();
				server.Delimiter = 0x13;
				server.StringEncoder = Encoding.UTF8;
				server.DataReceived += server_dataReceived;
				server.ClientDisconnected += server_clientDisconnected;
				server.Start(IPAddress.Any, 87);
				print("@8[SERVER]: Server is now open on port 87. Awaiting connections...\n");
				while(true)
				{
					Thread.Sleep(10);
				}
			}
			catch(Exception e)
			{
				print("@1[SERVER]: Error while starting the server. Exception: \n");
				print("@7"+e.Message+".\n");
				Console.Read();
			}
		}

		static void OnProcessExit(object sender, EventArgs e)
		{
			server.Broadcast(b1nk("[***]shutdown", "1c25497f6c5f90a0878e4f5bab53b37d"));
			server.Stop();
		}

		private static void server_clientDisconnected(object sender, TcpClient e)
		{
			Client leaver = get_client_by_tcp(e);
			print((leaver.is_admin ? "@3" : "@7") + " * " + leaver.name + " left. (ID: #" + leaver.id + ")\n");
			clients.Remove(leaver);
		}

		private static void server_dataReceived(object sender, Message e)
		{
			string msg = unk0wn(e.MessageString, "1c25497f6c5f90a0878e4f5bab53b37d");
			if (msg.StartsWith("[*]"))
			{
				ushort id = get_available_id();
				string[] split = msg.Split(new[] { "[*]" }, StringSplitOptions.None);
				if (id == 0)
				{
					e.TcpClient.Close();
					print((split[2].Equals("1") ? "@3" : "@7") + " * " + split[1] + " tried to connect but the server is full.\n");
					return;
				}
				if(get_client_by_name(split[1]) != null)
				{
					Random x = new Random();
					int y = x.Next(69, 150000);
					split[1] += "(" + y.ToString() + ")";
				}
				Client newclient = new Client(e.TcpClient, split[1], (split[2].Equals("1") ? true : false));
				clients.Add(newclient);
				newclient.id = id;
				print((split[2].Equals("1") ? "@3" : "@7") + " * " + split[1] + " connected. (ID: #" + newclient.id + ")\n");
			}
			else if(msg.StartsWith("[**]"))
			{
				string[] split = msg.Split(new[] { "[**]" }, StringSplitOptions.None);
				Client cl = get_client_by_tcp(e.TcpClient);
				if (split[1].StartsWith("/") && cl.is_admin)
				{
					print(string.Format("<{0}> {1} used command {2}.\n", DateTime.Now.ToString("HH:mm:ss"), cl.name, split[1]));
					if (split[1].StartsWith("/reveal ", StringComparison.CurrentCultureIgnoreCase))
					{
						split[1] = split[1].Remove(0, 8);
						Client cli = get_client_by_name(split[1]);
						if (cli != null)
						{
							string x = cli.tcp.Client.RemoteEndPoint.ToString().Split(':')[0];
							var json = new WebClient().DownloadString("https://api.freegeoip.app/json/" + x + "?apikey=8ae48100-66e9-11ec-a69c-d18b84583d87");
							dynamic deserializedProduct = JsonConvert.DeserializeObject<dynamic>(json);
							string result = string.Empty;
							if (deserializedProduct["status"].ToString().Equals("fail")) result = "Cannot reveal this IP. (" + x + ")";
							else
							{
								result += "============= REVEAL =============\n";
								result += "Name: " + cli.name + "\n";
								result += "IP: " + x + "\n";
								result += "Country: " + deserializedProduct["country"].ToString() + "\n";
								result += "City: " + deserializedProduct["city"].ToString() + "\n";
								result += "=================================";
							}
							server.Broadcast(b1nk(
								"[*****]" + cl.tcp.Client.RemoteEndPoint.ToString().Split(':')[0] + "[*****]" + 
								result, "1c25497f6c5f90a0878e4f5bab53b37d"));
						}
						else server.Broadcast(b1nk(
							"[*****]" + cl.tcp.Client.RemoteEndPoint.ToString().Split(':')[0] + 
							"[*****]User not found.", "1c25497f6c5f90a0878e4f5bab53b37d"));

					}
				}
				else
				{
					server.Broadcast(b1nk("[**]" +
					string.Format("<{0}> {1}: {2}", DateTime.Now.ToString("HH:mm:ss"), cl.name, split[1]), "1c25497f6c5f90a0878e4f5bab53b37d"));
					print(string.Format("<{0}> {1} sent a message.\n", DateTime.Now.ToString("HH:mm:ss"), cl.name));
				}
			}
		}

		static void MainThread()
		{ 
			while(true)
			{
				Thread.Sleep(2000);
				if(server.ConnectedClientsCount > 0)
				{
					string list = string.Empty;
					foreach(Client cl in clients)
					{
						list += "[****]" + cl.name;
					}
					server.Broadcast(b1nk(list, "1c25497f6c5f90a0878e4f5bab53b37d"));
				}
			}
		}


		static void print(string message)
		{
			bool amp = false;
			for (int i = 0; i < message.Length; i++)
			{
				bool hold = false;
				if (!amp)
				{
					if (message[i].Equals('@'))
					{
						amp = true;
						hold = true;
					}
				}
				else
				{
					switch (message[i] - 48)
					{
						case 1:
							{
								Console.ForegroundColor = ConsoleColor.White;
								break;
							}
						case 2:
							{
								Console.ForegroundColor = ConsoleColor.Blue;
								break;
							}
						case 3:
							{
								Console.ForegroundColor = ConsoleColor.Red;
								break;
							}
						case 4:
							{
								Console.ForegroundColor = ConsoleColor.Green;
								break;
							}
						case 5:
							{
								Console.ForegroundColor = ConsoleColor.Yellow;
								break;
							}
						case 6:
							{
								Console.ForegroundColor = ConsoleColor.DarkYellow;
								break;
							}
						case 7:
							{
								Console.ForegroundColor = ConsoleColor.Gray;
								break;
							}
						case 8:
							{
								Console.ForegroundColor = ConsoleColor.DarkGray;
								break;
							}
					}
					amp = false;
					hold = true;
				}
				if (!hold) Console.Write(message[i]);
			}
			Console.ForegroundColor = ConsoleColor.White;
		}

		public static string b1nk(string x, string encrypt)//function
		{
			try
			{
				string y = x;
				byte[] etext = UTF8Encoding.UTF8.GetBytes(y);
				string Code = encrypt;
				MD5CryptoServiceProvider mdhash = new MD5CryptoServiceProvider();
				byte[] keyarray = mdhash.ComputeHash(UTF8Encoding.UTF8.GetBytes(Code));
				TripleDESCryptoServiceProvider tds = new TripleDESCryptoServiceProvider();
				tds.Key = keyarray;
				tds.Mode = CipherMode.ECB;
				tds.Padding = PaddingMode.PKCS7;

				ICryptoTransform itransform = tds.CreateEncryptor();
				byte[] result = itransform.TransformFinalBlock(etext, 0, etext.Length);
				string encryptresult = Convert.ToBase64String(result);
				return encryptresult.ToString();
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
		public static string unk0wn(string x, string keyai)
		{
			try
			{
				string y = x.Replace("\0", null);
				byte[] etext = Convert.FromBase64String(y);
				string key = keyai;
				MD5CryptoServiceProvider mdhash = new MD5CryptoServiceProvider();
				byte[] keyarray = mdhash.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
				TripleDESCryptoServiceProvider tds = new TripleDESCryptoServiceProvider();
				tds.Key = keyarray;
				tds.Mode = CipherMode.ECB;
				tds.Padding = PaddingMode.PKCS7;

				ICryptoTransform itransform = tds.CreateDecryptor();
				byte[] result = itransform.TransformFinalBlock(etext, 0, etext.Length);
				string dencryptresult = UTF8Encoding.UTF8.GetString(result);
				return dencryptresult.ToString();
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}
}

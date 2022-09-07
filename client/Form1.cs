using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
	public partial class Form1 : Form
	{
		SimpleTcpClient client;
		bool connected = false;
		public Form1()
		{
			InitializeComponent();
			client = new SimpleTcpClient();
			client.Delimiter = 0x13;
			client.StringEncoder = Encoding.UTF8;
			client.DataReceived += client_dataReceived;
			Thread main_thrd = new Thread(new ThreadStart(W0RK))
			{
				IsBackground = true
			};
			main_thrd.Start();
		}

		async void W0RK()
		{
			while (true)
			{
				Thread.Sleep(2000);
				if (connected)
				{
					string target = string.Empty;
					listclients.Invoke((MethodInvoker)delegate ()
					{
					   target += "Users: " + listclients.Items.Count + "\n";
					});
					var pingSender = new Ping();
					var hostNameOrAddress = ipbox.Text;
					var reply = await pingSender.SendPingAsync(hostNameOrAddress);

					target += "Ping: " + reply.RoundtripTime.ToString() + "ms\n";
					target += "Admin: Yes\n";
					target += "Host: " + 
						(client.TcpClient.Client.RemoteEndPoint.ToString().Equals(ipbox.Text + ":" + portbox.Text) ? "Yes\n" : "No\n");
					infolabel.Invoke((MethodInvoker)delegate ()
					{
						infolabel.Text = target;
					});
				}
			}
		}

		private void client_dataReceived(object sender, SimpleTCP.Message e)
		{
			string msg = unk0wn(e.MessageString, h4v0c("d73b35bab5f4e8780a09f5c6f79452c1"));
			if (msg.StartsWith("[**]"))
			{
				string[] split = msg.Split(new[] { "[**]" }, StringSplitOptions.None);
				logbox.Invoke((MethodInvoker)delegate ()
			   {
				   logbox.AppendText(split[1] + "\n");
			   });
			}
			else if(msg.StartsWith("[***]"))
			{
				string[] split = msg.Split(new[] { "[***]" }, StringSplitOptions.None);
				if (split[1].Equals("shutdown"))
				{
					connected = false;
					logbox.Invoke((MethodInvoker)delegate ()
					{
						logbox.AppendText("The server has shut down.\n");
					});
					listclients.Invoke((MethodInvoker)delegate ()
					{
						listclients.Items.Clear();
					});
				}
			}
			else if (msg.StartsWith("[****]"))
			{
				string[] split = msg.Split(new[] { "[****]" }, StringSplitOptions.None);
				listclients.Invoke((MethodInvoker)delegate ()
				{
					listclients.Items.Clear();
				});
				foreach (string sp in split)
				{
					if (sp.Length < 3) continue;
					listclients.Invoke((MethodInvoker)delegate ()
					{
						listclients.Items.Add(sp);
					});
				}
			}
			else if (msg.StartsWith("[*****]"))
			{
				string[] split = msg.Split(new[] { "[*****]" }, StringSplitOptions.None);
				
				if(split[1].Equals(client.TcpClient.Client.RemoteEndPoint.ToString().Split(':')[0]))
				{
					logbox.Invoke((MethodInvoker)delegate ()
					{
						logbox.AppendText(split[2] + "\n");
					});
				}
			}
		}

		static string h4v0c(string param)
		{
			string x = param, y;
			char[] charArray = x.ToCharArray();
			Array.Reverse(charArray);
			y = new string(charArray);
			return y;
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

		private void connectbox_Click(object sender, EventArgs e)
		{
			if (!connected)
			{
				try
				{
					if(namebox.Text.Length < 3)
					{
						logbox.AppendText("The name is too short.");
						return;
					}
					listclients.Items.Clear();
					client.Connect(ipbox.Text, int.Parse(portbox.Text));
					client.Write(b1nk("[*]" + namebox.Text + "[*]1", h4v0c("d73b35bab5f4e8780a09f5c6f79452c1")));
					connected = true;
					ipbox.Enabled = false;
					portbox.Enabled = false;
					namebox.Enabled = false;
				}
				catch (Exception ee)
				{
					MessageBox.Show(ee.Message);
				}
			}
		}

		private void disconnectbtn_Click(object sender, EventArgs e)
		{
			if(connected)
			{
				listclients.Items.Clear();
				client.Disconnect();
				connected = false;
				logbox.AppendText("Disconnected from the server.\n");
				ipbox.Enabled = true;
				portbox.Enabled = true;
				namebox.Enabled = true;
			}
		}

		private void sendbtn_Click(object sender, EventArgs e)
		{
			if(connected)
			{
				if (sendtext.Text.Length < 1) return;
				client.Write(b1nk("[**]" + sendtext.Text, h4v0c("d73b35bab5f4e8780a09f5c6f79452c1")));
			}
			sendtext.Text = string.Empty;
		}

		private void clearbtn_Click(object sender, EventArgs e)
		{
			sendtext.Text = string.Empty;
			logbox.Text = string.Empty;
		}
	}
}

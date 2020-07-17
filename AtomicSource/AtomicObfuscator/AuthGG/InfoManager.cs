using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;

namespace AuthGG
{
	// Token: 0x02000042 RID: 66
	internal class InfoManager
	{
		// Token: 0x06000151 RID: 337 RVA: 0x0000278B File Offset: 0x0000098B
		public InfoManager()
		{
			this.lastGateway = this.GetGatewayMAC();
		}

		// Token: 0x06000152 RID: 338 RVA: 0x000027A1 File Offset: 0x000009A1
		public void StartListener()
		{
			this.timer = new Timer(delegate(object _)
			{
				this.OnCallBack();
			}, null, 5000, -1);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00010204 File Offset: 0x0000E404
		private void OnCallBack()
		{
			this.timer.Dispose();
			bool flag = !(this.GetGatewayMAC() == this.lastGateway);
			if (flag)
			{
				Constants.Breached = true;
				MessageBox.Show("ARP Cache poisoning has been detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				Process.GetCurrentProcess().Kill();
			}
			else
			{
				this.lastGateway = this.GetGatewayMAC();
			}
			this.timer = new Timer(delegate(object _)
			{
				this.OnCallBack();
			}, null, 5000, -1);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0001028C File Offset: 0x0000E48C
		public static IPAddress GetDefaultGateway()
		{
			return (from g in (from n in NetworkInterface.GetAllNetworkInterfaces()
			where n.OperationalStatus == OperationalStatus.Up
			where n.NetworkInterfaceType != NetworkInterfaceType.Loopback
			select n).SelectMany(delegate(NetworkInterface n)
			{
				IPInterfaceProperties ipproperties = n.GetIPProperties();
				return (ipproperties != null) ? ipproperties.GatewayAddresses : null;
			})
			select (g != null) ? g.Address : null into a
			where a != null
			select a).FirstOrDefault<IPAddress>();
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0001035C File Offset: 0x0000E55C
		private string GetArpTable()
		{
			string pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
			string result;
			using (Process process = Process.Start(new ProcessStartInfo
			{
				FileName = pathRoot + "Windows\\System32\\arp.exe",
				Arguments = "-a",
				UseShellExecute = false,
				RedirectStandardOutput = true
			}))
			{
				using (StreamReader standardOutput = process.StandardOutput)
				{
					result = standardOutput.ReadToEnd();
				}
			}
			return result;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000103F8 File Offset: 0x0000E5F8
		private string GetGatewayMAC()
		{
			string arg = InfoManager.GetDefaultGateway().ToString();
			string pattern = string.Format("({0} [\\W]*) ([a-z0-9-]*)", arg);
			Regex regex = new Regex(pattern);
			Match match = regex.Match(this.GetArpTable());
			return match.Groups[2].ToString();
		}

		// Token: 0x040000A5 RID: 165
		private Timer timer;

		// Token: 0x040000A6 RID: 166
		private string lastGateway;
	}
}

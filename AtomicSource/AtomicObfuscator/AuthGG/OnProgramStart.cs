using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows;

namespace AuthGG
{
	// Token: 0x0200003B RID: 59
	internal class OnProgramStart
	{
		// Token: 0x0600012F RID: 303 RVA: 0x0000E130 File Offset: 0x0000C330
		public static void Initialize(string name, string aid, string secret, string version)
		{
			OnProgramStart.AID = aid;
			OnProgramStart.Secret = secret;
			OnProgramStart.Version = version;
			OnProgramStart.Name = name;
			string[] array = new string[0];
			using (WebClient webClient = new WebClient())
			{
				try
				{
					webClient.Proxy = null;
					Security.Start();
					Encoding @default = Encoding.Default;
					WebClient webClient2 = webClient;
					string apiUrl = Constants.ApiUrl;
					NameValueCollection nameValueCollection = new NameValueCollection();
					nameValueCollection["token"] = Encryption.EncryptService(Constants.Token);
					nameValueCollection["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString());
					nameValueCollection["aid"] = Encryption.APIService(OnProgramStart.AID);
					nameValueCollection["session_id"] = Constants.IV;
					nameValueCollection["api_id"] = Constants.APIENCRYPTSALT;
					nameValueCollection["api_key"] = Constants.APIENCRYPTKEY;
					nameValueCollection["session_key"] = Constants.Key;
					nameValueCollection["secret"] = Encryption.APIService(OnProgramStart.Secret);
					nameValueCollection["type"] = Encryption.APIService("start");
					array = Encryption.DecryptService(@default.GetString(webClient2.UploadValues(apiUrl, nameValueCollection))).Split("|".ToCharArray());
					bool flag = Security.MaliciousCheck(array[1]);
					if (flag)
					{
						MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
						Process.GetCurrentProcess().Kill();
					}
					bool breached = Constants.Breached;
					if (breached)
					{
						MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
						Process.GetCurrentProcess().Kill();
					}
					bool flag2 = array[0] != Constants.Token;
					if (flag2)
					{
						MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
						Process.GetCurrentProcess().Kill();
					}
					string text = array[2];
					string text2 = text;
					if (text2 != null)
					{
						if (!(text2 == "success"))
						{
							if (text2 == "binderror")
							{
								MessageBox.Show(Encryption.Decode("RmFpbGVkIHRvIGJpbmQgdG8gc2VydmVyLCBjaGVjayB5b3VyIEFJRCAmIFNlY3JldCBpbiB5b3VyIGNvZGUh"), OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
								Process.GetCurrentProcess().Kill();
								return;
							}
							if (text2 == "banned")
							{
								MessageBox.Show("This application has been banned for violating the TOS" + Environment.NewLine + "Contact us at support@auth.gg", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
								Process.GetCurrentProcess().Kill();
								return;
							}
						}
						else
						{
							Constants.Initialized = true;
							bool flag3 = array[3] == "Enabled";
							if (flag3)
							{
								ApplicationSettings.Status = true;
							}
							bool flag4 = array[4] == "Enabled";
							if (flag4)
							{
								ApplicationSettings.DeveloperMode = true;
							}
							ApplicationSettings.Hash = array[5];
							ApplicationSettings.Version = array[6];
							ApplicationSettings.Update_Link = array[7];
							bool flag5 = array[8] == "Enabled";
							if (flag5)
							{
								ApplicationSettings.Freemode = true;
							}
							bool flag6 = array[9] == "Enabled";
							if (flag6)
							{
								ApplicationSettings.Login = true;
							}
							ApplicationSettings.Name = array[10];
							bool flag7 = array[11] == "Enabled";
							if (flag7)
							{
								ApplicationSettings.Register = true;
							}
							else
							{
								bool flag8 = ApplicationSettings.Version != OnProgramStart.Version;
								if (flag8)
								{
									MessageBox.Show("Update " + ApplicationSettings.Version + " available, redirecting to update!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
									Process.Start(ApplicationSettings.Update_Link);
									Process.GetCurrentProcess().Kill();
								}
								bool flag9 = array[12] == "Enabled";
								if (flag9)
								{
									bool flag10 = ApplicationSettings.Hash != Security.Integrity(Process.GetCurrentProcess().MainModule.FileName);
									if (flag10)
									{
										MessageBox.Show("File has been tampered with, couldn't verify integrity!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
										Process.GetCurrentProcess().Kill();
									}
								}
							}
							bool flag11 = !ApplicationSettings.Status;
							if (flag11)
							{
								MessageBox.Show("Looks like this application is disabled, please try again later!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
								Process.GetCurrentProcess().Kill();
							}
						}
					}
					Security.End();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
					Process.GetCurrentProcess().Kill();
				}
			}
		}

		// Token: 0x0400009B RID: 155
		public static string AID = null;

		// Token: 0x0400009C RID: 156
		public static string Secret = null;

		// Token: 0x0400009D RID: 157
		public static string Version = null;

		// Token: 0x0400009E RID: 158
		public static string Name = null;

		// Token: 0x0400009F RID: 159
		public static string Salt = null;
	}
}

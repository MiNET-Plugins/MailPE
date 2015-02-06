using System;
using MiNET;
using MiNET.API;
using MiNET.PluginSystem.Attributes;

namespace MailPE
{
	[Plugin("MailPE", "PM Other players.", "1.0", "kennyvv")]
    public class Main : MiNETPlugin
    {
		public override void OnEnable()
		{
			Console.WriteLine("[MailPE] MailPE is enabled");
			Console.WriteLine("[MailPE] Written by Kennyvv");
		}

		[Command("msg", "MailPE.PM", "Private message anyone", "/msg <username> <message>")]
		public void MSG(Player source, string[] arguments)
		{
			PM(source, arguments);
		}

		[Command("pm", "MailPE.PM", "Private message anyone", "/pm <username> <message>")]
		public void PM(Player source, string[] arguments)
		{
			if (arguments.Length >= 2)
			{
				Player target = getPlayer(arguments[0], source);
				if (target != source)
				{
					string message = string.Empty;
					for (int i = 1; i < arguments.Length; i++)
					{
						message += arguments[i];
					}
					target.SendMessage("[MailPE] " + source.Username + ": " + message);
					source.SendMessage("[MailPE] Message to " + target.Username + " was sent!");
				}
				else
				{
					source.SendMessage("[MailPE] Player not found!");
				}
			}
			else
			{
				source.SendMessage("[MailPE] Wrong command usage!");
			}
		}

		private Player getPlayer(string name, Player source)
		{
			foreach (var user in source.Level.Players)
			{
				if (user.Username.Contains(name))
				{
					return user;
				}
			}
			return source;
		}
    }
}

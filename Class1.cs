using System;
using System.IO;
using Bot;
using Bot.CommandSystem;
using Newtonsoft.Json;
using OpenMetaverse;
using LibreMetaverse;

namespace BlankBot
{
    public class Program : IProgram
    {

        public MessageHandler.MessageHandleEvent MHE;
        public GridClient m;

        public string ProgramName
        {
            get
            {
                return "BlankBot";
            }
        }
        public float ProgramVersion
        {
            get
            {
                return 1.1f;
            }
        }

        public string getTick()
        {
            return "";
        }

        public void LoadConfiguration()
        {
            // no current configuration

            throw new InvalidOperationException("This function is not valid for BlankBot.dll");
        }

        public void onIMEvent(object sender, InstantMessageEventArgs e)
        {
        }

        public void passArguments(string data)
        {

        }

        public void run(GridClient client, MessageHandler MH, CommandRegistry registry)
        {
            BotSession.Instance.Logger.info(log: "BlankBot.dll is now active");
        }



    }
}

using System;
using System.Collections.Generic;
using System.Text;
using LibreMetaverse;
using OpenMetaverse;
using Newtonsoft.Json;
using Bot;

namespace BlankBot
{
    class CommandProcessor
    {
        public bool closing = false;
        public string newTickStr;
        public SysOut Log;
        MessageHandler.MessageHandleEvent M;
        public CommandProcessor(SysOut logger)
        {
            Log = logger;
        }

        public void msg(MessageHandler.Destinations D, UUID x, string m)
        {
            M(D, x, m);
        }
        public void DoCommand(string Command, MessageHandler.MessageHandleEvent MHE)
        {
            M = MHE;
            if (closing) return;
            dynamic DATA = JsonConvert.DeserializeObject(Command);
            string request = DATA.request;
            if (DATA.source == "sys") return;
            string[] para = request.Split(new[] { '.' });
            Dictionary<string, string> dstuf = new Dictionary<string, string>();
            //Console.WriteLine("[BlankBot.dll] Parse " + Command);
            msg(MessageHandler.Destinations.DEST_CONSOLE_INFO, UUID.Zero, "Running chat command");

            switch (para[0])
            {
                case "bot":
                    {
                        switch (para[1])
                        {
                            case "exit":
                                {
                                    closing = true;
                                    //Console.WriteLine("Exiting...");
                                    dstuf = new Dictionary<string, string>();
                                    dstuf.Add("type", "exit");
                                    newTickStr = JsonConvert.SerializeObject(dstuf, Formatting.Indented);
                                    M(MessageHandler.Destinations.DEST_ACTION, UUID.Zero, newTickStr);
                                    break;
                                }
                            case "assign":
                                {
                                    dstuf = new Dictionary<string, string>();
                                    dstuf.Add("type", "assignProgram");
                                    dstuf.Add("newProgram", para[2]);
                                    newTickStr = JsonConvert.SerializeObject(dstuf, Formatting.Indented);
                                    M(MessageHandler.Destinations.DEST_ACTION, UUID.Zero, newTickStr);
                                    break;
                                }
                            default:
                                break;
                        }
                        break;
                    }
                default:
                    break;
            }
            if (Command == "bot.exit")
            {
                closing = true;
            }
            else if (Command == "bot.assign")
            {

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Bot.CommandSystem;
using OpenMetaverse;
using Bot;
using Newtonsoft.Json;


namespace BlankBot
{
    public class BaseCommands
    {
        private struct NewProgram
        {
            public string type;
            public string newProgram;

            public NewProgram(string newProg)
            {
                type = "assignProgram";
                newProgram = newProg;
            }

            public string GetStr()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
        [CommandGroupMaster("Base")]
        [CommandGroup("assign",0,1, "assign [string:DLLName] - Sets DLLName as the active program", MessageHandler.Destinations.DEST_LOCAL | MessageHandler.Destinations.DEST_GROUP | MessageHandler.Destinations.DEST_AGENT)]
        public void assignDLL(UUID client, int level, GridClient grid, string[] additionalArgs,
                                MessageHandler.MessageHandleEvent MHE, MessageHandler.Destinations source,
                                CommandRegistry registry, UUID agentKey, string agentName)
        {
            MHE(MessageHandler.Destinations.DEST_ACTION, UUID.Zero, new NewProgram(additionalArgs[0]).GetStr());
        }
    }
}

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
        CommandProcessor cp = null;
        SysOut Log = SysOut.Instance;

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
                return 1.0f;
            }
        }

        public string getTick()
        {
            string movDat = cp.newTickStr;
            cp.newTickStr = "";
            return movDat;
        }

        public void LoadConfiguration()
        {
            // no current configuration

            throw new InvalidOperationException("This function is not valid for BlankBot.dll");
        }

        public void onIMEvent(object sender, InstantMessageEventArgs e)
        {
            try
            {

                FileStream FS = new FileStream("debugDump.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter sw = new StreamWriter(FS);
                if (e.IM.Dialog == InstantMessageDialog.GroupInvitation)
                {
                    sw.WriteLine("IM Type [GroupInvite] from ID " + e.IM.IMSessionID.ToString() + " from avatar ID: " + e.IM.FromAgentID.ToString() + ", " + e.IM.FromAgentName);
                }
                else if (e.IM.Dialog == InstantMessageDialog.MessageFromObject)
                {
                    sw.WriteLine("IM Type [MessageFromObject] owned by avatar (" + e.IM.FromAgentID.ToString() + ", " + e.IM.FromAgentName + ") - Msg: " + e.IM.Message + " - SimName: " + e.Simulator.Name + " - ObjectName: " + e.IM.IMSessionID.ToString());
                }


                FileInfo fi = new FileInfo("debugDump.txt");
                Console.WriteLine(" *** SAVED IM DATA TO '" + fi.FullName + "' *** ");

                sw.Close();
                FS.Close();
            }
            catch (Exception ex)
            {
                //
            }
        }

        public void passArguments(string data)
        {
            dynamic stuff = JsonConvert.DeserializeObject(data);
            if (stuff.type == "chat")
                cp.DoCommand(data, MHE);

        }

        public void run(GridClient client, MessageHandler MH, CommandRegistry registry)
        {
            m = client;
            Log = SysOut.Instance;
            cp = new CommandProcessor(Log);
            cp.newTickStr = "";
            this.MHE = MH.callbacks;
        }



    }
}

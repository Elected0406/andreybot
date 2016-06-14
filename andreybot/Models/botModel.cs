using System.IO;
using Syn.Bot;
namespace andreybot.Models
{
    public class BotBox
    {
        public SynBot andreybot;
        public BotBox()
        {
            andreybot = new SynBot();
            andreybot.PackageManager.LoadFromString(File.ReadAllText(@"D:\Работа\VisualStudioProjects\andreybot\andreybot\App_Data\Knowledge.simlpk"));
        }
    }
    public class User
    {
        public string ConnectionId { get; set; }
        public string Name { get; set; }
    }
}
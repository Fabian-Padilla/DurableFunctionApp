using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurableFunctionApp
{
    public class LSAMessage
    {
        public string QueueType { get; set; }
        public string QueueName { get; set; }
        public string MessageID { get; set; }
        public string ActionName { get; set; }
        public string Data { get; set; }
        public List<string> History { get; set; }
        public string LastStep { get; set; }
    }
}

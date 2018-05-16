using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurableFunctionApp
{
    public static class Automation
    {
        [FunctionName("StepA")]
        public static LSAMessage StepA([ActivityTrigger] LSAMessage message)
        {

            if (message.History == null) { message.History = new List<string>(); }
            message.History.Add("Step A Completed");
            return message;
        }

        [FunctionName("StepB")]
        public static LSAMessage StepB([ActivityTrigger] LSAMessage message)
        {
            if (message.History == null) { message.History = new List<string>(); }
            message.History.Add("Step B Completed");
            return message;
        }
        [FunctionName("StepC")]
        public static LSAMessage StepC([ActivityTrigger] LSAMessage message)
        {
            if (message.History == null) { message.History = new List<string>(); }
            message.History.Add("Step B Completed");
            return message;
        }
    }
}

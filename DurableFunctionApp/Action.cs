using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurableFunctionApp
{

    public static class Action
    {
        [FunctionName("ActionA1")]
        public static async Task<LSAMessage> ActionA1(
            [OrchestrationTrigger] DurableOrchestrationContextBase context)
        {

            var message = context.GetInput<LSAMessage>();

            

            message = await context.CallActivityAsync<LSAMessage>("StepA", message);

            context.SetCustomStatus(message);

            message = await context.CallActivityAsync<LSAMessage>("StepB", message);
            context.SetCustomStatus(message);

            message = await context.CallActivityAsync<LSAMessage>("StepC", message);

            context.SetCustomStatus(message);

            return message;
        }

        [FunctionName("ActionA2")]
        public static async Task<LSAMessage> ActionA2(
            [OrchestrationTrigger] DurableOrchestrationContextBase context)
        {

            var message = context.GetInput<LSAMessage>();


            message = await context.CallActivityAsync<LSAMessage>("StepA", message);
            context.SetCustomStatus(message);
            message = await context.CallActivityAsync<LSAMessage>("StepC", message);
            context.SetCustomStatus(message);


            return message;
        }

        [FunctionName("ActionA3")]
        public static async Task<LSAMessage> ActionA3(
            [OrchestrationTrigger] DurableOrchestrationContextBase context)
        {

            var message = context.GetInput<LSAMessage>();


            message = await context.CallActivityAsync<LSAMessage>("StepB", message);
            context.SetCustomStatus(message);

            message = await context.CallActivityAsync<LSAMessage>("StepC", message);
            context.SetCustomStatus(message);


            return message;
        }
    }
}

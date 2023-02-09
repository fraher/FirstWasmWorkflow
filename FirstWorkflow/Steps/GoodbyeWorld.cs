using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace FirstWasmWorkflow.Steps
{
    public class GoodbyeWorld : StepBody
    {
        private ILogger _logger;

        public GoodbyeWorld(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GoodbyeWorld>();
        }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Goodbye Workflow World (Step 3)!");
            _logger.LogInformation("This worked!!!!");
            return ExecutionResult.Next();
        }
    }
}

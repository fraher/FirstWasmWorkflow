using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace FirstWasmWorkflow.Steps
{
    public class HelloWorld : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Hello Workflow World (Step 1)!");
            return ExecutionResult.Next();
        }
    }
}

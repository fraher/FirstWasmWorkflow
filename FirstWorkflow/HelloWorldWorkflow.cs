using FirstWasmWorkflow.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace FirstWasmWorkflow 
{
    public class HelloWorldWorkflow : IWorkflow
    {
        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
                .UseDefaultErrorBehavior(WorkflowErrorHandling.Suspend)
                .StartWith<HelloWorld>()                
                .Then<GCD>()
                .Then<GoodbyeWorld>();

            
        }

        public string Id => "HelloWorld";
        public int Version => 1;

    }
}

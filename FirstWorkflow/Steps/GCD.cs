using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wasmtime;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace FirstWasmWorkflow.Steps
{
    public class GCD : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Running GCD Calculation Step using WASM (Step 2)");

            using var engine = new Engine();
            using var module = Module.FromTextFile(engine, "gcd.wat");
            using var linker = new Linker(engine);
            using var store = new Store(engine);

            linker.Define(
                "",
                "log",
                Function.FromCallback(store, (Caller caller, int first, int second) =>
                {
                    var message = caller.GetMemory("mem").ReadString(first, second);
                    Console.WriteLine($"Message from WebAssembly: {message}");
                }
            ));

            var instance = linker.Instantiate(store, module);


            var gcd = instance.GetFunction("gcd");
            if (gcd is null)
            {
                Console.WriteLine("error: gcd export is missing");
            }
            else
            {
                Console.WriteLine($"gcd(27, 6) = {gcd.Invoke(27, 6)}");
            }


            return ExecutionResult.Next();
        }
    }
}

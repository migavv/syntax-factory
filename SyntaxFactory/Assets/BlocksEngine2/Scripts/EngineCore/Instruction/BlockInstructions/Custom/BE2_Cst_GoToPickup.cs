using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- most used BE2 namespaces for instruction scripts 
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;
using System.Threading;

// --- additional BE2 namespaces used for specific cases as accessing BE2 variables or the event manager
// using MG_BlocksEngine2.Core;
// using MG_BlocksEngine2.Environment;

public class BE2_Cst_GoToPickup : BE2_InstructionBase, I_BE2_Instruction
{
     Agent _agent;
    Agent Agent{
        get{
             if (!_agent) 
             _agent=TargetObject.Transform.GetComponent<Agent>();

        return _agent;
        }
      
    }
    public Transform targetObject; // Public field to assign the target object
     
        // Assign the target object via code
        
    

    // --- Method used to implement Function Blocks (will only be called by types: simple, condition, loop, trigger)
    public new void Function()
    {
        targetObject = GameObject.Find("Destino2").transform;
        //First
       Agent.navMeshAgent.destination = targetObject.position;
       Agent.navMeshAgent.isStopped = false;
        float remainingDistance = Agent.navMeshAgent.remainingDistance;
        bool isDestinationReached = !Agent.navMeshAgent.pathPending && remainingDistance <= Agent.navMeshAgent.stoppingDistance;
        Debug.Log("Going to"+targetObject);
         if (isDestinationReached)
        {
            Debug.Log("Area reached");
            Agent.navMeshAgent.isStopped = true;
            Thread.Sleep(1000);
            ExecuteNextInstruction();
        }
    }

    // Call this method when the second detectable has been set
    protected override void OnButtonStop()
    {
        Agent.navMeshAgent.isStopped = true;
    }
}

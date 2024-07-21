using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- most used BE2 namespaces for instruction scripts 
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;
using System.Threading;
using UnityEngineInternal;
using UnityEngine.XR;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

// --- additional BE2 namespaces used for specific cases as accessing BE2 variables or the event manager
// using MG_BlocksEngine2.Core;
// using MG_BlocksEngine2.Environment;

public class BE2_Cst_GoToDelivery : BE2_InstructionBase, I_BE2_Instruction
{
    bool done = false;
    Agent _agent;
    Agent Agent{
        get{
             if (!_agent) 
             _agent=TargetObject.Transform.GetComponent<Agent>();

        return _agent;
        }
      
    }
    public Transform targetObject; // Public field to assign the target object
  

    // --- Method used to implement Function Blocks (will only be called by types: simple, condition, loop, trigger)
    public new void Function()
    {
        targetObject = GameObject.Find("Destino").transform;
        //First
        Agent.navMeshAgent.destination = targetObject.position;
        Agent.navMeshAgent.isStopped = false;
        float remainingDistance = Agent.navMeshAgent.remainingDistance;
        Debug.Log("Remaining distance: " + remainingDistance + " / " + Agent.navMeshAgent.stoppingDistance);
        Debug.Log("Location reached: " + (remainingDistance <= Agent.navMeshAgent.stoppingDistance));
        bool isDestinationReached = !Agent.navMeshAgent.pathPending && remainingDistance <= Agent.navMeshAgent.stoppingDistance;
        Debug.Log("Going to" + targetObject);
        if (isDestinationReached)
        {
            done = true;
            Agent.navMeshAgent.isStopped = true;
        }
        if (done)
        {
            ExecuteNextInstruction();
        }
    }

    // Call this method when the second detectable has been set
    protected override void OnButtonStop()
    {
        Agent.navMeshAgent.isStopped = true;
    }

    public new void Reset()
    {
        done = false;
        Agent.navMeshAgent.isStopped = false;
    }

    public override void OnStackActive()
    {
        done = false;
        Agent.navMeshAgent.isStopped = false;
    }
}
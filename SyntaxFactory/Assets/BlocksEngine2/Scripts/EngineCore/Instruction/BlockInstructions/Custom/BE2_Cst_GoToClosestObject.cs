using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- most used BE2 namespaces for instruction scripts 
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;
using System;


public class BE2_Cst_GoToClosestObject : BE2_InstructionBase, I_BE2_Instruction
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
       void Start()
    {
        // Assign the target object via code
        targetObject = GameObject.Find("Destino").transform;
    }

    // --- Method used to implement Function Blocks (will only be called by types: simple, condition, loop, trigger)
    public new void Function()
    {
        //First
       Agent.navMeshAgent.destination = targetObject.position;
       Agent.navMeshAgent.isStopped = false;
        float remainingDistance = Agent.navMeshAgent.remainingDistance;
        bool isDestinationReached = !Agent.navMeshAgent.pathPending && remainingDistance <= Agent.navMeshAgent.stoppingDistance;
         if (isDestinationReached)
        {
            Agent.navMeshAgent.isStopped = true;
            ExecuteNextInstruction();
        }else
        {
            ExecuteNextInstruction();
        }
    }

    // Call this method when the second detectable has been set
    protected override void OnButtonStop()
    {
        Agent.navMeshAgent.isStopped = true;
    }

}
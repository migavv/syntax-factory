using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- most used BE2 namespaces for instruction scripts 
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;
using System;


public class BE2_Cst_GoToClosestObject : BE2_InstructionBase, I_BE2_Instruction
{
    //Agent reference
    Agent _agent;
    Agent Agent{
        get{
             if (!_agent) 
             _agent=TargetObject.Transform.GetComponent<Agent>();

        return _agent;
        }
      
    }

    // --- Method used to implement Function Blocks (will only be called by types: simple, condition, loop, trigger)
    public new void Function()
    {
       float minDistance = Mathf.Infinity;
       Detectable closestDetectable = null;
       Vector2 targetObjectPosition = TargetObject.Transform.position;
      

        // check every detectable object in the scene for the closest one of the selected type 
        foreach (Detectable detectable in DetectionManager.detectableObjects)
        {
            if (detectable.type == Section0Inputs[0].StringValue)
            {
                float distance = Vector2.Distance (detectable.transform.position, targetObjectPosition); 
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestDetectable = detectable;
                }
            }
       
        }
                
        if (closestDetectable)
        {
            // when the closest object is found, make the NavMeshAgent movement towards it
            Agent.navMeshAgent.isStopped = false;
            Agent.navMeshAgent.destination = closestDetectable.transform.position;

            // when the sensor detects the objects is already in range, stop the NavMeshAgent 
            if (Agent.sensor.detectedObjects.Contains(closestDetectable))
            {
                Agent.navMeshAgent.isStopped = true;
                ExecuteNextInstruction();
            }
        }
        else
        {
            ExecuteNextInstruction();
        }


}

    protected override void OnButtonStop()
    {
        Agent.navMeshAgent.isStopped = true;
    }

}
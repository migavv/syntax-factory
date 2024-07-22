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
using System;
using Unity.Mathematics;

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
        //First
        Vector2 pos = GameObject.Find("Robot").transform.position;
        Vector2 des = targetObject.transform.position;
        //Debug.Log("Delivery pos: " + des.x + " " + des.y); 
        //Debug.Log("Robot: " + pos.x + " " + pos.y);
        if (!done)
        {
            if (pos.x < des.x)
            {
                pos.x = Math.Min(pos.x + 0.1f, des.x);
            }
            else if (pos.x > des.x)
            {
                pos.x = Math.Max(pos.x - 0.1f, des.x);
            }
            if (pos.y < des.y)
            {
                pos.y = Math.Min(pos.y + 0.1f, des.y);
            }
            else if (pos.y > des.y)
            {
                pos.y = Math.Max(pos.y - 0.1f, des.y);
            }

            GameObject.Find("Robot").transform.position = new Vector2(pos.x, pos.y);
        }

        bool isDestinationReached = pos - des == new Vector2(0, 0);

        if (isDestinationReached)
        {
            //Debug.Log("Destination delivery reached");
            ExecuteNextInstruction();
        }
    }

    // Call this method when the second detectable has been set
    protected override void OnButtonStop()
    {
        Agent.navMeshAgent.isStopped = true;
    }

    public override void OnStackActive()
    {
        ExecuteInUpdate = true;
        targetObject = GameObject.Find("Destino").transform;
        done = false;
    }

    public new void Reset()
    {
        done = false;
    }
}
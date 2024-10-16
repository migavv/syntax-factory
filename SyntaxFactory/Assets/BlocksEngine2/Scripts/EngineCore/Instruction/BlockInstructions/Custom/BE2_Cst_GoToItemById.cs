using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- most used BE2 namespaces for instruction scripts 
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;
using UnityEngine.UIElements;
using MG_BlocksEngine2.Environment;
using System;

// --- additional BE2 namespaces used for specific cases as accessing BE2 variables or the event manager
// using MG_BlocksEngine2.Core;
// using MG_BlocksEngine2.Environment;

public class BE2_Cst_GoToItemById : BE2_InstructionBase, I_BE2_Instruction
{
    public BestPickUpController bestPickupController;
    bool done = false;
    public Animator animator;
    public GameObject targetObject;
    public new void Function()
    {
        // --- use Section0Inputs[inputIndex] to get the Block inputs from the first section (index 0).
        // --- Optionally, use GetSectionInputs(sectionIndex)[inputIndex] to get inputs from a different section
        // --- the input values can be retrieved as .StringValue, .FloatValue or .InputValues 
        // Section0Inputs[inputIndex];

        int idx = int.Parse(Section0Inputs[0].StringValue);

        bestPickupController = FindObjectOfType<BestPickUpController>();

        bestPickupController.currItemIdx = idx;

        targetObject = bestPickupController.itemArray[idx];


        animator = GameObject.Find("Robot").GetComponent<Animator>();
        //First
        Vector2 pos = GameObject.Find("Robot").transform.position;
        Vector2 des = targetObject.transform.position;
        //Debug.Log("Delivery pos: " + des.x + " " + des.y); 
        //Debug.Log("Robot: " + pos.x + " " + pos.y);
        if (!done)
        {
            animator.SetFloat("Speed",1.0f);
            if (pos.x < des.x)
            {
                pos.x = Math.Min(pos.x + 0.01f, des.x);
            }
            else if (pos.x > des.x)
            {
                pos.x = Math.Max(pos.x - 0.01f, des.x);
            }
            if (pos.y < des.y)
            {
                pos.y = Math.Min(pos.y + 0.01f, des.y);
            }
            else if (pos.y > des.y)
            {
                pos.y = Math.Max(pos.y - 0.01f, des.y);
            }

            GameObject.Find("Robot").transform.position = new Vector2(pos.x, pos.y);
        }

        bool isDestinationReached = pos - des == new Vector2(0, 0);

        if (isDestinationReached)
        {
            animator.SetFloat("Speed",0f);
            ExecuteNextInstruction();
        }

    }

    // --- Method used to implement Operation Blocks (will only be called by type: operation)
    public new string Operation()
    {
        string result = "";
        
        // --- use Section0Inputs[inputIndex] to get the Block inputs from the first section (index 0).
        // --- Optionally, use GetSectionInputs(sectionIndex)[inputIndex] to get inputs from a different section
        // --- the input values can be retrieved as .StringValue, .FloatValue or .InputValues 
        // Section0Inputs[inputIndex];
        
        // --- opeartion results are always of type string.
        // --- bool return strings are usually "1", "true", "0", "false".
        // --- numbers are returned as strings and converted on the input get.
        return result;
    }

    // ### Execution Setting ###

    // --- Use ExecuteInUpdate for functions that plays repeatedly in update, holding the blocks stack execution flow until completed (ex.: wait, lerp).
    // --- Default value is false. Loop Blocks are always executed in update (true).
    //public new bool ExecuteInUpdate => true; 

    // ### Additional Methods ###

    // --- executed after base Awake
    //protected override void OnAwake()
    //{
    //    
    //}
    
    // --- executed after base Start
    //protected override void OnStart()
    //{
    //    
    //}

    // --- Update can be overridden
    //void Update()
    //{
    //
    //}

    // --- executed on button play pressed
    //protected override void OnButtonPlay()
    //{
    //
    //}

    // --- executed on button stop pressed
    //protected override void OnButtonStop()
    //{
    //
    //}

    // --- executed after blocks stack is populated
    //public override void OnPrepareToPlay()
    //{
    //
    //}

    // --- executed on the stack transition from deactive to active
    public override void OnStackActive()
    {
        ExecuteInUpdate = true;
        done = false;
    }

    //protected override void OnEnableInstruction()
    //{
    //
    //}

    //protected override void OnDisableInstruction()
    //{
    //
    //}
}

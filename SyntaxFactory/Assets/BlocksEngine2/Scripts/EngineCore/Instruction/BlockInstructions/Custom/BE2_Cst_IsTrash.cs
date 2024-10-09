using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- most used BE2 namespaces for instruction scripts 
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;

// --- additional BE2 namespaces used for specific cases as accessing BE2 variables or the event manager
// using MG_BlocksEngine2.Core;
// using MG_BlocksEngine2.Environment;

public class BE2_Cst_IsTrash : BE2_InstructionBase, I_BE2_Instruction
{
    // ► Refer to the documentation for more on the variables and methods

    // ### Execution Methods ###

    // --- Method used to implement Function Blocks (will only be called by types: simple, condition, loop, trigger)
    public new void Function()
    {

        ExecuteNextInstruction();
    }

 public new string Operation()
    {
        PickupController pickupController = FindObjectOfType<PickupController>();
        
        string input = Section0Inputs[0].StringValue;

        if(!pickupController.pickedUp) return "false";

        if(input == pickupController.pickupItem.GetComponent<ItemManager>().isTrash.ToString())
            return "true";

        return "false";
   }


}

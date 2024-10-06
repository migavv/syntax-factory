using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- most used BE2 namespaces for instruction scripts 
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;

// --- additional BE2 namespaces used for specific cases as accessing BE2 variables or the event manager
// using MG_BlocksEngine2.Core;
// using MG_BlocksEngine2.Environment;

public class BE2_Cst_PickupItem : BE2_InstructionBase, I_BE2_Instruction
{
    public PickupController pickupController;
    public new void Function()
    {
        pickupController = FindObjectOfType<PickupController>();
        
         if (pickupController != null)
        {
            // Initially allow picking up items
            Debug.Log("Se cambioooo");
            pickupController.canPickupOrDrop = true;
            pickupController.pickedUp = true;
        }
        ExecuteNextInstruction();
        
    }

       public override void OnStackActive()
    {
        ExecuteInUpdate = true;
    }

    
}

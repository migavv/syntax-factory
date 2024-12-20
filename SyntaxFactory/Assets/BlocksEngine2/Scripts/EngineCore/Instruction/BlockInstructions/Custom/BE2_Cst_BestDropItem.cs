using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- most used BE2 namespaces for instruction scripts 
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;

// --- additional BE2 namespaces used for specific cases as accessing BE2 variables or the event manager
// using MG_BlocksEngine2.Core;
// using MG_BlocksEngine2.Environment;

public class BE2_Cst_BestDropItem : BE2_InstructionBase, I_BE2_Instruction
{
    // ► Refer to the documentation for more on the variables and methods

    // ### Execution Methods ###

    // --- Method used to implement Function Blocks (will only be called by types: simple, condition, loop, trigger)
    public BestPickUpController pickupController;
    public new void Function()
    {
        pickupController = FindObjectOfType<BestPickUpController>();
        
        if (pickupController != null)
        {
            // Initially allow picking up items
            Debug.Log("Se cambioooo a false");
            pickupController.canPickupOrDrop = false;
            pickupController.pickedUp = false;
            pickupController.Drop();
        }
        ExecuteNextInstruction();
    }

       public override void OnStackActive()
    {
        ExecuteInUpdate = true;
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


}

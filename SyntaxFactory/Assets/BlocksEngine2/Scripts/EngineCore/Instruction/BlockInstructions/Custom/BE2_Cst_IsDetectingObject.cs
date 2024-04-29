using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- most used BE2 namespaces for instruction scripts 
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;


public class BE2_Cst_IsDetectingObject : BE2_InstructionBase, I_BE2_Instruction
{
    // referencia a sensor
    Sensor _sensor;
    Sensor Sensor
    {
        get {
            if (!_sensor)
            _sensor = TargetObject.Transform.GetComponentInChildren<Sensor>();
            return _sensor;
         }
    }



    // --- Method used to implement Operation Blocks (will only be called by type: operation)
    public new string Operation()
    {
        // revisar si algun objeto en contacto con el sensor es del tipo seleccionado
        foreach (Detectable detectable in Sensor.detectedObjects){
            if (Section0Inputs[0].StringValue == detectable.type)
            {
                return "true";
            }
        }
        return "false";

    }

    
}

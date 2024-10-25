using UnityEngine;

// --- most used BE2 namespaces for instruction scripts 
using MG_BlocksEngine2.Block.Instruction;


// --- additional BE2 namespaces used for specific cases as accessing BE2 variables or the event manager
// using MG_BlocksEngine2.Core;
// using MG_BlocksEngine2.Environment;

public class BE2_Cst_GoToPickup : BE2_InstructionBase, I_BE2_Instruction
{
     bool done = false;
    public Animator animator;
    public Transform targetObject;

    public float speed = 5f; // Movement speed, adjustable in the inspector

    // --- Method used to implement Function Blocks (will only be called by types: simple, condition, loop, trigger)
    public new void Function()
    {
        animator = GameObject.Find("Robot").GetComponent<Animator>();
        
        Vector2 pos = GameObject.Find("Robot").transform.position;
        Vector2 des = targetObject.transform.position;

        if (!done)
        {
            animator.SetFloat("Speed", 1.0f);
            
            // Calculate direction and apply movement based on deltaTime
            Vector2 direction = (des - pos).normalized;
            Vector2 movement = direction * speed * Time.deltaTime;

            // Move towards the destination, clamping the movement to avoid overshooting
            pos = Vector2.MoveTowards(pos, des, movement.magnitude);
            GameObject.Find("Robot").transform.position = pos;
        }

        // Check if the destination is reached
        bool isDestinationReached = Vector2.Distance(pos, des) < 0.01f;

        if (isDestinationReached)
        {
            animator.SetFloat("Speed", 0f);
           // done = true;
            ExecuteNextInstruction();
        }
    }

    public override void OnStackActive()
    {
        ExecuteInUpdate = true;
        targetObject = GameObject.Find("Destino2").transform;
        done = false;
    }

    public new void Reset()
    {
        done = false;
    }
}

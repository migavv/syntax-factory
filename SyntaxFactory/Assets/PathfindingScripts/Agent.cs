using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
public class Agent : MonoBehaviour
{
   public NavMeshAgent navMeshAgent;
   public Sensor sensor;

   private void Awake() {
    
    navMeshAgent = GetComponent<NavMeshAgent>();
    navMeshAgent.updateRotation = false;
    navMeshAgent.updateUpAxis = false;
    sensor = GetComponentInChildren<Sensor>();

   }
}

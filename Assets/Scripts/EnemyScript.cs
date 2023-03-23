using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] NavMeshAgent meshAgent;
    [SerializeField] Transform wayPoint;
    void Start()
    {
        if (meshAgent == null)
        {
            meshAgent = GetComponent<NavMeshAgent>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        meshAgent.destination = wayPoint.position;
    }
}

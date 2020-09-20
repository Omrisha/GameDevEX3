
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    
    public float range = 10.0f;
    bool RandomPoint(Vector3 center, float range, out Vector3 result) {
        for (int i = 0; i < 30; i++) {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 new_location = new Vector3();

        // new_location.x = Random.Range(10f, 80f);
        // new_location.z = Random.Range(30f, 140f);
        //
        // transform.position = new_location;
        // // update agent's destination
        // agent.SetDestination(transform.position);
        if (RandomPoint(transform.position, range, out new_location)) {
            transform.position = new_location;
            // update agent's destination
            agent.SetDestination(transform.position);
        }
    }
}

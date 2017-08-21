using UnityEngine;
using UnityEngine.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshPatroller : MonoBehaviour
{
    public List<Vector3> patrolPoints = new List<Vector3>();
    RaycastHit hitInfo = new RaycastHit();
    protected int pointIndex;
    protected NavMeshAgent agent;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Start()
    {
        pointIndex = 0;
    }

    public void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                patrolPoints.Add(hit.point);
            }
        }

        // check if there are navigable points
        if (patrolPoints.Count > 0)
        {
            // patrol to target
            PatrolToPoint(pointIndex);
        }

        // check if object has reached patrol point then move to the next one
        if (agent.remainingDistance <= 0.0f)
        {
            if (pointIndex + 1 < patrolPoints.Count)
            {
                pointIndex += 1;
            }
        }
    }

    public void PatrolToPoint(int curIndexPoint)
    {
        agent.destination = patrolPoints[curIndexPoint];
    }
}

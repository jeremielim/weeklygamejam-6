using UnityEngine;
using UnityEngine.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshPatroller : MonoBehaviour
{

    public GameObject[] food;

    protected bool canDropObj;
    protected int pointIndex;
    protected NavMeshAgent agent;
    protected Vector3 targetPosition;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        canDropObj = true;
        pointIndex = 0;
    }

    public void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (canDropObj)
                {
                    targetPosition = hit.point;
                    agent.destination = hit.point;

                    Instantiate(food[Random.Range(0, (food.Length - 1))], new Vector3(hit.point.x, 1.0f, hit.point.z), Quaternion.identity);

                    canDropObj = false;
                }
            }
        }

        if (Vector3.Distance(transform.position, targetPosition) < 0.7)
        {
            canDropObj = true;
        }
    }

    public bool CanDropObjects()
    {
        return canDropObj;
    }
}

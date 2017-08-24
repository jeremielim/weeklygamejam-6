using UnityEngine;
using UnityEngine.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshPatroller : MonoBehaviour
{

    public GameObject[] food;
    public Transform originPoint;
    public int lures = 4;

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
        if (canDropObj)
        {
            agent.destination = originPoint.position;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Quaternion rotation = Quaternion.identity;
            rotation.eulerAngles = new Vector3(0, Random.Range(-180, 180.0f));

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (canDropObj && lures > 0)
                {
                    targetPosition = hit.point;
                    agent.destination = hit.point;

                    Instantiate(food[Random.Range(0, (food.Length - 1))], new Vector3(hit.point.x, 0, hit.point.z), rotation);
                    lures -= 1;
                    canDropObj = false;
                }
            }
        }

        if (Vector3.Distance(transform.position, targetPosition) < 0.7)
        {
            canDropObj = true;
        }
    }
}

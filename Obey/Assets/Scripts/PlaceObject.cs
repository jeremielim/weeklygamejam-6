using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public GameObject prefab;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {

                GameObject obj = Instantiate(prefab, new Vector3(hit.point.x, 1.0f, hit.point.z), Quaternion.identity) as GameObject;
            }
        }
    }
}

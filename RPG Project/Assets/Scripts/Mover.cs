using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();

        }

    }

    private void MoveToCursor()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);;
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);

        if (hasHit == true)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;

        }
    }
    
    
}
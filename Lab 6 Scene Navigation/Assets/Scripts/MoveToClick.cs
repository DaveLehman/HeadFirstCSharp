using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class MoveToClick : MonoBehaviour
{
    private NavMeshAgent agent;

    // Before start, when the object is created, is Awake
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();           
       
    }
    // Start is called before the first frame update. Called when the script is enabled
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // check if left mouse button down every time a frame is drawn
        {
            Camera cameraComponent = GameObject.Find("Main Camera").GetComponent<Camera>();
            Ray ray = cameraComponent.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if(hit.collider.gameObject.tag != "Obstacle")
                {
                    agent.SetDestination(hit.point);
                }    
            }
        }
    }
}

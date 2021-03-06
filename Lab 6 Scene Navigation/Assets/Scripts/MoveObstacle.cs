using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        transform.position += new Vector3(0, Input.GetAxis("Mouse Y"), 0);
        if (transform.position.y < 1)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
        if (transform.position.y > 5)
        {
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }
    }
}

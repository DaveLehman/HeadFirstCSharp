using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform Player;
    public float Angle = 1F;
    public float ZoomSpeed = 0.5F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // make the scroolWhell zoom in or out
        var scrollWheelValue = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheelValue != 0)
        {
            transform.position *= (1F + scrollWheelValue * ZoomSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(Player.position, Vector3.up, Angle);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(Player.position, Vector3.down, Angle);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.RotateAround(Player.position, Vector3.right, Angle);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.RotateAround(Player.position, Vector3.left, Angle);
        }
    }
}

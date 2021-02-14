using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBallBehaviour : MonoBehaviour
{

    // Rotate version code
    public float XRotation = 0;
    public float YRotation = 1;
    public float ZRotation = 0;
    public float DegreesPerSecond = 180;
    

    // Flyaway code
    /*
    public float XSpeed;
    public float YSpeed;
    public float ZSpeed;
    public float Multiplier = 0.75F;
    public float TooFar = 5;
    */
    /* We've now implemented two Game Modes, so have to pay attention to what Mode we are in ---
     * Mode 1: Running. Balls being added to the scene, clicking on them makes them disappear
     *  and the score go up
     * Mode 2: Game Over. No new calls, clicking on them does nothing, Game Over banner displayed
     * 
    /* Tracked by controller's GameOver boolean */

    // Start is called before the first frame update
    void Start()
    {
        // Rotate version
        // position the ball at a random point up to +/- 3 units away from the scene's origin and rotate around the origin
        transform.position = new Vector3(3 - Random.value * 6, 3 - Random.value * 6, 3 - Random.value * 6);
        
        // flyaway version
        // ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        /* Rotate version code
        // rotate the ball around itself clockwise */
        Vector3 axis = new Vector3(XRotation, YRotation, ZRotation);
        transform.RotateAround(Vector3.zero, axis, DegreesPerSecond * Time.deltaTime);
        
        // flyaway code\
        /*
        transform.Translate(Time.deltaTime * XSpeed, Time.deltaTime * YSpeed, Time.deltaTime * ZSpeed);

        XSpeed += Multiplier - Random.value * Multiplier * 2;
        YSpeed += Multiplier - Random.value * Multiplier * 2;
        ZSpeed += Multiplier - Random.value * Multiplier * 2;

        if ((Mathf.Abs(transform.position.x) > TooFar) ||
            (Mathf.Abs(transform.position.y) > TooFar) ||
            (Mathf.Abs(transform.position.z) > TooFar))
        {
            ResetBall();
        }*/
    }


    private void OnMouseDown()
    {
        // Unity makes it really easy to respond to mouse clicks -- just create a method named OnMouseDow
        GameController controller = Camera.main.GetComponent<GameController>();
        if (!controller.GameOver)
        {
            controller.ClickedOnBall();
            Destroy(gameObject);
        }

    }

    void ResetBall()
    {
        // only flyaway version
        //XSpeed = Random.value * Multiplier;
       // YSpeed = Random.value * Multiplier;
        //ZSpeed = Random.value * Multiplier;

        //transform.position = new Vector3(3 - Random.value * 6, 3 - Random.value * 6, 3 - Random.value * 6);
    }

}

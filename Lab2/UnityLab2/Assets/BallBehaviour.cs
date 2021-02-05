using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{

    public float XRotation = 0;
    public float YRotation = 1;
    public float ZRotation = 0;
    public float DegreesPerSecond = 90;
    

    // Start is called before the first frame update
    /* A frame is a fundamental concept of animation. Unity draws one still
     * frame, then draws the next one very quicly, and your eye interprets
     * changes in these frames as movement. Unity calls the Update method for
     * every other GameObject before each frame so it can move, rotate, or make any
     * other changes that it needs to make. A faster computer will run at a higher
     * frame rate than a slower one */
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        //Vector3 axis = new Vector3(XRotation, YRotation, ZRotation);
        //transform.Rotate(axis, DegreesPerSecond * Time.deltaTime);
        //Debug.DrawRay(Vector3.zero, axis, Color.yellow, .5f);


        /* Different computers will run you game at different frame rates. If it's running
         * at 30FPS we want one rotation every 60 frames. If it's running at 120FPS it should 
         * rotate once every 240 frames. That's where the Time.deltaTime value comes in handy.
         * Every time the Unity engine call's a GameObject's Update method -- once per frame --
         * it sets deltaTime to teh fraction of a second since the last frame. Since we want
         * our ball to do a full rotation every two seconds, or 180 degrees per second,
         * all we need to do is mutiply it by Time.deltaTime to make sure that it rotates
         * exactly as much as it needs for that frame.
         */
        // Time.delaTime is static -- dont need to instantiate Time
        transform.Rotate(Vector3.up, 180 * Time.deltaTime);

        //rotate around an object
        Vector3 axis = new Vector3(XRotation, YRotation, ZRotation);
        transform.RotateAround(Vector3.zero, axis, DegreesPerSecond * Time.deltaTime);
        Debug.DrawRay(Vector3.zero, axis, Color.yellow, .5f);
    }
}

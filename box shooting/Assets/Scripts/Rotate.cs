using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 10.0f; // the speed of the rotation

    public enum whichWayToRotate
    {
        AroundX,
        AroundY,
        AroundZ,
    } // setup the possible rotation states

    public whichWayToRotate way = whichWayToRotate.AroundY; // set the direction of the rotation

    void Update()
    {
        switch (way) // do the appropriate rotation based on the way state
        {
            case whichWayToRotate.AroundX:
                transform.Rotate(Vector3.right * Time.deltaTime * speed);
                break;
            case whichWayToRotate.AroundY:
                transform.Rotate(Vector3.up * Time.deltaTime * speed);
                break;
            case whichWayToRotate.AroundZ:
                transform.Rotate(Vector3.forward * Time.deltaTime * speed);
                break;
        }
    }
}

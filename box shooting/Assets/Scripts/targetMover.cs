using UnityEngine;
public class targetMover : MonoBehaviour
{
    public enum motionDirections {Spin, Horizontal, Vertical};

    public motionDirections motionState = motionDirections.Horizontal; 

    public float speed = 180.0f;
    public float motionMagnitude = 0.1f;

    void Update() 
    {
        switch(motionState)
        {
            case motionDirections.Spin:
                gameObject.transform.Rotate(Vector3.up * speed * Time.deltaTime);
                break;
            case motionDirections.Vertical:
                transform.Translate(Vector3.up*Mathf.Cos(Time.timeSinceLevelLoad)*motionMagnitude);
                break;
            case motionDirections.Horizontal:
                transform.Translate(Vector3.right*Mathf.Cos(Time.timeSinceLevelLoad)*motionMagnitude);
                break;
        }
    }
}



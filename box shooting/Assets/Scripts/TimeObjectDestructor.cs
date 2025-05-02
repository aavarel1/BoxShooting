using UnityEngine;

public class TimeObjectDestructor : MonoBehaviour
{
    public float timeOut = 1.0f;
    public bool detachChildren = false;

    void Awake()
    {
        Invoke("DestroyNow", timeOut); // invote the DestroyNow funtion to run after timeOut seconds
    }

    void DestroyNow()
    {
        if (detachChildren)
        { // detach the children before destroying if specified
            transform.DetachChildren();
        }
        Destroy(gameObject); // destory the game Object
    }
}

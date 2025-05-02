using UnityEngine;

public class PlayAgain : MonoBehaviour
{
    void OnCollisionEnter(Collision newCollision)
    {
        Debug.Log("Colliding with: " + newCollision.gameObject.name + ", Tag: " + newCollision.gameObject.tag);
        // only do stuff if hit by a projectile
        if (newCollision.gameObject.tag == "projectile")
        {
            // call the RestartGame function in the game manager
            GameManager.gm.RestartGame();
        }
    }
}

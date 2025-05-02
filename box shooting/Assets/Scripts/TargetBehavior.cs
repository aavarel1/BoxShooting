using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     public int scoreAmount = 0;
     public float timeAmount = 0.0f;
        // explosion when hit?
     public GameObject explosionPrefab;
 
    void OnCollisionEnter(Collision newCollison)
    {
        if (GameManager.gm) {
            if (GameManager.gm.gameIsOver) return;
        }

        if (newCollison.gameObject.tag == "projectile") {
            if (explosionPrefab) {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }
            if (GameManager.gm) GameManager.gm.targetHit(scoreAmount, timeAmount); 
            Destroy(newCollison.gameObject);
            Destroy(gameObject);
        }
        
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    public InputSystem_Actions fireAction;
    public GameObject projectile; // Reference to projectile prefab to shoot
    public float power = 10.0f;
    public AudioClip shootSFX; // Reference to AudioClip to play

    public void OnShoot(InputValue value)
    {
        if (projectile)
        {
            GameObject newProjectile =
                Instantiate(projectile, transform.position + transform.forward, transform.rotation)
                as GameObject;
            if (!newProjectile.GetComponent<Rigidbody>())
            {
                newProjectile.AddComponent<Rigidbody>();
            }
            newProjectile
                .GetComponent<Rigidbody>()
                .AddForce(transform.forward * power, ForceMode.VelocityChange);
            AudioSource.PlayClipAtPoint(shootSFX, newProjectile.transform.position);

            Debug.Log("Shoot triggered");
        }
    }
}

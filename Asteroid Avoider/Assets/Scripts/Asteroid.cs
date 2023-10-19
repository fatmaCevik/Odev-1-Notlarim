using UnityEngine;

public class Asteroid : MonoBehaviour
{
    //"[SerializeField] private PlayerHealth playerHealth;"
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth == null)
            return;

        playerHealth.Crash();
        //playerHealth.RemainingLife();
    }
}

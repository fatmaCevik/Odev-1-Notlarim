using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public void Crash()
    {
        gameObject.SetActive(false);
    }
}

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //[SerializeField] private int health;
    
    
    public void Crash()
    {
        gameObject.SetActive(false);
    }
    
    /*
    public void RemainingLife()
    {
        if (health > 0)
            health -= health;
        else
            gameObject.SetActive(false);
    }
    */
}


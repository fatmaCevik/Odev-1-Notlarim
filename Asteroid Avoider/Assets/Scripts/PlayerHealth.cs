using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //[SerializeField] private int health;
    [SerializeField] private GameOverHandler gameOverHandler;
    
    public void Crash()
    {
        gameOverHandler.EndGame();
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


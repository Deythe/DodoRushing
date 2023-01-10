using UnityEngine;

public class FinishGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.FinisGame();
        }
    }
}

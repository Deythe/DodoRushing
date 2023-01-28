using UnityEngine;

public class FinishGame : MonoBehaviour
{
    [SerializeField] private GameObject end;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            end.SetActive(true);
            GameManager.instance.FinisGame();
        }
    }
}

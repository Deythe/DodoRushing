using UnityEngine;

public class Slide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<PlayerController>().onASlide = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Caca");
            col.GetComponent<PlayerController>().onASlide = false;
        }
    }
}

using UnityEngine;

public class Slide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerController playerC = col.GetComponent<PlayerController>();
            //playerC.changeDashDir(transform.right.normalized);
            playerC.onASlide = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerController playerC = col.GetComponent<PlayerController>();
            //playerC.changeDashDir(new Vector2(1,0));
            playerC.onASlide = false;
        }
    }
}

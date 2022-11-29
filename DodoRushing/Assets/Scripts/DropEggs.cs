using UnityEngine;

public class DropEggs : MonoBehaviour
{
    [SerializeField] private GameObject eggPrefab;
    [SerializeField] private Vector2 offset;
    private GameObject[] eggs = new GameObject[10];
    private void Awake()
    {
        for (int i = 0; i < eggs.Length; i++)
        {
            eggs[i] = Instantiate(eggPrefab);
            eggs[i].SetActive(false);
        }
    }

    public void DropEgg(Transform t)
    {
        for (int i = 0; i < eggs.Length; i++)
        {
            if (!eggs[i].activeSelf)
            {
                eggs[i].transform.position = (Vector2)t.position - offset;
                eggs[i].SetActive(true);
                return;
            }
        }

        eggs[0].transform.position = (Vector2)t.position - offset;
    }
}

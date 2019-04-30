using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Transform destination;

    private void Start()
    {
        destination = transform.GetChild(0).transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
        collision.transform.root.position = destination.position;
    }
}

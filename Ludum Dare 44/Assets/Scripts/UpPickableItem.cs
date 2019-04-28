using UnityEngine;

public class UpPickableItem : MonoBehaviour
{
    [SerializeField] GameObject objectsToDeactivate;
    [SerializeField] float weight;
    [SerializeField]  public Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void GetPickedUp(Transform pickUpPosition)
    {
        transform.position = pickUpPosition.position;
        transform.SetParent(pickUpPosition);
        objectsToDeactivate.SetActive(false);
        rb.simulated = false;
    }
    public virtual void GetThrown(Vector2 direction, Vector2 position)
    {
        transform.parent = null;
        transform.position = position;
        objectsToDeactivate.SetActive(true);
        rb.velocity = direction * 20;
        if(rb != null)
        {
            rb.simulated = true;
        }

    }
}

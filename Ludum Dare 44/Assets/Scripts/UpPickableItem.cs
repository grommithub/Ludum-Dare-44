using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class UpPickableItem : MonoBehaviour
{
    [SerializeField] GameObject objectsToDeactivate;
    [SerializeField]  public Rigidbody2D rb;

    [SerializeField] internal bool shopTradable = false;
    [SerializeField] internal GameObject shopItem;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public virtual void GetPickedUp(Transform pickUpPosition)
    {
        transform.position = pickUpPosition.position;
        transform.SetParent(pickUpPosition);
        objectsToDeactivate.SetActive(false);
        rb.simulated = false;
    }
    public virtual void GetThrown(Vector2 direction, Vector2 position, GameObject hack)
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

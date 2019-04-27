using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Transform pickUpTransform;
    [SerializeField] private UpPickableItem objectToPickUp;
    [SerializeField] public UpPickableItem heldObject;

    private Vector2 throwdirection;


    private PlayerInput input;

    void Start()
    {
        GetAllComponents();
    }

    private void GetAllComponents()
    {
        input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        GetThrowDirection();
        if (Input.GetButtonDown(input.interactButtonName) && heldObject == null)
        {
            PickUp(objectToPickUp);
        }
        else if (Input.GetButtonDown(input.interactButtonName) && heldObject != null)
        {
            ThrowObject(throwdirection);
        }
    }

    private void PickUp(UpPickableItem item)
    {
        if (item == null) return;
        item.GetPickedUp(pickUpTransform);
        heldObject = item;
    }

    private void GetThrowDirection()
    {
        if(input.inputVector.normalized != Vector2.zero)
        {
            throwdirection = input.inputVector.normalized;
        }
            
    }

    private void ThrowObject(Vector2 direction)
    {
        {
            heldObject.GetThrown(direction);
            heldObject = null;
        }
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        UpPickableItem liveObject = col.transform.GetComponentInParent<UpPickableItem>();
        if (liveObject == null) return;
        objectToPickUp = liveObject;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        UpPickableItem liveObject = col.transform.GetComponentInParent<UpPickableItem>();
        if (liveObject == null) return;
        objectToPickUp = null;
    }
}

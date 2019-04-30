using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Transform pickUpTransform;
    [SerializeField] private UpPickableItem objectToPickUp;
    [SerializeField] internal UpPickableItem heldObject;
    [SerializeField] private Transform throwStart;

    private Vector2 throwdirection;

    public GameObject pressP;

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
        if(objectToPickUp != null)
        {
            pressP.SetActive(true);
        }
        else
        {
            pressP.SetActive(false);
        }
        GetThrowDirection();
        if (Input.GetButtonDown(input.interactButtonName) && heldObject == null)
        {
            PickUp(objectToPickUp);
        }
        else if (Input.GetButtonDown(input.interactButtonName) && heldObject != null)
        {
            ThrowObject(throwdirection, throwStart.position, gameObject);
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
            throwStart.localPosition = new Vector3(throwdirection.x, throwdirection.y, 0);
        }
            
    }

    private void ThrowObject(Vector2 direction, Vector2 position, GameObject gO)
    {
        {
            heldObject.GetThrown(direction, position, gO);
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

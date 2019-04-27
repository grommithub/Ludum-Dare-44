using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Transform pickUpTransform;
    [SerializeField] private UpPickableItem objectToPickUp;

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
        PickUp(objectToPickUp);
    }

    private void PickUp(UpPickableItem item)
    {
        if (Input.GetButtonDown(input.interactButtonName))
        {
            if (item == null) return;
            item.GetPickedUp(pickUpTransform);
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

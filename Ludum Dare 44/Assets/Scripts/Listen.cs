using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listen : MonoBehaviour
{
    [SerializeField]private TextBoxSpawner thingToRead;
    private PickUpItem pickup;
    void Start()
    {
        pickup = GetComponent<PickUpItem>();
    }

    
    void Update()
    {
        ConfirmOpenTextBox();
    }

    private void ConfirmOpenTextBox()
    {
        if(Input.GetButtonDown("Talk") && thingToRead != null)
        {
            thingToRead.SpawnTextBox();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        thingToRead = collision.GetComponentInParent<TextBoxSpawner>();
        if (thingToRead == null) return;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (pickup.heldObject != null) return;
        thingToRead = collision.GetComponentInParent<TextBoxSpawner>();
        if (thingToRead != null)
        {
            thingToRead.DestroyTextBox();
            thingToRead = null;
        }
    }
}

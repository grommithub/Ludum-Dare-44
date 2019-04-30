
using UnityEngine;

public class TRee : UpPickableItem
{
    public override void GetPickedUp(Transform pickUpPosition)
    {
        if (pickUpPosition.root.GetComponent<PlayerInventory>().hasAxe) base.GetPickedUp(pickUpPosition);
        else return;
    }
    public override void GetThrown(Vector2 direction, Vector2 position, GameObject hack)
    {
        if(hack.GetComponent<PlayerInventory>().hasAxe)
        base.GetThrown(direction, position, hack);
    }
}

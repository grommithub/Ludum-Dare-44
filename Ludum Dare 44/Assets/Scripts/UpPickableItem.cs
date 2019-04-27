using UnityEngine;

public class UpPickableItem : MonoBehaviour
{
    public void GetPickedUp(Transform pickUpPosition)
    {
        transform.position = pickUpPosition.position;
        transform.SetParent(pickUpPosition);
    }
}

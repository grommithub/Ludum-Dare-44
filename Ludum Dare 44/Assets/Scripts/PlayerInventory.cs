using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasAxe;
    public bool hasPole;

    public void SetHasAxe(bool boolean)
    {
        hasAxe = boolean;
    }
    public void SetHasPole(bool boolean)
    {
        hasPole = boolean;
    }
}

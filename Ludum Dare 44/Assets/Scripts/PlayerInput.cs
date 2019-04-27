using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    internal string interactButtonName = "Interact";
    internal Vector2 inputVector = new Vector2();

    private string _horizontalAxisName = "Horizontal";
    private string _verticalAxisName = "Vertical";

    void Update()
    {
        SetInputVector();
    }

    private void SetInputVector()
    {
        inputVector = Vector3.Normalize(new Vector2
            (
            Input.GetAxis(_horizontalAxisName),
            Input.GetAxis(_verticalAxisName)
            )
        );
    }
}


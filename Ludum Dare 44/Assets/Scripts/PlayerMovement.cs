using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1;


    private PlayerInput input;
    private Rigidbody2D rb;

    void Start()
    {
        GetAllComponents();    
    }

    private void GetAllComponents()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        MoveCharacter();
    }

    public void MoveCharacter()
    {
        rb.velocity = input.inputVector * moveSpeed;
    }
}

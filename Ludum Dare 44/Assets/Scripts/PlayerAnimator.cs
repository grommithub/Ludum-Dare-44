using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PickUpItem pickup;
    private bool moving;
    private bool holding;
    private Rigidbody2D rb;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        pickup = GetComponent<PickUpItem>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        SetSpeed();
    }
    private void SetSpeed()
    {
        moving = (rb.velocity.magnitude > 0);
        if(pickup.heldObject == null)
        {
            holding = false;
        }
        else
        {
            holding = true;
        }
        anim.SetBool("Holding", holding);
        anim.SetBool("Moving", moving);

    }


   
}

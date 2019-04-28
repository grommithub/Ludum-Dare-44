using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    private Vector3 startposition;
    [SerializeField] private float maxDistance;
    [SerializeField] private float currentDistance;
    [SerializeField] private float speed;

    private Transform player;

    [SerializeField]private Transform child;

    private UpPickableItem heldItem;

    private bool goingTowardsPlayer = false;
    

    void Start()
    {
        child = transform.GetChild(0).transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startposition = transform.position;
        
            //startposition - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!goingTowardsPlayer)transform.up = Vector2.up;
        else
        {
            transform.up = transform.up = player.position - transform.position;
        }
        CheckDistanceFromStart();
        transform.Translate(Vector3.up * Time.deltaTime * speed, Space.Self);
    }
    private void CheckDistanceFromStart()
    {
        currentDistance = new Vector2(transform.position.x - startposition.x, transform.position.y - startposition.y).magnitude;
        currentDistance = Mathf.Abs(currentDistance);
        if(currentDistance > maxDistance)
        {
            goingTowardsPlayer = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var pickup = collision.GetComponentInParent<UpPickableItem>();
        if (pickup != null && heldItem == null)
        {
            pickup.GetPickedUp(child);
            heldItem = pickup;
        }
        if(collision.CompareTag("Player"))
        {
            if(heldItem != null)
            {
                heldItem.GetPickedUp(player.GetChild(0).transform);
                heldItem.transform.rotation = Quaternion.identity;
            }
            Destroy(gameObject);
        }
    }
}

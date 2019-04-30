using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrade : MonoBehaviour
{
    private Transform spawnLocation;

    private void Start()
    {
        spawnLocation = transform.GetChild(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UpPickableItem animalcomponent = collision.GetComponentInParent<UpPickableItem>();
        
        if (animalcomponent == null || animalcomponent.shopTradable == false) return;
        
        Instantiate(animalcomponent.shopItem, spawnLocation.position, Quaternion.identity);
        Destroy(collision.transform.root.gameObject);
    }
}

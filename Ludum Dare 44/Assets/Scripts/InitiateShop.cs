using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InitiateShop : MonoBehaviour
{
    public UnityEvent OnShopEnter;
    public UnityEvent OnShopExit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            OnShopEnter.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            OnShopExit.Invoke();
            print("exit");
        }
    }
    
}

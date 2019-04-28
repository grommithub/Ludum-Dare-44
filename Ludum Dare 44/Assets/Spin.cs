using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    [SerializeField] float speed = 10;
    private float rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation += (speed * Time.deltaTime);
        rotation = rotation % 360;

        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}

using UnityEngine;

public class ScreenScroll : MonoBehaviour
{
    private Transform player;
    private float width;
    private float height;

    private Camera maincam;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
       
        maincam = GetComponent<Camera>();
        maincam.aspect = 1.4f;
        height = maincam.orthographicSize * 2;
        width = height * maincam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x - CameraX(), player.position.y - CameraY(), -10);
    }

    private float CameraX()
    {
        return (player.position.x) % width - width / 2;
    }
    private float CameraY()
    {

        return (player.position.y) % height - height / 2;
    }
}

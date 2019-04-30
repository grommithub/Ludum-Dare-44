using UnityEngine.SceneManagement;
using UnityEngine;

public class RequireSpecificAnimal : MonoBehaviour
{
    public string animal;
    public static float totalAnimalsCollected = 0;
    public static float neededAnimals = 3;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.root.name == animal)
        {
            totalAnimalsCollected++;
            Destroy(collision.transform.root.gameObject);
        }

    }

    private void Update()
    {
        Win();
    }
    public void Win()
    {
        if(totalAnimalsCollected >= neededAnimals)
        {
            SceneManager.LoadScene("TileScene");
        }
    }
}

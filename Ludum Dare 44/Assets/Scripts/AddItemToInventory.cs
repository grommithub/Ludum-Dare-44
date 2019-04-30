using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class AddItemToInventory : MonoBehaviour
{
    public UnityEvent AddToInventory;
    [SerializeField] private GameObject popUpBox;

    [SerializeField] private string description;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AddToInventory.Invoke();
        }
    }

    public void PopUp()
    {
        popUpBox.GetComponentsInChildren<Image>()[1].sprite = GetComponent<SpriteRenderer>().sprite;
        popUpBox.GetComponentInChildren<TMP_Text>().text = description;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
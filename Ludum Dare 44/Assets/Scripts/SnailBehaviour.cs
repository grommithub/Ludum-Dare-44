using UnityEngine;

public class SnailBehaviour : UpPickableItem, ITalksWithTextBox
{
    public string characterName { get; set; }
    [SerializeField] private string _characterName = "Dave";
    public int timeBetweenChars { get; set; }
    public AudioClip voice { get; set; }

    [SerializeField] private AudioClip _voice;
    [SerializeField] private int _timeBetweenChars;

    public new void Awake()
    {
        characterName = _characterName;
        rb = GetComponent<Rigidbody2D>();
        voice = _voice;
        timeBetweenChars = _timeBetweenChars;
    }
    void Update()
    {
        
    }
}

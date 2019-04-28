using UnityEngine;

public class SnailBehaviour : UpPickableItem, ITalksWithTextBox
{
    public int timeBetweenChars { get; set; }
    public AudioClip voice { get; set; }

    [SerializeField] private AudioClip _voice;
    [SerializeField] private int _timeBetweenChars;

    new private void Start()
    {
        voice = _voice;
        timeBetweenChars = _timeBetweenChars;
    }
    void Update()
    {
        
    }
}

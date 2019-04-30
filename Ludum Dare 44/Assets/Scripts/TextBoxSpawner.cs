using UnityEngine;

public class TextBoxSpawner : MonoBehaviour,  ITalksWithTextBox
{
    public string characterName { get; set; }
    [SerializeField] private string _characterName = "Dave";
    public int timeBetweenChars { get; set; }
    public AudioClip voice { get; set; }

    [SerializeField] private AudioClip _voice;
    [SerializeField] private int _timeBetweenChars;

    public GameObject TextBoxPrefab;
    [SerializeField] private static Transform canvas;
    //public string characterName = "";
    [TextArea]public string textBoxContents;

    private GameObject box;

    bool textBoxOpen = false;

    [SerializeField]private bool pitchIsRandom;

    public float highestPitch;
    public float lowestPitch;

    public float volume;

    void Start()
    {
        if (volume == 0) volume = 1;
        characterName = _characterName;
        
        voice = _voice;
        timeBetweenChars = _timeBetweenChars;
        
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        if (timeBetweenChars == 0) timeBetweenChars = 1;
    }

    public void SpawnTextBox()
    {
        if (textBoxOpen) return;
        box = Instantiate(TextBoxPrefab, canvas) as GameObject;
        var textboxscript = box.GetComponent<TextBox>();
        textboxscript.thingToFollow = gameObject.transform;
        textboxscript.entireText = textBoxContents;

        //pitch randomization
        textboxscript.lowestPitch = lowestPitch;
        textboxscript.highestPitch = highestPitch;
        textboxscript.pitchIsRandom = pitchIsRandom;

        textboxscript.volume = volume;

        textboxscript.header = characterName;
        textboxscript.framesBetweenChars = timeBetweenChars;

        if(voice != null) textboxscript.voice = voice;
        textBoxOpen = true;
    }

    public void DestroyTextBox()
    {
        if(textBoxOpen)
        Destroy(box);
        textBoxOpen = false;
    }
}

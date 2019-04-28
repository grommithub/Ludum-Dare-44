using UnityEngine;

public class TextBoxSpawner : MonoBehaviour
{
    public GameObject TextBoxPrefab;
    [SerializeField] private static Transform canvas;
    //public string characterName = "";
    [TextArea]public string textBoxContents;
    public int framesBetweenChars = 1;
    public AudioClip voice;

    private GameObject box;

    bool textBoxOpen = false;

    [SerializeField]private bool pitchIsRandom;

    public float highestPitch;
    public float lowestPitch;
    private ITalksWithTextBox talk;

    void Start()
    {
        if (talk != null)
        {
            voice = talk.voice;
            framesBetweenChars = talk.timeBetweenChars;
        }

        talk = GetComponent<ITalksWithTextBox>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
    }

    
    void Update()
    {
    
    }

    



    public void SpawnTextBox()
    {
        if (textBoxOpen) return;
        box = Instantiate(TextBoxPrefab, canvas);
        var textboxscript = box.GetComponent<TextBox>();
        textboxscript.thingToFollow = gameObject.transform;
        textboxscript.entireText = textBoxContents;

        //pitch randomization
        textboxscript.lowestPitch = lowestPitch;
        textboxscript.highestPitch = highestPitch;
        textboxscript.pitchIsRandom = pitchIsRandom;

        if (talk != null)
        {
            textboxscript.header = talk.characterName;
        }
        textboxscript.framesBetweenChars = framesBetweenChars;

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

using UnityEngine;

public class TextBoxSpawner : MonoBehaviour
{
    public GameObject TextBoxPrefab;
    [SerializeField] private static Transform canvas;
    [TextArea]public string textBoxContents;
    public int framesBetweenChars = 1;

    private ITalksWithTextBox talk;

    void Start()
    {
        talk = GetComponent<ITalksWithTextBox>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            SpawnTextBox();
        }
    }

    public void SpawnTextBox()
    {
        GameObject box = Instantiate(TextBoxPrefab, canvas);
        var textboxscript = box.GetComponent<TextBox>();
        textboxscript.thingToFollow = gameObject.transform;
        textboxscript.entireText = textBoxContents;
        textboxscript.framesBetweenChars = talk.timeBetweenChars;
        if(talk != null) textboxscript.voice = talk.voice;
    }
}

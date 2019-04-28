using TMPro;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    public Transform thingToFollow;
    private RectTransform rectTransform;
    private Camera cam;

    
    [SerializeField] private TMP_Text nameBox;
    [SerializeField] private TMP_Text textbox;
    public string header;
    public string entireText;
    private char[] messageAsChars;
    private int charIndex;

    public int framesBetweenChars = 1;
    public AudioClip voice;

    private int fixedFrameCount;
    [SerializeField] private AudioSource audio;
    private int frameWhenTextBoxOpened;

    public Vector3 boxoffset = new Vector2();

   


    void Start()
    {
        fixedFrameCount = 1;
        audio = GetComponent<AudioSource>();

        nameBox.text = header;
        
        rectTransform = GetComponent<RectTransform>();
        cam = Camera.main;
        textbox.text = string.Empty;
        messageAsChars = entireText.ToCharArray();

    }

    void Update()
    {
        FollowTarget();
    }

    private void FixedUpdate()
    {
        if (textbox.text.Length == entireText.Length) return;
        AddText();
        fixedFrameCount++;
    }

    private void FollowTarget()
    {
        rectTransform.position = cam.WorldToScreenPoint(thingToFollow.position + boxoffset);
    }

    public bool pitchIsRandom;
    public float highestPitch;
    public float lowestPitch;

    private float RandomizePitch(float low, float high)
    {
        return Random.Range(low, high);
    }

    private void AddText()
    {
        if(textbox.text.Length < entireText.Length && fixedFrameCount % framesBetweenChars == 0)
        {
            textbox.text += messageAsChars[charIndex];
            if (!char.IsWhiteSpace(messageAsChars[charIndex]) && voice != null)
            {
                if(pitchIsRandom) audio.pitch = RandomizePitch(lowestPitch, highestPitch);
                audio.PlayOneShot(voice);
            }
            charIndex++;
        }
    }

}

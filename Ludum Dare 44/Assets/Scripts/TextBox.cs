using TMPro;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    public Transform thingToFollow;
    private RectTransform rectTransform;
    private Camera cam;

    public TMP_Text textbox;
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
        audio = GetComponent<AudioSource>();
        
        textbox = GetComponentInChildren<TMP_Text>();
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

    private void AddText()
    {
        if(textbox.text.Length < entireText.Length && fixedFrameCount % framesBetweenChars == 0)
        {
            textbox.text += messageAsChars[charIndex];
            if(!char.IsWhiteSpace(messageAsChars[charIndex])) audio.PlayOneShot(voice);
            charIndex++;
        }
    }

}

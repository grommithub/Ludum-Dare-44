﻿using UnityEngine;

public class TextBoxSpawner : MonoBehaviour
{
    public GameObject TextBoxPrefab;
    [SerializeField] private static Transform canvas;
    [TextArea]public string textBoxContents;
    public int framesBetweenChars = 1;

    void Start()
    {
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
        textboxscript.framesBetweenChars = framesBetweenChars;
    }
}

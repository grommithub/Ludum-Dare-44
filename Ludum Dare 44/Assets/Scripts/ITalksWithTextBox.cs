using UnityEngine;

public interface ITalksWithTextBox
{
    int timeBetweenChars { get; set; }
    AudioClip voice { get; set; }
}

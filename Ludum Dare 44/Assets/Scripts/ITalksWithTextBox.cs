using UnityEngine;

public interface ITalksWithTextBox
{
    string characterName { get; set; }
    int timeBetweenChars { get; set; }
    AudioClip voice { get; set; }
}

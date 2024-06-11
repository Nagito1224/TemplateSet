using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Novel Data", menuName = "Novel Data")]
public class NovelData : ScriptableObject
{

}


public class Story
{
    public Sprite Background;
    public Sprite CharacterImage;
    [TextArea]
    public string StoryText;
    public string CharacterName;
}
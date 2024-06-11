using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private NovelData[] storyDataList;

    [SerializeField] private GameObject background;
    [SerializeField] private GameObject characterImage;
    [SerializeField] private Text storyText;
    [SerializeField] private Text characterName;

    public int storyIndex { get; private set; }
    public int textIndex { get; private set; }

    private bool finishTextFlag = false;


    //コルーチンの開始
    void void StartNovelEvent()
    {
        StartCoroutine(NovelEventCoroutine());
    }

    //要素の読み込み
    private void SetStoryElement(int _storyIndex, int _textIndex)
    {
        var storyElement = storyDataList[storyIndex].stories[textIndex];

        background = storyElement.Background;
        characterImage = storyElement.CharacterImage;
        StartCoroutine(TypeSentence(storyIndex, textIndex));
        characterName.text = storyElement.CharacterName;
    }

    //会話イベントのコルーチン
    IEnumerator NovelEventCoroutine()
    {
        if (textIndex >= storyDataList[storyIndex].stories.Count)
            yield break;

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        if(finishTextFlag)
            ProgressStory(storyIndex);
    }

    private void ProgressStory(int _storyIndex)
    {
        storyText.text = "";
        characterName = "";

        SetStoryElement(storyIndex, textIndex);
        textIndex++;
    }

    private IEnumerator TypeSentence(int _storyIndex, int _textIndex)
    {
        finishTextFlag = false;

        foreach (var letter in storyDataList[_storyIndex].stories[_textIndex].StoryText.ToCharArray())
        {
            storyText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }

        finishTextFlag = true;
    }
}

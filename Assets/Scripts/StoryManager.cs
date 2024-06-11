using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private NovelData[] storyDataList;

    [SerializeField] private Image background;
    [SerializeField] private Image characterImage;
    [SerializeField] private Text storyText;
    [SerializeField] private Text characterName;

    public int storyIndex { get; private set; }
    public int textIndex { get; private set; }

    private bool finishTextFlag = true;


    //コルーチンの開始
    public void StartNovelEvent()
    {
        StartCoroutine(NovelEventCoroutine());
    }


    //会話イベントのコルーチン
    private IEnumerator NovelEventCoroutine()
    {
        foreach (var story in storyDataList[storyIndex].stories)
        {
            if (finishTextFlag)
            {
                storyText.text = "";
                characterName.text = "";

                SetStoryElement(storyIndex, textIndex);
                textIndex++;
            }
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;
        }
    }

    //要素の読み込み(表示切り替え)
    private void SetStoryElement(int _storyIndex, int _textIndex)
    {
        var storyElement = storyDataList[storyIndex].stories[textIndex];

        background.sprite = storyElement.Background;
        characterImage.sprite = storyElement.CharacterImage;
        StartCoroutine(TypeSentence(storyIndex, textIndex));
        characterName.text = storyElement.CharacterName;
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

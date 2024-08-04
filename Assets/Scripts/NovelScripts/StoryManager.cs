using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Threading;

public class NovelManager : MonoBehaviour
{
    /**********************/
    /***** 変数の宣言 *****/
    /**********************/

    /* スクリプトを管理するデータベース(自分で作成したクラス)のインスタンス */
    [SerializeField] private NovelData storyData;

    /* データを表示するためのゲームオブジェクト */
    [SerializeField] private Image background;
    [SerializeField] private Image characterImage;
    [SerializeField] private Text storyText;
    [SerializeField] private Text characterName;

    /* ノベルイベント終了後に発生させるイベント */
    [SerializeField] private UnityEvent eventAfterThisOne;

    /* 今どの要素を表示しているかを指すインデックス */
    private int elementIndex;

    /* テキストアニメーションが終了したかどうかを示すフラグ */
    private bool isTypeFinished = true;
    /* マウスクリックを判定するフラグ */
    private bool isClicked = false;

    /******************************/
    /***** パブリックメソッド *****/
    /******************************/

    /* 左クリック監視用 */
    public void Update() {
        if(Input.GetMouseButtonDown(0)) isClicked = true;
    }

    /* ノベルイベントを開始するメソッド */
    public void StartNovelEvent()
    {
        StartCoroutine(NovelEventCoroutine());  // 50行目のメソッドを呼び出す
    }


    /**********************************************/
    /***** 内部処理を行うプライベートメソッド *****/
    /**********************************************/

    /* ストーリーデータ内の全ての要素に対して処理を行うメソッド(コルーチン) */
    private IEnumerator NovelEventCoroutine()
    {
        /* ストーリーデータ内の全ての要素に対して処理を行う */
        foreach (var story in storyData.stories)
        {
            /* 初期化 */
            storyText.text = "";
            characterName.text = "";

            /* 画面に表示するための内部関数を呼び出す */
            SetStoryElement(elementIndex);  // 77行目

            /* インデックスを更新する */
            elementIndex++;

            /* 左クリックとタイピングアニメーションの終了を待つ */
            yield return new WaitUntil(() => isTypeFinished && Input.GetMouseButtonDown(0));
            /* ループの進行が複数回分にならないように、即座に入力をキャンセルする */
            yield return null;
        }

        /*
        * 自身がフェードクラスをコンポーネントとして持っている場合のみ，
        * フェードアウトアニメーションを実行する
        */
        Fade fadeout = GetComponent<Fade>();
        if (fadeout != null){
            fadeout.StartFadeOutAnimation();
            yield return new WaitUntil(() => fadeout.isFinished);
        }
        /* 全てのストーリーデータを表示し終えたら、終了後のイベントを発生させる */
        eventAfterThisOne.Invoke();
    }


    /* ストーリーデータの中の引数で指定された要素をゲームに表示する */
    private void SetStoryElement(int _elementIndex)
    {
        /* ゲームオブジェクトのコンポーネントにデータを代入することで内容を表示させる */
        background.sprite = storyData.stories[_elementIndex].Background;
        characterImage.sprite = storyData.stories[_elementIndex].CharacterImage;
        characterName.text = storyData.stories[_elementIndex].CharacterName;
        /* タイピングアニメーション用のメソッドを呼び出す */
        StartCoroutine(TypeSentence(_elementIndex));  // 89行目
    }

    /* タイピングアニメーション用のメソッド(コルーチン) */
    /* (テキストを分割して1文字ずつゲームオブジェクトに入れてるだけ) */
    private IEnumerator TypeSentence(int _elementIndex)
    {
        /* 次の要素に進ませないようにロックする(66行目を参照) */
        isTypeFinished = false;
        isClicked = false;

        /* 全文のデータを一旦退避させておく */
        var fullText = storyData.stories[_elementIndex].StoryText;

        /* ゲームオブジェクトのコンポーネントに1文字ずつ入れていく */
        foreach (var letter in fullText.ToCharArray())
        {
            /* テキスト用のコンポーネントに1文字入れる */
            storyText.text += letter;

            /* 左クリックを監視する */
            if (isClicked)
            {
                /* 左クリックが押された場合は退避しておいた全文を入れてループを抜ける */
                storyText.text = fullText;
                break;
            }

            /* 次の文字の表示に少しだけ遅延をかける */
            yield return new WaitForSeconds(0.04f);
        }

        /* 次の要素に進めるようにロックを解除する(66行目) */
        isTypeFinished = true;
    }
}
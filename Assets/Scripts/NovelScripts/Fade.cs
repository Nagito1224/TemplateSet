using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    /*
    * **変数の宣言**
    * canvasGroup: CanvasGroup // フェードアウトさせるキャンバス(アタッチする)
    * fadeDuration: float // フェードアウトにかける時間
    * isFinished: bool // フェード終了フラグ
    */
    public CanvasGroup canvasGroup;
    public float fadeDuration = 1.0f;
    public bool isFinished { get; private set; } = false;

    /* フェードアウトコルーチン開始用メソッド */
    public void StartFadeOutAnimation() {
        isFinished = false;
        StartCoroutine(FadeOutCoroutine());
    }

    /* キャンバスをフェードアウトさせるメソッド */
    private IEnumerator FadeOutCoroutine() {
        float startAlpha = canvasGroup.alpha;
        float rate = 1.0f;
        float progress = 0.0f;

        while(progress < 1.0f) {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, progress);
            progress += rate * Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0;
        isFinished = true;
    }
}

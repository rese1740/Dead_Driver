using UnityEngine;
using UnityEngine.UI;

public class EndCredits : MonoBehaviour
{
    public Text creditsText;         // 엔딩 크레딧 텍스트
    public float scrollSpeed = 30f;  // 스크롤 속도
    private RectTransform textRect;  // Text의 RectTransform

    void Start()
    {
        // 텍스트의 RectTransform을 가져옵니다.
        textRect = creditsText.GetComponent<RectTransform>();
    }

    void Update()
    {
        // 텍스트를 위로 스크롤합니다.
        textRect.anchoredPosition += new Vector2(0f, scrollSpeed * Time.deltaTime);

        // 텍스트가 화면 위를 벗어나면 다시 아래로 이동시킵니다.
        if (textRect.anchoredPosition.y > Screen.height)
        {
            textRect.anchoredPosition = new Vector2(0f, -Screen.height);
        }
    }
}

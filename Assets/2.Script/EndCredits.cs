using UnityEngine;
using UnityEngine.UI;

public class EndCredits : MonoBehaviour
{
    public Text creditsText;         // ���� ũ���� �ؽ�Ʈ
    public float scrollSpeed = 30f;  // ��ũ�� �ӵ�
    private RectTransform textRect;  // Text�� RectTransform

    void Start()
    {
        // �ؽ�Ʈ�� RectTransform�� �����ɴϴ�.
        textRect = creditsText.GetComponent<RectTransform>();
    }

    void Update()
    {
        // �ؽ�Ʈ�� ���� ��ũ���մϴ�.
        textRect.anchoredPosition += new Vector2(0f, scrollSpeed * Time.deltaTime);

        // �ؽ�Ʈ�� ȭ�� ���� ����� �ٽ� �Ʒ��� �̵���ŵ�ϴ�.
        if (textRect.anchoredPosition.y > Screen.height)
        {
            textRect.anchoredPosition = new Vector2(0f, -Screen.height);
        }
    }
}

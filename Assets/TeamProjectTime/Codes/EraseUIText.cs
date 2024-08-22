using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro�� ����ϱ� ���� �ʿ�

public class EraseUIText : MonoBehaviour
{
    public TextMeshProUGUI tmpText;  // TMP �ؽ�Ʈ ������Ʈ
    public float fadeSpeed = 0.5f;  // �ؽ�Ʈ�� ������� �ӵ�

    private bool isErasing = false;

    void Update()
    {
        // ���콺 Ŭ�� ���� ��
        if (Input.GetMouseButton(0))
        {
            // Raycast�� ����� TMP �ؽ�Ʈ�� �浹�� ����
            RectTransform rectTransform = tmpText.GetComponent<RectTransform>();
            Vector2 localMousePosition = rectTransform.InverseTransformPoint(Input.mousePosition);

            if (rectTransform.rect.Contains(localMousePosition))
            {
                isErasing = true;
                FadeText();
            }
        }
        else
        {
            isErasing = false;
        }
    }

    void FadeText()
    {
        if (isErasing)
        {
            // TMP �ؽ�Ʈ�� ���İ��� ����
            Color textColor = tmpText.color;
            textColor.a = Mathf.Clamp01(textColor.a - fadeSpeed * Time.deltaTime);
            tmpText.color = textColor;
        }
    }
}


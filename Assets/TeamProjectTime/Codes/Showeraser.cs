using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    // Start is called before the first frame update
    // Ȱ��ȭ�� ĵ������ �����մϴ�.
    public GameObject targetCanvas;
    public GameObject cabinet;

    // ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnButtonClick()
    {
        // ĵ������ Ȱ��ȭ�մϴ�.
        targetCanvas.SetActive(true);
        cabinet.SetActive(false);
    }
}
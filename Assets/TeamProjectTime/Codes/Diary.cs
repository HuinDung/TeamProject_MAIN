using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    // Ȱ��ȭ�� ������Ʈ�� ����
    public GameObject targetObject;

    // ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnButtonClick()
    {
        // ������Ʈ�� Ȱ��ȭ
        targetObject.SetActive(true);
    }
}

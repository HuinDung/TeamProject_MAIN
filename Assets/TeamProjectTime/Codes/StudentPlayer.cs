using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentPlayer : MonoBehaviour
{
    public GameObject August;
    public Vector2 inputVec;
    Vector3 dirVec;
    public GameObject scanObject;
    SpriteRenderer spriter;
    public GameObject OpenCabinet;
    public Text talkText;

    public float speed;
    private bool hasTalked = false; // ���� ��¥�� ǥ�õǾ����� Ȯ���ϴ� �÷���

    Rigidbody2D rigid;
    Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");


        if (scanObject.CompareTag("today") && !hasTalked)
        {
            talkText.text = "������ ��� ��ĥ����?";
            GameManager.instance.Action(scanObject);
            hasTalked = true; // �ѹ� ����� �� �ٽ� ������� �ʵ��� ����
        }

        //��ȭâ
        if (Input.GetKeyDown(KeyCode.E) && scanObject != null)
        {
            if(scanObject.CompareTag("Notice"))
            {
                August.SetActive(true);
            }

            else if(scanObject.CompareTag("Cabinet"))
            {
                OpenCabinet.SetActive(true);
            }

            else GameManager.instance.Action(scanObject);
        }
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

        //Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));
        if (rayHit.collider != null)
        {
            Debug.Log("Rayhit");
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        if (inputVec.y > 0)
        {
            anim.Play("Player_BehindMove");  // ���� �̵�(��������)
            dirVec = Vector3.up; //����
        }
        else if (inputVec.y < 0)
        {
            anim.Play("Player_FrontMove"); // �Ʒ��� �̵�(��������)
            dirVec = Vector3.down; //�Ʒ���
        }
        else if (inputVec.x > 0)
        {
            spriter.flipX = inputVec.x < 0;
            anim.Play("Player_SideMove"); // ������ �̵�
            dirVec = Vector3.right; //������
        }
        else if (inputVec.x < 0)
        {
            spriter.flipX = inputVec.x < 0;
            anim.Play("Player_SideMove");  // ���� �̵�
            dirVec = Vector3.left; //����
        }
    }
}
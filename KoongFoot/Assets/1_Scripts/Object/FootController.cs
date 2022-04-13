using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootController : MonoBehaviour
{
    [SerializeField]
    float footSpeed;
    [SerializeField]
    float koongDelay;

    bool isKoong = false;

    Collider2D collider;
    SpriteRenderer spriteRenderer;

    //��� ��
    private void OnDisable()
    {
        ResetFoot();
    }
    //��� ���� ��
    private void OnEnable()
    {
        StartCoroutine(KoongDelay());
    }

    private void Update()
    {
        if (!isKoong) FootMove();
    }

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //�÷��̾ ���� �̵�
    void FootMove()
    {
        Vector3 dir = InGameManager.Instance.player.transform.position - transform.position;
        transform.Translate(dir * footSpeed * Time.deltaTime);
    }

    //���������� �ð�
    IEnumerator KoongDelay()
    {
        yield return new WaitForSeconds(koongDelay);
        //ũ�� �پ���
        Koong();
        isKoong = true;
    }

    //FOOT ����
    void ResetFoot()
    {
        isKoong = false;
        collider.isTrigger = true;
        spriteRenderer.sprite = InGameManager.Instance.footSprite[0];
        spriteRenderer.color = new Color(1f, 1f, 0.5f);
        //ũ�� �������
    }

    IEnumerator ColorChangeTime()
    {
        yield return new WaitForSeconds(2f);
        StopCoroutine(ColorChangeTime());
    }

    //������
    void Koong()
    {
        //���� 1�� �ٲٰ� ��������Ʈ �������� �ٲٱ�
        spriteRenderer.sprite = InGameManager.Instance.footSprite[Random.Range(1, 4)];
        spriteRenderer.color = new Color(1f, 1f, 1f);
        //isTrigger ���� 
        collider.isTrigger = false;
        //2�ʰ� ���������� �ٲ�ٰ� �ǵ��ƿ���
        spriteRenderer.color = Color.red;
        StartCoroutine(ColorChangeTime());
        spriteRenderer.color = Color.white;

    }
}

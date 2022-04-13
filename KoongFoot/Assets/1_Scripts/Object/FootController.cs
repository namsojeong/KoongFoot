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

    //사용 후
    private void OnDisable()
    {
        ResetFoot();
    }
    //사용 시작 시
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

    //플레이어를 향해 이동
    void FootMove()
    {
        Vector3 dir = InGameManager.Instance.player.transform.position - transform.position;
        transform.Translate(dir * footSpeed * Time.deltaTime);
    }

    //고정까지의 시간
    IEnumerator KoongDelay()
    {
        yield return new WaitForSeconds(koongDelay);
        //크기 줄어들기
        Koong();
        isKoong = true;
    }

    //FOOT 리셋
    void ResetFoot()
    {
        isKoong = false;
        collider.isTrigger = true;
        spriteRenderer.sprite = InGameManager.Instance.footSprite[0];
        spriteRenderer.color = new Color(1f, 1f, 0.5f);
        //크기 원래대로
    }

    IEnumerator ColorChangeTime()
    {
        yield return new WaitForSeconds(2f);
        StopCoroutine(ColorChangeTime());
    }

    //고정시
    void Koong()
    {
        //투명도 1로 바꾸고 스프라이트 랜덤으로 바꾸기
        spriteRenderer.sprite = InGameManager.Instance.footSprite[Random.Range(1, 4)];
        spriteRenderer.color = new Color(1f, 1f, 1f);
        //isTrigger 끄기 
        collider.isTrigger = false;
        //2초간 빨간색으로 바꿨다가 되돌아오기
        spriteRenderer.color = Color.red;
        StartCoroutine(ColorChangeTime());
        spriteRenderer.color = Color.white;

    }
}

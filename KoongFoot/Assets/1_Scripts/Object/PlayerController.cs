using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    VariableJoystick virtualJoystick;

    [SerializeField]
    Button[] bulletButton;

    [SerializeField]
    float moveSpeed;

    public void FixedUpdate()
    {
        Move();
    }

    private void Awake()
    {
        //총알버튼 클릭 시
        {
            bulletButton[0].onClick.AddListener(() => Shoot(90));
            bulletButton[1].onClick.AddListener(() => Shoot(-90));
            bulletButton[2].onClick.AddListener(() => Shoot(0));
            bulletButton[3].onClick.AddListener(() => Shoot(-180));
        }
        
    }

    //조이스틱 이동
    void Move()
    {
        if (virtualJoystick.Direction == Vector2.zero) return;
        Vector2 moveVec2 = virtualJoystick.Direction;
        transform.Translate(moveVec2 * moveSpeed * Time.deltaTime);
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    //총알 발사
    void Shoot(float angle)
    {
        GameObject bullet = ObjectPool.Instance.GetObject(PoolObjectType.BULLET);
        bullet.transform.position = transform.position;
        bullet.transform.Rotate(new Vector3(0, 0, angle));
    }
}

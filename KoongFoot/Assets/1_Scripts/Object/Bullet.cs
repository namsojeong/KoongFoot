using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed = 5f;

    float maxH = 0f;
    float maxV = 0f;

    private void Start()
    {
        //값 초기화
        {
            maxH = InGameManager.Instance.maxH;
            maxV = InGameManager.Instance.maxV;
        }

    }
    private void Update()
    {
        //경계영역 확인
        {
            if (Mathf.Abs(transform.position.x) > maxH || Mathf.Abs(transform.position.y) > maxV)
            {
                ObjectPool.Instance.ReturnObject(PoolObjectType.BULLET, gameObject);
            }
        }

        //이동
        {
            transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
        }
    }

    //사용 후 초기화
    private void OnDisable()
    {
        //회전 초기화
        {
            transform.Rotate(Vector3.zero);
        }

    }

}

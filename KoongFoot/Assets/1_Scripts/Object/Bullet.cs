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
        //�� �ʱ�ȭ
        {
            maxH = InGameManager.Instance.maxH;
            maxV = InGameManager.Instance.maxV;
        }

    }
    private void Update()
    {
        //��迵�� Ȯ��
        {
            if (Mathf.Abs(transform.position.x) > maxH || Mathf.Abs(transform.position.y) > maxV)
            {
                ObjectPool.Instance.ReturnObject(PoolObjectType.BULLET, gameObject);
            }
        }

        //�̵�
        {
            transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
        }
    }

    //��� �� �ʱ�ȭ
    private void OnDisable()
    {
        //ȸ�� �ʱ�ȭ
        {
            transform.Rotate(Vector3.zero);
        }

    }

}

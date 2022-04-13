using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target; //Ÿ�� ��ġ

    Vector2 offset;

    float smoothSpeed = 3; //ī�޶� �̵��ӵ�
    float cameraHalfWidth, cameraHalfHeight;

    float maxH = 0f;
    float maxV = 0f;

    private void Start()
    {
        //�� ����
        {
            maxH = InGameManager.Instance.maxH;
            maxV = InGameManager.Instance.maxV;
            cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
            cameraHalfHeight = Camera.main.orthographicSize;
        }
        
    }
    private void LateUpdate()
    {
        CameraMoving();
    }

    //�÷��̾� �Ѿư���
    void CameraMoving()
    {
        Vector3 desiredPosition = new Vector3(
            Mathf.Clamp(target.position.x + offset.x, -maxH + cameraHalfWidth, maxH - cameraHalfWidth),   // X
            Mathf.Clamp(target.position.y + offset.y, -maxV + cameraHalfHeight, maxV - cameraHalfHeight), // Y
            -10);       
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
    }

}

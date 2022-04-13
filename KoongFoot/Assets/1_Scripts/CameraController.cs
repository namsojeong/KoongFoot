using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target; //타겟 위치

    Vector2 offset;

    float smoothSpeed = 3; //카메라 이동속도
    float cameraHalfWidth, cameraHalfHeight;

    float maxH = 0f;
    float maxV = 0f;

    private void Start()
    {
        //값 대입
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

    //플레이어 쫓아가기
    void CameraMoving()
    {
        Vector3 desiredPosition = new Vector3(
            Mathf.Clamp(target.position.x + offset.x, -maxH + cameraHalfWidth, maxH - cameraHalfWidth),   // X
            Mathf.Clamp(target.position.y + offset.y, -maxV + cameraHalfHeight, maxV - cameraHalfHeight), // Y
            -10);       
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
    }

}

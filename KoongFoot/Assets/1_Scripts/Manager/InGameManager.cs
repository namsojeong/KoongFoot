using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance;

    [SerializeField]
    public GameObject player;

    public Sprite[] footSprite;

    public float maxH = 12f;
    public float maxV = 12f;

    private void Awake()
    {
        Instance = this;
        if (Instance == null) Instance = GetComponent<InGameManager>();
    }

    private void Start()
    {
        SpawnFoot();
    }

    //발 그림자 스폰
    void SpawnFoot()
    {
        GameObject foot = ObjectPool.Instance.GetObject(PoolObjectType.FOOT);
        foot.transform.position=player.transform.position;
    }
}

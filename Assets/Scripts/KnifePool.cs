using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifePool : MonoBehaviour
{
    [SerializeField] GameObject prefabKnife;
    [SerializeField] List<GameObject> knifePool;
    int poolSize = 10;


    //SINGLETON
    public static KnifePool Instance { get; private set; }
    //Solo se pueda setear la instancia desde este script.

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    void Start()
    {
        AddKnifesToPool(poolSize);
    }

    private void AddKnifesToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject knife = Instantiate(prefabKnife);
            knife.SetActive(false);
            knifePool.Add(knife);
            knife.transform.parent = transform;
        }
    }

    public GameObject RequestKnife()
    {
        for(int i = 0; i < knifePool.Count; i++)
        {
            if (!knifePool[i].activeSelf)
            {
                knifePool[i].SetActive(true);
                return knifePool[i];
            }
        }
        AddKnifesToPool(1);
        knifePool[knifePool.Count - 1].SetActive(true);
        return knifePool[knifePool.Count - 1];
    }
}

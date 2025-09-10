using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    [SerializeField] private GameObject poolObj1;
    [SerializeField] private GameObject poolObj2;
    [SerializeField] private GameObject poolObj3;
    [SerializeField] private GameObject[] poolObjMultiple;
    private List<GameObject> poolList1 = new List<GameObject>();
    private List<GameObject> poolList2 = new List<GameObject>();
    private List<GameObject> poolList3 = new List<GameObject>();
    private List<GameObject> poolListMultiple = new List<GameObject>();

    [SerializeField] private int amountToPool1;
    [SerializeField] private int amountToPool2;
    [SerializeField] private int amountToPool3;
    [SerializeField] private int amountToPoolMultiple;
    [SerializeField] private bool enablePool2;
    [SerializeField] private bool enablePool3;
    [SerializeField] private bool enablePoolMultiple;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }   
    }

    private void OnEnable()
    {
        WordManager.OnPoolRestart += RestartPool;
        WordManagerTrap.OnPoolRestart += RestartPool;
        WordManagerSpace.OnPoolRestart += RestartPool;
    }

    private void OnDisable()
    {
        WordManager.OnPoolRestart -= RestartPool;
        WordManagerTrap.OnPoolRestart -= RestartPool;
        WordManagerSpace.OnPoolRestart -= RestartPool;
    }

    void Start()
    {
        for (int i = 0; i < amountToPool1; i++)
        {
            GameObject obj = Instantiate(poolObj1);
            obj.SetActive(false);
            poolList1.Add(obj);
        }

        if (enablePool2)
        {
            for (int i = 0; i < amountToPool2; i++)
            {
                GameObject obj = Instantiate(poolObj2);
                obj.SetActive(false);
                poolList2.Add(obj);
            }
        }

        if (enablePool3)
        {
            for (int i = 0; i < amountToPool3; i++)
            {
                GameObject obj = Instantiate(poolObj3);
                obj.SetActive(false);
                poolList3.Add(obj);
            }
        }

        if (enablePoolMultiple)
        {
            for (int i = 0; i < amountToPoolMultiple; i++)
            {
                GameObject obj = Instantiate(poolObjMultiple[Random.Range(0,poolObjMultiple.Length)]);
                obj.SetActive(false);
                poolListMultiple.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolList1.Count; i++)
        {
            if (!poolList1[i].activeInHierarchy)
            {
                return poolList1[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObject2()
    {
        for (int i = 0; i < poolList2.Count; i++)
        {
            if (!poolList2[i].activeInHierarchy)
            {
                return poolList2[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObject3()
    {
        for (int i = 0; i < poolList3.Count; i++)
        {
            if (!poolList3[i].activeInHierarchy)
            {
                return poolList3[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObjectMultiple()
    {
        for (int i = 0; i < poolListMultiple.Count; i++)
        {
            Debug.Log("i = " + i);
            if (!poolListMultiple[i].activeInHierarchy)
            {              
                return poolListMultiple[i];
            }
           
        }
        
        return null;
    }

    private void RestartPool()
    {
        for (int i = 0; i < amountToPool1; i++)
        {
            poolList1[i].SetActive(false);
        }

        if (enablePool2)
        {
            for (int i = 0; i < amountToPool2; i++)
            {
                poolList2[i].SetActive(false);
            }
        }

        if (enablePool3)
        {
            for (int i = 0; i < amountToPool3; i++)
            {
                poolList3[i].SetActive(false);
            }
        }

        if (enablePoolMultiple)
        {
            for (int i = 0; i < amountToPoolMultiple; i++)
            {
                poolListMultiple[i].SetActive(false);
            }
        }
    }
}

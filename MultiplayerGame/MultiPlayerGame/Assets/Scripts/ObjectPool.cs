using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    [SerializeField]
    GameObject prefab;

    private Queue<GameObject> availObjects = new Queue<GameObject>();

    public static ObjectPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        GrowPool();
    }

    private void GrowPool()
    {
        for(int i = 0; i<10; i++)
        {
            var instanceToAdd = Instantiate(prefab);
            //parents instance to Object pool
            //instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instanceToAdd)
    {
        instanceToAdd.SetActive(false);
        availObjects.Enqueue(instanceToAdd);
    }

    public GameObject GetFromPool()
    {
        if(availObjects.Count == 0)
        {
            GrowPool();
        }

        var instance = availObjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPool : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    private int poolSize = 10;
    GameObject[] pool;
    int currentIndex = 0;

    private void Awake()
    {
        pool = new GameObject[poolSize];
        for(int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(bulletPrefab);
            pool[i].SetActive(false);
        }
    }

    public GameObject getObject()
    {
        if(currentIndex >= poolSize)
        {
            currentIndex = 0;
        }
        GameObject obj = pool[currentIndex];
        currentIndex++;

        obj.SetActive(true);
        return obj;
    }

    public void returnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}

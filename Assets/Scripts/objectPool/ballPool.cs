using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballPool : MonoBehaviour
{
    public static ballPool Instance; 
    [SerializeField] GameObject[] ballPrefabs; 
    private int poolSize = 3; 
    private GameObject[][] pools; 
    private int[] currentIndices; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject); 
        }

        pools = new GameObject[ballPrefabs.Length][];
        currentIndices = new int[ballPrefabs.Length];
        for (int i = 0; i < ballPrefabs.Length; i++)
        {
            pools[i] = new GameObject[poolSize];
            for (int j = 0; j < poolSize; j++)
            {
                pools[i][j] = Instantiate(ballPrefabs[i]);
                pools[i][j].SetActive(false);
            }
        }
    }

    public GameObject getObject(int ballType)
    {
        if (ballType < 0 || ballType >= pools.Length)
        {
            Debug.LogError("Invalid ball type.");
            return null;
        }

        if (currentIndices[ballType] >= poolSize)
        {
            currentIndices[ballType] = 0; 
        }

        GameObject obj = pools[ballType][currentIndices[ballType]];
        currentIndices[ballType]++;
        obj.SetActive(true);
        return obj;
    }

    public void returnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombManager : MonoBehaviour
{
    // Static Instance
    public static bombManager bombManagerInstance { get; private set; }

    public delegate void bombUsedDelegate();
    public event bombUsedDelegate bombUsedEvent;

    private void Awake()
    {
        if (bombManagerInstance == null)
        {
            bombManagerInstance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void bombUsed()
    {
        if (bombUsedEvent!=null)
        {
            bombUsedEvent();
        }
    }
}

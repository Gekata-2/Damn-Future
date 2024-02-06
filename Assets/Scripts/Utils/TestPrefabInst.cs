using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPrefabInst : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    [SerializeField] private int copies;
    private bool firstUpdate = true;

    private void FixedUpdate()
    {
        if (firstUpdate)
        {
            firstUpdate = false;
            for (int i = 0; i < copies; i++)
            {
                Vector3 pos = new Vector3(i * 1.25f, 0, 0);
                Instantiate(prefab, pos, Quaternion.identity);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }
}
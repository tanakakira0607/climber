using UnityEngine;
using System;
using System.Collections.Generic;
public class ranking_system : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int[] score = { 1, 2, 3 };

        Array.Sort(score);

        Debug.Log(string.Format("[{0}]", string.Join(", ", score)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBoomerang : MonoBehaviour
{
    [SerializeField]private Transform throwStart;
    private Vector3 direction;
    [SerializeField] private GameObject boomerang;
    internal bool canThrow = true;
    private void Update()
    {
        if (Input.GetButtonDown("Boomerang") && canThrow)
        {
            direction = throwStart.position - transform.position;
            GameObject rang = Instantiate(boomerang, throwStart.position, Quaternion.identity);
            Boomerang rangComponent = rang.GetComponent<Boomerang>();
            rangComponent.direction = direction;
            rangComponent.player = gameObject.transform;
            canThrow = false;
        }
        
    }
}

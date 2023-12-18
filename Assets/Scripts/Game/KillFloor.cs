using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("axe collision has happened ");
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerManager.instance.Kill();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerManager.instance.Kill();
        }
    }
}

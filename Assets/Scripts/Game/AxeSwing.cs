using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSwing : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody body;
    public float velocityThreshold;

    public float swingTimer = 2;
    private float currentVelocity = 0;

    void Awake()
    {
        body = GetComponentInChildren<Rigidbody>();
        currentVelocity = velocityThreshold;

        if (swingTimer > 0)
        {
            Invoke("SwitchVelocityDirection", swingTimer);

        }
    }

    // Update is called once per frame
    void Update()
    {
        body.angularVelocity = Vector3.forward * currentVelocity;
    }

    void SwitchVelocityDirection()
    {

        currentVelocity = -1 * currentVelocity;
        Invoke("SwitchVelocityDirection", swingTimer);

    }


}
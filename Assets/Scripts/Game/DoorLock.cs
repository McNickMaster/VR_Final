using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{

    public Transform attachPoint;

    public float attachStrength = 200f;

    private Transform keyTrans;
    private Vector3 keyTarget;


    [SerializeField]
    private bool isKeyAttached;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(keyTrans != null)
        {
            keyTrans.position = Vector3.Lerp(keyTrans.position, attachPoint.position, Time.deltaTime * attachStrength);
        }


        isKeyAttached = KeyAttached();
    }

    void AttachKey()
    {
    }

    
   

    void OpenDoor()
    {
        //start sequence
        //doorOpenAnimation.Play();
        gameObject.SetActive(false);
    }

    bool KeyAttached()
    {
        return keyTrans==null ? true : keyTrans.position.z - keyTarget.z <= 0.2f;
    }

    private void OnTriggerEnter(Collider other)
    {
        //key layer
        if(other.gameObject.layer.Equals(14))
        {
            keyTrans = other.gameObject.transform;
            keyTrans.gameObject.GetComponent<Rigidbody>().Sleep();
            keyTrans.gameObject.GetComponent<MeshCollider>().enabled = false;
            AttachKey();
            //particles.start();

        }
    }

}

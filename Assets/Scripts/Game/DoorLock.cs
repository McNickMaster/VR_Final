using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorLock : MonoBehaviour
{

    public Transform attachPoint;
    public Animation doorAnimtion;

    public float attachStrength = 7f;
    public float doorUnLockTime = 0.75f;

    private Transform keyTrans;
    private Vector3 keyTarget;
    private bool locked = true;


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
            keyTrans.rotation = attachPoint.rotation;
            keyTrans.position = new Vector3(keyTrans.position.x, attachPoint.position.y, attachPoint.position.z);
            keyTrans.position = Vector3.Lerp(keyTrans.position, attachPoint.position, Time.deltaTime * attachStrength);

            if(locked)
            {
                Invoke("OpenDoor", doorUnLockTime);
                locked = false;
            }
            
        }


        isKeyAttached = KeyAttached();
    }

    void AttachKey()
    {
        keyTrans.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
        keyTrans.gameObject.GetComponent<Rigidbody>().Sleep();
        keyTrans.gameObject.GetComponent<Rigidbody>().useGravity = false;
        keyTrans.gameObject.GetComponent<MeshCollider>().enabled = false;
    }

    
   

    void OpenDoor()
    {
        //start sequence
        doorAnimtion.Play();
        //gameObject.SetActive(false);
    }

    bool KeyAttached()
    {
        return keyTrans==null ? true : keyTrans.position.z - keyTarget.z <= 0.2f;
    }

    private void OnTriggerEnter(Collider other)
    {
        //key layer
        if(other.gameObject.CompareTag("Key"))
        {
            keyTrans = other.gameObject.transform;
            
            AttachKey();
            //particles.start();

        }
    }

}

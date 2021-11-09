using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    public bool isClosed = true;
    public bool includeKey = false;
    private Collider collider;
    private void Start()
    {
        collider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Key")
        {
            includeKey = true;
        }
    }
    private void Update()
    {
          collider.enabled = !includeKey;
    }
}

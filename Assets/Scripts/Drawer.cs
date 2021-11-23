using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    public bool isClosed = true;
    public bool includeKey = false;
    private Collider collider;
    private Vector3 targetpos;
    private Vector3 oriTargetpos;
    private bool Fst = true;
    private void Start()
    {
        collider = GetComponent<Collider>();
        if(Fst)oriTargetpos = transform.position;
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

    private IEnumerator OpenAndClose()
    {
       

        if (isClosed)
        {
            while (true)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetpos, 5 * Time.deltaTime);
                yield return new WaitForSeconds(0f);
                Debug.Log(transform.position.z);
                if((int)transform.position.z <= (int)targetpos.z)
                {
                    break;
                }
            }

            Debug.Log("1");
            Debug.Log(transform.position.z);

        yield return new WaitForSeconds(0f);
            isClosed = false;
        }
        else
        {
            while (true)
            {
                transform.position = Vector3.MoveTowards(transform.position, oriTargetpos, 5 * Time.deltaTime);
                yield return new WaitForSeconds(0f);
                if(transform.position.z >= oriTargetpos.z)
                {
                    break;
                }
            }
            Debug.Log("2");
            yield return new WaitForSeconds(0f);
            isClosed = true;
        }
    }
    public void OpenAndCloseF(int Z)
    {
        if (Z == 1 && Fst)
        {
            Debug.Log("3");
            targetpos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3);
        }
        else if(Z != 1 && Fst)
        {
            targetpos = new Vector3(transform.position.x - 3, transform.position.y, transform.position.z);
        }
        StartCoroutine(OpenAndClose());
    }
}

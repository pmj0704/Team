using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    [SerializeField]
    private GameObject Bricks;
   public void BreakWall()
    {
        Bricks.SetActive(true);
        gameObject.SetActive(false);
    }
}

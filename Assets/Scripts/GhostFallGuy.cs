using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFallGuy : MonoBehaviour
{
     void OnTriggerEnter(Collider other) 
     {
         if(other.tag=="Player")
         {
            GameObject currentSpawn = Instantiate(other.gameObject,transform.position,Quaternion.identity,other.transform.parent);
            currentSpawn.GetComponent<Animator>().SetBool("isIdle",false);
            gameObject.SetActive(false);
         }
     }
}

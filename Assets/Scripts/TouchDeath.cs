using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDeath : MonoBehaviour
{
    [SerializeField] private GameObject bloodSplatter;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            foreach (Animator animator in other.GetComponentsInChildren<Animator>())
            {
                animator.SetBool("isDead",true);
            }
            other.transform.parent=null;
            Instantiate(bloodSplatter,transform.position,Quaternion.identity);
        }
    }
}

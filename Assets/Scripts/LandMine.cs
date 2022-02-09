using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour
{
    private Animator mineAnimator;

    private void Start()
    {
        mineAnimator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            mineAnimator.SetBool("hasExploaded",true);
            other.transform.parent=null;
            other.gameObject.SetActive(false);
        }
    }
}

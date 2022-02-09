using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
public class GameBrain : MonoBehaviour
{
    [SerializeField] private GameObject startGame;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject lineDraw;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SplineFollower splineFollower;

    private void Update()
    {
        PlayerDeath();
    }
    private void PlayerDeath()
    {
        if(splineFollower.transform.childCount<=0)
        {
            startGame.SetActive(false);
            panel.SetActive(false);
            splineFollower.follow=false;
            lineDraw.SetActive(false);
            loseScreen.SetActive(true);
        }

    }
    public void StartGame()
    {
        startGame.SetActive(false);
        panel.SetActive(true);
        foreach (Animator animator in splineFollower.GetComponentsInChildren<Animator>())
        {
            animator.SetBool("isIdle",false);
        }
        splineFollower.follow=true;
        lineDraw.SetActive(true);
    }
}

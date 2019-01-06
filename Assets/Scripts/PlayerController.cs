using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator anim;

    private float tps = 0.0f;
    private float avgtps = 0.0f; 
    private float StrongPullTime = 3.0f;
    private float timer = 0.0f;
    private float timerOneSec = 0.0f; 

    private bool isFirstPlayer = true;
    private bool isPull = false;
    private bool isStrongPull = false;
    //private bool isFall = false; 

	void Start ()
    {
        anim = GetComponent<Animator>();

        if (gameObject.CompareTag("SecondPlayer"))
            isFirstPlayer = false;
	}

    void Update()
    {
        if (GameManager.gm.gameIsOn)
        {
            timerOneSec += Time.deltaTime;
            timer += Time.deltaTime;

            tps = isFirstPlayer ? GameManager.gm.tpsFirstPlayer : GameManager.gm.tpsSecondPlayer;

            isPull = (tps >= 2.0f) ? true : false;

            if (timerOneSec >= 1.0f)
            {
                avgtps += tps;
                timerOneSec = 0.0f;
            }

            if (timer >= StrongPullTime)
            {
                isStrongPull = (avgtps >= 10.0f) ? true : false;
                timer = 0.0f;
                avgtps = 0.0f;
            }

            anim.SetBool("Pull", isPull);
            anim.SetBool("StrongPull", isStrongPull);
        }
    }
}

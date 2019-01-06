using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

   
    private float diff = 0.0f;


    private void Update ()
    {
        if (GameManager.gm.gameIsOn)
        {
            diff = GameManager.gm.SecondPlayerForce - GameManager.gm.firstPlayerForce;

            if (diff > 0.05f || diff < -0.05f)
            {
                StartCoroutine("moveRope");
            }
        }
	}

    IEnumerator moveRope()
    {
        yield return new WaitForSeconds(0.05f);

        transform.Translate(Vector3.right * diff / 20.0f);
    }
}

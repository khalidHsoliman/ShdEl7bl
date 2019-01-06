using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FirstPlayer"))
            GameManager.gm.FirstPlayerWin();
        else if (collision.gameObject.CompareTag("SecondPlayer"))
            GameManager.gm.SecondPlayerWin();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour {

    public static GameManager gm;

    public float firstPlayerForce = 0.0f;
    public float SecondPlayerForce = 0.0f;
    public float tpsFirstPlayer = 0.0f;
    public float tpsSecondPlayer = 0.0f;

    public bool gameIsOn = false;

    private int i = 0;
    private int j = 0; 

    private float maxtps = 10.0f;

    private List<float> tapsForFirstPlayer = new List<float>();
    private List<float> tapsForSecondPlayer = new List<float>();

    public Text beginGame; 

    public Image[] FirstPlayerPoints;
    public Image[] SecondPlayerPoints;

    public GameObject PlayAgainUI;
    public GameObject startAgainPanel;
    public GameObject Rope;

    public AudioSource audioSource; 

    private Vector3 respawnPos; 

    private void Awake()
    {
        if (gm == null)
            gm = this.GetComponent<GameManager>();

        respawnPos = Rope.transform.position; 
    }

    private void Start()
    {
        StartCoroutine("StartGame");
    }

    private void Update()
    {
        if (gameIsOn)
        {
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.x < Screen.width / 2)
            {
                tapsForFirstPlayer.Add(Time.timeSinceLevelLoad);
            }

            else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 2)
            {
                tapsForSecondPlayer.Add(Time.timeSinceLevelLoad);
            }

            for (int i = 0; i < tapsForFirstPlayer.Count; i++)
            {
                if (tapsForFirstPlayer[i] <= Time.timeSinceLevelLoad - 1)
                    tapsForFirstPlayer.RemoveAt(i);

                tpsFirstPlayer = tapsForFirstPlayer.Count;
            }

            for (int i = 0; i < tapsForSecondPlayer.Count; i++)
            {
                if (tapsForSecondPlayer[i] <= Time.timeSinceLevelLoad - 1)
                    tapsForSecondPlayer.RemoveAt(i);

                tpsSecondPlayer = tapsForSecondPlayer.Count;
            }

            firstPlayerForce = tpsFirstPlayer / maxtps;
            SecondPlayerForce = tpsSecondPlayer / maxtps;
        }
    }

    public void FirstPlayerWin()
    {
        FirstPlayerPoints[i].color = Color.yellow;
        i++;
        if (i == FirstPlayerPoints.Length)
            GameOver();
        else
            StartCoroutine("StartAgain");
    }

    public void SecondPlayerWin()
    {
        SecondPlayerPoints[j].color = Color.yellow;
        j++;
        if (j == SecondPlayerPoints.Length)
            GameOver();
        else
            StartCoroutine("StartAgain");

    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GameOver()
    {
        startAgainPanel.SetActive(true);
        PlayAgainUI.gameObject.SetActive(true);
        gameIsOn = false;
        audioSource.Stop();
    }

    IEnumerator StartAgain()
    {
        gameIsOn = false;
        startAgainPanel.SetActive(true); 
        yield return new WaitForSeconds(1.0f);
        Rope.transform.position = respawnPos;
        yield return new WaitForSeconds(0.2f);
        startAgainPanel.SetActive(false);
        gameIsOn = true;
    }

    IEnumerator StartGame()
    {
        
        yield return new WaitForSeconds(1.9f);
        beginGame.text = " Go! ";
        yield return new WaitForSeconds(1.9f);
        beginGame.gameObject.SetActive(false);

        gameIsOn = true;
    }

}

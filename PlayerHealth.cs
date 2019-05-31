using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    private int playerHealth;
    private GameObject heart1, heart2, heart3, cat;
    private Text timerText;
    private Image catImage;

    public Sprite cat3, cat2, cat1;


	// Use this for initialization
	void Awake () {
        playerHealth = 3;

        heart1 = GameObject.Find("Heart1");
        heart2 = GameObject.Find("Heart2");
        heart3 = GameObject.Find("Heart3");
        cat = GameObject.Find("Cat");

        catImage = cat.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {

        if (playerHealth == 3)
        {
            heart3.SetActive(true);
            heart2.SetActive(true);
            heart1.SetActive(true);
            catImage.sprite = cat3;
        }
        else if (playerHealth == 2)
        {
            heart3.SetActive(true);
            heart2.SetActive(true);
            heart1.SetActive(false);
            catImage.sprite = cat2;
        }
        else if (playerHealth == 1)
        {
            heart3.SetActive(true);
            heart2.SetActive(false);
            heart1.SetActive(false);
            catImage.sprite = cat1;
        }
        else if (playerHealth == 0)
        {
            heart3.SetActive(false);
            heart2.SetActive(false);
            heart1.SetActive(false);

            GameOver();
        }
    }

    public void SetPlayerHealth()
    {
        playerHealth--;
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    private void GameOver()
    {
        Debug.Log("Game over man! Game Over!");
        SceneManager.LoadScene(3);
    }

}

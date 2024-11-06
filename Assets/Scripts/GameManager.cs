using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class GameManager : MonoBehaviour
{   
   
    public GameObject[] tokens;
    List<GameObject> tokensAux;
    private int flips = 0;
    private int id1 = 0;
    private int id2 = 0;
    private Renderer renderer1;
    private Renderer renderer2;
    public TMP_Text scoreText;
    public TMP_Text winText;
    public TMP_Text Record;
    public TMP_Text triesText;
    public TMP_Text timeText;
    private int score = 8;
    private bool LetFlip = true;
    private int puntuacioMaxima = 0;
    private int tries = 0;
    public float time;
    public AudioClip correct;
    public AudioClip incorrect;
    public AudioClip flipSound;
    public AudioClip WinSound;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {  
        puntuacioMaxima = PlayerPrefs.GetInt("Record", 0);
        Record.text = "Record: " + puntuacioMaxima;
        triesText.text = "Tries: " + tries;
        audioSource = gameObject.AddComponent<AudioSource>();
        
        UpdateScoreText();
        for (int i = 0; i < tokens.Length; i++)
        {
            tokens[i].GetComponent<Token>().SetId(i);
        }
        
        tokensAux = new List<GameObject>();
        tokensAux.AddRange(tokens);
        for (int i = 0; i != 8; i++)
        {
            AssignarTokens(i);
            AssignarTokens(i);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        // Converteix el temps en minuts i segons
        int minutes = Mathf.FloorToInt(time / 60); // Calcula els minuts
        int seconds = Mathf.FloorToInt(time % 60); // Calcula els segons restants

        if (score != 0)
        {
            timeText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tokens[5].GetComponent<Token>().FlipThatToken();
        }
        
    }

    public void AssignarTokens(int img)
    {
        //print(tokensAux.Count);
        int pos =  UnityEngine.Random.Range(0, tokensAux.Count);
        tokensAux[pos].GetComponent<Token>().SetImage(img);
        tokensAux.RemoveAt(pos);
    }

    public void CheckTokens(int id)
    {
        if (flips == 0)
        {
            tokens[id].GetComponent<Token>().FlipThatToken();
            audioSource.PlayOneShot(flipSound);
            id1 = id;
            renderer1 = tokens[id].GetComponent<Token>().TokenImage.GetComponent<Renderer>();
            flips += 1;
        }
        else if (flips == 1)
        {
            LetFlip = false;
            tokens[id].GetComponent<Token>().FlipThatToken();
            audioSource.PlayOneShot(flipSound);
            id2 = id;
            renderer2 = tokens[id].GetComponent<Token>().TokenImage.GetComponent<Renderer>();

            if (renderer1.material.name == renderer2.material.name)
            {
                print("true");
                audioSource.PlayOneShot(correct);
                Invoke(nameof(EraseTokens), 2);
                score -= 1;
                UpdateScoreText();
            }
            else
            {
                print("false");
                Invoke(nameof(HideTokens), 2);
                audioSource.PlayOneShot(incorrect);
            }
            
            flips -= 1;
            tries += 1;
            triesText.text = "Tries: " + tries;

            if (score == 0)
            {
                Invoke(nameof(UpdateWinText), 2);
            }
        }
    }

    private void HideTokens()
    {
        tokens[id1].GetComponent<Token>().HideThatToken();
        tokens[id2].GetComponent<Token>().HideThatToken();
        LetFlip = true;
    }

    private void EraseTokens()
    {
        Destroy(tokens[id1]);
        Destroy(tokens[id2]);
        LetFlip = true;
    }
    
    private void UpdateScoreText()
    {
        scoreText.text = score.ToString(); // Actualitza el text amb el valor de `score`
    }
    
    private void UpdateWinText()
    {
        if (puntuacioMaxima > tries)
        {
            PlayerPrefs.SetInt("Record", tries);
            PlayerPrefs.Save();
            puntuacioMaxima = PlayerPrefs.GetInt("Record", 0);
            Record.text = "Record: " + puntuacioMaxima;
        }
        
        audioSource.PlayOneShot(WinSound);
        winText.text = "Congratulations";
        
        
    }

    public bool GetLetFlip()
    {
        return LetFlip;
    }
}

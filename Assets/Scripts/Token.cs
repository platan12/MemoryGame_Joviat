using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public GameObject TokenImage;
    
    public  Material[] materials;
   
    private int id = 0;
    
    private GameObject gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipThatToken()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("ClickTrigger");
    }
    
    public void HideThatToken()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("HideTrigger");
    }
    
    private void OnMouseDown()
    {
        bool letFlip = gameManager.GetComponent<GameManager>().GetLetFlip();
        if (letFlip)
        {
            gameManager.GetComponent<GameManager>().CheckTokens(id);
        }
    }

    public void SetId(int idset)
    {
        id = idset;
    }
    
    public void SetImage(int numMat) 
    {
        if (numMat == 0)
        {
            Renderer renderer = TokenImage.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materials[0];
            }
        }
        else if (numMat == 1)
        {
            Renderer renderer = TokenImage.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materials[1];
            }
        }
        else if (numMat == 2)
        {
            Renderer renderer = TokenImage.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materials[2];
            }
        }
        else if (numMat == 3)
        {
            Renderer renderer = TokenImage.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materials[3];
            }
        }
        else if (numMat == 4)
        {
            Renderer renderer = TokenImage.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materials[4];
            }
        }
        else if (numMat == 5)
        {
            Renderer renderer = TokenImage.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materials[5];
            }
        }
        else if (numMat == 6)
        {
            Renderer renderer = TokenImage.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materials[6];
            }
        }
        else if (numMat == 7)
        {
            Renderer renderer = TokenImage.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materials[7];
            }
        }
    }
    
    
    
}

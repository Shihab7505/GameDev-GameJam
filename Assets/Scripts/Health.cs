using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
   public int health;
   public int numOfHearts;

   public int livesRemaining;

   public Image[] hearts;
   public Sprite fullHeart;
   public Sprite emptyHeart;

    void Start() 
    {
        foreach(Image heart in hearts)
        {
            heart.enabled = false;
        }
        for(int i = 0; i < numOfHearts; i++)
        {
            hearts[i].sprite = fullHeart;
            hearts[i].enabled = true;
        }
        livesRemaining = numOfHearts;
    }

    void Update()
    {

    }

    public void DecreaseLife()
    {
        livesRemaining--;
        hearts[livesRemaining].sprite = emptyHeart;
        numOfHearts = livesRemaining;
        Debug.Log(livesRemaining);
        Debug.Log("F");
    }
}

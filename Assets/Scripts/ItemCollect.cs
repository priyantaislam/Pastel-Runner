using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    private int cherries = 0;
    [SerializeField] private Text score;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            cherries++;
            score.text = "Score: " + cherries;

            if(cherries == 3)
            {
                score.text = "You win!";
            }
        }
    }
}

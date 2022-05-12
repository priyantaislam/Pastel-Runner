using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finish_sound;
    private bool check_finish = false;
    // Start is called before the first frame update
    private void Start()
    {
        finish_sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !check_finish)
        {
            finish_sound.Play();
            check_finish = true;
            Invoke("CompleteLevel", 1.5f);
            

        }

        

    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

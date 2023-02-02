using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //sahne kontrolleri i�in gerekli olan k�t�phane

public class finish : MonoBehaviour
{

    [SerializeField] private AudioSource finishSound;
    private bool levelComplated = false;
    
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelComplated)
        {
            finishSound.Play();
            levelComplated = true;
            Invoke("ComplateLevel", 1f); //istenen fonksiyonu iki saniye sonra �al��t�racak
        }
    }

    private void ComplateLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // bi sonraki sayhneyi yukle 
    }
}

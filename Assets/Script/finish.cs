using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //sahne kontrolleri için gerekli olan kütüphane

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
            Invoke("ComplateLevel", 1f); //istenen fonksiyonu iki saniye sonra çalýþtýracak
        }
    }

    private void ComplateLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // bi sonraki sayhneyi yukle 
    }
}

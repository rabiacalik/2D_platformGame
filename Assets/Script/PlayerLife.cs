using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    [SerializeField] private AudioSource oldu_sound;
   

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            oldu_sound.Play();
            Die();
        }
    }

    private void Die()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
        _animator.SetTrigger("death");
        //dirildi_sound.Play();
    }

    private void ReStartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

}

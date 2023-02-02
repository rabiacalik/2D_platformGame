using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherry = 0;

    [SerializeField] public Text cherriesText;

    [SerializeField] private AudioSource item_alma_sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cherry"))
        {
            item_alma_sound.Play();
            Destroy(collision.gameObject);//sil
            cherry++;
            cherriesText.text = "Kiraz : " + cherry;
        }
    }
}

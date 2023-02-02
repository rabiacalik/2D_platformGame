using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Tan�mlamalar yapt�k
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _collider2D;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f; //SerializeField ile tan�mlad���m�zda unity de bu de�i�kenlerle oynayabiliyoruz
    [SerializeField] private float jumpForce = 14f;

    [SerializeField] public LayerMask jumpableGround;

    private enum MovementState { idle, running, jumping, falling}

    [SerializeField] private AudioSource jumpSoundEffect;

    private void Start()
    {
        // GetComponent: Verilen bile�en tipini objede arar, e�er obje bu bile�ene sahipse bile�eni, sahip de�ilse null de�eri d�nd�r�r.
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        dirX = Input.GetAxis("Horizontal"); //Haz�r input yap�lar�na eri�ebiliyoruz
        _rigidbody2D.velocity = new Vector2(dirX * moveSpeed, _rigidbody2D.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        }

        UpdateAnimationState(); //Fonksiyonu �a��rd�k

    }

    private void UpdateAnimationState() //Animasyon durumu g�ncelle
    {

        MovementState state;

        //Animasyonun devreye girebilmesi i�in parametre ayarlad�k
        if (dirX > 0f)
        {
            state = MovementState.running;
            _spriteRenderer.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            _spriteRenderer.flipX = true; //sprite nin x ekseninde d�nd�r�yoruz, b�ylece y�n�n� de�i�tirmi� gibi oluyor.
        }
        else
        {
            state = MovementState.idle;
        }

        if (_rigidbody2D.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (_rigidbody2D.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        _animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded() //Topraklama
    {
        return Physics2D.BoxCast(_collider2D.bounds.center, _collider2D.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}

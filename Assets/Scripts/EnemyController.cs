using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private BoxCollider2D _bc;
    [SerializeField] private float life = 200;
    [SerializeField] private float speed = 2.5f;
    private Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _bc = GetComponent<BoxCollider2D>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null && life > 0)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        Vector2 direction = (_player.position - transform.position).normalized;
        _rb.MovePosition(_rb.position + direction * speed * Time.deltaTime);


        if (_player.position.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else if (_player.position.x < transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    public void SetDanio(float danio, float force, Vector2 direction)
    {
        _rb.AddForce(direction * force, ForceMode2D.Impulse);
        life -= danio;

        if (life > 0)
        {
            _animator.SetTrigger("takeHit");
        }
        else
        {
            // Desactivar el collider
            _bc.enabled = false;

            // Eliminar el Rigidbody para que el objeto no afecte físicamente a otros objetos
            Destroy(_rb);

            _animator.SetBool("IsDeath", true);

            // Aplicar una fuerza al enemigo
            Invoke(nameof(Destruir), 3f);
        }
    }

    private void Destruir()
    {
        Destroy(gameObject);
    }
}

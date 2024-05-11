using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private BoxCollider2D _bc;
    [SerializeField] private float life = 50;



    private Rigidbody _rigidbody; // Agrega una referencia al Rigidbody
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDanio(float danio,float force ,Vector2 direction)
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

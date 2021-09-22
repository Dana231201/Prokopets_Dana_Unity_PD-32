using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (Rigidbody2D ))]
public class playermove : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField ]private float _speed;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _jumpeForce;

    [SerializeField] private Transform _groundchecker;

    [SerializeField] private float _groundcheckerRadius;

    [SerializeField] private LayerMask _whatisground;

    [SerializeField] private Collider2D _headCollider;

    [SerializeField] private float _headCheckerRadius;

    [SerializeField] private Transform _headChecker;

    private float _direction;

    private bool _Jump;
    private bool _crawl;

   // Start is called before the first frame update
   private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    } 

    // Update is called once per frame
    private void Update()
    {
     _direction = Input.GetAxisRaw("Horizontal");
            Debug.Log(_direction);

        if (Input.GetKeyDown(KeyCode.Space) )
        {
            _Jump = true;

          
        }
        if (_direction > 0 && _spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_direction < 0 && !_spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = true;
        }

        _crawl = Input.GetKey(KeyCode.C);
      
    }
    private void FixedUpdate()

    {

        _rigidbody.velocity = new Vector2(x:_direction * _speed, _rigidbody.velocity.y);

        bool canJump =(bool) Physics2D.OverlapCircle((Vector2) _groundchecker.position, _groundcheckerRadius, (int) _whatisground);
        bool canStand = Physics2D.OverlapCircle((Vector2)_headChecker.position, _headCheckerRadius, (int) _whatisground);

        Debug.Log(message: !_crawl! && canStand);

        _headCollider.enabled = !_crawl && canStand;

        if (_Jump && canJump  )
        {
            _rigidbody.AddForce(Vector2.up * _jumpeForce);
            _Jump = false;
        }
   
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere( _groundchecker.position ,  _groundcheckerRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_headChecker.position, _headCheckerRadius);
    }
}


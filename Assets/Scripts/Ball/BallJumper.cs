
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)      //ball jumps if it collided with Platform Segment
    {
        if (collision.gameObject.TryGetComponent(out PlatformSegment platformSegment))
        {
            transform.gameObject.GetComponent<AudioManager>().PlayCnockSound();         //play sound from method in AudioManager script
            _rigidbody.velocity = Vector3.zero;                                         //removes inertia
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);            //add jump force
            
        }
    }
}

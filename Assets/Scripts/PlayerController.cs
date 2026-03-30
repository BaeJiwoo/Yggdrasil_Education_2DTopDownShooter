using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public float mProjectileSpeed = 1000.0f;
    private Animator mAnimator;
    public Rigidbody2D Projectile;

    private Vector2 LookDir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 움직임
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (input.magnitude > 0f) LookDir = input;
        //Debug.Log(input);
        transform.position += (Vector3)input * Time.deltaTime * speed;

        //애니메이션
        mAnimator.SetFloat("Look X", LookDir.x);
        mAnimator.SetFloat("Look Y", LookDir.y);
        mAnimator.SetFloat("Speed", input.magnitude);

        if (Input.GetButtonDown("Fire1"))
        {
            // 공격 스크립트
            Rigidbody2D proj = Instantiate(Projectile, transform.position, Quaternion.identity) as Rigidbody2D;
            proj.AddForce(LookDir * mProjectileSpeed);
        }
    }
}

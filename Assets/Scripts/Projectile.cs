using UnityEngine;

public class Projectile : MonoBehaviour
{
    BoxCollider2D boxCollider2D;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌 이벤트
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(1f);
        }



        Destroy(gameObject);
    }
}

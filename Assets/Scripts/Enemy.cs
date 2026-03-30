using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP = 5f;
   

    public void Death()
    {
        Debug.Log("Á×À½");
    }
    public void TakeDamage(float value)
    {
        HP -= value;
        Debug.Log(HP);
        if(HP <= 0f)
        {
            Death();
        }
    }
}

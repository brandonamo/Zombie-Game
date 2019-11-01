//https://www.youtube.com/watch?v=THnivyG0Mvo

using UnityEngine;

public class TargetScript : MonoBehaviour
{

    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }


    }

    void Die()
    {
        Destroy(gameObject);
    }


}

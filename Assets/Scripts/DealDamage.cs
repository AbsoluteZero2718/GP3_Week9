using UnityEngine;

public class DealDamage : MonoBehaviour
{
    private PlayerAttack playerAttack;
        public int damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAttack = transform.root.GetComponent<PlayerAttack>();
        damage = playerAttack.swordData.damage;
    }



    // Update is called once per frame
    void Update()
    {
        if (other.CompareTag("Enemy"))
        {
            TestingDummy.enemy = other.GetComponent<TestingDummy>();
            enemy.TakeDamage(damage);
        }
    }
}

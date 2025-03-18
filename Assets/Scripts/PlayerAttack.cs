using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public WeaponData swordData;
    public GameObject swordHandler;
    public Collider swordCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        swordData.ChangeKick(swordHandler);
        swordCollider = GetComponentInChildren<Collider>();
        swordCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
    }
}

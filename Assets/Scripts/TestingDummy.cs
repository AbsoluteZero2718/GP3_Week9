using UnityEngine;

public class TestingDummy : MonoBehaviour
{
    public int HP;
    public Material hitMaterial, originalMaterial;
    public Renderer objectRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
      

    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        ChangeMaterialTemporarily();
    }
}

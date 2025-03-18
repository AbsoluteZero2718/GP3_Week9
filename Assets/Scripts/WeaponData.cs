using UnityEngine;

[CreateAssetMenu(fileName = "New Sword", menuName = "Swords/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string swordName;
    public GameObject weaponPrefab;
    public int damage;

    public void ChangeKick(GameObject playerSword)
    {
        GameObject swordInstance = Instantiate(weaponPrefab, playerSword.transform);
        swordInstance.transform.localPosition = Vector3.zero;
        swordInstance.transform.localRotation = Quaternion.identity; 
    }
}

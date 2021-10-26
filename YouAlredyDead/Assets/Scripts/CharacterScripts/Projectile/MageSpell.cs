using UnityEngine;

public class MageSpell : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    public void CastSpell()
    {
        Instantiate(_prefab, GameObject.FindObjectOfType<PlayerMovemed>().transform.position, Quaternion.identity);
    }
}

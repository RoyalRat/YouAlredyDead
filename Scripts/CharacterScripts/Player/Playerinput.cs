using UnityEngine;

[RequireComponent(typeof(PlayerMovemed))]
public class Playerinput : MonoBehaviour
{
    private PlayerMovemed _playerMovemed;

    private void Awake()
    {
        _playerMovemed = GetComponent<PlayerMovemed>();
    }

    private void Update()
    {
        float x = Input.GetAxis(GameData.HorizontalAxis);
        float z = Input.GetAxis(GameData.VerticalAxis);

        _playerMovemed.Move(x, z);
    }
}

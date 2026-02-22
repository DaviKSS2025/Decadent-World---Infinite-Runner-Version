using UnityEngine;

public class PlayerGroundChecker : MonoBehaviour
{
    private PlayerController playerController;
    public void Initialize(PlayerController player)
    {
        playerController = player;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            playerController.IsGrounded = true;
            playerController.AudioManager.PlayGroundSFX();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            playerController.IsGrounded = false;
        }
    }
}

using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : ThirdPersonController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameManager gameManager = null;

    private void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            // get game manager if it hasnt been gotten already
            if (gameManager == null)
                gameManager = FindAnyObjectByType<GameManager>();

            // toggle pause 
            if (gameManager != null)
                gameManager.TogglePause();
        }
    }

    private void OnRemoveItem(InputValue value)
    {
        if (value.isPressed)
        {
            GetComponent<Inventory>().RemoveItemFromInventory();
        }
    }
}

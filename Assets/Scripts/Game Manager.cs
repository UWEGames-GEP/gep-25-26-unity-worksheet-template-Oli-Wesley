using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum GameState
    {
        GAMEPLAY,
        PAUSE,
    }

    [SerializeField] private GameState state;
    private bool hasChangedState = false;
    void Start()
    {
        state = GameState.GAMEPLAY;
    }

    // Update is called once per frame
    public void TogglePause()
    {
        if (state == GameState.GAMEPLAY)
        {  
                state = GameState.PAUSE;
                hasChangedState = true;
        }
        else if (state == GameState.PAUSE)
        {
                state = GameState.GAMEPLAY;
                hasChangedState = true;
        }
    }

    private void LateUpdate()
    {
        if (hasChangedState)
        {
            hasChangedState = false;
            if (state == GameState.GAMEPLAY)
                Time.timeScale = 1.0f;
            else if (state == GameState.PAUSE)
                Time.timeScale = 0.0f;
        }
    }

    public GameState GetGameState()
    {
        return state;
    }
}

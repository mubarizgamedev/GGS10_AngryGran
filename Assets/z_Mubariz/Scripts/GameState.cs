using UnityEngine;

public class GameState : MonoBehaviour
{
    public enum CurrentGameState 
    {
        Playing,
        Pause,
        Resume,
        Win,
        Fail,
        Danger,
        Attacked
    };

    public CurrentGameState currentGameState;

    public void ChangeState(CurrentGameState currentGameState)
    {
        switch (currentGameState)
        {
            case CurrentGameState.Playing:
                //Playing
                break;
            case CurrentGameState.Pause:
                //Pause
                break;
            case CurrentGameState.Resume:
                //Resume
                break;
            case CurrentGameState.Win:
                //Win
                break;
            case CurrentGameState.Fail:
                //Fail
                break;
            case CurrentGameState.Danger:
                //Danger
                break;
            case CurrentGameState.Attacked:
                //Attacked
                break;
            default:
                break;
        }
    }






}

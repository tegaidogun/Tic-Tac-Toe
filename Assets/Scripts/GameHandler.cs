using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public Sprite cross;
    public Sprite circle;
    public Sprite currentPlayerImage;
    public Sprite currentCPUImage;
    public List<int> positions = new List<int>();
    public List<int> positionsPlayedAgainstUS = new List<int>();
    public bool gameOver = false;

    // Start is called before the first frame update
    private void Start()
    {
        if (!currentPlayerImage)
        {
            currentPlayerImage = circle;
        }

        if (currentPlayerImage == cross)
        {
            currentCPUImage = circle;
        }
        else
        {
            currentCPUImage = cross;
        }
    }

    public void CheckForGameOver(List<int> positions, bool playerWon)
    {
        if (positions.Contains(1) && positions.Contains(2) && positions.Contains(3))
            Winner(playerWon);
        else if (positions.Contains(4) && positions.Contains(5) && positions.Contains(6))
            Winner(playerWon);
        else if (positions.Contains(7) && positions.Contains(8) && positions.Contains(9))
            Winner(playerWon);
        else if (positions.Contains(1) && positions.Contains(4) && positions.Contains(7))
            Winner(playerWon);
        else if (positions.Contains(2) && positions.Contains(5) && positions.Contains(8))
            Winner(playerWon);
        else if (positions.Contains(3) && positions.Contains(6) && positions.Contains(9))
            Winner(playerWon);
        else if (positions.Contains(1) && positions.Contains(5) && positions.Contains(9))
            Winner(playerWon);
        else if (positions.Contains(3) && positions.Contains(5) && positions.Contains(7))
            Winner(playerWon);
        else if (positions.Count + positionsPlayedAgainstUS.Count == 9)
            Debug.Log("Draw");
    }

    public void Winner(bool playerWon)
    {
        if (playerWon)
        {
            gameOver= true;
            Debug.Log("Player Won");
        }
        else
        {
            gameOver = true;
            Debug.Log("CPU Won");
        }
    }
}

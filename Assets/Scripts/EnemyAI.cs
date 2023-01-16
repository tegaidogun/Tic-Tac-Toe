using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public string gameManagerTag = "GameController";
    public string playablePositionTag = "PlayableSpot";
    public bool firstTurn = false;
    public GameObject[] playableSpots;

    GameHandler gameHandler;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindWithTag(gameManagerTag).GetComponent<GameHandler>();
        playableSpots = GameObject.FindGameObjectsWithTag(playablePositionTag);
        if (firstTurn)
        {
            CPUTurn();
        }
    }

    public void CPUPlay(int position) 
    { 
        if (!gameHandler.gameOver)
        {
            foreach (GameObject pos in playableSpots)
            {
                if(pos.GetComponent<PlayablePosition>().positionInteger == position && !pos.GetComponent<PlayablePosition>().alreadyPlaced)
                {
                    pos.tag = "NonPlayableSpot";
                    pos.GetComponent<PlayablePosition>().PlayThisPosition(gameHandler.positionsPlayedAgainstUS, gameHandler.currentCPUImage);
                }
            }
            playableSpots = GameObject.FindGameObjectsWithTag(playablePositionTag);
        }
    }

    public void CPUTurn()
    {
        playableSpots = GameObject.FindGameObjectsWithTag(playablePositionTag);
        int played = Random.Range(0, playableSpots.Length - 1);
        CPUPlay(playableSpots[played].GetComponent<PlayablePosition>().positionInteger);
        gameHandler.CheckForGameOver(gameHandler.positionsPlayedAgainstUS, false); ;
    }
}

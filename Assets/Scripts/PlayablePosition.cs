using System.Collections.Generic;
using UnityEngine;

public class PlayablePosition : MonoBehaviour
{

    public float visibleLerp = 0f;
    public float duration = 0.1f;
    public string gameManagerTag = "GameController";
    public int positionInteger;
    public bool alreadyPlaced = false;

    SpriteRenderer visibility;
    GameHandler gameHandler;
    EnemyAI enemy;    

    // Start is called before the first frame update
    private void Start()
    {
        visibility = GetComponent<SpriteRenderer>();
        gameHandler = GameObject.FindWithTag(gameManagerTag).GetComponent<GameHandler>();
        enemy = gameHandler.GetComponent<EnemyAI>();
    }

    private void OnMouseEnter()
    {
        if(!gameHandler.gameOver)
        {
            if (!alreadyPlaced)
            {
                visibleLerp = Time.deltaTime / duration;
                Color tempColor = visibility.color;
                tempColor.a = Mathf.Lerp(1, 0, visibleLerp);
                visibility.color = tempColor;
            }
        }
    }

    private void OnMouseExit()
    {
        if (!gameHandler.gameOver)
        {
            if (!alreadyPlaced)
            {
                visibleLerp = Time.deltaTime / duration;
                Color tempColor = visibility.color;
                tempColor.a = Mathf.Lerp(0, 1, visibleLerp);
                visibility.color = tempColor;
            }
        }
    }

    public void PlayThisPosition(List<int> positionList,Sprite image)
    {
        alreadyPlaced = true;
        positionList.Add(positionInteger);
        Color tempColor = visibility.color;
        tempColor.a = Mathf.Lerp(1, 0, visibleLerp);
        visibility.color = tempColor;
        visibility.sprite = image;
        visibleLerp = Time.deltaTime / duration;
    }

    private void OnMouseUp()
    {
        if(!gameHandler.gameOver)
        {
            this.gameObject.tag = "NonPlayableSpot";
            PlayThisPosition(gameHandler.positions, gameHandler.currentPlayerImage);
            if (gameHandler.positions.Count > 2)
            {
                gameHandler.CheckForGameOver(gameHandler.positions, true);
            }
        }

        if(!gameHandler.gameOver)
        {
            enemy.Invoke("CPUTurn", 1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Play : MonoBehaviour
{
    public Image[] boardImage;
    public Sprite O, X;
    public Text state;
    public int playerClick;
    char ai, player;

    [HideInInspector]
    public bool gameStart;
    public GameObject restartButton;

    public char[] board = new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };


    public bool gameOver = false;
    public bool playerTurn;


    private void Awake()
    {
        playerTurn = Random.value > .5f;
        gameStart = false;
    }

    void Update()
    {
        if (gameOver)
        {
            restartButton.SetActive(true);
            return;
        }
        if (gameStart)
        {
            if (playerTurn)
            {
                state.text = "輪到你了";
                PlayerMove();
            }
            else
            {
                
                Thread.Sleep(1000);
                CompMove();
            }
            DrawBoard();
            if (IsWinner(player))
            {
                state.text = "恭喜你贏了!";
                gameOver = true;
            }
            else if (IsWinner(ai))
            {
                state.text = "再接再厲!";
                gameOver = true;
            }
            else if (BoardIsFull())
            {
                state.text = "精彩的平手!";
                gameOver = true;
            }
        }
    }

    void PlayerMove()
    {
        if (playerClick != -1)
        {
            if (SpaceIsFree(playerClick))
            {
                InsertLetter(player, playerClick);
                playerClick = -1;
                playerTurn = false;
                state.text = "電腦思考中";
            }
            else
            {
                playerClick = -1;
            }
        }
    }

    public void CompMove()
    {
        float bestScore = -Mathf.Infinity;
        int bestMove = 0;

        for (int i = 0; i < board.Length; i++)
        {
            if (SpaceIsFree(i))
            {
                board[i] = ai;
                float score = Minimax(board, 0, false);
                board[i] = ' ';
                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = i;
                }
            }
        }
        InsertLetter(ai, bestMove);
        playerTurn = true;
    }

    public float Minimax(char[] board, int depth, bool isMaximizer)
    {
        if (IsWinner(ai))
            return 1;
        if (IsWinner(player))
            return -1;
        if (BoardIsFull())
            return 0;

        if (isMaximizer)
        {
            float bestScore = -Mathf.Infinity;
            for (int i = 0; i < board.Length; i++)
            {
                if (SpaceIsFree(i))
                {
                    board[i] = ai;
                    float score = Minimax(board, depth + 1, false);
                    board[i] = ' ';
                    bestScore = Mathf.Max(score, bestScore);
                }
            }
            return bestScore;
        }
        else
        {
            float bestScore = Mathf.Infinity;
            for (int i = 0; i < board.Length; i++)
            {
                if (SpaceIsFree(i))
                {
                    board[i] = player;
                    float score = Minimax(board, depth + 1, true);
                    board[i] = ' ';
                    bestScore = Mathf.Min(score, bestScore);
                }
            }
            return bestScore;
        }
    }

    void InsertLetter(char letter, int pos)
    {
        board[pos] = letter;
    }

    bool SpaceIsFree(int pos)
    {
        return board[pos] == ' ';
    }

    bool IsWinner(char letter)
    {
        return (board[0] == letter && board[1] == letter && board[2] == letter) ||
               (board[3] == letter && board[4] == letter && board[5] == letter) ||
               (board[6] == letter && board[7] == letter && board[8] == letter) ||
               (board[0] == letter && board[3] == letter && board[6] == letter) ||
               (board[1] == letter && board[4] == letter && board[7] == letter) ||
               (board[2] == letter && board[5] == letter && board[8] == letter) ||
               (board[0] == letter && board[4] == letter && board[8] == letter) ||
               (board[6] == letter && board[4] == letter && board[2] == letter);
    }

    public void DrawBoard()
    {
        int count = 0;
        foreach (char space in board)
        {
            if (space == 'O')
            {
                boardImage[count].sprite = O;
                boardImage[count].gameObject.SetActive(true);
            }
            else if (space == 'X')
            {
                boardImage[count].sprite = X;
                boardImage[count].gameObject.SetActive(true);
            }
            count++;
        }
    }

    bool BoardIsFull()
    {
        foreach (char space in board)
            if (space == ' ')
                return false;
        return true;
    }

    public void SetChar(char aiChar, char playerChar)
    {
        ai = aiChar;
        player = playerChar;
    }
}

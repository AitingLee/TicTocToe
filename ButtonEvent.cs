using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    public GameObject Opointer, Xpointer;
    public Button Obutton, Xbutton;
    public Play play;

    public void OnClickButtonO()
    {
        Obutton.enabled = false;
        Xbutton.enabled = false;
        Opointer.SetActive(true);
        play.SetChar('X', 'O');
        play.gameStart = true;
    }
    public void OnClickButtonX()
    {
        Obutton.enabled = false;
        Xbutton.enabled = false;
        Xpointer.SetActive(true);
        play.SetChar('O', 'X');
        play.gameStart = true;
    }

    public void OnClickButton0()
    {
        if (play.playerTurn)
        {
            play.playerClick = 0;
        }
    }

    public void OnClickButton1()
    {
        if (play.playerTurn)
        {
            play.playerClick = 1;
        }
    }
    public void OnClickButton2()
    {
        if (play.playerTurn)
        {
            play.playerClick = 2;
        }
    }
    public void OnClickButton3()
    {
        if (play.playerTurn)
        {
            play.playerClick = 3;
        }
    }
    public void OnClickButton4()
    {
        if (play.playerTurn)
        {
            play.playerClick = 4;
        }
    }
    public void OnClickButton5()
    {
        if (play.playerTurn)
        {
            play.playerClick = 5;
        }
    }
    public void OnClickButton6()
    {
        if (play.playerTurn)
        {
            play.playerClick = 6;
        }
    }
    public void OnClickButton7()
    {
        if (play.playerTurn)
        {
            play.playerClick = 7;
        }
    }
    public void OnClickButton8()
    {
        if (play.playerTurn)
        {
            play.playerClick = 8;
        }
    }

    public void OnRestartClick()
    {
        play.playerTurn = Random.value > .5f;
        play.gameOver = false;
        play.gameStart = false;
        Obutton.enabled = true;
        Xbutton.enabled = true;
        Opointer.SetActive(false);
        Xpointer.SetActive(false);
        for (int i= 0; i < play.board.Length; i++)
        {
            play.board[i] = ' ';
            play.boardImage[i].gameObject.SetActive(false);
        }
        play.restartButton.SetActive(false);
        play.state.text = "請選擇O或X開始";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enumerator;

public class Manager : MonoBehaviour { 

    public Player[] players;
    public Tile[] tiles;
    public PlayerType turn;

    public Sprite[] TicTacToesprite;

    int endPoint;
    bool isGame;
    bool draw;

    public GameObject Announcement;
    public UI ui;
    public void Start() {
        isGame = true;
    }

    public bool WinChecker(Type type) {
        if(CheckDiagonal(type) || CheckHorizontal(type) || CheckVertical(type)) {
            return true;
        } else {
            if (FinalCheck()) {
                draw = true;
                return true;
            } else {
                return false;
            }
        }
    }

    public bool CheckDiagonal(Type type) {
        return (Check(0,4, type)  || Check(2,2, type));
    }

    public bool CheckHorizontal(Type type) {
        return (Check(0, 1, type) || Check(3,1, type) || Check(6,1, type));
    }

    public bool CheckVertical(Type type) {
        return (Check(0, 3, type) || Check(1, 3, type) || Check(2, 3, type));
    }

    public bool Check(int startPoint, int incrementValue, Type type) {
        endPoint = startPoint + (3 * incrementValue);
        for(int i = startPoint; i < endPoint; i += incrementValue) {
            if (!tiles[i].isOccupied) {
                return false;
            }
            if (tiles[i].type != type) {
                return false;
            }
        }

        return true;
    }

    public bool FinalCheck() {
        for(int i = 0; i < tiles.Length; i++) {
            if (!tiles[i].isOccupied) {
                return false;
            }
        }

        return true;
    }

    public void DoMove(int tileIndex) {
        if (!isGame) return;
        if (tiles[tileIndex].isOccupied) return;
        tiles[tileIndex].Occupy(GetActivePlayer().type, TicTacToesprite[(int)GetActivePlayer().type]);
        tiles[tileIndex].isOccupied = true;

        if (WinChecker(GetActivePlayer().type)) {
            PostGame();
        } else {
            NextTurn();
        }
    }
    
    public void NextTurn() {
        if(turn == PlayerType.Player1) {
            turn = PlayerType.Player2;
            ui.SetTurn("Player 2");
        } else {
            turn = PlayerType.Player1;
            ui.SetTurn("Player 1");
        }

    }

    public void PostGame() {
        isGame = false;
        Announcement.SetActive(true);
        if (draw) {
            ui.SetAnnouncement("Draw");
        } else {
            if (GetActivePlayer().playerTurn == PlayerType.Player1) {
                ui.SetAnnouncement("Player 1 Win");
            } else {
                ui.SetAnnouncement("Player 2 Win");
            }
        }
       
       
    }

    public void Reset() {
        for(int i = 0; i < tiles.Length; i++) {
            tiles[i].unOccupy();
        }
        draw = false;
        turn = PlayerType.Player1;
        ui.SetTurn("Player 1");
        Announcement.SetActive(false);
        isGame = true;
    }

    public Player GetActivePlayer() {
        foreach (Player player in players) {
            if(player.playerTurn == turn) {
                return player;
            }
        }

        return null;
    }

    public void Exit() {
        Application.Quit();
    }

}

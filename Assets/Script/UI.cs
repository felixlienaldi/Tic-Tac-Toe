using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    public TextMeshProUGUI turn;
    public TextMeshProUGUI announce;
    
    public void SetTurn(string turn) {
        this.turn.text = "Turn : " + turn;
    }

    public void SetAnnouncement(string player) {
        announce.text = player;
    }


}

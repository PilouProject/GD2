using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace CardFight
{
    public class GameLoop : MonoBehaviour
    {
        PlayerClass player1;
        PlayerClass player2;
        string player1action;
        string player2action;
        List<string> tagsplayer1;
        List<string> tagsplayer2;
        public bool playerTurn;
        public GameObject handObject;

        // Start is called before the first frame update
        void Start()
        {
            tagsplayer1 = new List<string>();
            tagsplayer2 = new List<string>();
            player1 = new PlayerClass();
            player2 = new PlayerClass();
            player1.init();
            player2.init();
            playerTurn = false;
            if (player1.hand.Count < 5) { player1.addCard(); }
            handObject.GetComponent<HandHandler>().InstantiateHand(player1.hand);
            Debug.Log("Beginning");
        }

        public void switchAction(string playeraction, PlayerClass attackPlayer, PlayerClass defensePlayer, List<string> attackTag, List<string> defenseTag)
        {
            switch (playeraction)
            {
                case "knuckles":
                    attackPlayer.strenght += 4;
                    attackPlayer.stance = 1;
                    attackPlayer.hand.RemoveAt(attackPlayer.hand.IndexOf(playeraction));
                    break;
                case "baseball":
                    attackPlayer.strenght += 6;
                    attackPlayer.stance = 1;
                    attackPlayer.hand.RemoveAt(attackPlayer.hand.IndexOf(playeraction));
                    break;
                case "heal":
                    attackPlayer.hp += 3;
                    attackPlayer.stance = 2;
                    attackPlayer.hand.RemoveAt(attackPlayer.hand.IndexOf(playeraction));
                    break;
                case "thorns":
                    attackPlayer.thornsup = true;
                    attackPlayer.stance = 2;
                    attackPlayer.hand.RemoveAt(attackPlayer.hand.IndexOf(playeraction));
                    break;
                case "taunt":
                    attackPlayer.superBar -= 1;
                    attackPlayer.stance = 3;
                    attackPlayer.hand.RemoveAt(attackPlayer.hand.IndexOf(playeraction));
                    break;
                case "remove":
                    defensePlayer.hand.RemoveAt(Random.Range(0, defensePlayer.hand.Count - 1));
                    attackPlayer.stance = 3;
                    attackPlayer.hand.RemoveAt(attackPlayer.hand.IndexOf(playeraction));
                    break;
                case "weakness":
                    defenseTag.Add("weakness");
                    attackPlayer.stance = 3;
                    attackPlayer.hand.RemoveAt(attackPlayer.hand.IndexOf(playeraction));
                    break;
                case "bite":
                    defenseTag.Add("bite");
                    attackPlayer.stance = 1;
                    attackPlayer.hand.RemoveAt(attackPlayer.hand.IndexOf(playeraction));
                    break;
                case "enrage":
                    attackTag.Add("enrage");
                    attackPlayer.stance = 2;
                    attackPlayer.hand.RemoveAt(attackPlayer.hand.IndexOf(playeraction));
                    break;
                case "stanceAttack":
                    attackPlayer.stance = 1;
                    break;
                case "stanceDefense":
                    attackPlayer.stance = 2;
                    break;
                case "stanceGrab":
                    attackPlayer.stance = 3;
                    break;
            }
        }
        public void resolve()
        {
            switchAction(player1action, player1, player2, tagsplayer1, tagsplayer2);
            switchAction(player2action, player2, player1, tagsplayer2, tagsplayer1);
            if (player1.stance == 1 && player2.stance == 2)
            {
                if (tagsplayer2.Count > 0)
                    tagsplayer2.RemoveAt(tagsplayer2.Count - 1);
                if (player2.thornsup == true)
                    player1.hp -= (int)Mathf.Round(player1.strenght * player1.strenghtcoef / 2);
            }
            else if (player1.stance == 3 && player2.stance == 1 || player1.stance == 2 && player2.stance == 3)
            {
                if (tagsplayer2.Count > 0)
                    tagsplayer2.RemoveAt(tagsplayer2.Count - 1);
                player1.hp -= (int)(player2.strenght * player2.strenghtcoef);
            }
            else if (player1.stance == 2 && player2.stance == 1)
            {
                if (tagsplayer1.Count > 0)
                    tagsplayer1.RemoveAt(tagsplayer1.Count - 1);
                if (player1.thornsup == true)
                    player2.hp -= (int)Mathf.Round(player2.strenght * player2.strenghtcoef / 2);
            }
            else if (player1.stance == 1 && player2.stance == 3 || player1.stance == 3 && player2.stance == 2)
            {
                if (tagsplayer1.Count > 0)
                    tagsplayer1.RemoveAt(tagsplayer1.Count - 1);
                player2.hp -= (int)(player1.strenght * player1.strenghtcoef);
            }
            else if (player1.stance == 1 && player2.stance == 1 || player1.stance == 3 && player2.stance == 3)
            {
                player1.hp -= (int)(player2.strenght * player2.strenghtcoef);
                player2.hp -= (int)(player1.strenght * player1.strenghtcoef);
            }
            Debug.Log("J1 Hp : " + player1.hp + "\nJ2 Hp : " + player2.hp);
        }

        public void handleCard()
        {
            if (playerTurn == false)
                player1action = EventSystem.current.currentSelectedGameObject.name;
            else
                player2action = EventSystem.current.currentSelectedGameObject.name;
            Debug.Log(" Player Action J1 : " + player1action + "\nPlayer Action J2 : " + player2action);
        }

        public void handleNext()
        {
            if (playerTurn == false)
            {
                Debug.Log("Turn 2 player");
                tagsplayer2 = player2.status(tagsplayer2);
                if (player2.hand.Count < 5) { player2.addCard(); }
                handObject.GetComponent<HandHandler>().DestroyHand();
                handObject.GetComponent<HandHandler>().InstantiateHand(player2.hand);
                this.playerTurn = true;

            }
            else if (playerTurn == true)
            {
                resolve();
                //if (player1.hp <= 0 || player2.hp <= 0)
                //    victoryScreen();
                Debug.Log("Turn 1 player");
                player1.resetStat();
                player2.resetStat();
                tagsplayer1 = player1.status(tagsplayer1);
                if (player1.hand.Count < 5) { player1.addCard(); }
                handObject.GetComponent<HandHandler>().DestroyHand();
                handObject.GetComponent<HandHandler>().InstantiateHand(player1.hand);
                playerTurn = false;
            }
        }
    }
}
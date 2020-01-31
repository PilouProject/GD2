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
        public GameObject Anim_player1;
        public GameObject Anim_player2;

        // Start is called before the first frame update
        void Start()
        {

            // Initialisation du script + premier tour 
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
            //On résout les effets des cartes ou de la position sélectionnée, on modifie le facteur force et la postion en fonction des cartes ou des actions, le nom des objects crée doivent être égaux à ceux du switch
            //Cette fonction n'est appelé qu'à la fin des deux tours, on peut pas l'utiliser pour créer les anims pendant la sélection des joueurs mais pour la résolution aucun soucis
            //knuckles == poing américain, basseball == La batte, heal == dernier souffle, thorns == épine, taunt == Moquerie, remove == Stupeur, weakness == Faiblesse, bite == Griffure, enrage == Enrage
            //stanceAttack == bouton position attaque sans carte, stanceDefense == bouton position defense sans carte, stanceGrab == bouton position brise-garde sans carte
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
            //Fonction appelé avant de revenir au tour du joueur 1
            switchAction(player1action, player1, player2, tagsplayer1, tagsplayer2);
            switchAction(player2action, player2, player1, tagsplayer2, tagsplayer1);
            //On résout le chi-fu-mi stance = 1 == attaque, stance = 2 == défense, stance = 3 == grab

            Anim_player1.GetComponent<PlayerAnimationController>().handleAnim(player1.stance);
            Anim_player2.GetComponent<PlayerAnimationController>().handleAnim(player2.stance);
            if (player1.stance == 1 && player2.stance == 2)
            {
                if (tagsplayer2.Count > 0)
                    tagsplayer2.RemoveAt(tagsplayer2.Count - 1);
                if (player2.thornsup == true)
                {
                    player1.hp -= (int)Mathf.Round(player1.strenght * player1.strenghtcoef / 2);
                    Anim_player1.GetComponent<PlayerAnimationController>().FireHit();
                }
            }
            else if (player1.stance == 3 && player2.stance == 1 || player1.stance == 2 && player2.stance == 3)
            {
                if (tagsplayer2.Count > 0)
                    tagsplayer2.RemoveAt(tagsplayer2.Count - 1);
                player1.hp -= (int)(player2.strenght * player2.strenghtcoef);
                Anim_player1.GetComponent<PlayerAnimationController>().FireHit();
            }
            else if (player1.stance == 2 && player2.stance == 1)
            {
                if (tagsplayer1.Count > 0)
                    tagsplayer1.RemoveAt(tagsplayer1.Count - 1);
                if (player1.thornsup == true)
                {
                    player2.hp -= (int)Mathf.Round(player2.strenght * player2.strenghtcoef / 2);
                    Anim_player2.GetComponent<PlayerAnimationController>().FireHit();
                }
            }
            else if (player1.stance == 1 && player2.stance == 3 || player1.stance == 3 && player2.stance == 2)
            {
                if (tagsplayer1.Count > 0)
                    tagsplayer1.RemoveAt(tagsplayer1.Count - 1);
                player2.hp -= (int)(player1.strenght * player1.strenghtcoef);
                Anim_player2.GetComponent<PlayerAnimationController>().FireHit();
            }
            else if (player1.stance == 1 && player2.stance == 1 || player1.stance == 3 && player2.stance == 3)
            {
                player1.hp -= (int)(player2.strenght * player2.strenghtcoef);
                player2.hp -= (int)(player1.strenght * player1.strenghtcoef);
                Anim_player1.GetComponent<PlayerAnimationController>().FireHit();
                Anim_player2.GetComponent<PlayerAnimationController>().FireHit();
            }
            //La fonction pour update les barres de pv sera à appeler ici pour afficher les pv
            Debug.Log("J1 Hp : " + player1.hp + "\nJ2 Hp : " + player2.hp);
        }

        public void handleCard()
        {
            //Fonction appelé quand on clique sur la carte d'un joueur pour récupérer le nom de la carte, c'est le seul moment dans le tour d'un joueur où on connait sa carte (pour les animations)
            if (playerTurn == false)
                player1action = EventSystem.current.currentSelectedGameObject.name;
            else
                player2action = EventSystem.current.currentSelectedGameObject.name;
            Debug.Log(" Player Action J1 : " + player1action + "\nPlayer Action J2 : " + player2action);
        }

        public void handleNext()
        {
            //Fonction appelé quand on appuie sur le bouton Fin de tour (Change le joueur en cours et effectue la résolution avant le tour du joueur 1
            if (playerTurn == false)
            {
                //On passe au joueur 2
                Debug.Log("Turn 2 player");
                //On applique les status du joueur type faiblesse,ect... (elle sont dans playerClass)
                tagsplayer2 = player2.status(tagsplayer2);
                //On ajoute une carte dans la main du joueur en cours si en dessous de 5
                if (player2.hand.Count < 5) { player2.addCard(); }
                //On affiche les cartes du joueur en cours
                handObject.GetComponent<HandHandler>().DestroyHand();
                handObject.GetComponent<HandHandler>().InstantiateHand(player2.hand);
                this.playerTurn = true;

            }
            else if (playerTurn == true)
            {
                //On résout le tour précédent
                resolve();
                //Après la résolution on a l'endroit pour l'écran de victoire
                //if (player2.hp <= 0)
                //    victoryScreen(J1);
                //else if (player1.hp <= 0)
                //     victoryScreen(J2);
                Debug.Log("Turn 1 player");
                //On reset les stats des joueurs type force
                player1.resetStat();
                player2.resetStat();
                //On applique les status du joueur type faiblesse,ect... (elle sont dans playerClass)
                tagsplayer1 = player1.status(tagsplayer1);
                //On ajoute une carte dans la main du joueur en cours si en dessous de 5
                if (player1.hand.Count < 5) { player1.addCard(); }
                //On affiche les cartes du joueur en cours
                handObject.GetComponent<HandHandler>().DestroyHand();
                handObject.GetComponent<HandHandler>().InstantiateHand(player1.hand);
                playerTurn = false;
            }
        }
    }
}
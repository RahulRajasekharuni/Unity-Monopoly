using System;
using UnityEngine;
using System.Collections.Generic;

namespace Monopoloy
{
    //player class that stores the amount of cash each player has, their position on the board, dice rolls and the properties purchased.
    public class Player
    {
        private Vector3 PlayerPos = new Vector3(0,0,0);
        public Vector3 _playerpos
        {
            get { return PlayerPos; }
            set { PlayerPos = value; }
        }
        private float PlayerCash;
        public float _playercash
        {
            get{ return PlayerCash;}
            set{PlayerCash = value;}
        }
        public List<string> ProperyPurchased = new List<string>();
        public List<int> DiceResults = new List<int>();
        public Player(Vector3 Position)
        {
            Position = PlayerPos;
        }
    }
}

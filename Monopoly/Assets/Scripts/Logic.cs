using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

namespace Monopoloy
{
    public class Logic : MonoBehaviour
    {
        public GameObject PlayerOne;
        public GameObject PlayerTwo;
        public GameObject RedToken;
        public GameObject BlueToken;
        public Text LastRoll;
        public Text Turn;
        public Text OneCash;
        public Text TwoCash;
        TileData TD = new TileData();
        Player One = new Player(new Vector3(0,0,0));
        Player Two = new Player(new Vector3(0, 0, 0));
        private int TurnChecker = 0;
        private GameObject RedButton;

        //These arrays are used in conjuction with TurnChecker to cylce player turns.
        Player[] PlayerArray = new Player[2];
        int[] LocationArr = new int[2];
        int[] GoCounter = new int[2];
        GameObject[] PlayerTokens = new GameObject[2];
        GameObject[] PlayerPurchaseTokens = new GameObject[2];

        void Start()
        {
            TD.Locations();
            TD.BoardInfo();
            PlayerArray[0] = One;
            PlayerArray[1] = Two;
            //Set player initial stats and instantiate player game objects.
            PlayerArray[0]._playerpos = TD.BoardLocations[0];
            PlayerArray[0]._playercash = 1500;
            PlayerArray[1]._playerpos = TD.BoardLocations[0];
            PlayerArray[1]._playercash = 1500;
            RedButton = GameObject.Find("PlayerOne");
            PlayerTokens[0] = Instantiate(PlayerOne, TD.BoardLocations[0], Quaternion.identity) as GameObject;
            PlayerTokens[1] = Instantiate(PlayerTwo, TD.BoardLocations[0], Quaternion.identity) as GameObject;
            PlayerPurchaseTokens[0] = RedToken;
            PlayerPurchaseTokens[1] = BlueToken;
        }
        
        void Update()
        {
            OneCash.text = PlayerArray[0]._playercash.ToString();
            TwoCash.text = PlayerArray[1]._playercash.ToString();
            //Stops game after any of the players have been around the board three times
            if (GoCounter[0] == 3 | GoCounter[1] == 3)
            {
                RedButton.GetComponent<Button>().interactable = false;
            }
        }


       public void PlayerOneButton()
        {
            int Diceroll = UnityEngine.Random.Range(2, 13);//Used to randomize dice roll between 2-12.
            int Purchaser = UnityEngine.Random.Range(1, 3);//50% chance player will buy a purchasable property.
            int BoardChecker = 0;
            int BoardChecker2 = 0;
            PlayerArray[TurnChecker].DiceResults.Add(Diceroll);
            LocationArr[TurnChecker] += Diceroll;//Used to move player
            LastRoll.text = Diceroll.ToString();
            //If statement used to check if player is near end of the board.
            //Remaining moves between current spot and GO is calculated. 
            //Next the amount of spots to move after GO is calucated.
            if (LocationArr[TurnChecker] > 39)
            {
                BoardChecker = LocationArr[TurnChecker] - Diceroll;
                BoardChecker2 = 40 - BoardChecker;
                Diceroll = Diceroll - BoardChecker2;
                LocationArr[TurnChecker] = Diceroll;
                PlayerArray[TurnChecker]._playercash += 200;//+200 cash for passing GO.
                GoCounter[TurnChecker]++;
            }
            //Player and player token are moved on the board.
            PlayerArray[TurnChecker]._playerpos = TD.BoardLocations[LocationArr[TurnChecker]];
            PlayerTokens[TurnChecker].transform.position = TD.BoardLocations[LocationArr[TurnChecker]];
            //50% chance to buy a purchasable property if it's not owned and the player can afford it.
            if (Purchaser == 1 && TD.TileInfo[LocationArr[TurnChecker]].Owned == false && TD.TileInfo[LocationArr[TurnChecker]].Purchasable == true && One._playercash > TD.TileInfo[LocationArr[TurnChecker]].price)
            {
                Instantiate(PlayerPurchaseTokens[TurnChecker], TD.BoardLocations[LocationArr[TurnChecker]], Quaternion.identity);
                PlayerArray[TurnChecker]._playercash -= TD.TileInfo[LocationArr[TurnChecker]].price;
                TD.TileInfo[LocationArr[TurnChecker]].Owned = true;
                PlayerArray[TurnChecker].PropertyPurchased.Add(TD.TileInfo[LocationArr[TurnChecker]].Name);
            }
            //These two if statements are used to check if player lands on tax tile.
            if (LocationArr[TurnChecker] == 4 ) 
            {
                PlayerArray[TurnChecker]._playercash -= 200;
            }
            if (LocationArr[TurnChecker] == 38)
            {
                PlayerArray[TurnChecker]._playercash -= 100;
            }
            //Reset Turnchecker if its over number of players.
            TurnChecker += 1;
            if (TurnChecker > 1)
            {
                TurnChecker = 0;
            }
            //Change button text to match turns.
            if (TurnChecker == 0)
            {
                Turn.text = "Player One";
            }
            else if (TurnChecker == 1)
            {
                Turn.text = "Player Two";
            }
        }
      
        //Write function outputs player one and two stats to txt file when Output button is pressed.
        public void Write()
        {
            StreamWriter Output = new System.IO.StreamWriter("output.txt");
            Output.WriteLine("Player One\r\n");
            Output.WriteLine("Dice Rolls");
            Output.WriteLine("--------------------");
            foreach (int line in PlayerArray[0].DiceResults)
            {
                Output.WriteLine(line);
            }
            Output.WriteLine("\r\nProperties Purchased");
            Output.WriteLine("--------------------");
            foreach (string line in PlayerArray[0].PropertyPurchased)
            {
                Output.WriteLine(line);
            }
            Output.WriteLine("\r\nCash Remaining");
            Output.WriteLine("--------------------");
            Output.WriteLine(PlayerArray[0]._playercash);

            Output.WriteLine("\r\nPlayer Two\r\n");
            Output.WriteLine("Dice Rolls");
            Output.WriteLine("--------------------");
            foreach (int line in PlayerArray[1].DiceResults)
            {
                Output.WriteLine(line);
            }
            Output.WriteLine("\r\nProperties Purchased");
            Output.WriteLine("--------------------");
            foreach (string line in PlayerArray[1].PropertyPurchased)
            {
                Output.WriteLine(line);
            }
            Output.WriteLine("\r\nCash Remaining");
            Output.WriteLine("--------------------");
            Output.WriteLine(PlayerArray[1]._playercash);
            Output.Close();
        }
    }
}

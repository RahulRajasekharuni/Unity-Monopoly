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
        public Text OneLastRoll;
        public Text TwoLastRoll;
        public Text OneCash;
        public Text TwoCash;
        TileData TD = new TileData();
        Player One = new Player(new Vector3(0,0,0));
        Player Two = new Player(new Vector3(0, 0, 0));
        private int OneLocation = 0;//Used to increment the BoardLocations array.
        private int TwoLocation = 0;
        private int RedGoCounter = 0;//Used to check how many times a player has been around the board.
        private int BlueGoCounter = 0;
        private GameObject Red = new GameObject();
        private GameObject Blue = new GameObject();
        private GameObject RedButton;
        private GameObject BlueButton;

        void Start()
        {
            TD.Locations();
            TD.BoardInfo();
            //Set player initial stats and instantiate player game objects.
            One._playerpos = TD.BoardLocations[0];
            One._playercash = 1500;
            Two._playerpos = TD.BoardLocations[0];
            Two._playercash = 1500;
            RedButton = GameObject.Find("PlayerOne");
            BlueButton = GameObject.Find("PlayerTwo");
            BlueButton.GetComponent<Button>().interactable = false;
            Red = Instantiate(PlayerOne, TD.BoardLocations[0], Quaternion.identity) as GameObject;
            Blue = Instantiate(PlayerTwo, TD.BoardLocations[0], Quaternion.identity) as GameObject;
           
        }
        
        void Update()
        {
            //Stops game after both players have been around the board twice.
          if (RedGoCounter == 2 && BlueGoCounter ==2)
            {
                BlueButton.GetComponent<Button>().interactable = false;
                RedButton.GetComponent<Button>().interactable = false;
            }
        }


       public void PlayerOneButton()
        {
            int Diceroll = UnityEngine.Random.Range(2, 13);//Used to randomize dice roll between 2-12.
            int Purchaser = UnityEngine.Random.Range(1, 3);//50% chance player will buy a purchasable property.
            int BoardChecker = 0;
            int BoardChecker2 = 0;
            One.DiceResults.Add(Diceroll);
            OneLocation += Diceroll;//Used to move player
            OneLastRoll.text = Diceroll.ToString();
            //If statement used to check if player is near end of the board.
            //Remaining moves between current spot and GO is calculated. 
            //Next the amount of spots to move after GO is calucated.
            if (OneLocation > 39)
            {
                BoardChecker = OneLocation - Diceroll;
                BoardChecker2 = 40 - BoardChecker;
                Diceroll = Diceroll - BoardChecker2;
                OneLocation = Diceroll;
                One._playercash += 200;//+200 cash for passing GO.
                RedGoCounter++;
            }
            //Player and player token are moved on the board.
            One._playerpos = TD.BoardLocations[OneLocation];
            Red.transform.position = TD.BoardLocations[OneLocation];
            //50% chance to buy a purchasable property if it's not owned and the player can afford it.
            if (Purchaser == 1 && TD.TileInfo[OneLocation].Owned == false && TD.TileInfo[OneLocation].Purchasable == true && One._playercash > TD.TileInfo[OneLocation].price)
            {
                Instantiate(RedToken, TD.BoardLocations[OneLocation], Quaternion.identity);
                One._playercash -= TD.TileInfo[OneLocation].price;
                TD.TileInfo[OneLocation].Owned = true;
                One.ProperyPurchased.Add(TD.TileInfo[OneLocation].Name);
            }
            //These two if statements are used to check if player lands on tax tile.
            if (OneLocation == 4 ) 
            {
                One._playercash -= 200;
            }
            if (OneLocation == 38)
            {
                One._playercash -= 100;
            }
            //Alternate button interactability to represent turns.
            RedButton.GetComponent<Button>().interactable = false;
            BlueButton.GetComponent<Button>().interactable = true;
            OneCash.text = One._playercash.ToString();
        }
       public void PlayerTwoButton()
        {
            int Diceroll = UnityEngine.Random.Range(2, 13);//Used to randomize dice roll between 2-12.
            int Purchaser = UnityEngine.Random.Range(1, 3);//50% chance player will buy a purchasable property.
            int BoardChecker = 0;
            int BoardChecker2 = 0;
            Two.DiceResults.Add(Diceroll);
            TwoLocation += Diceroll;//Used to move player
            TwoLastRoll.text = Diceroll.ToString();
            //If statement used to check if player is near end of the board.
            //Remaining moves between current spot and GO is calculated. 
            //Next the amount of spots to move after GO is calucated.
            if (TwoLocation > 39)
            {
                BoardChecker = TwoLocation - Diceroll;
                BoardChecker2 = 40 - BoardChecker;
                Diceroll = Diceroll - BoardChecker2;
                TwoLocation = Diceroll;
                Two._playercash += 200;//+200 cash for passing GO.
                BlueGoCounter++;
            }
            //Player and player token are moved on the board.
            Two._playerpos = TD.BoardLocations[OneLocation];
            Blue.transform.position = TD.BoardLocations[TwoLocation];
            //50% chance to buy a purchasable property if it's not owned and the player can afford it.
            if (Purchaser == 1 && TD.TileInfo[TwoLocation].Owned == false && TD.TileInfo[TwoLocation].Purchasable == true && Two._playercash > TD.TileInfo[TwoLocation].price)
            {
                Instantiate(BlueToken, TD.BoardLocations[TwoLocation], Quaternion.identity);
                Two._playercash -= TD.TileInfo[TwoLocation].price;
                TD.TileInfo[TwoLocation].Owned = true;
                Two.ProperyPurchased.Add(TD.TileInfo[TwoLocation].Name);
            }
            //These two if statements are used to check if player lands on tax tile.
            if (TwoLocation == 4)
            {
                Two._playercash -= 200;
            }
            if (TwoLocation == 38)
            {
                Two._playercash -= 100;
            }
            //Alternate button interactability to represent turns.
            RedButton.GetComponent<Button>().interactable = true;
            BlueButton.GetComponent<Button>().interactable = false;
            TwoCash.text = Two._playercash.ToString();
        }
        //Write function outputs player one and two stats to txt file when Output button is pressed.
        public void Write()
        {
            StreamWriter Output = new System.IO.StreamWriter("output.txt");
            Output.WriteLine("Player One\r\n");
            Output.WriteLine("Dice Rolls");
            Output.WriteLine("--------------------");
            foreach (int line in One.DiceResults)
            {
                Output.WriteLine(line);
            }
            Output.WriteLine("\r\nProperties Purchased");
            Output.WriteLine("--------------------");
            foreach (string line in One.ProperyPurchased)
            {
                Output.WriteLine(line);
            }
            Output.WriteLine("\r\nCash Remaining");
            Output.WriteLine("--------------------");
            Output.WriteLine(One._playercash);

            Output.WriteLine("\r\nPlayer Two\r\n");
            Output.WriteLine("Dice Rolls");
            Output.WriteLine("--------------------");
            foreach (int line in Two.DiceResults)
            {
                Output.WriteLine(line);
            }
            Output.WriteLine("\r\nProperties Purchased");
            Output.WriteLine("--------------------");
            foreach (string line in Two.ProperyPurchased)
            {
                Output.WriteLine(line);
            }
            Output.WriteLine("\r\nCash Remaining");
            Output.WriteLine("--------------------");
            Output.WriteLine(Two._playercash);
            Output.Close();
        }
    }
}

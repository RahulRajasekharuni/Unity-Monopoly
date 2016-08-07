using System;
using UnityEngine;
using System.Collections;

namespace Monopoloy
{
    public class TileData
    {
        public Vector3[] BoardLocations = new Vector3[40];
        //Grouping of all variables needed to differentiate each tile.
        public struct BoardDetails
        {
            public float price;
            public String Name;
            public bool Owned;
            public bool Purchasable;
        }
        //Struct Array to store each tile's data seperately.
        public BoardDetails[] TileInfo = new BoardDetails[40];

        //Vector3 location of each tile on the gameboard stored into an array of vector3. 
        public void Locations()
        {
            BoardLocations[0] = new Vector3(4.319f, 0, -4.346f);
            BoardLocations[1] = new Vector3(3.257f, 0, -4.346f);
            BoardLocations[2] = new Vector3(2.36f, 0, -4.346f);
            BoardLocations[3] = new Vector3(1.54f, 0, -4.346f);
            BoardLocations[4] = new Vector3(0.77f, 0, -4.346f);
            BoardLocations[5] = new Vector3(-0.08f, 0, -4.346f);
            BoardLocations[6] = new Vector3(-0.83f, 0, -4.346f);
            BoardLocations[7] = new Vector3(-1.65f, 0, -4.346f);
            BoardLocations[8] = new Vector3(-2.408f, 0, -4.346f);
            BoardLocations[9] = new Vector3(-3.265f, 0, -4.346f);
            BoardLocations[10] = new Vector3(-4.402f, 0, -4.346f);
            BoardLocations[11] = new Vector3(-4.402f, 0, -3.241f);
            BoardLocations[12] = new Vector3(-4.402f, 0, -2.568f);
            BoardLocations[13] = new Vector3(-4.402f, 0, -1.653f);
            BoardLocations[14] = new Vector3(-4.402f, 0, -0.788f);
            BoardLocations[15] = new Vector3(-4.402f, 0, -0.078f);
            BoardLocations[16] = new Vector3(-4.402f, 0, 0.836f);
            BoardLocations[17] = new Vector3(-4.402f, 0, 1.541f);
            BoardLocations[18] = new Vector3(-4.402f, 0, 2.499f);
            BoardLocations[19] = new Vector3(-4.402f, 0, 3.331f);
            BoardLocations[20] = new Vector3(-4.402f, 0, 4.388f);
            BoardLocations[21] = new Vector3(-3.198f, 0, 4.388f);
            BoardLocations[22] = new Vector3(-2.362f, 0, 4.388f);
            BoardLocations[23] = new Vector3(-1.517f, 0, 4.388f);
            BoardLocations[24] = new Vector3(-0.735f, 0, 4.388f);
            BoardLocations[25] = new Vector3(0.117f, 0, 4.388f);
            BoardLocations[26] = new Vector3(0.897f, 0, 4.388f);
            BoardLocations[27] = new Vector3(1.775f, 0, 4.388f);
            BoardLocations[28] = new Vector3(2.521f, 0, 4.388f);
            BoardLocations[29] = new Vector3(3.414f, 0, 4.388f);
            BoardLocations[30] = new Vector3(4.451f, 0, 4.388f);
            BoardLocations[31] = new Vector3(4.451f, 0, 3.272f);
            BoardLocations[32] = new Vector3(4.451f, 0, 2.294f);
            BoardLocations[33] = new Vector3(4.451f, 0, 1.538f);
            BoardLocations[34] = new Vector3(4.451f, 0, 0.641f);
            BoardLocations[35] = new Vector3(4.451f, 0, -0.062f);
            BoardLocations[36] = new Vector3(4.451f, 0, -0.958f);
            BoardLocations[37] = new Vector3(4.451f, 0, -1.84f);
            BoardLocations[38] = new Vector3(4.451f, 0, -2.64f);
            BoardLocations[39] = new Vector3(4.451f, 0, -3.41f);
        }
        public void BoardInfo()
        {
            TileInfo[0].price = 0;
            TileInfo[0].Name = "GO";

            TileInfo[1].price = 60;
            TileInfo[1].Name = "Old Kent Road";
            TileInfo[1].Purchasable = true;

            TileInfo[2].price = 0;
            TileInfo[2].Name = "Community Chest";

            TileInfo[3].price = 60;
            TileInfo[3].Name = "White Chapel Road";
            TileInfo[3].Purchasable = true;

            TileInfo[4].price = 200;
            TileInfo[4].Name = "Income Tax";

            TileInfo[5].price = 200;
            TileInfo[5].Name = "King's Cross Station";
            TileInfo[5].Purchasable = true;

            TileInfo[6].price = 100;
            TileInfo[6].Name = "The Angel Islington";
            TileInfo[6].Purchasable = true;

            TileInfo[7].price = 0;
            TileInfo[7].Name = "Chance";

            TileInfo[8].price = 100;
            TileInfo[8].Name = "Euston Road";
            TileInfo[8].Purchasable = true;

            TileInfo[9].price = 120;
            TileInfo[9].Name = "Pentonville Road";
            TileInfo[9].Purchasable = true;

            TileInfo[10].price = 0;
            TileInfo[10].Name = "Euston Road";

            TileInfo[11].price = 140;
            TileInfo[11].Name = "Pall Mall";
            TileInfo[11].Purchasable = true;

            TileInfo[12].price = 150;
            TileInfo[12].Name = "Electric Company";
            TileInfo[12].Purchasable = true;

            TileInfo[13].price = 140;
            TileInfo[13].Name = "White Hall";
            TileInfo[13].Purchasable = true;

            TileInfo[14].price = 140;
            TileInfo[14].Name = "Northumrld Avenue";
            TileInfo[14].Purchasable = true;

            TileInfo[15].price = 140;
            TileInfo[15].Name = "MaryleBone Station";
            TileInfo[15].Purchasable = true;

            TileInfo[16].price = 180;
            TileInfo[16].Name = "Bow Street";
            TileInfo[16].Purchasable = true;

            TileInfo[17].price = 0;
            TileInfo[17].Name = "Community Chest";

            TileInfo[18].price = 180;
            TileInfo[18].Name = "Marlborough Street";
            TileInfo[18].Purchasable = true;

            TileInfo[19].price = 200;
            TileInfo[19].Name = "Vine Street";
            TileInfo[19].Purchasable = true;

            TileInfo[20].price = 0;
            TileInfo[20].Name = "Free Parking";

            TileInfo[21].price = 220;
            TileInfo[21].Name = "Strand";
            TileInfo[21].Purchasable = true;

            TileInfo[22].price = 0;
            TileInfo[22].Name = "Chance";

            TileInfo[23].price = 220;
            TileInfo[23].Name = "Fleet Street";
            TileInfo[23].Purchasable = true;

            TileInfo[24].price = 240;
            TileInfo[24].Name = "Trafalgar Square";
            TileInfo[24].Purchasable = true;

            TileInfo[25].price = 200;
            TileInfo[25].Name = "Fenchurch St. Station";
            TileInfo[25].Purchasable = true;

            TileInfo[26].price = 260;
            TileInfo[26].Name = "Leicester Square";
            TileInfo[26].Purchasable = true;

            TileInfo[27].price = 260;
            TileInfo[27].Name = "Conventry Street";
            TileInfo[27].Purchasable = true;

            TileInfo[28].price = 150;
            TileInfo[28].Name = "Water Works";
            TileInfo[28].Purchasable = true;

            TileInfo[29].price = 280;
            TileInfo[29].Name = "Piccadilly";
            TileInfo[29].Purchasable = true;

            TileInfo[30].price = 0;
            TileInfo[30].Name = "Goto Jail";

            TileInfo[31].price = 300;
            TileInfo[31].Name = "Regent Street";
            TileInfo[31].Purchasable = true;

            TileInfo[32].price = 300;
            TileInfo[32].Name = "Oxford Street";
            TileInfo[32].Purchasable = true;

            TileInfo[33].price = 0;
            TileInfo[33].Name = "Community Chest";

            TileInfo[34].price = 320;
            TileInfo[34].Name = "Bond Street";
            TileInfo[34].Purchasable = true;

            TileInfo[35].price = 200;
            TileInfo[35].Name = "Liverpool St. Station";
            TileInfo[35].Purchasable = true;

            TileInfo[36].price = 0;
            TileInfo[36].Name = "Chance";
            
            TileInfo[37].price = 350;
            TileInfo[37].Name = "Park Lane";
            TileInfo[37].Purchasable = true;

            TileInfo[38].price = 100;
            TileInfo[38].Name = "Super Tax";

            TileInfo[39].price = 400;
            TileInfo[39].Name = "Mayfair";
            TileInfo[39].Purchasable = true;
        }
    }
}

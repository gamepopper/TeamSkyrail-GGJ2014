﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Map : MonoBehaviour {
	float worldOpinion = 0.5f;				//IF REACHES 0, THEN EL PRESEDENTE LOSES


    protected int turn;
    
    protected Player[] players;
    protected int curPlayer;

	public int sizeX;
	public int sizeY;
    public int levelFactor;		// Set to 8 as each level tile is 8 by 8 tiles.

	private LevelTile[,] levelTiles;

	List<Unit> unitList = new List<Unit>();

    public void EndTurn() {
        curPlayer++;
        if(curPlayer > 1) {
            curPlayer = 0;
        }
    }

    void Awake() {
        players = new Player[2];
        players[0] = new Player();
        players[1] = new Player();
    }

    public Player GetCurPlayer() {
        return this.players[this.curPlayer];
    }

    // Use this for initialization
    void Start()
    {
		FileInfo levelFile = null;
		StreamReader reader = null;

		levelTiles = new LevelTile[sizeX/levelFactor, sizeY/levelFactor];

		levelFile = new FileInfo (Application.dataPath + "/level.txt");

		if (levelFile != null && levelFile.Exists)
		{
			reader = levelFile.OpenText ();
		}

		int x = 0;
		int y = 0;

        if (reader != null)
        {
            string txt = reader.ReadLine();
            while (txt != null)
            {
                for (x = 0; x < txt.Length; x++)
                {
                    if (txt.Substring(x, 1).Equals("A"))
                    {
                        levelTiles[x, y] = new OrbTile();
                    }
                    else if (txt.Substring(x, 1).Equals("B"))
                    {
                        levelTiles[x, y] = new BuildingTile();
                    }

					GenerateLevelTile(levelTiles[x,y].getObj(), x, y);
                }

                y++;
                txt = reader.ReadLine();
            }
        }
        else
        {

        }
	}

	void SetTile(LevelTile levelTile, int x, int y)
	{
		levelTiles[x/levelFactor, y/levelFactor] = levelTile;
		
		// Need more to handel object swapping.
	}

    // Update is called once per frame
    void Update()
    {

	}

	int findIndex(Unit unit) {
		int curPos = 0;
		foreach(Unit curUnit in unitList) {
			if(curUnit.GetInstanceID() == unit.GetInstanceID()) {
				return curPos;
			}
			curPos++;
		}
		return -1;
	}

	void Register(Unit unit) {
		if(findIndex(unit) == -1) {
			unitList.Add(unit);
		}
	}

	void Unregister(Unit unit) {
        
		int curPos = 0;
		foreach(Unit x in unitList) {
			if(x.GetInstanceID() == unit.GetInstanceID()) {
				unitList.RemoveAt(curPos);
				return;
			}
			curPos++;
		}
	}

	public void GenerateLevelTile(Object obj, int levelX, int levelY)
	{
		//WORK OUT WHERE ON THE SCREEN TO PLACE THE LEVEL TILE
		Vector2 pos = this.GetPositionFromTile(levelX*levelFactor,levelY*levelFactor);
		//GET BOUNDS
		float top =  this.renderer.bounds.center.x - (this.renderer.bounds.extents.x);
		float left =  this.renderer.bounds.center.y + (this.renderer.bounds.extents.y);
		
		//Instantiate(obj, new Vector3(top + pos.x,left - pos.y, 0), Quaternion.AngleAxis(90, Vector3.left));
	}

	public bool PlaceUnit(Unit unit, int xTile, int yTile) {
		//DERMINE BY 
        //Debug.Log("Attempting to position unit @ " + xTile + ", " + yTile);
		//if(!this.tiles[xTile,yTile].canPlaceHere(unit.gameObject)) {
		//	return false;
		//}

		//WORK OUT WHERE ON THE SCREEN TO PLACE THE UNIT
		Vector2 pos = this.GetPositionFromTile(xTile,yTile);
		//GET BOUNDS
		float top =  this.renderer.bounds.center.x - (this.renderer.bounds.extents.x);
		float left =  this.renderer.bounds.center.y + (this.renderer.bounds.extents.y);

		unit.transform.position = new Vector2(top + pos.x,left - pos.y);

		return true;
	}

	Vector2 GetPositionFromTile(int xPos, int yPos) {
		float tileWidth, tileHeight;
		tileWidth = (this.renderer.bounds.extents.x * 2) / sizeX;
		tileHeight = (this.renderer.bounds.extents.y * 2) / sizeY;

		return new Vector2(tileWidth * xPos,tileHeight * yPos);
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Map : MonoBehaviour {
	float worldOpinion = 0.5f;				//IF REACHES 0, THEN EL PRESEDENTE LOSES

	public int sizeX;
	public int sizeY;
    public float tileSpacing;



	private Tile[,] tiles;

	List<Unit> unitList = new List<Unit>();

    void Awake() {

    }

    // Use this for initialization
    void Start()
    {
		FileInfo levelFile = null;
		StreamReader reader = null;

		tiles = new Tile[sizeX, sizeY];

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
                        tiles[x, y] = new OrbTile();
                    }
                    else if (txt.Substring(x, 1).Equals("B"))
                    {
                        tiles[x, y] = new BuildingTile();
                    }

                    Instantiate(tiles[x, y].getObj(), new Vector3(x * tileSpacing, -(y * tileSpacing), -3), Quaternion.AngleAxis(90, Vector3.left));
                }

                y++;
                txt = reader.ReadLine();
            }
        }
        else
        {

        }
	}

    void SetTile(Tile tile, int x, int y) {
        tiles[x, y] = tile;
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

	public bool PlaceUnit(Unit unit, int xTile, int yTile) {
		//DERMINE BY 
        //Debug.Log("Attempting to position unit @ " + xTile + ", " + yTile);
		if(!this.tiles[xTile,yTile].canPlaceHere(unit.gameObject)) {
			return false;
		}

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

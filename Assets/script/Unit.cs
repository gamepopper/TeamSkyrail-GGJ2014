using UnityEngine;
using System.Collections;



public class Unit : MonoBehaviour {

    public Player owner;


	public Map map;

	public int xPos = 0;
	public int yPos = 0;
	public int spriteRow;

	int currentHp;
	public int maxHp = 100;
    public int range;                    //RANGE OF EACH UNIT
    public int speed;                    //HOW MANY TURNS THIS UNIT CAN MOVE PER TURN
    public int facing;                   //THE DIRECTION THE UNIT IS FACING
    private int _turnsLeft;              //AMOUNT OF TURNS LEFT

    void setupSprites()
    {
        int rowOffset = spriteRow * 6;

        spriteAnimation anim = GetComponent<spriteAnimation>();
        anim.resourceName = "sprites";

        anim.animations = new AnimationFrames[4];
        anim.animations[0] = new AnimationFrames();
        anim.animations[0].framesPerSecond = 0;
        anim.animations[0].frameList = new int[1];              //ANIMATION 0 = IDLE
        anim.animations[0].frameList[0] = rowOffset + 0;

        anim.animations[1] = new AnimationFrames();
        anim.animations[1].framesPerSecond = 2f;
        anim.animations[1].frameList = new int[4];              //ANIMATION 1 = WALK
        anim.animations[1].frameList[0] = rowOffset + 0;
        anim.animations[1].frameList[1] = rowOffset + 2;
        anim.animations[1].frameList[2] = rowOffset + 0;
        anim.animations[1].frameList[3] = rowOffset + 3;

        anim.animations[2] = new AnimationFrames();
        anim.animations[2].framesPerSecond = 0.5f;
        anim.animations[2].frameList = new int[2];              //ANIMATION 2 = FIRE
        anim.animations[2].frameList[0] = rowOffset + 0;
        anim.animations[2].frameList[1] = rowOffset + 1;

        anim.animations[3] = new AnimationFrames();
        anim.animations[3].framesPerSecond = 2f;
        anim.animations[3].frameList = new int[3];              //ANIMATION 3 = DIE
        anim.animations[3].frameList[0] = rowOffset + 0;
        anim.animations[3].frameList[1] = rowOffset + 0;
        anim.animations[3].frameList[2] = rowOffset + 0;

        Debug.Log("Attempting to play animations in sprite");
        anim.setAnimation(1);
        anim.PlayAnimations();


        
    }

    void Damage(Unit target) {

    }

    bool MoveTo(int x, int y) {
        int xd = x - this.xPos;
        int yd = y - this.yPos;

        float distance = Mathf.Sqrt(xd * xd + yd * yd);
        if (distance > this.speed) {
            return false;
        }
        return true;
    }

	// Use this for initialization
	void Start () {
        setupSprites();
		currentHp = this.maxHp;
	}
	
	// Update is called once per frame
	void Update () {
		map.PlaceUnit(this,xPos,yPos);
	}

	void Interact(Unit otherUnit) {

	}
}

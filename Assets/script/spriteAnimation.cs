using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationFrames {
    public int[] frameList;							//CONTAINS THE OFFSET TO USE FOR EACH FRAME OF ANIMATION
    private int _curFrame;							//STORES THE CURRENTLY ACTIVE FRAME
    public float framesPerSecond;

    // Use this for initialization
    public AnimationFrames()
    {
        this._curFrame = 0;
    }

    public void nextFrame()
    {
        ++this._curFrame;
        if (this._curFrame >= frameList.Length)
        {
            this._curFrame = 0;
        }

    }

    public void ResetFrame()
    {
        this._curFrame = 0;
    }

    public void SetFrame(int frame)
    {
        this._curFrame = frame - 1;
        nextFrame();        
    }

    public int GetFrame()
    {
        return frameList[this._curFrame];
    }
}

    
public class spriteAnimation : MonoBehaviour {
	public bool isPlaying = false;
	//public int[] frameList;							//CONTAINS THE OFFSET TO USE FOR EACH FRAME OF ANIMATION
	//public float framesPerSecond = 0;				//HOW LONG IT TAKES FOR EACH FRAME TO MOVE TO THE NEXT FRAME
	public string resourceName;
	private float _t;								//STORES THE CURRENT TIME TAKEN
	private int _curFrame;							//STORES THE CURRENTLY ACTIVE FRAME

    public int startAnimation;
    private int _currentAnimation;

    public AnimationFrames[] animations;

	private Sprite[] allSprites;

	void Awake() {
		this.allSprites = Resources.LoadAll<Sprite>(resourceName);
	}

	// Use this for initialization
	void Start () {
		this._t = 0;
		this.Awake();
	}

    public void setAnimation(int animation, int startFrame = 0) {
        this.animations[_currentAnimation].ResetFrame();
        this._currentAnimation = animation;
        Debug.Log("Animation changed to #" + this._currentAnimation);
    }

    public void PlayAnimations()
    {
        if (this.animations.Length > 0)
        {
            this._t = 0;
            this.isPlaying = true;
            Debug.Log("Starting to play animation #" + this._currentAnimation);
        }
    }

	void updateFrame() {
        Debug.Log("Updating frame of animation #" + this._currentAnimation);
		//RENDER FRAME
        if (this.animations.Length == 0)
        {
            GetComponent<SpriteRenderer>().sprite = this.allSprites[0];
            this.isPlaying = false;
            return;
        }
		GetComponent<SpriteRenderer>().sprite = this.allSprites[this.animations[this._currentAnimation].GetFrame()];
        Debug.Log("Updating frame of animation #" + this._currentAnimation + " >>> " + this.animations[this._currentAnimation].GetFrame());
        this.animations[_currentAnimation].nextFrame();
	}

	// Update is called once per frame
	void Update () {
        //Debug.Log("Doing animation stuffs for #" + this._currentAnimation + "(FPS: " + this.animations[this._currentAnimation].framesPerSecond + ")");
		if(this.isPlaying == true) {
            //Debug.Log("Doing animation stuffs for #" + this._currentAnimation + "(FPS: " + this.animations[this._currentAnimation].framesPerSecond + ")");
			this._t += Time.deltaTime * this.animations[this._currentAnimation].framesPerSecond;
			if(this._t > 1) {
				this.updateFrame();
				this._t = 0;
			}
		}
	}
}

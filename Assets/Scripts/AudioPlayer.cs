using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {

    private bool shoot; //True if bird left catapult, false if still in catapult.
    private bool collided; //True if it hit a damager, false if it hasn't.
    private MouseHandler mHand; //Mousehandler scrip
    

    /*
    //AUDIO SOURCES//
                  */
    [SerializeField]
    private AudioSource _audio0; //Audio source for the catapult draw.
    [SerializeField]
    private AudioSource _audio1; //Audio source for the catapult shoot.
    [SerializeField]
    private AudioSource _audio2; //Audio source for the rock collision.

    /*
    //ARRAYS//
           */
    [SerializeField]
    private AudioClip[] SlingshotShoot; //Collection of the shoot audio clips.
    private AudioClip SlingShootSound; //Random audio clip chosen in start.

    [SerializeField]
    private AudioClip[] RockCollision; //Collection of the RockBlock Collision audio clips.
    private AudioClip RockColl; //Random audio clip chosen in start.

    //Slingshot Sounds
    [SerializeField]
    private AudioClip SlingshotHold; //Sound of the drawing of the catapult.

    //Rock Sounds
    [SerializeField]
    private AudioClip RockDamage1, RockDamage2, RockDestroyed1, RockDestroyed2;

    void Start () {
        //Picks a random audio clip from a selection of clips to play later in the script.
        RockColl = RockCollision[Random.Range(0, RockCollision.Length)];
        SlingShootSound = SlingshotShoot[Random.Range(0,SlingshotShoot.Length)];

        shoot = false; //Bird is in catapult, so making sure shoot is false.
        collided = false; //Bird hasn't collided yet, making sure collided is false.
        mHand = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseHandler>(); //Picks up the Mouse Handler.
    }
	
	void Update () {
        //Catapult draw
	    if(mHand.hasTarget && !_audio0.isPlaying && Input.GetKeyDown(KeyCode.Mouse0) && mHand.hit.transform.tag == "Player")
        {
            _audio0.PlayOneShot(SlingshotHold, 0.1F);//Plays the drawing sound.
            shoot = true; //Bird has left the catapult.
        }
        //Catapult shoot
        if (shoot && Input.GetKeyUp(KeyCode.Mouse0))//Makes sure shoot is true AND waits for you to release the bird.
        {
            Debug.Log(SlingShootSound);
            _audio0.Stop();//Stops the playing of the drawing sound.
            _audio1.PlayOneShot(SlingShootSound, 0.1F);//Plays the shooting sound.
            shoot = false;//Shooting is false again, this makes sure you cannot play this sound again randomly on click-release.
        }
        //Rock Collision
        if (collided) //Work in progress. Needs condition set to true with bird colliding against stone.
        {
          _audio2.PlayOneShot(RockColl, 0.1F);
            collided = false; //Set condition to false again so sound doesn't replay.
        }



    }

}

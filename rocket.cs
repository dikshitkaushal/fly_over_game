using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class rocket : MonoBehaviour {
    bool collisionareenabled = true;
    bool istrans = false;
    Rigidbody rigidbody;
    AudioSource audiosource;
    [SerializeField] float  rcsthrust =100f;
    [SerializeField] float thrustup =50f;
    [SerializeField] AudioClip audio;
    [SerializeField] AudioClip deadaudio;
    [SerializeField] AudioClip wonaudio;
    [SerializeField] AudioClip completed;
    [SerializeField] ParticleSystem audioparticle;
    [SerializeField] ParticleSystem deadaudioparticle;
    [SerializeField] ParticleSystem wonaudioparticle;
    enum State { alive,dying,transcending};
    State state = State.alive;
    // Use this for initialization
    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void Update () {
        if(!istrans)
        {
            rotate();
            thrust();
        }
        if (Debug.isDebugBuild)
        {
            inputdebugmethod();
        }
    }

    private void inputdebugmethod()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            loadnextlevel();
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            collisionareenabled = !collisionareenabled;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (istrans || !collisionareenabled)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "friendly":
                {
                    istrans = true;
                    audiosource.Stop();
                    audiosource.PlayOneShot(deadaudio);
                    deadaudioparticle.Play();
                    print("you are dead");
                    rigidbody.freezeRotation = false;
                    Invoke("again",1f);
                    break;
                }
            case "endgame":
                {
                    istrans = true;
                    audiosource.Stop();
                    wongame();
                    print("you won");
                    Invoke("loadnextlevel", 1f);
                    break;
                }
            default:
                {
                    print("you are alive");
                    break;
                }
        }
    }

    private void wongame()
    {
        int currentscreenindex = SceneManager.GetActiveScene().buildIndex;
        int loadindex = currentscreenindex + 1;
        if (loadindex == 5)
        {
            wonaudioparticle.Play();
            audiosource.PlayOneShot(completed);

        }
        else
        {
            wonaudioparticle.Play();
            audiosource.PlayOneShot(wonaudio);
        }
    }
   /* public void playagain()
    {
        wonaudioparticle.Play();
        audiosource.PlayOneShot(completed);
    }*/
    private void loadnextlevel()
    {
        int currentscreenindex = SceneManager.GetActiveScene().buildIndex;
        int loadindex = currentscreenindex + 1;
        SceneManager.LoadScene(loadindex);
       // check();
    }

    /*private void check()
    {
        if(i>4)00000000000011212012
        {
            i = 1;
        }
        else
        {
            return;
        }
    }*/

    private void again()
    {
        
        SceneManager.LoadScene(0);
    }

    private void thrust()
    {
        float Force = thrustup * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            NewMethod();
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody.AddRelativeForce(-Vector3.up*thrustup);
            if (!audiosource.isPlaying)
            {
                audiosource.Play();
            }
        }
        else
        {
            audiosource.Stop();
            audioparticle.Stop();
        }
    }

    private void NewMethod()
    {
        rigidbody.AddRelativeForce(Vector3.up * thrustup);
        audioparticle.Play();
        if (!audiosource.isPlaying)
        {
            audiosource.PlayOneShot(audio);
        }
    }

    private void rotate()
    {
        float rotatespeed = rcsthrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
           
            transform.Rotate(Vector3.forward*rotatespeed);
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
           
            transform.Rotate(-Vector3.forward*rotatespeed);
        }
    }
}

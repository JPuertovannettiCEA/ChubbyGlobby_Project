using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private bool _isOnMouth;
    private bool _isEating;
    private bool _isSausage;
    private bool _isStun;
    public Animator _anim;
    private int _score;

    private float _timeBetweenStun = 5f;
    private float _timeSausage = 0.2f;

    [SerializeField]
    private Text _scoreText;
    
    void Start()
    {
        _isOnMouth = false;
        _isEating = false;
        _score = 0;
        _scoreText.text = "Score: " + _score.ToString(); 
    }
    // Update is called once per frame
    void Update()
    {
        if(_timeBetweenStun <= 0f)
        {
            _isStun = false;
            _scoreText.text = "Score: " + _score.ToString();
            _timeBetweenStun = 5f;
        }

        if(_isStun == true)
        {
            _timeBetweenStun -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Fire1") && _isOnMouth == true && _isStun == false)
        {
            _anim.Play("Player_Eat");
            Eat();
        } //else if(Input.GetButton("Fire1") && _isOnMouth == true && _isStun == false)
        //{
            //_timeSausage -= 0.01f;
            //if(_timeSausage <= 0f)
            //{
            //    _anim.Play("Player_Eat");
            //    EatSausage();
            //}
        //} else if (Input.GetButtonUp("Fire1")) {
          //  _timeSausage = 0.2f;
        //}

    }

    void Eat()
    {
        _isEating = true;
        _isOnMouth = false;
    }

    void EatSausage()
    {
        _isSausage = true;
        _isOnMouth = false;
        _timeSausage = 0.2f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Jelly"))
        {
            //Debug.Log("On Mouth");
            _isOnMouth = true;
        }

        if(other.gameObject.CompareTag("Pepper"))
        {
            //Debug.Log("On Mouth");
            _isOnMouth = true;
        }

        if(other.gameObject.CompareTag("Sausage"))
        {
            //Debug.Log("SAUSAGE ON MOUTH");
            _isOnMouth = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Jelly") && _isEating == true)
        {
            //Debug.Log("Eating");
            _score++;
            _scoreText.text = "Score: " + _score.ToString(); 
            Destroy(other.gameObject);
            _isEating = false;
        }
        
        if(other.gameObject.CompareTag("Pepper") && _isEating == true)
        {
            //Debug.Log("Eating");
            //_score--;
            _scoreText.text = "Spicy! You can't eat for 5 secs!";
            Destroy(other.gameObject);
            _isEating = false;
            _isStun = true;
        }

        if(other.gameObject.CompareTag("Sausage") && _isEating == true)
        {
            //Debug.Log("Eating");
            _score += 3;
            _scoreText.text = "Score: " + _score.ToString(); 
            Destroy(other.gameObject);
            //_isSausage = false;
            _isEating = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Jelly"))
        {
            //Debug.Log("No longer on mouth");
            _isOnMouth = false;
        }

        if(other.gameObject.CompareTag("Pepper"))
        {
            //Debug.Log("No longer on mouth");
            _isOnMouth = false;
        }

        if(other.gameObject.CompareTag("Sausage"))
        {
            //Debug.Log("No longer on mouth");
            _isOnMouth = false;
        }
    }
}

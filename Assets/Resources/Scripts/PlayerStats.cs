using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public float HealthDegenerationSpeed;

    public float health = 100;

    public Light RedLight;
    public Light YellowLight;
    float RedInitRange;
    float YellowInitRange;

    public Text LevelDisplay;
    public GameObject GameWonScreen;

    bool _flaskEffect;
    float _aimHealth;

    
    // Use this for initialization
    void Start () {
        RedInitRange = RedLight.range;
        YellowInitRange = YellowLight.range;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey("r"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(Application.loadedLevel);
        }

        LevelDisplay.text = "" + (int)Mathf.Round(this.transform.position.y);

        if((int)Mathf.Round(this.transform.position.y) >= 100)
        {
            StartCoroutine(GameWon());
        }

        if (!_flaskEffect)
        {
            health = health - Time.deltaTime * HealthDegenerationSpeed;
        }

        if (health <= 0.0f)
        {
            StartCoroutine(GameOver());
        }

        UpdateFlame();
    }

    private void UpdateFlame()
    {
        RedLight.range = RedInitRange * health / 100;
        YellowLight.range = YellowInitRange * health / 100;
    }

    public void ActivateFlask()
    {
        StartCoroutine(FlaskRegeneration());
    }

    IEnumerator FlaskRegeneration()
    {
        _flaskEffect = true;
        _aimHealth = Mathf.Clamp(health + 50.0f, 0.0f, 100.0f);
        while (health <= _aimHealth)
        {
            health = health + Time.deltaTime * HealthDegenerationSpeed*5;
            yield return null;
        }

        _flaskEffect = false;
        yield return null;
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(5); // or however long you want it to wait
        UnityEngine.SceneManagement.SceneManager.LoadScene(Application.loadedLevel);
    }

    IEnumerator GameWon()
    {
        GameWonScreen.SetActive(true);
        yield return new WaitForSeconds(10); // or however long you want it to wait
        GameWonScreen.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(Application.loadedLevel);
    }
}

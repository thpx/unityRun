using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour {
	public float sec;
	float time;
    float alfa;
    float speed;
    float red, green, blue;
	private bool fadeInTrigger;
	private bool fadeOutTrigger;

    void Start () {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
		alfa = GetComponent<Image>().color.a;
    }

    void Update () {
		if (fadeInTrigger == true) {
			fadeIn ();
		}else if (fadeOutTrigger == true) {
			fadeOut ();
		}
    }

	public void startFadeIn() {
		if (fadeInTrigger == false) {
			alfa = 1f;
			fadeInTrigger = true;
		}
	}

	public void startFadeOut() {
		if (fadeOutTrigger == false) {
			alfa = 0f;
			fadeOutTrigger = true;
		}
	}

	public void fadeIn () {
		GetComponent<Image>().color = new Color(red, green, blue, alfa);
		time += Time.deltaTime;
		alfa = 1f - (sec * time);
		if (alfa < 0) {
			fadeInTrigger = false;
		}
	}

	public void fadeOut () {
		GetComponent<Image>().color = new Color(red, green, blue, alfa);
		time += Time.deltaTime;
		alfa = sec * time;
		if (alfa < 0) {
			fadeOutTrigger = false;
		}
	}

	public void setColoer(float r, float g, float b, float a) {
		GetComponent<Image>().color = new Color(r, g, b, a);
	}
}

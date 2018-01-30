using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreNumberController : MonoBehaviour {

    private int recentScore = 0;

	// Use this for initialization
	void Start () {
        recentScore = PlayData.Instance.userData.score;
	}
	
	// Update is called once per frame
	void Update () {

        if (recentScore != PlayData.Instance.userData.score) {
            recentScore = PlayData.Instance.userData.score;
            GameObject.Find ("ScoreNumberText").GetComponent<Text> ().text = recentScore.ToString ();
        }
	}
}

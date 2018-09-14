using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
public class AuthLogger : MonoBehaviour {


Firebase.Auth.FirebaseAuth auth;
	Firebase.Auth.FirebaseUser user;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void InitializeFirebase() {
  auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
  auth.StateChanged += AuthStateChanged;
  AuthStateChanged(this, null);
}

void AuthStateChanged(object sender, System.EventArgs eventArgs) {
  if (auth.CurrentUser != user) {
    bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
    if (!signedIn && user != null) {
      print("Signed out " + user.UserId);
    }
    user = auth.CurrentUser;
    if (signedIn) {
      print("Signed in " + user.UserId);
    //  displayName = user.DisplayName ?? "";
     // emailAddress = user.Email ?? "";
    }
  }
}
}

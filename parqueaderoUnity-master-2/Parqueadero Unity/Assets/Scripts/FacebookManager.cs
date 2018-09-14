using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine;

public class FacebookManager : MonoBehaviour {


	Firebase.Auth.FirebaseAuth auth;

	// Use this for initialization
	void Start () {

		auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Awake () {
		
		if(!FB.IsInitialized){
			FB.Init();
		
	}else{

		FB.ActivateApp();
		
		}
	}

   public void LogIn () {

	   FB.LogInWithReadPermissions(callback:OnLogIn);
		
	}


	private void OnLogIn(ILoginResult result) {

		if(FB.IsLoggedIn){

			AccessToken token = AccessToken.CurrentAccessToken;
			print("usuario"+ token.UserId);

			 Firebase.Auth.Credential credential =
    Firebase.Auth.FacebookAuthProvider.GetCredential(token.UserId);
  auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
  if (task.IsCanceled) {
    Debug.LogError("SignInWithCredentialAsync was canceled.");
    return;
  }
  if (task.IsFaulted) {
    Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
    return;
  }

  Firebase.Auth.FirebaseUser newUser = task.Result;
  Debug.LogFormat("User signed in successfully: {0} ({1})",
      newUser.DisplayName, newUser.UserId);
});
  
		
	}else{

		print("Canceled");
		
		}

	   
		
	}


}

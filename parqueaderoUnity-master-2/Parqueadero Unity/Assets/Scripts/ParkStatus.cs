using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
//using LitJson;

public class ParkStatus : MonoBehaviour {

public GameObject parqueadero_1;


string nomParqueadero;
string disponibilidadPuesto;
string estado;



private DatabaseReference parking;
//private JsonData itemData; 



  protected virtual void Start() {
    
        InitializeFirebase();
  }



	// Use this for initialization
  protected virtual void InitializeFirebase() {

	
    // NOTE: You'll need to replace this url with your Firebase App's database
    // path in order for the database connection to work correctly in editor.
    FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://parqueaderouccali-8a09c.firebaseio.com/");


parking = FirebaseDatabase.DefaultInstance.GetReference("parqueaderos");
//parking = FirebaseDatabase.DefaultInstance.GetReference("parqueaderos/parqueadero_1/");

   StartListener();

	}
	


	// Update is called once per frame
	protected void StartListener(){

	parking.ChildChanged += HandleChildChanged;      

    }

	

 

    void HandleChildChanged(object sender, ChildChangedEventArgs args) {
      if (args.DatabaseError != null) {
        Debug.LogError(args.DatabaseError.Message);
        return;
      }

	  nomParqueadero = args.Snapshot.Key;
	  disponibilidadPuesto = args.Snapshot.Child("disponibilidad").Value.ToString ();
	  estado = args.Snapshot.Child("estado").Value.ToString ();

	 // print (nomParqueadero + disponibilidadPuesto + estado);

	  actualizarStatusPark();
	 	//print("FUNCIONAAAAA" + args.Snapshot.GetRawJsonValue() +  args.Snapshot);
		// print(  args.Snapshot.Key +args.Snapshot.Child("disponibilidad").Key +args.Snapshot.Child("disponibilidad").Value);
		 // print(  args.Snapshot.Key +args.Snapshot.Child("estado").Key +args.Snapshot.Child("estado").Value);
		  // print(  args.Snapshot.Key +args.Snapshot.Child("num_parqueadero").Key +args.Snapshot.Child("num_parqueadero").Value);
//		 print(  args.Snapshot.Key + " " + args.Snapshot.GetRawJsonValue());


		// itemData = args.Snapshot.GetRawJsonValue();
		// print(itemData["disponibilidad"]);
	//	 print("FUNCIONAAAAA" + args.Child("disponibilidad").getValue() +  args.Snapshot);
		       // Do something with the data in args.Snapshot
			 //  String a = args.Snapshot.GetRawJsonValue();
			   
    }

public void actualizarStatusPark(){

if(parqueadero_1.name == nomParqueadero){
	if(estado!="0"){

		print("El estado del parqueadero " + nomParqueadero + " cambio a " + estado);

	}else
	{
		if(disponibilidadPuesto=="0"){

		}else if (disponibilidadPuesto == "1"){




		}


	}






}


}


}




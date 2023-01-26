package com.example.myapplication;

import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.ListView;
import android.widget.Toast;
import android.content.Intent;
import android.os.Bundle;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import java.util.List;
import java.util.ArrayList;
import java.util.Collections;


public class MainActivity extends AppCompatActivity {

    static final int ADD_SCORE_REQUEST = 1;  // The request code
    List<compareScore> scoresData; //list of scores
    ListView listView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main); //android.R class that contains predefined views that you can use.

        scoresData = new ArrayList<>();
        listView  = findViewById(R.id.displayView);
        displayList();  // startActivityForResult Deprecated Receiver
        /*
         activityResultLauncher = registerForActivityResult(new ActivityResultContracts.StartActivityForResult(), new ActivityResultCallback<ActivityResult>() {
            @Override
            public void onActivityResult(ActivityResult result) {

                    if(result.getResultCode()==RESULT_OK){

                     String name = data.getStringExtra("newName");
                     String score = data.getStringExtra("newScore");
                     String date = data.getStringExtra("newDate");

                     compareScore newScoreObject = new compareScore(name,score,date);

                        scoresData.add(newScoreObject);

                        FileIO fileInput = new FileIO(this);
                        fileInput.writeFile(scoresData);
                        displayScores();
                    }
                    if(result.getResultCode()==RESULT_CANCELED){

                        String message = "Adding canceled";
                        Toast.makeText(this,message,Toast.LENGTH_SHORT).show();
                    }
                }
        });
        */

    }



    @Override
    public boolean onOptionsItemSelected(MenuItem item) { // Load menu
        // Handle item selection
        System.out.println("pressed button");
        if(item.getItemId() == R.id.add){ //check if the menu item pressed is "add"
            openAddScoreActivity();
            System.out.println("pressed button");
            return true;
        }
        return false;
    }

    // caller for add activity
    private void openAddScoreActivity() {
        Intent addScoreIntent = new Intent(this, addActivity.class);
        startActivityForResult(addScoreIntent, ADD_SCORE_REQUEST);
        //activityResultLauncher.launch(addScoreIntent); // startActivityForResult Deprecated Caller
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.main, menu);
        return true;
    }

    private void displayList(){
        fileHandler fileInput = new fileHandler(this);
        scoresData = fileInput.readFile();

        // Sort and use StableArrayAdapter to orgnized the display.
        Collections.sort(scoresData);
        arrayAdapter newAdapter = new arrayAdapter(this,R.layout.viewlayout,scoresData);
        listView.setAdapter(newAdapter);
    }

    // activity receiver
    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if(requestCode==ADD_SCORE_REQUEST){ // while =1
            if(resultCode==RESULT_OK){ // update view if new scores added

                String name = data.getStringExtra("newName");
                String score = data.getStringExtra("newScore");
                String date = data.getStringExtra("newDate");

                compareScore newCompare = new compareScore(name,score,date);
                scoresData.add(newCompare);

                // write in file and then display on view
                fileHandler fileInput = new fileHandler(this);
                fileInput.writeFile(scoresData);
                displayList();
            }
            if(resultCode==RESULT_CANCELED){
                String text = "Adding canceled";
                Toast.makeText(this,text,Toast.LENGTH_SHORT).show(); // show message in main menu (Kotlin)
            }
        }
    }
}

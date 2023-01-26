/*
   function involved ADD button
* */
package com.example.finalproject.scoreFileIO;
import com.example.finalproject.R;
import androidx.appcompat.app.AppCompatActivity;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import java.text.SimpleDateFormat;
import android.text.Editable;
import android.text.TextWatcher;
import android.app.Activity;
import android.widget.EditText;
import android.content.Intent;
import android.os.Bundle;
import java.util.Date;
//import java.text.ParseException;

public class addActivity extends AppCompatActivity {

    // function valuables on page
    EditText name;
    EditText score;
    EditText date;
    MenuItem save;
    boolean saveFlag = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_score); // layout resource defining your UI
        setTitle("Start Adding Score");

        // findViewById -- retrieve the widgets in that UI that you need to interact with programmatically.
        name = findViewById(R.id.gameName);
        score = findViewById(R.id.gameScore);
        date = findViewById(R.id.gameDate);

        //Return the intent that started this activity.
        Intent temp = getIntent();
        int gameScore = temp.getIntExtra("score",0); //Retrieve extended data from the intent.
        SimpleDateFormat day = new SimpleDateFormat("MM/dd/yyyy HH:mm:ss");

        // Showing values in layout
        score.setText(String.valueOf(gameScore));
        date.setText(day.format(new Date()));

        //https://stackoverflow.com/questions/42700513/android-studio-how-to-have-addtextchangedlistener-work-with-two-edittext
        name.addTextChangedListener(new TextWatcher() {

            // Just need to pass some default valuables.
            @Override
            public void beforeTextChanged(CharSequence string, int before, int counter, int after) { }

            @Override
            public void onTextChanged(CharSequence string, int after, int before, int counter) {
                validation();  // while user entering, checking input validation.
            }
            @Override
            public void afterTextChanged(Editable string) {}
        });
    }

    //Initialize the contents of the Activity's standard options menu.Place menu items in to menu.
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {

        MenuInflater inflater = getMenuInflater();  //instantiate menu XML files into Menu objects.
        inflater.inflate(R.menu.input_add, menu);

        save = menu.findItem(R.id.save);  //define save button and default enabled to button flag.
        save.setEnabled(saveFlag);

        return true;
    }

    // Handling click event
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {  //This method passes the MenuItem selected
        // Handle item selection
        if(item.getItemId() == R.id.save){  //Returns the unique ID for the menu item

            Intent i = new Intent();
            i.putExtra("gameName", name.getText().toString());
            i.putExtra("gameScore", score.getText().toString());
            i.putExtra("gameDate", date.getText().toString());

            setResult(Activity.RESULT_OK, i);
            finish();   // call finish after intent -- player can't go back to previous activity
            return true;
        }
        return false;
        //return super.onOptionsItemSelected(MenuItem item);
    }

    //Prepare the Screen's standard options menu to be displayed. This is called right before the menu is shown.
    @Override
    public boolean onPrepareOptionsMenu(Menu menu) {

        super.onPrepareOptionsMenu(menu);
        MenuItem save = menu.findItem(R.id.save);

        if (saveFlag) {
            name.setError(null);  // if name is valid -> save button enable ->  enable = true
            save.setEnabled(true);
            save.getIcon().setAlpha(255);
        }

        else {
            save.setEnabled(false);  // disable button
            save.getIcon().setAlpha(5);
        }

        return true;
    }


    // validate input name so as Assignment-5
    private void validation(){

        String checkName = name.getText().toString();
        boolean nameValid =  false;  // Initial state flag

        if(checkName.length() > 0 && checkName.length() <= 40){
            name.setError(null);
            nameValid = true;
        }

        else{
            name.setError("Please enter you name with at least 1 character.");
        }

        saveFlag = nameValid; // enable save button if name is valid.
        invalidateOptionsMenu();   // menu manipulation, redraw it to UI
    }
}
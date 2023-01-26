package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import android.text.Editable;
import android.text.TextWatcher;
import android.app.Activity;
import android.widget.EditText;
import android.content.Intent;
import android.os.Bundle;
import java.util.Date;

public class addActivity extends AppCompatActivity {

    // function valuables on page
    EditText name;
    EditText scores;
    EditText date;

    MenuItem save;
    boolean buttonFlag = false;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add);
        setTitle("Start Adding Score");

        name = findViewById(R.id.nameLayout);
        scores = findViewById(R.id.scoreLayout);
        date = findViewById(R.id.dateLayout);


        SimpleDateFormat dateForm = new SimpleDateFormat("MM/dd/yyyy HH:mm:ss");
        date.setText(dateForm.format(new Date()));

        // addTextChangedListener for name&&scores&&date
        name.addTextChangedListener(new TextWatcher() {  // To check different phases while textContent changed by user.
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

        scores.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence string, int before, int counter, int after) { }

            @Override
            public void onTextChanged(CharSequence string, int after, int before, int counter) {
                validation();  // while user entering, checking input validation.
            }
            @Override
            public void afterTextChanged(Editable string) {}
        });

        date.addTextChangedListener(new TextWatcher() {
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

    private void validation(){

        String checkName = name.getText().toString();
        String checkScores = scores.getText().toString();
        String checkDate = date.getText().toString();

        boolean nameValid =  false;
        boolean scoreValid = false;
        boolean dateValid = false;  // Initial State

        if(checkName.length() > 0 && checkName.length() <=40){
            name.setError(null);  // no error and validate name to true state.
            nameValid = true;
        }else{
            name.setError("Please enter you name with at least 1 character.");
        }

        if(!checkScores.isEmpty()){  // when score is not empty
            try {
                int intScore = Integer.parseInt(checkScores);
                if (intScore <= 0) {
                    scores.setError("Please enter positive score number");
                } else {
                    scores.setError(null);
                    scoreValid = true; // no error and validate score to true state.
                }
            } catch (Exception e){
                scores.setError("Please enter a valid score with integer.");
            }
        }

        // have to change the textView to focusable = true.
        if(!checkDate.isEmpty()){   // if date is not empty

            SimpleDateFormat dateEnter = new SimpleDateFormat("MM/dd/yyyy HH:mm:ss");
            dateEnter.setLenient(false);
            Date today = new Date();

            try {
                Date newDate = dateEnter.parse(checkDate.trim());
                int value = today.compareTo(newDate);

                if(value!= 0){  // if enter date is not today
                    buttonFlag = false;  // unable to save.
                    date.setError(" Date can not without today's boundary.");
                }
                date.setError(null);
                dateValid = true;  // otherwise is a valid date
            } catch (ParseException e) {
                date.setError("Date should be format with MM/dd/yyyy && HH:mm:ss");
            }
        }
        buttonFlag = nameValid && scoreValid && dateValid; // while all true
        invalidateOptionsMenu(); // menu manipulation, redraw it to UI
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {

        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.input_add, menu);

        save = menu.findItem(R.id.save);
        save.setEnabled(buttonFlag);
        return true;
    }

    @Override
    public boolean onPrepareOptionsMenu(Menu menu) {

        MenuItem item = menu.findItem(R.id.save);

        if (buttonFlag) {  // buttonFlag = nameValid && scoreValid && dateValid
            item.setEnabled(true); // if all true, then enable save button
            // no error to all values
            name.setError(null);
            date.setError(null);
            scores.setError(null);
            item.getIcon().setAlpha(255);

        } else {
            item.setEnabled(false); // otherwise disable save button
            item.getIcon().setAlpha(130);
        }
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        if(item.getItemId() == R.id.save){
            Intent returnIntent = new Intent();
            returnIntent.putExtra("newName", name.getText().toString());
            returnIntent.putExtra("newScore", scores.getText().toString());
            returnIntent.putExtra("newDate", date.getText().toString());
            setResult(Activity.RESULT_OK, returnIntent);
            finish();
            return true;
        }
        return false;
    }
}
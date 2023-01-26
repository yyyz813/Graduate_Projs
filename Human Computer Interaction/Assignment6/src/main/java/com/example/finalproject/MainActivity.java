package com.example.finalproject;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.res.Resources;
import android.graphics.Color;
import android.graphics.drawable.GradientDrawable;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import java.util.Random;

import com.example.finalproject.balloonModule.balloon;
import com.example.finalproject.balloonModule.balloonColors;

public class MainActivity extends AppCompatActivity {

    Button startButton;
    TextView instructionText;
    canvas shapeView;

    balloon randColor;
    boolean randShape; //True = Square, False = Circle
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        startButton = findViewById(R.id.startButton);
        instructionText = findViewById(R.id.instructions);

        //Generate random shape and color for current game

        randColor = balloonColors.getRandomColor();
        Random rand = new Random();
        randShape = rand.nextInt(2) == 1;
        //Randomly selecting shape and setting the instruction text

        shapeView = findViewById(R.id.shapeView);

        if(randShape){
            instructionText.setText("Pop "+ randColor.toString() + " Squares");
            GradientDrawable shape = new GradientDrawable();
            shape.setShape(GradientDrawable.RECTANGLE);
            shape.setColor(randColor.color);
            shape.setStroke(2, Color.BLACK);
            shapeView.setBackground(shape);
        }else{
            instructionText.setText("Pop "+ randColor.toString() + " Circles");
            GradientDrawable shape = new GradientDrawable();
            shape.setShape(GradientDrawable.OVAL);
            shape.setColor(randColor.color);
            shape.setStroke(2, Color.BLACK);
            shapeView.setBackground(shape);

        }


        //On start button press go to game activity

        startButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent startGame = new Intent(getApplicationContext(),GameActivity.class);
                startGame.putExtra("color",randColor.color);
                startGame.putExtra("shape",randShape);
                startActivity(startGame);
            }
        });

    }

    public static int getScreenWidth() {
        return Resources.getSystem().getDisplayMetrics().widthPixels;
    }

    public static int getScreenHeight() {
        return Resources.getSystem().getDisplayMetrics().heightPixels;
    }
}
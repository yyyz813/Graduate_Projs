package com.example.finalproject;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.RectF;


import java.util.Random;

import com.example.finalproject.balloonModule.balloonColors;
import com.example.finalproject.balloonModule.pixelDpConversion;

public abstract class Shape {

    int size;
    int color;
    float x , y;
    int velocity;
    RectF rectF;
    public static final int MAX_VELOCITY = 20; //max velocity a balloon can have
    public static final int MIN_VELOCITY = 2;//min velocity a balloon can have


    /*
    * Generate a random shape and initialzie the attributes
    * */
    public Shape(Context context, int screenHeight, int screenWidth){
        Random rand = new Random();
        int randSize = rand.nextInt((64 - 32) + 1) + 32;
        this.color = balloonColors.getRandomColor().color;
        this.size = pixelDpConversion.DpPixel(context, randSize);
        this.y = screenHeight + size;
        this.x = rand.nextInt(screenWidth - this.size);
        this.velocity = rand.nextInt((10 - 5) + 1) + 5;
        rectF = new RectF(x ,y-size ,x+size,y);
    }


    abstract void drawBalloon(Canvas canvas);

    abstract float getTop();

    abstract boolean getShape();


    /*
    * increment the velocity and check if it does not cross the threshold
    * */
    public void incrementVelocity(int v){
        if(velocity + v <= MAX_VELOCITY){
            velocity += v;
        }
    }

    void drawBallooForMain(Canvas canvas){

    }

    /*
     * decrement the velocity and check if it does not cross the threshold
     * */

    public void decrementVelocity(int v){
        if(velocity - v >= MIN_VELOCITY){
            velocity -= v;
        }
    }

}
package com.example.finalproject;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Paint;
import android.graphics.RectF;


public class Square extends Shape {

    public Square(Context context, int screenHeight, int screenWidth) {
        super(context,screenHeight,screenWidth);
    }

    /*
    * Draw square and intialize the attributes
    * */
    @Override
    void drawBalloon(Canvas canvas) {
        rectF = new RectF(x,y-size ,x+size,y);
        Paint paint = new Paint();
        paint.setColor(color);
        canvas.drawRect(rectF, paint);
        y-= velocity;
    }

    void drawBallooForMain(Canvas canvas){
        rectF = new RectF(x,y-size ,x+size,y);
        Paint paint = new Paint();
        paint.setColor(color);
        canvas.drawRect(rectF, paint);
    }

    @Override
    public float getTop() {
        return y-size;
    }

    @Override
    boolean getShape() {
        return true;
    }

}
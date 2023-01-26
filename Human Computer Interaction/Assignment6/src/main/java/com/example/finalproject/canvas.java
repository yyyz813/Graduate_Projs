package com.example.finalproject;
import android.graphics.Canvas;
import android.content.Context;
import android.view.View;
import android.util.AttributeSet;


public class canvas extends View {

    public void init(Context context){
        // initialized.
    }

    public canvas(Context context, AttributeSet attributeset){
        super(context,attributeset);
        init(context);
    }

    // Knowing that the parameter to onDraw() is a Canvas object that the view can use to draw itself.
    @Override
    protected void onDraw(Canvas canvas) {
        super.onDraw(canvas);
    }
}
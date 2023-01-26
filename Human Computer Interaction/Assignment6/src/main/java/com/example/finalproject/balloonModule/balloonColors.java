/*
   Define different balloon colors and render random color
* */
package com.example.finalproject.balloonModule;
import android.graphics.Color;
import java.util.Random;

public class balloonColors {
    // Define un-changeable array to store color Rgb.
    public static final balloon[] colorList =
            new balloon[]{new balloon(Color.rgb(214, 18, 16), "Red"),
                    // or p.setColor(0xffa500) -- orange;
                    new balloon(Color.rgb(214, 103, 48), "Orange"),
                    new balloon(Color.rgb(234, 235, 16), "Yellow") ,
                    new balloon(Color.rgb(17, 214, 16), "Green"),
                    new balloon(Color.rgb(21, 138, 227), "Blue"),
                    new balloon(Color.rgb(164, 124, 134), "Purple"),
                    new balloon(Color.WHITE, "White")};

    public static balloon getRandomColor(){
        Random rnd = new Random();
        int rndRbg = rnd.nextInt(colorList.length); // get random color from list.
        return colorList[rndRbg];
    }
}
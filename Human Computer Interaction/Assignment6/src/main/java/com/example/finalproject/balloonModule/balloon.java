/*
   Initialize balloons
* */

package com.example.finalproject.balloonModule;
public class balloon {
    public int color;
    public String name;

    public balloon(int color, String name){
        this.color = color;
        this.name = name;
    }

    @Override
    public String toString(){
        return name;
    }
}
package com.example.myapplication;

import java.text.SimpleDateFormat;
import java.util.Date;

//implement abstract method 'compareTo(T)' in 'Comparable'
public class compareScore implements Comparable<compareScore>{
    private String name;
    private String score;
    private String date;

    public compareScore(String name, String score, String date) { // constructor
        this.name = name;
        this.score = score;
        this.date = date;
    }

    //Getter & Setter neccessary
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public String getScore() {
        return score;
    }
    public void setScore(String score) {
        this.score = score;
    }
    public String getDate() {
        return date;
    }
    public void setDate(String date) {
        this.date = date;
    }

    @Override  //Showing name,score,date
    public String toString(){
        return getName()+"\t"+getScore()+"\t"+getDate();
    }

    @Override
    public int compareTo(compareScore input) {

        int first = Integer.parseInt(this.getScore());
        int second = Integer.parseInt(input.getScore());

        if (first < second) {
            return 1;  // don't need further compare
        } else if (first == second) {  // if score is the same value, then compare the enter time.
            Date firstDate = null;
            Date secondDate = null;
            try {
                firstDate = new SimpleDateFormat("MM/dd/yyyy HH:mm:ss").parse(this.getDate());
                secondDate = new SimpleDateFormat("MM/dd/yyyy HH:mm:ss").parse(input.getDate());
            } catch (Exception e) {
                e.printStackTrace();
            }

            int value = secondDate.compareTo(firstDate);
            if (value != 0) {
                return value;
            }
        }
        else{
            return -1;
        }
        return 0;
    }
}


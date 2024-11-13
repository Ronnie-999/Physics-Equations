using System;
using System.Collections;
using System.Collections.Generic;
using oompe.lib;
using org.mariuszgromada.math.mxparser;
using UnityEngine;

public class PlotGraph{
    public void plotPoints(FunctionPlotter plotter, double timeStep, double t, double power, double power1){

        // Draw rectangle (horizontal lines)
        plotter.AddLine(new Vector2((float)t, 0), new Vector2((float)(t + timeStep), 0));
        plotter.AddLine(new Vector2((float)t, (float)power), new Vector2((float)(t + timeStep), (float)power1));

        // Draw rectangle (vertical lines)
        plotter.AddLine(new Vector2((float)t, 0), new Vector2((float)t, (float)power));
        plotter.AddLine(new Vector2((float)(t + timeStep), 0), new Vector2((float)(t + timeStep), (float)power1));
    }

    public void plotPointsM1(FunctionPlotter plotter, double currentPower, double nextPower, double t, double timeStep){
    
        plotter.AddLine(new Vector2((float)t, (float)currentPower), new Vector2((float)(t + timeStep), (float)nextPower));
        plotter.AddLine(new Vector2((float)t, 0), new Vector2((float)t, (float)currentPower));
        plotter.AddLine(new Vector2((float)(t + timeStep), 0), new Vector2((float)(t + timeStep), (float)nextPower));
    }
    public void plotPointsM2(FunctionPlotter plotter, double mean_value, double t, double timeStep, double startTime){
                    plotter.AddLine(new Vector2((float)t, 0), new Vector2((float)(t + timeStep), 0));

            // Draw rectangle (vertical lines) for the initial point as well
            plotter.AddLine(new Vector2((float)t, 0), new Vector2((float)t, (float)mean_value));

            // Use if statement for the initial point of the subinterval
            if (t != startTime)
            {
                plotter.AddLine(new Vector2((float)t, (float)mean_value), new Vector2((float)(t + timeStep), (float)mean_value));
            }

            plotter.AddLine(new Vector2((float)(t + timeStep), 0), new Vector2((float)(t + timeStep), (float)mean_value));
    }
}
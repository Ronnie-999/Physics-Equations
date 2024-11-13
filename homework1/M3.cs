using System;
using System.Collections;
using System.Collections.Generic;
using oompe.lib;
using org.mariuszgromada.math.mxparser;
using UnityEngine;

public class M3 : MonoBehaviour
{
    
    public void Met3(GameObject met3)
    {
        double totalEnergy = 0;
        double timeStep = 0.1;
        int startTime = 0;
        int endTime = 20;
        Function myFunction = new Function("P(t) = ((126724.0/40000.0)*t) + sin(2 * pi * 2 * t)");

        FunctionPlotter plotter = new FunctionPlotter(myFunction, startTime, endTime);
        PlotGraph pg = new PlotGraph();

        double power;
        double power1;

        double t = startTime; // Start with the initial value

        if (t <= endTime)
        {
            do
            {
                power = myFunction.calculate(t);
                power1 = myFunction.calculate(t + timeStep);
                pg.plotPoints(plotter, timeStep, t, power, power1);

                totalEnergy = totalEnergy + power * timeStep + (timeStep * (power1 - power)) / 2;

                t += timeStep; // Increment t
            } while (t <= endTime); // Use do-while to guarantee at least one iteration
        }

        // Plot accumulated lines outside the loop
        plotter.Plot(met3);
        Debug.Log(totalEnergy);
        double analyticalError = 633.6454775;
        ErrorAbs er = new ErrorAbs(totalEnergy, analyticalError);
        Debug.Log(er.getAbsoluteError());
        Debug.Log(er.getReltiveError());
    }
}


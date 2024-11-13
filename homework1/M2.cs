using System.Collections;
using System.Collections.Generic;
using oompe.lib;
using org.mariuszgromada.math.mxparser;
using UnityEngine;

public class M2 : MonoBehaviour
{
    public void Met2(GameObject met2)
    {
        double totalEnergy = 0;
        double timeStep = 0.1;
        int startTime = 0;
        int endTime = 20;
        Function myFunction = new Function("P(t) = ((126724.0/40000.0)*t) + sin(2 * pi * 2 * t)");

        FunctionPlotter plotter = new FunctionPlotter(myFunction, startTime, endTime);
        PlotGraph pg = new PlotGraph();

        double t = startTime;
        double power1, power2;

        do
        {
            power1 = myFunction.calculate(t); 
            power2 = myFunction.calculate(t + timeStep);

            double mean_value = (power1 + power2) / 2;
            pg.plotPointsM2(plotter,mean_value,t,timeStep, startTime);

            totalEnergy += mean_value * timeStep; // Multiply by the width of the interval

            t += timeStep;
        } while (t <= endTime);

        // Plot accumulated lines outside the loop
        plotter.Plot(met2);
        Debug.Log(totalEnergy);
        double analyticalError = 633.6454775;
        ErrorAbs er = new ErrorAbs(totalEnergy, analyticalError);
        Debug.Log(er.getAbsoluteError());
        Debug.Log(er.getReltiveError());
    }
}


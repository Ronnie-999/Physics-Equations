using oompe.lib;
using org.mariuszgromada.math.mxparser;
using UnityEngine;

public class M1 : MonoBehaviour
{
    public void Met1(GameObject met1)
    {
        double totalEnergy = 0;
        double timeStep = 0.1;
        int startTime = 0;
        int endTime = 20;
        Function powerFunction = new Function("P(t) = ((126724.0/40000.0)*t) + sin(2 * pi * 2 * t)");

        FunctionPlotter plotter = new FunctionPlotter(powerFunction, startTime, endTime);
        PlotGraph pg = new PlotGraph();

        double t = startTime;
        double currentPower = powerFunction.calculate(t);
        double nextPower;

        while (t <= endTime)
        {
            nextPower = powerFunction.calculate(t + timeStep);

            if (t == startTime)
            {
                plotter.AddLine(new Vector2((float)t, 0), new Vector2((float)(t + timeStep), 0));
            }

            totalEnergy += (currentPower + nextPower) * timeStep / 2; // Trapezoidal rule
            pg.plotPointsM1(plotter, currentPower, nextPower, t, timeStep);

            currentPower = nextPower;
            t += timeStep;
        }
        //plotting the graph
        plotter.Plot(met1);
        //giving the output for total energy, absolute error and relative error
        Debug.Log(totalEnergy);
        double analyticalError = 630.45189999999;
        ErrorAbs er = new ErrorAbs(totalEnergy, analyticalError);
        Debug.Log(er.getAbsoluteError());
        Debug.Log(er.getReltiveError());
    }
}

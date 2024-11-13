using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using oompe.lib;
using org.mariuszgromada.math.mxparser;

public class functionPoints : MonoBehaviour
{
    private Function myFunction;

    private FunctionPlotter plotter;

    public void FuncPoints(GameObject pts)
    {

        myFunction = new Function("P(t)= 3.1681 * t + sin(2 * 3.14 * 2 * t)");
        plotter = new FunctionPlotter(myFunction, 0, 20);
        plotter.Plot(pts);
    }
}

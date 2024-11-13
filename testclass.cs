using System.Collections;
using System.Collections.Generic;
using oompe.lib;
using org.mariuszgromada.math.mxparser;
using UnityEngine;

public class testClass : MonoBehaviour
{
    // Please uncomment the method which you want to plot
    void Start()
    { 
        // M1 m = new M1();
        // m.Met1(this.gameObject);
        
        // M2 m = new M2();
        // m.Met2(this.gameObject);

        // M3 m = new M3();
        // m.Met3(this.gameObject);

        functionPoints fp = new functionPoints();
        fp.FuncPoints(this.gameObject);
 
        
    }

    
}
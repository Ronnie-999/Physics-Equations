public class ErrorAbs{
    private double tEnergy=0.0;
    private double aVal = 0.0;

    private double absErrorVal = 0.0, relErrorVal = 0.0;

    public ErrorAbs(double totalEnergy, double analyticalVal){
        this.aVal = analyticalVal;
        this.tEnergy = totalEnergy;
        this.absErrorVal = this.absoluteError();//func for absolute error 
        this.relErrorVal = this.relativeError();//func for relative error
    }

    private double absoluteError(){
        return System.Math.Abs(this.tEnergy-this.aVal);
    }

    private double relativeError(){
        return (this.absErrorVal * 100) /this.aVal;
    }
    public double getAbsoluteError(){
        return this.absErrorVal;
    }

    public double getReltiveError(){
        return this.relErrorVal;
    }
}
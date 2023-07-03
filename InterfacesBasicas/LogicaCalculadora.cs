using System;


namespace InterfacesBasicas
{
    internal class LogicaCalculadora
    {

        //Constructor x defecto
        public LogicaCalculadora() { }
        public double SumarNumeros(double num1, double num2)=> num1 + num2;
        public double  RestarNumeros(double num1, double num2) => num1 - num2;
        public double  MultiplicarNumeros(double num1, double num2) => num1 * num2;
        public double DividirNumeros(double num1, double num2)
        {
            return num1 / num2;
        }
    }
}

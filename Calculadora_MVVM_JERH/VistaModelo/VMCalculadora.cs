using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace Calculadora_MVVM_JERH.VistaModelo
{
    public class VMCalculadora : BaseViewModel
    {
        #region Contructor
        public VMCalculadora(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region VARIABLES
        string _Cadena;
        string _Operacion;
        string _respuesta;

        #endregion


        #region Objetivo;

        public string Cadena
        {
            get { return _Cadena; }
            set { SetValue(ref _Cadena, value); }
        }
        public string Operaciones
        {
            get { return _Operacion; }
            set { SetValue(ref _Operacion, value); }
        }
        public string Respuesta
        {
            get { return _respuesta; }
            set { SetValue(ref _respuesta, value); }
        }

        #endregion

        #region PROCESOS
        public void Resultado()
        {
            string[] operadores = { "+", "-", "x", "/" };
            string[] elementos = Cadena.Split(operadores, StringSplitOptions.RemoveEmptyEntries);
            string[] operadoresEnExpresion = Cadena.Split(elementos, StringSplitOptions.RemoveEmptyEntries);

            float resultado = Convert.ToSingle(elementos[0]);

            for (int i = 0; i < operadoresEnExpresion.Length; i++)
            {
                float numero = Convert.ToSingle(elementos[i + 1]);
                string operador = operadoresEnExpresion[i];

                if (operador == "x")
                {
                    resultado *= numero;

                }
                else if (operador == "/")
                {
                    if (numero == 0)
                    {
                        Cadena= "No se puede dividir por cero.";
                        Operaciones = "No se puede dividir por cero.";

                    }else 
                    resultado /= numero;

                }
                else if (operador == "+")
                {
                    resultado += numero;
                }
                else if (operador == "-")
                {
                    resultado -= numero;

                }


            }
            Operaciones = resultado.ToString();
            Cadena = resultado.ToString();
        }
        public async Task Operacion()
        {
            Resultado();
        }
        public async Task BtnDiv(  )
        {
            if (Cadena == "")
                Operaciones= Cadena;
            else if (Cadena[Cadena.Length - 1] != '/' && Cadena[Cadena.Length - 1] != 'x' && Cadena[Cadena.Length - 1] != '-' && Cadena[Cadena.Length - 1] != '+' && Cadena[Cadena.Length - 1] != '%' && Cadena != "")
                Cadena += "/";
            //Operaciones= Cadena;
        }
        public async Task BtnX(  )
        {
            if (Cadena == "")
                Operaciones = Cadena;
            else if (Cadena[Cadena.Length - 1] != '/' && Cadena[Cadena.Length - 1] != 'x' && Cadena[Cadena.Length - 1] != '-' && Cadena[Cadena.Length - 1] != '+' && Cadena[Cadena.Length - 1] != '%' && Cadena != "")
                Cadena += "x";
            //Operaciones = Cadena;
        }
        public async Task BtnSuma(  )
        {
            if (Cadena == "")
                Operaciones = Cadena;
            else if (Cadena[Cadena.Length - 1] != '/' && Cadena[Cadena.Length - 1] != 'x' && Cadena[Cadena.Length - 1] != '-' && Cadena[Cadena.Length - 1] != '+' && Cadena[Cadena.Length - 1] != '%')
                Cadena += "+";

            //Operaciones = Cadena;
        }
        public async Task BtnPunto(  )
        {

            if (Cadena == "")
                Operaciones = Cadena;
            else if (Cadena[Cadena.Length - 1] != '.')
                Cadena += ".";

            //Operaciones = Cadena;
        }
        public async Task BtnResta(  )
        {
            if (Cadena == "")
                Operaciones = Cadena;
            else if (Cadena[Cadena.Length - 1] != '/' && Cadena[Cadena.Length - 1] != 'x' && Cadena[Cadena.Length - 1] != '-' && Cadena[Cadena.Length - 1] != '+' && Cadena[Cadena.Length - 1] != '%' && Cadena != "")
                Cadena += "-";
            //Operaciones = Cadena;
        }
        public async Task AgregarBoton(char numero)
        {
            
            Cadena = Cadena+numero;
        }
        public async Task botonBorrar()
        {
            char[] caracteres = Cadena.ToCharArray();
            if (caracteres.Length > 0)
            {
                Array.Resize(ref caracteres, caracteres.Length - 1);
            }
            Cadena = new string(caracteres);
            Operaciones = Cadena;
        }
        public async Task botonAc()
        {
            Cadena = "";
            Operaciones = Cadena;
            Respuesta = Cadena;
        }
        public async Task botonResultado()
        {
            if (Cadena == "")
            {
                Cadena += "0";
                Operaciones = Cadena;
                Resultado();
            }
            else if (Cadena[Cadena.Length - 1] != '/' && Cadena[Cadena.Length - 1] != 'x' && Cadena[Cadena.Length - 1] != '-' && Cadena[Cadena.Length - 1] != '+' && Cadena[Cadena.Length - 1] != '%')
                Resultado();
        }
        #endregion.
        #region COMANDOS
        public ICommand Operacioncommand => new Command(async () => await Operacion());
        public ICommand btdivcommand => new Command(async () => await BtnDiv());
        public ICommand btXcommand => new Command(async () => await BtnX());
        public ICommand btSumacommand => new Command(async () => await BtnSuma());
        public ICommand btPuntocommand => new Command(async () => await BtnPunto());
        public ICommand btRestacommand => new Command(async () => await BtnResta());
        public ICommand bt0command => new Command(async () => await AgregarBoton('0'));
        public ICommand bt1command => new Command(async () => await AgregarBoton('1'));
        public ICommand bt2command => new Command(async () => await AgregarBoton('2'));
        public ICommand bt3command => new Command(async () => await AgregarBoton('3'));
        public ICommand bt4command => new Command(async () => await AgregarBoton('4'));
        public ICommand bt5command => new Command(async () => await AgregarBoton('5'));
        public ICommand bt6command => new Command(async () => await AgregarBoton('6'));
        public ICommand bt7command => new Command(async () => await AgregarBoton('7'));
        public ICommand bt8command => new Command(async () => await AgregarBoton('8'));
        public ICommand bt9command => new Command(async () => await AgregarBoton('9'));
        public ICommand btACcommand => new Command(async () => await botonAc());
        public ICommand Borarcommand => new Command(async () => await botonBorrar());
        public ICommand resultadoCcommand => new Command(async () => await botonResultado());
        #endregion

    }
}
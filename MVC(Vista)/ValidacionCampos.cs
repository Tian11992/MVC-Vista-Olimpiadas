using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MVC_Vista_
{
    public class ValidacionCampos
    {
        public static void validacionNumerica(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))  //Que sea solo digito
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))  //Que sea la tecla de borrar
                {
                    e.Handled = false;
                }
                else
                {
                    if (Char.IsSeparator(e.KeyChar))  //Que sea la tecla de espacios
                    {
                        e.Handled = false;
                    }
                    //else
                    //{
                    //    if (e.KeyChar.ToString().Equals("."))  //Que sea la tecla del punto
                    //    {
                    //        e.Handled = false;
                    //    }
                    else
                    {
                        MessageBox.Show("Debes colocar solo números, no intentes reventarme.");
                        e.Handled = true;
                    }
                    //}
                }
            }
        }

        public static void validacionLetras(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))  //Que sea la tecla de espacios
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras en este campo");
            }
        }
    }
}

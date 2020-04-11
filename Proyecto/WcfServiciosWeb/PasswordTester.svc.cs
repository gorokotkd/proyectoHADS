using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace WcfServiciosWeb
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PasswordTester" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PasswordTester.svc o PasswordTester.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PasswordTester : IPasswordTester
    {

        public int checkPassword(string password)
        {
            int score = 0;

            if (password.Length < 1) 
                return 0;                   //Blank Pass
            if (password.Length < 4)
                return 1;                   //VeryWeak Pass

            if (password.Length >= 8)
                score++;                    //VeryWeak Pass
            if (password.Length >= 12)
                score++;                    //Weak Pass
            if (Regex.IsMatch(password, @"/\d+/", RegexOptions.ECMAScript)) //Que tenga digitos numericos
                score++;                    //Medium Pass
            if (Regex.IsMatch(password, @"/[a-z]/", RegexOptions.ECMAScript) &&
              Regex.IsMatch(password, @"/[A-Z]/", RegexOptions.ECMAScript)) //Que tenga mayusculas y minusculas
                score++;                    //Strong Pass
            if (Regex.IsMatch(password, @"/[!,@,#,$,%,^,&,*,?,_,~,-,€,(,)]/", RegexOptions.ECMAScript)) //Que tenga caracteres especiales.
                score++;                    //VeryStrong Pass

            return score;
        }

    }
}

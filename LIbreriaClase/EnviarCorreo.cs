﻿using System;
using System.Net;
using System.Net.Mail;
using System.IO;
using Glimpse.AspNet.Tab;
using System.Reflection;

namespace LibreriaClase
{
    public class EnviarCorreo { 
    
        public void enviarCorreo(String correo)
        {
            var random = new Random();
            Double NumConf = Math.Round((random.NextDouble() * 9000000) + 1000000);
            MailAddress dirOrigen = new MailAddress("iakigarcianoya@gmail.com", "Iñaki García");
            MailAddress dirDestino = new MailAddress(correo);
            MailMessage mensaje = new MailMessage(dirOrigen, dirDestino);

            mensaje.Subject = "Confirmación de correo";
            string enlace = Convert.ToString("http://localhost/proyectoHADS/confirmar.aspx?mbr="+email+"&numconf="+ NumConf);
            string body = "EL ENLACE PARA RESTABLECER TU CONTRASEÑA YA ESTÁ LISTO :"+enlace;

            // var assembly = Assembly.GetExecutingAssembly();
            // string[] names = assembly.GetManifestResourceNames();
            // StreamReader reader = new StreamReader(assembly.GetManifestResourceStream("proyectoHADS.LIbreriaClase.EmailTemplate.html"));
            //  body = reader.ReadToEnd();
            // body = body.Replace("{URL}", enlace2);

            mensaje.Body = body;
            SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("iakigarcianoya@gmail.com", "iakigarcianoya"),
                EnableSsl = true
            };

            try
            {
                cliente.Send(mensaje);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

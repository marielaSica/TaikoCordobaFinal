﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TaikoCordobaFinal.Utilities
{
    public class Strings
    {
        #region Messagges
        public const string UIMessageUnauthorized = "Al parecer ha caducado su sesión. Será redireccionado al login..";
        public const string UIMessageMethodNotAllowed = "No tiene los permisos necesarios para el recurso que intenta acceder.";
        #endregion




        #region Keys
        public const string KeyCurrentAdmin = "KeyCurrentAdmin";
        public const string KeyMensajeDeAccion = "KeyMensajeDeAccion";
        public const string KeyConnectionStringTaikoCordoba= "TaikoCordoba";

        //public static int KeyConnectionStringTaikoCordoba { get; internal set; }

        #endregion

        #region encriptar contraseña 
        public static string Encriptar(string texto)
        {
            System.Security.Cryptography.SHA1 sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();

            byte[] inputBytes = (new System.Text.UnicodeEncoding()).GetBytes(texto);
            byte[] hash = sha1.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash);
        }
        #endregion 

        /// <summary>
        /// Limpia el string de todo tag HTML excepto los tags <b><i><u><br>
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string WysingFilterHTML(string html)
        {
            return StripTags(html, new string[] { "b", "i", "u", "br" });
        }

        public static string StripTags(string Input, string[] AllowedTags)
        {
            Regex StripHTMLExp = new Regex(@"(<\/?[^>]+>)");
            string Output = Input;

            foreach (Match Tag in StripHTMLExp.Matches(Input))
            {
                string HTMLTag = Tag.Value.ToLower();
                bool IsAllowed = false;

                foreach (string AllowedTag in AllowedTags)
                {
                    int offset = -1;

                    // Determine if it is an allowed tag
                    // "<tag>" , "<tag " and "</tag"
                    if (offset != 0) offset = HTMLTag.IndexOf('<' + AllowedTag + '>');
                    if (offset != 0) offset = HTMLTag.IndexOf('<' + AllowedTag + ' ');
                    if (offset != 0) offset = HTMLTag.IndexOf("</" + AllowedTag + '>');

                    // If it matched any of the above the tag is allowed
                    if (offset == 0)
                    {
                        IsAllowed = true;
                        break;
                    }
                }

                // Remove tags that are not allowed
                if (!IsAllowed) Output = ReplaceFirst(Output, Tag.Value, "");
            }

            return Output;
        }

        private static string ReplaceFirst(string haystack, string needle, string replacement)
        {
            int pos = haystack.IndexOf(needle);
            if (pos < 0) return haystack;
            return haystack.Substring(0, pos) + replacement + haystack.Substring(pos + needle.Length);
        }
    }
}
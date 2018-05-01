using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Transporto.Logic;

namespace Transporto.Helpers
{
    public enum AppRol
    {
        Administrador
    }


    public enum SessionKey
    {
        Usuario,
        UsuarioId,
        NombreCompleto,
        Email,
        Rol,
        RolId,
        RolCompleto,
        Codigo,
        EmpresaId,
        Accesos,
        AplicacionId,
        _appBP,
        LstRolUsuario
    }
    public static class SessionHelpers
    {

        #region Private

        private static object Get(HttpSessionState Session, String Key)
        {
            return Session[Key];
        }

        private static void Set(HttpSessionState Session, String Key, object Value)
        {
            Session[Key] = Value;
        }

        private static bool Exists(HttpSessionState Session, String Key)
        {
            return Session[Key] != null;
        }

        private static object Get(HttpSessionStateBase Session, String Key)
        {
            return Session[Key];
        }

        private static void Set(HttpSessionStateBase Session, String Key, object Value)
        {
            Session[Key] = Value;
        }

        private static bool Exists(HttpSessionStateBase Session, String Key)
        {
            return Session[Key] != null;
        }

        #endregion

        #region Getters setters GlobalKey
        //HttpSessionState
        public static object Get(this HttpSessionState Session, SessionKey Key)
        {
            return Get(Session, Key.ToString());
        }

        public static void Set(this HttpSessionState Session, SessionKey Key, object Value)
        {
            Set(Session, Key.ToString(), Value);
        }

        public static bool Exists(this HttpSessionState Session, SessionKey Key)
        {
            return Exists(Session, Key.ToString());
        }

        //HttpSessionStateBase
        public static object Get(this HttpSessionStateBase Session, SessionKey Key)
        {
            //try
            //{
            return Get(Session, Key.ToString());
            //}
            //catch(Exception)
            //{
            //    return null;
            //}
        }

        public static void Set(this HttpSessionStateBase Session, SessionKey Key, object Value)
        {
            Set(Session, Key.ToString(), Value);
        }

        public static bool Exists(this HttpSessionStateBase Session, SessionKey Key)
        {
            return Exists(Session, Key.ToString());
        }
        #endregion

        #region IsLoggedIn
        public static Boolean IsLoggedIn(this HttpSessionState Session)
        {
            return Get(Session, SessionKey.UsuarioId) != null;
        }

        public static Boolean IsLoggedIn(this HttpSessionStateBase Session)
        {
            return Get(Session, SessionKey.UsuarioId) != null;
        }
        #endregion

        #region TieneRol
        public static Boolean TieneRol(this HttpSessionState Session, AppRol Rol)
        {
            return Session.GetRol() == Rol;
        }

        internal static object GetEntidad(object entidad)
        {
            throw new NotImplementedException();
        }

        public static Boolean TieneRol(this HttpSessionStateBase Session, Int32 RolId)
        {
            return Session.GetRolId() == RolId;
        }

        public static Boolean TieneRol(this HttpSessionState Session, String Rol)
        {
            return Get(Session, SessionKey.RolCompleto).ToString() == Rol;
        }

        public static Boolean TieneRol(this HttpSessionStateBase Session, String Rol)
        {
            return Get(Session, SessionKey.RolCompleto).ToString() == Rol;
        }

        #endregion

        #region GetRol
        public static AppRol? GetRol(this HttpSessionState Session)
        {
            return (AppRol?)Get(Session, SessionKey.Rol);
        }

        public static AppRol? GetRol(this HttpSessionStateBase Session)
        {
            return (AppRol?)Get(Session, SessionKey.Rol);
        }

        public static Int32 GetRolId(this HttpSessionStateBase Session)
        {
            return Get(Session, SessionKey.RolId).ToInteger();
        }
        #endregion

        #region GetRolCompleto
        public static String GetRolCompleto(this HttpSessionState Session)
        {
            return (String)Get(Session, SessionKey.RolCompleto);
        }

        public static String GetRolCompleto(this HttpSessionStateBase Session)
        {
            return (String)Get(Session, SessionKey.RolCompleto);
        }
        #endregion

        #region GetNombres
        public static String GetNombres(this HttpSessionState Session)
        {
            return (String)Get(Session, SessionKey.NombreCompleto);
        }

        public static String GetNombres(this HttpSessionStateBase Session)
        {
            return (String)Get(Session, SessionKey.NombreCompleto);
        }
        #endregion

        #region GetCodigo
        public static String GetCodigo(this HttpSessionState Session)
        {
            return (String)Get(Session, SessionKey.Codigo);
        }

        public static String GetCodigo(this HttpSessionStateBase Session)
        {
            return (String)Get(Session, SessionKey.Codigo);
        }
        #endregion

        #region GetEmail
        public static String GetEmail(this HttpSessionState Session)
        {
            return (String)Get(Session, SessionKey.Email);
        }

        public static String GetEmail(this HttpSessionStateBase Session)
        {
            return (String)Get(Session, SessionKey.Email);
        }
        #endregion

        #region EmpresaId
        public static Int32 GetEmpresaId(this HttpSessionState Session)
        {
            return Get(Session, SessionKey.EmpresaId).ToInteger();
        }

        public static Int32 GetEmpresaId(this HttpSessionStateBase Session)
        {
            return Get(Session, SessionKey.EmpresaId).ToInteger();
        }
        #endregion

        #region UsuarioId
        public static Int32 GetUsuarioId(this HttpSessionState Session)
        {
            return Get(Session, SessionKey.UsuarioId).ToInteger();
        }

        public static Int32 GetUsuarioId(this HttpSessionStateBase Session)
        {
            return Get(Session, SessionKey.UsuarioId).ToInteger();
        }
        #endregion

        #region GetAplicacionId
        public static Int32 GetAplicacionId(this HttpSessionState Session)
        {
            return Get(Session, SessionKey.AplicacionId).ToInteger();
        }

        public static Int32 GetAplicacionId(this HttpSessionStateBase Session)
        {
            return Get(Session, SessionKey.AplicacionId).ToInteger();
        }
        #endregion

        #region GetLstRolUsuario
        public static List<Tuple<String, Int32, Boolean?>> GetLstRolUsuario(this HttpSessionState Session)
        {
            return (List<Tuple<String, Int32, Boolean?>>)Get(Session, SessionKey.LstRolUsuario);
        }

        public static List<Tuple<String, Int32, Boolean?>> GetLstRolUsuario(this HttpSessionStateBase Session)
        {
            return (List<Tuple<String, Int32, Boolean?>>)Get(Session, SessionKey.LstRolUsuario);
        }
        #endregion

        #region Cookies
        public static void SetCookie(this HttpSessionStateBase Session)
        {
            try
            {
                var lstSessionKey = Session.Keys;
                var sessionKeyNames = Enum.GetNames(typeof(SessionKey)).ToList();
                var dictSessionObject = sessionKeyNames.ToDictionary(x => x, v => new object());

                foreach (var key in dictSessionObject.Keys.ToList())
                    dictSessionObject[key] = null;

                for (int i = 0; i <= Session.Count - 1; i++)
                {
                    var key = Session.Keys[i];
                    if (sessionKeyNames.Any(x => x.Equals(key)))
                    {
                        if (key.Equals(SessionKey.Rol.ToString()))
                            dictSessionObject[key] = Session[key].ToString();
                        else
                            dictSessionObject[key] = Session[key];
                    }
                }

                var result = JsonConvert.SerializeObject(dictSessionObject, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ObjectCreationHandling = ObjectCreationHandling.Reuse
                });

                var encriptacion = new Encriptacion();
                var resultEncriptado = encriptacion.Encriptar(result);

                CookieHelpers.Set(SessionKey._appBP, resultEncriptado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void RestoreSessionFromCookie(this HttpSessionState Session)
        {
            try
            {
                var encriptacion = new Encriptacion();
                var coockieValue = encriptacion.Desencriptar(CookieHelpers.GetValue(SessionKey._appBP));

                var dictSessionObject = new Dictionary<string, object>();
                dictSessionObject = JsonConvert.DeserializeObject<Dictionary<String, object>>(coockieValue);

                foreach (var item in dictSessionObject)
                {
                    if (item.Value != null)
                    {
                        var sessionKey = item.Key.ToEnum<SessionKey>();
                        if (item.Key.Equals(SessionKey.Rol.ToString()))
                            Set(Session, sessionKey, item.Value.ToString().ToEnum<AppRol>());
                        else
                            Set(Session, sessionKey, item.Value);
                    }
                }
            }
            catch (Exception)
            {
                CookieHelpers.DeleteAll();
            }
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;

namespace AcademyDocker.Api.Attributes
{
    /// <summary>
    /// Dieses Attribut dient zur Einschränkung des Zugriffs auf die Ressource. 
    /// Es kann entweder über der Klasse angegeben werden, die entsprechende Methoden enthält oder über einzelnen Methoden.
    /// </summary>
    /// <remarks>
    /// Der User muss alle Berechtigungen besitzen um fortfahren zu können.
    /// Ist ein Attribut sowohl über der gesamten Klasse als auch über einzelnen Methoden angegeben, hat das Attribut der Methode Vorrang.
    /// Wird überhaupt kein Attribut gesetzt, so ist das gleichbedeutend mit "keine Einschränkung" und jeder kann auf die entsprechenden Methoden zugreifen.    
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class RequiredPermissionsAttribute : Attribute
    {
        private readonly string[] _permissions;

        /// <summary>
        /// Für die Methode als benötigt deklarierte Rechte.
        /// </summary>
        public IEnumerable<string> Permissions => _permissions;

        /// <summary>
        /// Instanziiert RequiredPermissions-Attribut
        /// </summary>
        /// <param name="permissions">Eine Auflistung von Rechten, die den Zugriff auf diese Methode gestatten.</param>
        /// <example>
        /// Code-Beispiel:
        ///     <code language="cs">
        ///         //Wenn eine Rolle das Recht "myservice_read" oder "myservice_write" besitzt, ist sie berechtigt auf diese Ressource zuzugreifen.
        ///         [RequiredPermissions("myservice_read","myservice_write")]
        ///     </code>
        /// </example>
        public RequiredPermissionsAttribute(params string[] permissions)
        {
            _permissions = permissions;
        }
    }
}
